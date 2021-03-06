using AForge.Video.DirectShow;
using ArcSoftFace.Entity;
using ArcSoftFace.SDKModels;
using ArcSoftFace.SDKUtil;
using ArcSoftFace.Utils;
using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BS_FS
{
    public partial class Form_SignIn : UITitlePage
    {
        private string uid;
        //引擎Handle
        private IntPtr pImageEngine = IntPtr.Zero;

        //保存右侧图片路径
        private string image1Path;

        //右侧图片人脸特征
        private IntPtr image1Feature;

        //保存对比图片的列表
        private List<string> imagePathList = new List<string>();

        //左侧图库人脸特征列表
        private List<IntPtr> imagesFeatureList = new List<IntPtr>();

        //相似度
        private float threshold = 0.5f;

        //用于标记是否需要清除比对结果
        private bool isCompare = false;

        private int[] id;

        #region 视频模式下相关

        //视频引擎Handle
        private IntPtr pVideoEngine = IntPtr.Zero;

        //视频引擎 FR Handle 处理   FR和图片引擎分开，减少强占引擎的问题
        private IntPtr pVideoImageEngine = IntPtr.Zero;
        /// <summary>
        /// 视频输入设备信息
        /// </summary>
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice deviceVideo;

        #endregion

        public Form_SignIn(String id)
        {
            InitializeComponent();
            uid = id;
            InitEngines();
            videoSource.Hide();
            this.Text = "签到签退";
        }
        /// <summary>
        /// 初始化引擎
        /// </summary>
        private void InitEngines()
        {
            //读取配置文件
            AppSettingsReader reader = new AppSettingsReader();
            string appId = (string)reader.GetValue("APP_ID", typeof(string));
            string sdkKey64 = (string)reader.GetValue("SDKKEY64", typeof(string));
            string sdkKey32 = (string)reader.GetValue("SDKKEY32", typeof(string));

            var is64CPU = Environment.Is64BitProcess;
            if (is64CPU)
            {
                if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(sdkKey64))
                {
                    MessageBox.Show("请在App.config配置文件中先配置APP_ID和SDKKEY64!");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(sdkKey32))
                {
                    MessageBox.Show("请在App.config配置文件中先配置APP_ID和SDKKEY32!");
                    return;
                }
            }

            //激活引擎    如出现错误，1.请先确认从官网下载的sdk库已放到对应的bin中，2.当前选择的CPU为x86或者x64
            int retCode = 0;

            try
            {
                retCode = ASFFunctions.ASFActivation(appId, is64CPU ? sdkKey64 : sdkKey32);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("无法加载 DLL") > -1)
                {
                    MessageBox.Show("请将sdk相关DLL放入bin对应的x86或x64下的文件夹中!");
                }
                else
                {
                    MessageBox.Show("激活引擎失败!");
                }
                return;
            }
            Console.WriteLine("Activate Result:" + retCode);

            //初始化引擎
            uint detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
            //检测脸部的角度优先值
            int detectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_HIGHER_EXT;
            //人脸在图片中所占比例，如果需要调整检测人脸尺寸请修改此值，有效数值为2-32
            int detectFaceScaleVal = 16;
            //最大需要检测的人脸个数
            int detectFaceMaxNum = 5;
            //引擎初始化时需要初始化的检测功能组合
            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE;
            //初始化引擎，正常值为0，其他返回值请参考http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
            retCode = ASFFunctions.ASFInitEngine(detectMode, detectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pImageEngine);
            Console.WriteLine("InitEngine Result:" + retCode);
            AppendText((retCode == 0) ? "引擎初始化成功!\n" : string.Format("引擎初始化失败!错误码为:{0}\n", retCode));
            if (retCode != 0)
            {

            }


            //初始化视频模式下人脸检测引擎
            uint detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
            int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION;
            retCode = ASFFunctions.ASFInitEngine(detectModeVideo, detectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMaskVideo, ref pVideoEngine);

            //视频专用FR引擎
            detectFaceMaxNum = 1;
            combinedMask = FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_FACE3DANGLE;
            retCode = ASFFunctions.ASFInitEngine(detectMode, detectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pVideoImageEngine);
            Console.WriteLine("InitVideoEngine Result:" + retCode);


            initVideo();
        }
        private void AppendText(string message)
        {
            //logBox.AppendText(message);
        }

        #region 视频检测相关

        /// <summary>
        /// 摄像头初始化
        /// </summary>
        private void initVideo()
        {
          
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filterInfoCollection.Count == 0)
            {
                // btnStartVideo.Enabled = false;
            }
            else
            {
                //  btnStartVideo.Enabled = true;
            }
        }
        //执行数据库操作
        private void SignSql(int id)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            Net n = new Net();
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Find(uid));
            if (rt.code.ToString() == "200")
            {
                string signintime = rt.data.signintime;
                string signouttime = rt.data.signouttime;
                string[] strArrayin = signintime.Split(':');
                string[] strArrayout = signouttime.Split(':');
                 MessageBox.Show("当前系统时间"+ int.Parse(DateTime.Now.ToString("HH"))+"签到时间" + strArrayin[0]+"签退时间"+ strArrayout[0]+ "签到时间1" + int.Parse(strArrayin[0]) + "签退时间" + int.Parse(strArrayout[0]));
                if (int.Parse(DateTime.Now.ToString("HH")) <= int.Parse(strArrayin[0]))
                {
                    string singid = uid + DateTime.Now.ToString("yyyy-MM-dd");
                    JsonBean fs = JsonConvert.DeserializeObject<JsonBean>(n.Findsign(uid, singid));
                    if (fs.code.ToString() == "200")
                    {
                        MessageBox.Show("尊敬的ID: " + fs.data.user_id + "  ,您今天已经签到！");
                        UIMessageDialog.ShowMessageDialog("尊敬的ID: " + fs.data.user_id + "  ,您今天已经签到！", UILocalize.InfoTitle, false, style);
       
                    }
                    else if (fs.code.ToString() == "-1")
                    {

                        JsonBean si = JsonConvert.DeserializeObject<JsonBean>(n.Signin(uid, singid, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd"),"0"));
                        //  MessageBox.Show("代码=" + rt.code + "\r\n" + "信息=" + rt.message + "\r\n" + "数据=" + rt.data);
                        if (si.code.ToString() == "200")
                        {
                            MessageBox.Show("尊敬的ID:  " + si.data.user_id + "  ,恭喜您签到成功");

                            UIMessageDialog.ShowMessageDialog("尊敬的ID:  " + si.data.user_id + "  ,恭喜您签到成功", UILocalize.InfoTitle, false, style);

                        }
                        else if (si.code.ToString() == "-1")
                        {
                            MessageBox.Show(si.message);

                        }
                        else if (si.code.ToString() == "404")
                        {

                            MessageBox.Show(si.message );
                        }
                        else if (si.code.ToString() == "100")
                        {
                            MessageBox.Show(si.message);

                        }
                        else if (si.code.ToString() == "1000")
                        {

                            MessageBox.Show(si.message);
                        }

                    }
                    else if (fs.code.ToString() == "404")
                    {
                        MessageBox.Show(fs.message);

                    }
                    else if (fs.code.ToString() == "100")
                    {

                        MessageBox.Show(fs.message);
                    }
                    else if (fs.code.ToString() == "1000")
                    {
                        MessageBox.Show(fs.message);

                    }

                }
                else if (int.Parse(DateTime.Now.ToString("HH")) > int.Parse(strArrayin[0]) && int.Parse(DateTime.Now.ToString("HH")) < int.Parse(strArrayout[0]))
                {

                    string signid = uid + DateTime.Now.ToString("yyyy-MM-dd");
                    JsonBean fs = JsonConvert.DeserializeObject<JsonBean>(n.Findsign(uid, signid));
                    if (fs.code.ToString() == "200")
                    {

                        int latehours = int.Parse(DateTime.Now.ToString("HH")) - int.Parse(strArrayin[0]);
                        int lateminute = int.Parse(DateTime.Now.ToString("MM")) - int.Parse(strArrayin[1]);
                        MessageBox.Show("尊敬的ID: " + fs.data.user_id + "  您已签到，您今天已经迟到,迟到时间  " + latehours.ToString() + ":" + lateminute.ToString() + "  !");
                        UIMessageDialog.ShowMessageDialog("尊敬的ID: " + fs.data.user_id + "  您已签到，您今天已经迟到,迟到时间  " + latehours.ToString() + ":" + lateminute.ToString() + "  !", UILocalize.InfoTitle, false, style);

                    }
                    else if (fs.code.ToString() == "-1")
                    {

                        int latehours = int.Parse(DateTime.Now.ToString("HH")) - int.Parse(strArrayin[0]);
                        int lateminute= int.Parse(DateTime.Now.ToString("MM")) - int.Parse(strArrayin[1]);
                        JsonBean si = JsonConvert.DeserializeObject<JsonBean>(n.Signin(uid, signid, latehours.ToString()+":" +lateminute.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd"), "0"));
                   
                        if (si.code.ToString() == "200")
                        {
                            MessageBox.Show("尊敬的ID:  " + si.data.user_id + "  ,签到成功，您已经迟到,迟到时间  " + latehours.ToString() + ":" + lateminute.ToString() + "  !");
                            UIMessageDialog.ShowMessageDialog("尊敬的ID:  " + si.data.user_id + "  ,签到成功，您已经迟到,迟到时间  " + latehours.ToString() + ":" + lateminute.ToString() + "  !", UILocalize.InfoTitle, false, style);


                        }
                        else if (si.code.ToString() == "-1")
                        {
                            MessageBox.Show(si.message);

                        }
                        else if (si.code.ToString() == "404")
                        {

                            MessageBox.Show(si.message + uid);
                        }
                        else if (si.code.ToString() == "100")
                        {
                            MessageBox.Show(si.message);

                        }
                        else if (si.code.ToString() == "1000")
                        {

                            MessageBox.Show(si.message);
                        }

                    }
                    else if (fs.code.ToString() == "404")
                    {
                        MessageBox.Show(fs.message);

                    }
                    else if (fs.code.ToString() == "100")
                    {

                        MessageBox.Show(fs.message);
                    }
                    else if (fs.code.ToString() == "1000")
                    {
                        MessageBox.Show(fs.message);

                    }

                } else if (int.Parse(DateTime.Now.ToString("HH")) > int.Parse(strArrayout[0]))
                {
                    string singid = uid + DateTime.Now.ToString("yyyy-MM-dd");

                    JsonBean fs = JsonConvert.DeserializeObject<JsonBean>(n.Findsign(uid, singid));
                    if (fs.code.ToString() == "200")
                    {

                        if (fs.data.signouttime.Equals("0")) {

                            JsonBean si = JsonConvert.DeserializeObject<JsonBean>(n.Signout(uid, singid, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            //  MessageBox.Show("代码=" + rt.code + "\r\n" + "信息=" + rt.message + "\r\n" + "数据=" + rt.data);
                            if (si.code.ToString() == "200")
                            {
                                MessageBox.Show("尊敬的ID: " + fs.data.user_id + "恭喜您签退成功");
                                UIMessageDialog.ShowMessageDialog("尊敬的ID: " + fs.data.user_id + "恭喜您签退成功", UILocalize.InfoTitle, false, style);


                            }
                            else if (si.code.ToString() == "-1")
                            {
                               
                                MessageBox.Show(si.message);

                            }
                            else if (si.code.ToString() == "404")
                            {

                                MessageBox.Show(si.message + uid);
                            }
                            else if (si.code.ToString() == "100")
                            {
                                MessageBox.Show(si.message);

                            }
                            else if (si.code.ToString() == "1000")
                            {

                                MessageBox.Show(si.message);
                            }

                        }
                        else {
                            MessageBox.Show("尊敬的ID: " + fs.data.user_id + "您今天已经签退！");
                           UIMessageDialog.ShowMessageDialog("尊敬的ID: " + fs.data.user_id + "您今天已经签退！", UILocalize.InfoTitle, false, style);
                        }
                   
                    }
                    else if (fs.code.ToString() == "-1")
                    {
                        MessageBox.Show("提示信息：" + fs.message + " ,您今天没有签到，已经无法签退了");
                        UIMessageDialog.ShowMessageDialog("提示信息：" + fs.message + " ,您今天没有签到，已经无法签退了", UILocalize.InfoTitle, false, style);
                    }
                    else if (fs.code.ToString() == "404")
                    {
                        MessageBox.Show(fs.message);

                    }
                    else if (fs.code.ToString() == "100")
                    {

                        MessageBox.Show(fs.message);
                    }
                    else if (fs.code.ToString() == "1000")
                    {
                        MessageBox.Show(fs.message);

                    }
  
                }
            }
            else if (rt.code.ToString() == "-1")
            {

                MessageBox.Show(rt.message);
            }
            else if (rt.code.ToString() == "404")
            {
                MessageBox.Show(rt.message);
            }
            else if (rt.code.ToString() == "100")
            {
                MessageBox.Show(rt.message);

            }
            else if (rt.code.ToString() == "1000")
            {

                MessageBox.Show(rt.message);
            }
   

        }
        private FaceTrackUnit trackUnit = new FaceTrackUnit();
        private Font font = new Font(FontFamily.GenericSerif, 10f);
        private SolidBrush brush = new SolidBrush(Color.Red);
        private Pen pen = new Pen(Color.Red);
        private bool isLock = false;

        /// <summary>
        /// 图像显示到窗体上，得到每一帧图像，并进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoSource_Paint(object sender, PaintEventArgs e)
        {
            if (videoSource.IsRunning)
            {
            
                //得到当前摄像头下的图片
                Bitmap bitmap = videoSource.GetCurrentVideoFrame();
                if (bitmap == null)
                {
                    return;
                }
                Graphics g = e.Graphics;
                float offsetX = videoSource.Width * 1f / bitmap.Width;
                float offsetY = videoSource.Height * 1f / bitmap.Height;
                //检测人脸，得到Rect框
                ASF_MultiFaceInfo multiFaceInfo = FaceUtil.DetectFace(pVideoEngine, bitmap);
                //得到最大人脸
                ASF_SingleFaceInfo maxFace = FaceUtil.GetMaxFace(multiFaceInfo);
                //得到Rect
                MRECT rect = maxFace.faceRect;
                float x = rect.left * offsetX;
                float width = rect.right * offsetX - x;
                float y = rect.top * offsetY;
                float height = rect.bottom * offsetY - y;
                //根据Rect进行画框
                g.DrawRectangle(pen, x, y, width, height);
                if (trackUnit.message != "" && x > 0 && y > 0)
                {
                
                    //将上一帧检测结果显示到页面上
                    g.DrawString(trackUnit.message, font, brush, x, y + 5);
                }
                //保证只检测一帧，防止页面卡顿以及出现其他内存被占用情况
                if (isLock == false)
                {
                    isLock = true;
                    //异步处理提取特征值和比对，不然页面会比较卡
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                    {
                        if (rect.left != 0 && rect.right != 0 && rect.top != 0 && rect.bottom != 0)
                        {
                            try
                            {
                                //提取人脸特征
                                IntPtr feature = FaceUtil.ExtractFeature(pVideoImageEngine, bitmap, maxFace);
                                float similarity = 0f;
                                //得到比对结果
                                int result = compareFeature(feature, out similarity);
                                if (result > -1)
                                {
                                    //将比对结果放到显示消息中，用于最新显示
                                    trackUnit.message = string.Format("{0}号 {1}", result, similarity);
                                    //执行数据库操作
                                    SignSql(result);
                                }
                                else
                                {
                                    //重置显示消息
                                    trackUnit.message = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                isLock = false;
                            }
                        }
                        isLock = false;
                    }));
                }
            }
        }

        /// <summary>
        /// 得到feature比较结果
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        private int compareFeature(IntPtr feature, out float similarity)
        {
            int result = -1;
            similarity = 0f;
            //如果人脸库不为空，则进行人脸匹配
            if (imagesFeatureList != null && imagesFeatureList.Count > 0)
            {
                for (int i = 0; i < imagesFeatureList.Count; i++)
                {
                    //调用人脸匹配方法，进行匹配
                    ASFFunctions.ASFFaceFeatureCompare(pVideoImageEngine, feature, imagesFeatureList[i], ref similarity);
                    if (similarity >= threshold)
                    {
                        result = i;
                        // result = id[i];
                        break;
                    }
                }
            }
            return result;
        }
        #endregion
        private object locker = new object();
        private void Form_User_Load(object sender, EventArgs e)
        {

            //必须保证有可用摄像头
            if (filterInfoCollection.Count == 0)
            {
                MessageBox.Show("未检测到摄像头，请确保已安装摄像头或驱动!");
                Dispose();
                Application.Exit();
            }
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.Hide();
            }
            else
            {
                if (isCompare)
                {
                    //比对结果清除
                    for (int i = 0; i < imagesFeatureList.Count; i++)
                    {
                        imageList.Items[i].Text = string.Format("{0}号", i);
                    }
                    isCompare = false;
                }
                videoSource.Show();
                deviceVideo = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                deviceVideo.VideoResolution = deviceVideo.VideoCapabilities[0];
                videoSource.VideoSource = deviceVideo;
                videoSource.Start();
            }
            lock (locker)
            {
                Net n = new Net();
                List<string> imagePathListTemp = new List<string>();
                var numStart = imagePathList.Count;
                //这个需要引入Newtonsoft.Json这个DLL并using
                //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
                JsonArrayBean rt = JsonConvert.DeserializeObject<JsonArrayBean>(n.Findfaceimg(uid));
                for(int i=0;i<rt.data.Length;i++) {
                    if (rt.data[i].faceimg.Equals("0"))
                    {

                    }
                    else {
                        imagePathListTemp.Add(rt.data[i].faceimg.ToString());
                     //   id[i] = int.Parse(rt.data[i].id.ToString());
                    }
          
               

                }


                //人脸检测以及提取人脸特征
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                    {
                        //人脸检测和剪裁
                        for (int i = 0; i < imagePathListTemp.Count; i++)
                        {
                            WebRequest request = WebRequest.Create(imagePathListTemp[i]);
                            WebResponse response = request.GetResponse();
                            Stream s = response.GetResponseStream();
                            byte[] data = new byte[1024];
                            int length = 0;
                            MemoryStream ms = new MemoryStream();
                            while ((length = s.Read(data, 0, data.Length)) > 0)
                            {
                                ms.Write(data, 0, length);
                            }
                            ms.Seek(0, SeekOrigin.Begin);
                        //    pictureBox1.Image = Image.FromStream(ms);
                            Image image = Image.FromStream(ms);
                            if (image.Width % 4 != 0)
                            {
                                image = ImageUtil.ScaleImage(image, image.Width - (image.Width % 4), image.Height);
                            }
                            ASF_MultiFaceInfo multiFaceInfo = FaceUtil.DetectFace(pImageEngine, image);

                            if (multiFaceInfo.faceNum > 0)
                            {
                                imagePathList.Add(imagePathListTemp[i]);
                                MRECT rect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects);
                                image = ImageUtil.CutImage(image, rect.left, rect.top, rect.right, rect.bottom);
                            }
                            else
                            {
                                continue;
                            }
                        }


                        //提取人脸特征
                        for (int i = numStart; i < imagePathList.Count; i++)
                        {
                            WebRequest request = WebRequest.Create(imagePathListTemp[i]);
                            WebResponse response = request.GetResponse();
                            Stream s = response.GetResponseStream();
                            byte[] data = new byte[1024];
                            int length = 0;
                            MemoryStream ms = new MemoryStream();
                            while ((length = s.Read(data, 0, data.Length)) > 0)
                            {
                                ms.Write(data, 0, length);
                            }
                            ms.Seek(0, SeekOrigin.Begin);
                            ASF_SingleFaceInfo singleFaceInfo = new ASF_SingleFaceInfo();
                            IntPtr feature = FaceUtil.ExtractFeature(pImageEngine, Image.FromStream(ms), out singleFaceInfo);
                            this.Invoke(new Action(delegate
                            {
                                if (singleFaceInfo.faceRect.left == 0 && singleFaceInfo.faceRect.right == 0)
                                {
                                    AppendText(string.Format("{0}号未检测到人脸\r\n", rt.data[i].id));
                                }
                                else
                                {
                                    AppendText(string.Format("已提取{0}号人脸特征值，[left:{1},right:{2},top:{3},bottom:{4},orient:{5}]\r\n",rt.data[i].id, singleFaceInfo.faceRect.left, singleFaceInfo.faceRect.right, singleFaceInfo.faceRect.top, singleFaceInfo.faceRect.bottom, singleFaceInfo.faceOrient));
                                    imagesFeatureList.Add(feature);
                                }
                            }));
                        }


                    }));
           
            }
            LoadingHelper.ShowLoading("加载中请稍后。", this, o =>
            {
                //这里写处理耗时的代码，代码处理完成则自动关闭该窗口
                Thread.Sleep(4000);
            });
        }

        private void Form_Sign_FormClosed(object sender, FormClosedEventArgs e)
        {
            //销毁引擎
            int retCode = ASFFunctions.ASFUninitEngine(pImageEngine);
            Console.WriteLine("UninitEngine pImageEngine Result:" + retCode);
            //销毁引擎
            retCode = ASFFunctions.ASFUninitEngine(pVideoEngine);
            Console.WriteLine("UninitEngine pVideoEngine Result:" + retCode);

            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop(); //关闭摄像头
            }
            Dispose();
            Application.Exit();
        }

        private void PagePanel_Click(object sender, EventArgs e)
        {

        }
        public override void Init()
        {

        }

        public override void Final()
        {
            //销毁引擎
            int retCode = ASFFunctions.ASFUninitEngine(pImageEngine);
            Console.WriteLine("UninitEngine pImageEngine Result:" + retCode);
            //销毁引擎
            retCode = ASFFunctions.ASFUninitEngine(pVideoEngine);
            Console.WriteLine("UninitEngine pVideoEngine Result:" + retCode);

            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop(); //关闭摄像头
            }
        }

        public void ShowSuccessTip(string text, int delay = 500, bool floating = true)
=> UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);
    }
}