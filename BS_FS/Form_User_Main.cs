using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_FS
{
    public partial class Form_User_Main : UIHeaderAsideMainFrame
    {
        string role;
        string uid;
        public Form_User_Main(string id, string role)
        {
        
 

            uid = id;
            this.role = role;
            InitializeComponent();
            this.Text = uid;
            int pageIndex = 1000;
            Header.SetNodePageIndex(Header.Nodes[0], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[0], 61451);
            TreeNode parent = Aside.CreateNode("首页", 61451, 24, pageIndex);
            //通过设置PageIndex关联
            Aside.CreateChildNode(parent, 61461, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 62140, 24, AddPage(new Form_SignIn(uid), ++pageIndex));
            Aside.CreateChildNode(parent, 62144, 24, AddPage(new Form_Admin_insert(uid, role), ++pageIndex));
            Aside.CreateChildNode(parent, 61508, 24, AddPage(new Form_People_Apply(uid), ++pageIndex));
            Aside.SetNodeTipsText(parent.Nodes[0], "0");

            pageIndex = 2000;
            Header.SetNodePageIndex(Header.Nodes[1], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[1], 61818);
            parent = Aside.CreateNode("查看", 61818, 24, pageIndex);

            //通过设置GUID关联，节点字体图标和大小由UIPage设置
    
            Aside.CreateChildNode(parent, 61584, 24, AddPage(new Form_People_Signlog(uid), ++pageIndex));
            Aside.CreateChildNode(parent, 61584, 24, AddPage(new Form_People_ApplyShow(uid), ++pageIndex));

            pageIndex = 3000;
            Header.SetNodePageIndex(Header.Nodes[2], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[2], 61950);
            parent = Aside.CreateNode("帮助", 61546, 24, pageIndex);
            //直接关联（默认自动生成GUID）
            Aside.CreateChildNode(parent, 61842, 24, AddPage(new Form_People_Uppwd(uid), ++pageIndex));

            Header.SetNodeSymbol(Header.Nodes[3], 61502);
            var styles = UIStyles.PopularStyles();
            foreach (UIStyle style in styles)
            {
                Header.CreateChildNode(Header.Nodes[3], style.DisplayText(), style.Value());
            }

            Aside.SelectFirst();


        }

        private void Header_MenuItemClick(string text, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 0:
                case 1:
                case 2:
                    Aside.SelectPage(pageIndex);
                    break;

                case 3:
                    UIStyle style = (UIStyle)pageIndex;
                    uiStyleManager1.Style = style;
                    break;
            }
   
        }

        private void FMain_Selecting(object sender, TabControlCancelEventArgs e, UIPage page)
        {
            page?.Text.ConsoleWriteLine();
        }


        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("SunnyUI.Net V3.0", "关于", Style, UIMessageBoxButtons.OK, false);
        }

        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitee.com/yhuse/SunnyUI");
        }
        public void Net(object source, System.Timers.ElapsedEventArgs e)

        {
            Net n = new Net();
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Findfaceimg(uid));

            if (rt.code.ToString() == "200")
            {

            }
            else if (rt.code.ToString() == "-1")
            {

                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();

            }
            else if (rt.code.ToString() == "404")
            {
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();


            }
            else if (rt.code.ToString() == "100")
            {

                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();

            }
            else if (rt.code.ToString() == "1000")
            {

                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();


            }
        }

        private void Aside_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
         

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}