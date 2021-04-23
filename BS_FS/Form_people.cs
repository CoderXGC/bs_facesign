
using System.Windows.Forms;
using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;

namespace BS_FS
{
    public partial class Form_people : Form
    {
        public Form_people(string id)
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

            this.panel1.Controls.Clear();

            //加入控件

            this.panel1.Controls.Add(From_admin_insert);

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

        private void 修改密码ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

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
          /*  FaceForm faceForm = new FaceForm();
            faceForm.Show();*/
          Form_Sign form_User = new Form_Sign(this.Text);
            form_User.Show();

        }
    }
}
