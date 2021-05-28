using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Threading;
using System.Windows.Forms;
using static BS_FS.net.JsonArrayBean;

namespace BS_FS
{
  
    public partial class Form_People_ApplyShow : UITitlePage
    {
        string uid;
        public Form_People_ApplyShow(String id)
        {
            InitializeComponent();
            uid = id;
            this.Text = "查看申请";
            //Thread.Sleep(3000);
            //  SetWaitFormDescription(UILocalize.SystemProcessing + "50%");
            //Thread.Sleep(3000);


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
        private delegate void ShowMessageDelegate(string code, string message, Datum[] data);
        private void ShowMessage(string code, string message,Datum[] data)
        {
              
           UIStyle style = (UIStyle)1;
             uiStyleManager1.Style = style;
            if (this.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                this.Invoke(showMessageDelegate, new object[] { code, message,data });
            }
            else
            {


                if (code == "200")
                {

                          for (int i = 0; i < data.Length; i++)
                           {
                        if (data[i].status.ToString() == "0") { 
                            this.uiListBox1.Items.Add("申请时间:" + data[i].applytime.ToString() + "审批状态：未审批 内容：" + data[i].message.ToString()); 
                        }

                        else if (data[i].status.ToString() == "1")
                        {

                            this.uiListBox1.Items.Add("申请时间:" + data[i].applytime.ToString() + "审批状态：已审批 内容：" + data[i].message.ToString());
                        }
                        else if (data[i].status.ToString() == "2")
                        {

                            this.uiListBox1.Items.Add("申请时间:" + data[i].applytime.ToString() + "审批状态：已拒绝 内容：" + data[i].message.ToString());
                        }
                           }

              
                    uiButton1.Enabled = true;
                    HideWaitForm();
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
            JsonArrayBean rt = JsonConvert.DeserializeObject<JsonArrayBean>(n.FinduserallApply(uid));

            timer.Elapsed += (o, a) =>
            {
                ShowMessage(rt.code.ToString(), rt.message,rt.data);
            };
        }

        private void Form_People_ApplyShow_Load(object sender, EventArgs e)
        {

 

        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (uiListBox1.SelectedIndex == -1)
            {
                UIMessageDialog.ShowMessageDialog("您还未选择要取消的申请，请选择！", UILocalize.InfoTitle, false, style);

            }
            else {
                
                string[] strArrayapp1 = uiListBox1.SelectedItem.ToString().Split("审批状态：");

                string[] strArrayapp2 = strArrayapp1[0].Split("请时间:");
                    UIMessageDialog.ShowMessageDialog(uid+strArrayapp2[1], UILocalize.InfoTitle, false, style);
                    Net n = new Net();
                    JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.DelApply(uid, uid + strArrayapp2[1]));
                    if (rt.code.ToString() == "200")
                    {
                        uiListBox1.Items.RemoveAt(uiListBox1.SelectedIndex);
                        UIMessageDialog.ShowMessageDialog("删除成功！", UILocalize.InfoTitle, false, style);

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
        public void SetWaitFormDescription(string desc)
        {
            UIWaitFormService.SetDescription(desc);
        }
        public void ShowWaitForm(string desc = "查询中，请稍候...")
        {
            UIWaitFormService.ShowWaitForm(desc);
        }
        public void HideWaitForm()
        {
            UIWaitFormService.HideWaitForm();
        }

        private void Form_People_ApplyShow_Shown(object sender, EventArgs e)
        {
        
    

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void uiListBox1_ItemClick(object sender, EventArgs e)
        {

        }
        public override void Init()
        {
            uiListBox1.Items.Clear();
            uiButton1.Enabled = false;
            Thread t = new Thread(new ThreadStart(GetData));
            t.IsBackground = true;
            t.Start();
            ShowWaitForm();

        }
        }
}
