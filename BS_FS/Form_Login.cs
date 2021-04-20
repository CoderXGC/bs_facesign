using System;
using System.Drawing;
using System.IO;

using Sunny.UI;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS_FS.net;
using Newtonsoft.Json;

namespace BS_FS
{
    public partial class ControlFm : Form
    {
        public ControlFm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void ControlFm_Load(object sender, EventArgs e)
        {
 


            try
            {
                Task.Factory.StartNew(() => {
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
            timer1.Stop();
            Dispose();
            Application.Exit();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            Net n = new Net();
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。

            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Login(id.Text, pwd.Text));
            //这样就可以取出json数据里面的值
            //  MessageBox.Show("代码=" + rt.code + "\r\n" + "信息=" + rt.message + "\r\n" + "数据=" + rt.data);
            if (rt.code.ToString() == "200")
            {
              
               // MessageBox.Show(n.Find(id.Text));
                ShowSuccessTip("登录成功");

                Form_people form_people = new Form_people(id.Text);
                form_people.StartPosition = FormStartPosition.CenterScreen;
                form_people.Show();
                this.Hide();
                /* Form_Admin form_Admin = new Form_Admin();
                 form_Admin.StartPosition = FormStartPosition.CenterScreen;
                 form_Admin.Show();
                 this.Hide();*/
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
            //FaceForm faceForm = new FaceForm();
            //faceForm.Show();
            /*   Form_Sign form_User = new Form_Sign();
               form_User.Show();
               //Form_Admin form_Admin = new Form_Admin();
               //form_Admin.Show();
               this.Hide();*/

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
            Close();
        }
    }

}
