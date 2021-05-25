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
            int pageIndex = 1000;
            Header.SetNodePageIndex(Header.Nodes[0], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[0], 61451);
            TreeNode parent = Aside.CreateNode("Controls", 61451, 24, pageIndex);
            //通过设置PageIndex关联
            Aside.CreateChildNode(parent, 61640, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 62141, 24, AddPage(new Form_SignIn(uid), ++pageIndex));
            Aside.CreateChildNode(parent, 61490, 24, AddPage(new Form_Admin_insert(uid, role), ++pageIndex));
            Aside.CreateChildNode(parent, 61770, 24, AddPage(new Form_People_Apply(uid), ++pageIndex));
            Aside.CreateChildNode(parent, 61842, 24, AddPage(new Form2(), ++pageIndex));
            Aside.CreateChildNode(parent, 61962, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61776, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61646, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61474, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61499, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61912, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61716, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61544, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61590, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61516, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61447, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 62104, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 61668, 24, AddPage(new Form1(), ++pageIndex));
            Aside.CreateChildNode(parent, 62173, 24, AddPage(new Form1(), ++pageIndex));
            Aside.SetNodeTipsText(parent.Nodes[0], "666666");

            pageIndex = 2000;
            Header.SetNodePageIndex(Header.Nodes[1], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[1], 61818);
            parent = Aside.CreateNode("Forms", 61818, 24, pageIndex);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            Aside.CreateChildNode(parent, AddPage(new Form1(), Guid.NewGuid()));
            Aside.CreateChildNode(parent, AddPage(new Form1(), Guid.NewGuid()));
            Aside.CreateChildNode(parent, AddPage(new Form1(), Guid.NewGuid()));

            pageIndex = 3000;
            Header.SetNodePageIndex(Header.Nodes[2], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[2], 61950);
            parent = Aside.CreateNode("Charts", 61950, 24, pageIndex);
            //直接关联（默认自动生成GUID）
            Aside.CreateChildNode(parent, AddPage(new Form1()));
            Aside.CreateChildNode(parent, AddPage(new Form1()));
            Aside.CreateChildNode(parent, AddPage(new Form1()));
            Aside.CreateChildNode(parent, AddPage(new Form1()));
            Aside.CreateChildNode(parent, AddPage(new Form1()));

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
    }
}