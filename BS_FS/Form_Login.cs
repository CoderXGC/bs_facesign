using System;
using System.Drawing;
using System.IO;

using Sunny.UI;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS_FS.net;
using Newtonsoft.Json;
using System.Threading;
using BS_FS.Utils;
using HZH_Controls.Forms;

namespace BS_FS
{
    public partial class ControlFm : Form
    {

        System.Timers.Timer timer = new System.Timers.Timer();
        public ControlFm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
          

        }
        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {

        }

        private void ControlFm_Load(object sender, EventArgs e)
        {


            uiProgressIndicator1.Visible = false;
            try
            {
                Task.Factory.StartNew(() =>
                {
                    //更新程序位于主程序安装目录的“UpdateApp”文件夹里面
                    string exePath = $@"{AppDomain.CurrentDomain.BaseDirectory}AppUpdate\UpdateApp.exe";
                    if (File.Exists(exePath))
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = exePath;
                        p.Start();
                    }
                });
            }
            catch { }
            string url = "https://www.ylesb.com/csimg/login.jpg";
            /*       this.pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(url).GetResponse().GetResponseStream());
                   this.pictureBox1.SendToBack();//将背景图片放到最下面
                     this.label1.Parent = this.pictureBox1;
                     this.label1.BackColor = Color.Transparent;
                     this.label2.Parent = this.pictureBox1;
                     this.label2.BackColor = Color.Transparent;
                     this.label3.Parent = this.pictureBox1;
                     this.label3.BackColor = Color.Transparent;
                     this.label4.Parent = this.pictureBox1;
                     this.label4.BackColor = Color.Transparent;
                     this.label5.Parent = this.pictureBox1;*/
            this.label5.BackColor = Color.Transparent;
            //     this.radioButton1.Parent= this.pictureBox1;
            //   this.radioButton2.Parent = this.pictureBox1;

            //   label3.Visible = false;
            // pwd.Visible = false;
        }



        private void ControlFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Application.Exit();
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
        private delegate void ShowMessageDelegate(string code, string message);
        private void ShowMessage(string code,string message)
        {
            if (this.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                this.Invoke(showMessageDelegate, new object[] { code,message });
            }
            else
            {
    
                if (code == "200")
                {
                    uiProgressIndicator1.Visible = false;

                    ShowSuccessTip("登录成功");
                    /*  Form_People form_people = new Form_People(id.Text,"1");
                      form_people.StartPosition = FormStartPosition.CenterScreen;
                      form_people.Show();*/
                    Form_User_Main form_User_Main =new Form_User_Main(id.Text, "1");
                    form_User_Main.StartPosition = FormStartPosition.CenterScreen;
                    form_User_Main.Show();
                    this.Hide();
                 
                }
                else if (code == "-1")
                {
                    uiButton1.Enabled = true;
                    id.Enabled = true;
                    pwd.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    pictureBox1.Visible = true;
                    label4.Enabled = true;
                    uiLabel1.Visible = false;
                    uiButton2.Text = "退出系统";
                    ShowErrorTip(message);

                }
                else if (code == "404")
                {
                    uiButton1.Enabled = true;
                    id.Enabled = true;
                    pwd.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    pictureBox1.Visible = true;
                    uiLabel1.Visible = false;
                    label4.Enabled = true;
                    uiButton2.Text = "退出系统";
                    ShowWarningTip(message);

                }
                else if (code == "100")
                {
                    uiButton1.Enabled = true;
                    id.Enabled = true;
                    pwd.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    pictureBox1.Visible = true;
                    uiLabel1.Visible = false;
                    label4.Enabled = true;
                    uiButton2.Text = "退出系统";
                    ShowWarningTip(message);

                }
                else if (code == "1000")
                {

                    uiButton1.Enabled = true;
                    id.Enabled = true;
                    pwd.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    pictureBox1.Visible = true;
                    uiLabel1.Visible = false;
                    label4.Enabled = true;
                    uiButton2.Text = "退出系统";
                    ShowWarningTip(message);

                }

                // textBox1.Text = message;
            }
        }
        //另外一种委托写法
        //richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(str + "\r\n"); }));

        private void GetData()
        {

            timer.Interval = 5000;
            timer.Enabled = true;
            timer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；  
            timer.Start();
            Net n = new Net();
            string pwdencrytion=PwdEncryption.MD5Encrypt32(pwd.Text);
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.UserLogin(id.Text, pwdencrytion));

        timer.Elapsed += (o, a) =>
            {

                //SetData();
                ShowMessage(rt.code.ToString(),rt.message);
            };
        }



        private void uiButton1_Click(object sender, EventArgs e)
        {

            uiLabel1.Visible = true;
            uiButton1.Enabled = false;
            id.Enabled = false;
            pwd.Enabled = false;
            pictureBox1.Visible = false;
            label4.Enabled = false;
            uiButton2.Text = "取消登录";
            uiProgressIndicator1.Visible = true;
            Thread t = new Thread(new ThreadStart(GetData));
            t.Priority = ThreadPriority.AboveNormal;
            t.Name = "登陆判断";
            t.IsBackground = true;
            t.Start();


        }
            //引用登录提示框架弹出气泡
        public void ShowSuccessTip(string text, int delay = 500, bool floating = true)
    => UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);
        private Point mouseOff; //抓取窗体Form中的鼠标的坐标,需要设置一个参数
        private bool leftFlag;  //标签，用来标记鼠标的左键的状态
        private void ControlFm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)   //判断鼠标左键是否被按下
            {
                mouseOff = new Point(e.X, e.Y); //通过结构，将鼠标在窗体中的坐标（e.X,e.Y）赋值给mouseOff参数
                leftFlag = true;    //标记鼠标左键的状态
            }
        }

        private void ControlFm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void ControlFm_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftFlag)    //判断，鼠标左键是否被按下
            {
                Point mouseSet = Control.MousePosition; //抓取屏幕中鼠标光标所在的位置
                mouseSet.Offset(-mouseOff.X, -mouseOff.Y);  //两个坐标相减，得到窗体左上角相对于屏幕的坐标
                Location = mouseSet;    //将上面得到的坐标赋值给窗体Form的Location属性
            }
        }

        private void ControlFm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')                                           //因为Form的KeyPreview属性，设置为True后，会向窗体注册窗体控件的键盘事件,所以鼠标拖动Panel，按下键值，其实是响应的Form的keypress事件。
            {
                leftFlag = false;
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (uiButton2.Text=="取消登录")
            {
                timer.Stop();
                uiButton1.Enabled = true;
                id.Enabled = true;
                pwd.Enabled = true;
                uiProgressIndicator1.Visible = false;
                pictureBox1.Visible = true;
                uiLabel1.Visible = false;
                label4.Enabled = true;
                uiButton2.Text = "退出系统";
            }
            else {
                Close();
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(0);//结束进程时，关闭所有线程  这个很重要，如果没有这个代码，页面关闭了，线程还在开启着

            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form_Login_Admin form_Login_Admin = new Form_Login_Admin();
            form_Login_Admin.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
