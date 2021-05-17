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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BS_FS.net.JsonArrayBean;

namespace BS_FS
{
    public partial class Form_Admin_Del : Form
    {
        bool flag = false;
        public Form_Admin_Del()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            Thread t = new Thread(new ThreadStart(GetData));
            t.IsBackground = true;
            t.Start();
            ShowWaitForm();
           
        }

        //声明委托
        private delegate void ShowMessageDelegate(string code, string message, Datum[] data);
        private void ShowMessage(string code, string message, Datum[] data)
        {

            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (this.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                this.Invoke(showMessageDelegate, new object[] { code, message, data });
            }
            else
            {
                if (code == "200")
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].id.ToString() == uiTextBox1.Text)
                        {

                            UIMessageDialog.ShowMessageDialog(data[i].id.ToString(), UILocalize.InfoTitle, false, style);
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        Net n = new Net();
                        JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.DelUser(uiTextBox1.Text));
                        if (rt.code.ToString() == "200")
                        {
                            flag = false;
                            HideWaitForm();
                            UIMessageDialog.ShowMessageDialog("删除成功！", UILocalize.InfoTitle, false, style);

                        }
                        else if (rt.code.ToString() == "-1")
                        {
                            HideWaitForm();
                            UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);
                        }
                        else if (rt.code.ToString() == "404")
                        {

                            HideWaitForm();
                            UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                        }
                        else if (rt.code.ToString() == "100")
                        {

                            HideWaitForm();
                            UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                        }
                        else if (rt.code.ToString() == "1000")
                        {

                            HideWaitForm();
                            UIMessageDialog.ShowMessageDialog(rt.message, UILocalize.InfoTitle, false, style);

                        }
                    }
                    else
                    {
                        HideWaitForm();
                        UIMessageDialog.ShowMessageDialog("未找到，删除失败！", UILocalize.InfoTitle, false, style);

                    }
                }
                else if (code == "-1")
                {
                    HideWaitForm();
                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);
                }
                else if (code == "404")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }
                else if (code == "100")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }
                else if (code == "1000")
                {
                    HideWaitForm();

                    UIMessageDialog.ShowMessageDialog(message, UILocalize.InfoTitle, false, style);

                }



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
            JsonArrayBean rt = JsonConvert.DeserializeObject<JsonArrayBean>(n.FindUser());

            timer.Elapsed += (o, a) =>
            {
                ShowMessage(rt.code.ToString(), rt.message, rt.data);
            };
        }

        public void ShowWaitForm(string desc = "查询中，请稍候...")
        {
            UIWaitFormService.ShowWaitForm(desc);
        }
        public void HideWaitForm()
        {
            UIWaitFormService.HideWaitForm();
        }

    }
}
