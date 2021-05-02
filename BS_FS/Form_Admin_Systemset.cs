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
    public partial class Form_Admin_Systemset : Form
    {
       
        public Form_Admin_Systemset()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            Net n = new Net();
           
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.UpdateSignTime(uiTextBox1.Text, uiTextBox2.Text));
            if (rt.code.ToString() == "200")
            {

                UIMessageDialog.ShowMessageDialog("修改成功！", UILocalize.InfoTitle, false, style);

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
}
