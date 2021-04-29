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
    public partial class Form_People_ApplyShow : Form
    {
        public Form_People_ApplyShow(String id)
        {
            InitializeComponent();
            this.Text = id;
        }

        private void Form_People_ApplyShow_Load(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            Net n = new Net();
            JsonArrayBean rt = JsonConvert.DeserializeObject<JsonArrayBean>(n.FinduserallApply(this.Text));
            uiListBox1.Items.Clear();
            for (int i = 0; i < rt.data.Length; i++)
            {

                if (rt.code.ToString() == "200")
                {
                    uiListBox1.Items.Add("申请时间：" + rt.data[i].applytime.ToString() + "审批状态:" + rt.data[i].status.ToString() + "内容：" + rt.data[i].message.ToString());

                }
                else if (rt.code.ToString() == "-1")
                {
                    UIMessageDialog.ShowMessageDialog(rt.message.ToString(), UILocalize.InfoTitle, false, style);

                }
                else if (rt.code.ToString() == "404")
                {
                    UIMessageDialog.ShowMessageDialog(rt.message.ToString(), UILocalize.InfoTitle, false, style);

                }
                else if (rt.code.ToString() == "100")
                {
                    UIMessageDialog.ShowMessageDialog(rt.message.ToString(), UILocalize.InfoTitle, false, style);

                }
                else if (rt.code.ToString() == "1000")
                {


                    UIMessageDialog.ShowMessageDialog(rt.message.ToString(), UILocalize.InfoTitle, false, style);

                }

            }
        }
    }
}
