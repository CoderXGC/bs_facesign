using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using Sunny.UI;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;

namespace BS_FS
{
    public partial class ControlFm : Form
    {
        public ControlFm()
        {
            InitializeComponent();
           
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
                ShowSuccessTip("登录成功");
                Form_Admin form_Admin = new Form_Admin();
                form_Admin.StartPosition = FormStartPosition.CenterScreen;
                form_Admin.Show();
                this.Hide();
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
    }
    
    
}
