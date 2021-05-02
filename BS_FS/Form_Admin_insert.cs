using ArcSoftFace.SDKModels;
using ArcSoftFace.SDKUtil;
using ArcSoftFace.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
using System.Collections.Specialized;

namespace BS_FS
{
    public partial class Form_Admin_insert : Form
    {
        //引擎Handle
        private IntPtr pImageEngine = IntPtr.Zero;

        //保存对比图片的列表
        private List<string> imagePathList = new List<string>();

        //左侧图库人脸特征列表
        private List<IntPtr> imagesFeatureList = new List<IntPtr>();



        private string[] path;
        string role;
        bool flag = true;
     
        public Form_Admin_insert(string id, string role)
        {
            InitializeComponent();
            InitEngines();
            this.role = role;
            this.Text = id;


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
                    uiButton1.Enabled = false;
                    uiButton2.Enabled = false;
                    uiButton3.Enabled = false;
                    uiButton4.Enabled = false;
                    MessageBox.Show("请在App.config配置文件中先配置APP_ID和SDKKEY64!");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(sdkKey32))
                {
                    uiButton1.Enabled = false;
                    uiButton2.Enabled = false;
                    uiButton3.Enabled = false;
                    uiButton4.Enabled = false;
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
                uiButton1.Enabled = false;
                uiButton2.Enabled = false;
                uiButton3.Enabled = false;
                uiButton4.Enabled = false;
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
            AppendText((retCode == 0) ? "引擎初始化成功!请执行录入!\n" : string.Format("引擎初始化失败!错误码为:{0}\n", retCode));
            if (retCode != 0)
            {
                uiButton1.Enabled = false;
                uiButton2.Enabled = false;
                uiButton3.Enabled = false;
                uiButton4.Enabled = false;
            }


            ////初始化视频模式下人脸检测引擎
            //uint detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
            //int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION;
            //retCode = ASFFunctions.ASFInitEngine(detectModeVideo, detectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMaskVideo, ref pVideoEngine);

            ////视频专用FR引擎
            //detectFaceMaxNum = 1;
            //combinedMask = FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_FACE3DANGLE;
            //retCode = ASFFunctions.ASFInitEngine(detectMode, detectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pVideoImageEngine);
            //Console.WriteLine("InitVideoEngine Result:" + retCode);


        }
        private void AppendText(string message)
        {
            logBox.AppendText(message);
        }
        private object locker = new object();

        private void button4_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
        


        }

