
using System.Collections.Generic;
using System.Windows.Forms;
using BS_FS.net;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
using Newtonsoft.Json;
using Sunny.UI;

namespace BS_FS
{
    public partial class Form_People : Form
    {
        public Form_People(string id)
        {
            InitializeComponent();
            this.Text = id;
        }

        private void 提交人脸信息ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            Form_Admin_insert From_admin_insert = new Form_Admin_insert(this.Text); //实例化一个子窗口

            //设置子窗口不显示为顶级窗口

            From_admin_insert.TopLevel = false;

            //设置子窗口的样式，没有上面的标题栏

            From_admin_insert.FormBorderStyle = FormBorderStyle.None;

            //填充

            From_admin_insert.Dock = DockStyle.Fill;

            //清空Panel里面的控件

            this.uiPanel1.Controls.Clear();

            //加入控件

            this.uiPanel1.Controls.Add(From_admin_insert);

            //让窗体显示

      
            Net n = new Net();
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Find(this.Text));
            //这样就可以取出json数据里面的值
            if (rt.data.faceimg.ToString().Equals("0"))
            {
                From_admin_insert.Show();

            } else if (rt.data.faceimg.ToString() != "")
            {
                ShowSuccessTip("已经提交过人脸信息了，请勿重复添加！");

            }
            else if (rt.code.ToString() == "-1")
            {
                From_admin_insert.Show();

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



        private void Form_people_Load(object sender, System.EventArgs e)
        {

        }
        public void ShowSuccessTip(string text, int delay = 500, bool floating = true)
=> UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);

        private void 签到ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
          Form_SignIn form_Sign = new Form_SignIn(this.Text);
            form_Sign.Show();

        }

        private void 查看签到信息ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form_People_Signlog form_People_Signlog = new Form_People_Signlog(this.Text); //实例化一个子窗口

            //设置子窗口不显示为顶级窗口

            form_People_Signlog.TopLevel = false;

            //设置子窗口的样式，没有上面的标题栏

            form_People_Signlog.FormBorderStyle = FormBorderStyle.None;

            //填充

            //  From_admin_query.Dock = DockStyle.Fill;

            //清空Panel里面的控件

            this.uiPanel1.Controls.Clear();

            //加入控件

            this.uiPanel1.Controls.Add(form_People_Signlog);

            //让窗体显示

            form_People_Signlog.Show();
        }

        private void 提交申请信息ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form_People_Apply form_People_Applly = new Form_People_Apply(this.Text); //实例化一个子窗口

            //设置子窗口不显示为顶级窗口

            form_People_Applly.TopLevel = false;

            //设置子窗口的样式，没有上面的标题栏

            form_People_Applly.FormBorderStyle = FormBorderStyle.None;

            //填充

            //  From_admin_query.Dock = DockStyle.Fill;

            //清空Panel里面的控件

            this.uiPanel1.Controls.Clear();

            //加入控件

            this.uiPanel1.Controls.Add(form_People_Applly);

            //让窗体显示

            form_People_Applly.Show();

        }

        private void 修改密码ToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            string value = "";
            if (this.InputPasswordDialog(ref value))
            {
               
            }
            /* FrmInputs frm = new FrmInputs("动态多输入窗体测试",
                    new string[] { "姓名", "电话", "身份证号", "新密码" },
                    new Dictionary<string, HZH_Controls.TextInputType>() { { "电话", HZH_Controls.TextInputType.Regex }, { "身份证号", HZH_Controls.TextInputType.Regex } },
                    new Dictionary<string, string>() { { "电话", "^1\\d{0,10}$" }, { "身份证号", "^\\d{0,18}$" } },
                    new Dictionary<string, KeyBoardType>() { { "电话", KeyBoardType.UCKeyBorderNum }, { "身份证号", KeyBoardType.UCKeyBorderNum } },
                    new List<string>() { "姓名", "电话", "身份证号" });
             frm.ShowDialog(this);*/

        }

        private void 查看申请信息ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form_People_ApplyShow form_People_AppllyShow = new Form_People_ApplyShow(this.Text); //实例化一个子窗口

            //设置子窗口不显示为顶级窗口

            form_People_AppllyShow.TopLevel = false;

            //设置子窗口的样式，没有上面的标题栏

            form_People_AppllyShow.FormBorderStyle = FormBorderStyle.None;

            //填充

            //  From_admin_query.Dock = DockStyle.Fill;

            //清空Panel里面的控件

            this.uiPanel1.Controls.Clear();

            //加入控件

            this.uiPanel1.Controls.Add(form_People_AppllyShow);

            //让窗体显示

            form_People_AppllyShow.Show();
        }
    }
}
