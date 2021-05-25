using BS_FS.net;
using BS_FS.Utils;
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
    public partial class Form2 : UITitlePage
    {
        public Form2()
        {
            InitializeComponent();
        }
        public override void Init()
        {
            string value = "";
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (this.InputPasswordDialog(ref value))
            {
                string pwdencrytion = PwdEncryption.MD5Encrypt32(value);
                //   UIMessageDialog.ShowMessageDialog(value, UILocalize.InfoTitle, false, style);

                Net n = new Net();
                JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Uppwd("10003", pwdencrytion));

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
}