        private void button1_Click(object sender, EventArgs e)
        {



            /* 
             *     string filename = idtb.Text + Path.GetFileName(path[0]);
             * MessageBox.Show(n.Uploadimg(this.Text, path[0], Path.GetFileName(path[0])));
                    //   MessageBox.Show(path[0]);
                    //    MessageBox.Show(n.Uploadimg(this.Text, path[0], Path.GetFileName(path[0])));
                   // MessageBox.Show(n.Uploadimgtest("file", path[0], nvc));*/
            /* if (!(String.IsNullOrEmpty(path[0])))
             {
                 if (!(String.IsNullOrEmpty(idtb.Text)))
                 {
                     if (!(String.IsNullOrEmpty(nametb.Text)))
                     {

                         DataMysql data = new DataMysql();
                         data.dataCon();
                         string cmdStr = "Select * from user where id='" + idtb.Text + "'";
                         DataSet ds;
                         ds = data.getDataSet(cmdStr);
                         if (ds.Tables[0].Rows.Count == 1)
                         {
                             MessageBox.Show("已经添加过此员工了，请勿重复添加！");
                             AppendText("已经添加过此员工了，请勿重复添加！");
                             imageLists.Images.Clear();
                             imageList.Items.Clear();
                             imagesFeatureList.Clear();
                             imagePathList.Clear();
                             idtb.Text = "";
                             nametb.Text = "";
                         }
                         else
                         {
                             string url = "https://www.ylesb.com/csimg/pound.php";
                             try
                             {
                                 WebClient client = new WebClient();
                                 client.Credentials = CredentialCache.DefaultCredentials;
                                 client.Headers.Add("Content-Type", "application/form-data");//注意头部必须是form-data
                                 string filename = idtb.Text + Path.GetFileName(path[0]);
                                 client.QueryString["file_name"] = filename;
                                 byte[] fileb = client.UploadFile(new Uri(url), "POST", path[0]);
                                 string res = Encoding.UTF8.GetString(fileb);
                             }
                             catch (Exception ex)
                             {
                                 AppendText(ex.Message);
                             }

                             DataMysql datasql = new DataMysql();
                             datasql.dataCon();
                             string imgname = "https://www.ylesb.com/csimg/" + idtb.Text + Path.GetFileName(path[0]);
                             string insert = "insert into user (id,name,faceimg) values ( '" + idtb.Text + "','" + nametb.Text + "','" + imgname + "')";
                             if (datasql.sqlExec(insert))
                             {
                                 AppendText("录入成功，请访问'" + imgname + "'查看是否本人\n");
                                 imageLists.Images.Clear();
                                 imageList.Items.Clear();
                                 imagesFeatureList.Clear();
                                 imagePathList.Clear();
                                 idtb.Text = "";
                                 nametb.Text = "";
                             }
                             else
                             {
                                 AppendText("录入失败，网络出现异常，请稍后再试！");
                                 imageLists.Images.Clear();
                                 imageList.Items.Clear();
                                 imagesFeatureList.Clear();
                                 imagePathList.Clear();
                                 idtb.Text = "";
                                 nametb.Text = "";
                             }
                         }
                     }
                     else
                     {
                         MessageBox.Show("您未输入员工姓名，请输入后提交!");
                     }
                 }
                 else {
                     MessageBox.Show("您未输入员工ID，请输入后提交!");
                 }
             }
             else
             {
                 MessageBox.Show("您未选择录入图片，请选择后提交!");
             }
             */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendText("清空成功");
            imageLists.Images.Clear();
            imageList.Items.Clear();
            imagesFeatureList.Clear();
            imagePathList.Clear();
            idtb.Text = "";
            nametb.Text = "";
        }
        public void ShowSuccessTip(string text, int delay = 500, bool floating = true)
   => UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);

        private void Form_Admin_insert_Load(object sender, EventArgs e)
        {
            if (role == "0")
            {
                label1.Visible = false;
                uiButton4.Visible = false;
                imageList.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                logBox.Visible = false;
                textBox2.Text = "管理员";

            }
            if (role == "1")
            {
                textBox1.Text = "员工";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                idtb.Enabled = false;
                Thread t = new Thread(new ThreadStart(GetData));
                t.IsBackground = true;
                t.Start();
                ShowWaitForm();

            }
     
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (role == "0")
            {
                Net n = new Net();
                //这个需要引入Newtonsoft.Json这个DLL并using
                //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
                JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.AddUser(idtb.Text,nametb.Text,int.Parse(textBox2.Text)));
                if (rt.code.ToString() == "200")
                {
           
                    ShowSuccessTip("添加成功");

                }
                else if (rt.code.ToString() == "-1")
                {
                    ShowErrorTip(rt.message);

                }
                else if (rt.code.ToString() == "404")
                {
                    ShowWarningTip(rt.message);

                }
                else if (rt.code.ToString() == "100")
                {
                    ShowWarningTip(rt.message);

                }
                else if (rt.code.ToString() == "1000")
                {
                    ShowWarningTip(rt.message);

                }


            }
            if (role == "1") {
                if (flag)
                {
                    Net n = new Net();
                    JsonBean rtt = JsonConvert.DeserializeObject<JsonBean>(n.UpdateUser(this.Text, textBox3.Text, textBox4.Text));

                    if (rtt.code.ToString() == "200")
                    {
                      
                        ShowSuccessTip("成功");

                    }
                    else if (rtt.code.ToString() == "-1")
                    {
                        ShowErrorTip(rtt.message);

                    }
                    else if (rtt.code.ToString() == "404")
                    {
                        ShowWarningTip(rtt.message);

                    }
                    else if (rtt.code.ToString() == "100")
                    {
                        ShowWarningTip(rtt.message);

                    }
                    else if (rtt.code.ToString() == "1000")
                    {
                        ShowWarningTip(rtt.message);

                    }

                }
                else {
                if (textBox3.Text == "") {
                    UIMessageDialog.ShowMessageDialog("请填写手机号！", UILocalize.InfoTitle, false, style);

                }
                else if (textBox4.Text == "") {
                    UIMessageDialog.ShowMessageDialog("请填写邮箱！", UILocalize.InfoTitle, false, style);

                }
                else{ NameValueCollection nvc = new NameValueCollection();
                    nvc.Add("id", this.Text);
                    Net n = new Net();
                    //这个需要引入Newtonsoft.Json这个DLL并using
                    //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
                    JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Uploadimgtest1(3000, "file", path[0], nvc));
                    if (rt.code.ToString() == "200")
                    {

                        JsonBean rtt = JsonConvert.DeserializeObject<JsonBean>(n.Addfaceimg(this.Text, rt.data.url));

                        if (rtt.code.ToString() == "200")
                        {
                            JsonBean rttt = JsonConvert.DeserializeObject<JsonBean>(n.UpdateUser(this.Text, textBox3.Text, textBox4.Text));

                                if (rttt.code.ToString() == "200")
                                {

                                    ShowSuccessTip("成功");

                                }
                                else if (rttt.code.ToString() == "-1")
                                {
                                    ShowErrorTip(rttt.message);

                                }
                                else if (rttt.code.ToString() == "404")
                                {
                                    ShowWarningTip(rttt.message);

                                }
                                else if (rttt.code.ToString() == "100")
                                {
                                    ShowWarningTip(rttt.message);

                                }
                                else if (rttt.code.ToString() == "1000")
                                {
                                    ShowWarningTip(rttt.message);

                                }
                  

                        }
                        else if (rtt.code.ToString() == "-1")
                        {
                            ShowErrorTip(rtt.message);

                        }
                        else if (rtt.code.ToString() == "404")
                        {
                            ShowWarningTip(rtt.message);

                        }
                        else if (rtt.code.ToString() == "100")
                        {
                            ShowWarningTip(rtt.message);

                        }
                        else if (rtt.code.ToString() == "1000")
                        {
                            ShowWarningTip(rtt.message);

                        }


                    }
                    else if (rt.code.ToString() == "-1")
                    {
                        ShowErrorTip(rt.message);

                    }
                    else if (rt.code.ToString() == "404")
                    {
                        ShowWarningTip(rt.message);

                    }
                    else if (rt.code.ToString() == "100")
                    {
                        ShowWarningTip(rt.message);

                    }
                    else if (rt.code.ToString() == "1000")
                    {
                        ShowWarningTip(rt.message);

                    } }
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            AppendText("清空成功");
            imageLists.Images.Clear();
            imageList.Items.Clear();
            imagesFeatureList.Clear();
            imagePathList.Clear();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //销毁引擎
            int retCode = ASFFunctions.ASFUninitEngine(pImageEngine);
            Console.WriteLine("UninitEngine pImageEngine Result:" + retCode);
            this.Close();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            flag = false;
            lock (locker)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "选择图片";
                openFileDialog.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
                openFileDialog.Multiselect = true;
                openFileDialog.FileName = string.Empty;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    List<string> imagePathListTemp = new List<string>();
                    var numStart = imagePathList.Count;
                    int isGoodImage = 0;

                    //保存图片路径并显示
                    string[] fileNames = openFileDialog.FileNames;
                    path = openFileDialog.FileNames;

                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        imagePathListTemp.Add(fileNames[i]);
                    }



                    //人脸检测以及提取人脸特征
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                    {
                        //禁止点击按钮
                        Invoke(new Action(delegate
                        {
                            uiButton1.Enabled = false;
                            uiButton2.Enabled = false;
                            uiButton3.Enabled = false;
                            uiButton4.Enabled = false;
                        }));

                        //人脸检测和剪裁
                        for (int i = 0; i < imagePathListTemp.Count; i++)
                        {
                            Image image = Image.FromFile(imagePathListTemp[i]);
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

                            this.Invoke(new Action(delegate
                            {
                                if (image == null)
                                {
                                    image = Image.FromFile(imagePathListTemp[i]);
                                }
                                imageLists.Images.Add(imagePathListTemp[i], image);
                                imageList.Items.Add((numStart + isGoodImage) + "号", imagePathListTemp[i]);
                                isGoodImage += 1;
                                image = null;
                            }));
                        }


                        //提取人脸特征
                        for (int i = numStart; i < imagePathList.Count; i++)
                        {
                            ASF_SingleFaceInfo singleFaceInfo = new ASF_SingleFaceInfo();
                            IntPtr feature = FaceUtil.ExtractFeature(pImageEngine, Image.FromFile(imagePathList[i]), out singleFaceInfo);
                            this.Invoke(new Action(delegate
                            {
                                if (singleFaceInfo.faceRect.left == 0 && singleFaceInfo.faceRect.right == 0)
                                {
                                    AppendText(string.Format("{0}号未检测到人脸\r\n", i));
                                }
                                else
                                {
                                    AppendText(string.Format("已提取{0}号人脸特征值，[left:{1},right:{2},top:{3},bottom:{4},orient:{5}]\r\n", i, singleFaceInfo.faceRect.left, singleFaceInfo.faceRect.right, singleFaceInfo.faceRect.top, singleFaceInfo.faceRect.bottom, singleFaceInfo.faceOrient));
                                    imagesFeatureList.Add(feature);
                                }
                            }));
                        }
                        //允许点击按钮
                        Invoke(new Action(delegate
                        {
                            uiButton1.Enabled = true;
                            uiButton2.Enabled = true;
                            uiButton3.Enabled = true;
                            uiButton4.Enabled = true;
                       
                        }));
                    }));

                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void idtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //方法一 声明委托
        private delegate void SetDataDelegate();
        private void SetData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetDataDelegate(SetData));
            }
            else
            {


            }
        }

        //声明委托
        private delegate void ShowMessageDelegate(string code, string message, string id, string name, string did, string telnum, string email);
        private void ShowMessage(string code, string message, string id, string name, string did, string telnum, string email)
        {

            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (this.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                this.Invoke(showMessageDelegate, new object[] { code, message, id,  name, did, telnum, email });
            }
            else
            {


                if (code == "200")
                {
                    idtb.Text = id;
                    nametb.Text = name;
                    if (did == "0") {
                        textBox2.Text = "技术部";
                        if (telnum == "0")
                        {
                            textBox3.Text = "请设置";
                        }
                        else {
                            textBox3.Text = telnum;
                        }
                        if (email == "0")
                        {
                            textBox4.Text = "请设置";
                        }
                        else {
                            textBox4.Text = email;
                        }

                    }
                    HideWaitForm();
                    if (role == "1") { 
                        Net n = new Net();
                    JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Find(this.Text));
                    //这样就可以取出json数据里面的值
                    if (rt.data.faceimg.ToString().Equals("0"))
                    {
                        UIMessageDialog.ShowMessageDialog("检测到您还未添加人脸信息，请添加人脸信息！", UILocalize.InfoTitle, false, style);

                    }
                    else if (rt.data.faceimg.ToString() != "")
                    {
                        UIMessageDialog.ShowMessageDialog("您已添加过人脸信息如需修改，请选择人脸信息，不修改则无需添加！", UILocalize.InfoTitle, false, style);

                    }
                    else if (rt.code.ToString() == "-1")
                    {
                        UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                    }
                    else if (rt.code.ToString() == "404")
                    {
                        UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                    }
                    else if (rt.code.ToString() == "100")
                    {
                        UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                    }
                    else if (rt.code.ToString() == "1000")
                    {
                        UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);


                    }
                    }


                }
                
                else if (code == "-1")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);
                }
                else if (code == "404")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }
                else if (code == "100")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }
                else if (code == "1000")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }

            }
        }
        //另外一种委托写法
        //richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(str + "\r\n"); }));

        private void GetData()
        {
            var timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；  
            timer.Start();
            Net n = new Net();
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Find(this.Text));

            timer.Elapsed += (o, a) =>
            {
                ShowMessage(rt.code.ToString(), rt.message, rt.data.id, rt.data.name, rt.data.did.ToString(),rt.data.telnum,rt.data.email);
            };
        }
        public void SetWaitFormDescription(string desc)
        {
            UIWaitFormService.SetDescription(desc);
        }
        public void ShowWaitForm(string desc = "查询中，请稍候...")
        {
            UIWaitFormService.ShowWaitForm(desc);
        }
        public void HideWaitForm()
        {
            UIWaitFormService.HideWaitForm();
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}