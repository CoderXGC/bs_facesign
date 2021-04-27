using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BS_FS
{
    [DefaultProperty("Text")]
    [DefaultEvent("OnLogin")]
    public partial class Form_Login_Admin : UIForm
    {
        public Form_Login_Admin()
        {
            InitializeComponent();
        }




        private UILoginImage loginImage;

        [DefaultValue(UILoginImage.Login1)]
        public UILoginImage LoginImage
        {
            get => loginImage;
            set
            {
                if (loginImage != value)
                {
                    loginImage = value;

            /*        if (loginImage == UILoginImage.Login1) BackgroundImage = Resources.Login1;
                    if (loginImage == UILoginImage.Login2) BackgroundImage = Resources.Login2;
                    if (loginImage == UILoginImage.Login3) BackgroundImage = Resources.Login3;
                    if (loginImage == UILoginImage.Login4) BackgroundImage = Resources.Login4;
                    if (loginImage == UILoginImage.Login5) BackgroundImage = Resources.Login5;
                    if (loginImage == UILoginImage.Login6) BackgroundImage = Resources.Login6;*/
                }
            }
        }

        public enum UILoginImage
        {
            Login1,
            Login2,
            Login3,
            Login4,
            Login5,
            Login6
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
       
                this.Close();
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
        private void ShowMessage(string code, string message)
        {
            if (this.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                this.Invoke(showMessageDelegate, new object[] { code, message });
            }
            else
            {

                if (code == "200")
                {
                    uiProgressIndicator1.Visible = false;

                    ShowSuccessTip("登录成功");
                    Form_Admin form_admin = new Form_Admin(edtUser.Text);
                    form_admin.StartPosition = FormStartPosition.CenterScreen;
                    form_admin.Show();
                    this.Hide();
                }
                else if (code == "-1")
                {
                    btnCancel.Enabled = true;
                    btnLogin.Enabled = true;
                    edtUser.Enabled = true;
                    edtPassword.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    ShowErrorTip(message);

                }
                else if (code == "404")
                {
                    btnCancel.Enabled = true;
                    btnLogin.Enabled = true;
                    edtUser.Enabled = true;
                    edtPassword.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    ShowWarningTip(message);

                }
                else if (code == "100")
                {
                    btnCancel.Enabled = true;
                    btnLogin.Enabled = true;
                    edtUser.Enabled = true;
                    edtPassword.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    ShowWarningTip(message);

                }
                else if (code == "1000")
                {
                    btnCancel.Enabled = true;
                    btnLogin.Enabled = true;
                    edtUser.Enabled = true;
                    edtPassword.Enabled = true;
                    uiProgressIndicator1.Visible = false;
                    ShowWarningTip(message);

                }

                // textBox1.Text = message;
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
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.AdminLogin(edtUser.Text, edtPassword.Text));

            timer.Elapsed += (o, a) =>
            {

                //SetData();
                ShowMessage(rt.code.ToString(), rt.message);
            };
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnLogin.Enabled = false;
            edtUser.Enabled = false;
            edtPassword.Enabled = false;
            uiProgressIndicator1.Visible = true;
            Thread t = new Thread(new ThreadStart(GetData));
            t.IsBackground = true;
            t.Start();

            /* if (ButtonLoginClick != null)
            {
                ButtonLoginClick?.Invoke(sender, e);
            }
            else
            {
                IsLogin = OnLogin != null && OnLogin(edtUser.Text, edtPassword.Text);
                if (IsLogin) Close();
            }*/
        }

        public event EventHandler ButtonLoginClick;

        public event EventHandler ButtonCancelClick;

        [DefaultValue(false), Browsable(false)]
        public bool IsLogin { get; protected set; }

        public delegate bool OnLoginHandle(string userName, string password);

        public event OnLoginHandle OnLogin;

        private void UILoginForm_Enter(object sender, EventArgs e)
        {
            //btnLogin.PerformClick();
        }

        private void Form_Login_Admin_Load(object sender, EventArgs e)
        {
            uiProgressIndicator1.Visible = false;
        }
    }
}