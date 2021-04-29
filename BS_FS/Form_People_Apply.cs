using BS_FS.net;
using BS_FS.Utils;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BS_FS
{
    public partial class Form_People_Apply : Form
    {
        public bool start = true;
        public bool end = true;
        public Form_People_Apply(string id)
        {
            InitializeComponent();
            this.Text = id;
            this.SizeChanged += new Resize(this).Form1_Resize;  //窗口自适应代码
            uiComboBox1.Items.Add("事假");//选择项1
            uiComboBox1.Items.Add("调休");
            uiComboBox1.Items.Add("病假");
            uiComboBox1.Items.Add("年假");
            uiComboBox1.Items.Add("产假");
            uiComboBox1.Items.Add("陪产假");
            uiComboBox1.Items.Add("婚假");
            uiComboBox1.Items.Add("例假");
            uiComboBox1.Items.Add("哺乳假");
            //用户输入

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (uiComboBox1.SelectedItem.ToString()) //获取选择的内容
            {

                case "事假":  break;

                case "调休":  break;

                case "病假":  break;

                case "年假": break;

                case "产假":  break;

                case "陪产假":  break;

                case "婚假": break;

                case "例假":  break;

                case "哺乳假":  break;

            }
        }

        private void Form_People_Apply_Load(object sender, EventArgs e)
        {
            uiLabel3.ForeColor = Color.Red;
            uiLabel5.ForeColor = Color.Red;
            uiLabel7.ForeColor = Color.Red;
            uiLabel9.ForeColor = Color.Red;
            uiLabel11.ForeColor = Color.Red;
            uiDatetimePicker1.Value =DateTime.Now;
            uiDatetimePicker1.Text = "请选择";
            uiDatetimePicker2.Value = DateTime.Now;
            uiDatetimePicker2.Text = "请选择";
        }

        private void uiTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            uiTextBox1.Text = "";
        }

        private void uiRichTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            uiTextBox1.Text = "";
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            uiButton1.Enabled = false;
           UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;

            if (uiComboBox1.Text.ToString() == "请选择")
            {
                UIMessageDialog.ShowMessageDialog("请选择请假类型!", UILocalize.InfoTitle, false, style);
                uiButton1.Enabled = true;
            }
            else if (start)
            {
                uiButton1.Enabled = true;
                UIMessageDialog.ShowMessageDialog("请选择开始时间!", UILocalize.InfoTitle, false, style);

            }
            else if (end)
            {
                UIMessageDialog.ShowMessageDialog("请选择结束时间!", UILocalize.InfoTitle, false, style);

                uiButton1.Enabled = true;
            }
            else if (uiTextBox1.Text == "时长(必填)")
            {
                UIMessageDialog.ShowMessageDialog("请手动输入时长!", UILocalize.InfoTitle, false, style);
                uiButton1.Enabled = true;
            }
            else if (uiRichTextBox1.Text == "请输入请假事由")
            {
                UIMessageDialog.ShowMessageDialog("请输入请假事由!", UILocalize.InfoTitle, false, style);
                uiButton1.Enabled = true;
            }
            else
            {
                Net n = new Net();
                MessageBox.Show(this.Text + uiDatetimePicker1.Value.DateTimeString() + "测试1" + uiRichTextBox1.Text + "测试2" + uiDatetimePicker1.Value.DateTimeString() + "测试3" + uiDatetimePicker2.Value.DateTimeString() + "测试4" + this.Text + "测试5" + uiComboBox1.SelectedItem.ToString());
                JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.AddApply(this.Text+ uiDatetimePicker1.Value.DateTimeString(),uiRichTextBox1.Text, DateTime.Now.ToString("yyyy-MM-ddHH:mm:ss"), uiDatetimePicker1.Value.DateTimeString(),uiDatetimePicker2.Value.DateTimeString(),this.Text, uiComboBox1.SelectedItem.ToString()));
                if (rt.code.ToString() == "200")
                {
 

                    ShowSuccessTip("提交成功，等待管理员审核！");
                    uiButton1.Enabled = true;


                }
                else if (rt.code.ToString() == "-1")
                {
                    uiButton1.Enabled = true;
                    ShowErrorTip(rt.message.ToString());

                }
                else if (rt.code.ToString() == "404")
                {
                    uiButton1.Enabled = true;
                    ShowWarningTip(rt.message.ToString());

                }
                else if (rt.code.ToString() == "100")
                {
                    uiButton1.Enabled = true;

                    ShowWarningTip(rt.message.ToString());

                }
                else if (rt.code.ToString() == "1000")
                {

                    uiButton1.Enabled = true;

                    ShowWarningTip(rt.message.ToString());

                }

                // MessageBox.Show(uiDatetimePicker1.Value.DateTimeString());
                // MessageBox.Show(uiDatetimePicker2.Value.Date.ToString());
                //  MessageBox.Show();

            }
        }

        private void uiDatetimePicker1_ValueChanged(object sender, DateTime value)
        {
            int compNum = DateTime.Compare(uiDatetimePicker1.Value.Date, DateTime.Now);
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (compNum < 0)
            {
                UIMessageDialog.ShowMessageDialog("选择错误，请选择比当前日期大的时间。", UILocalize.InfoTitle, false, style);

            }
            else {
                start = false;
            }

       
        }

        private void uiDatetimePicker2_ValueChanged(object sender, DateTime value)
        {
            int compNum = DateTime.Compare(Convert.ToDateTime(uiDatetimePicker2.Value.DateTimeString()), DateTime.Now);
            int compNumbefore = DateTime.Compare(Convert.ToDateTime(uiDatetimePicker2.Value.DateTimeString()), Convert.ToDateTime(uiDatetimePicker1.Value.DateTimeString()));
            UIStyle style = (UIStyle)1;
            uiStyleManager1.Style = style;
            if (compNum < 0)
            {
                UIMessageDialog.ShowMessageDialog("选择错误，请选择比当前日期大的时间。", UILocalize.InfoTitle, false, style);

            }
            else if (compNumbefore < 0)
            {
                UIMessageDialog.ShowMessageDialog("选择错误，请选择比开始日期大的时间。", UILocalize.InfoTitle, false, style);

            }
            else {
               uiTextBox1.Text=GetDateDiff(Convert.ToDateTime(uiDatetimePicker1.Value.DateTimeString()), Convert.ToDateTime(uiDatetimePicker2.Value.DateTimeString()));
                end = false;

            }
         
        }

        /// <summary>
        /// 获取时间差字符串
        /// </summary>
        /// <param name="timeStart">起始时间</param>
        /// <param name="timeEnd">截止时间</param>
        /// <returns></returns>
        public  string GetDateDiff(DateTime timeStart, DateTime timeEnd)
        {
            int rhours = 0;
            TimeSpan timeSpanS = new TimeSpan(timeStart.Ticks);
            TimeSpan timeSpanE = new TimeSpan(timeEnd.Ticks);
            TimeSpan timeDiff = timeSpanE.Subtract(timeSpanS);

            string days = timeDiff.Days.ToString();                 //获取时间差值的天数
            string hours = timeDiff.Hours.ToString();               //获取时间差值的小时数
            string minutes = timeDiff.Minutes.ToString();           //获取时间差值的分钟数
            string seconds = timeDiff.Seconds.ToString();           //获取时间差值的秒钟数
            Net n = new Net();
            //这个需要引入Newtonsoft.Json这个DLL并using
            //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
            JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Find(this.Text));
            string signintime = rt.data.signintime;
            string signouttime = rt.data.signouttime;
            string[] strArrayin = signintime.Split(':');
            string[] strArrayout = signouttime.Split(':');
                if (int.Parse(strArrayin[0]) < int.Parse(timeStart.ToString("HH")) && int.Parse(strArrayout[0]) > int.Parse(timeEnd.ToString("HH")))
                {
                    if (hours=="0")
                    {
                        rhours = int.Parse(timeStart.ToString("HH")) - int.Parse(strArrayin[0]);
                    }
                    else
                    {
                       
                        rhours = int.Parse(timeStart.ToString("HH")) - int.Parse(strArrayin[0]) + 1;

                    }
                    rhours = rhours + int.Parse(days)*(int.Parse(strArrayout[0])-int.Parse(strArrayin[0]));

                }
                else
                {
                rhours = int.Parse(days) * (int.Parse(strArrayout[0]) - int.Parse(strArrayin[0])) + (int.Parse(strArrayout[0]) - int.Parse(strArrayin[0]));

                }
            

            
          
            return rhours.ToString();
        }
        public string GetDateTimeDiff(DateTime timeStart, DateTime timeEnd)
        {
            TimeSpan timeSpanS = new TimeSpan(timeStart.Ticks);
            TimeSpan timeSpanE = new TimeSpan(timeEnd.Ticks);
            TimeSpan timeDiff = timeSpanE.Subtract(timeSpanS);

            int days = int.Parse(timeDiff.Days.ToString());                 //获取时间差值的天数
            int hours = int.Parse(timeDiff.Hours.ToString());               //获取时间差值的小时数
            int minutes = int.Parse(timeDiff.Minutes.ToString());           //获取时间差值的分钟数
            int seconds = int.Parse(timeDiff.Seconds.ToString());           //获取时间差值的秒钟数
            string result = string.Format("From {0} to {1},it crossed  {2} Days ,{3} Hours , {4} Minutes ,{5} Seconds. ", timeStart, timeEnd, days, hours, minutes, seconds);
            return result;
        }
        public void ShowSuccessTip(string text, int delay = 1000, bool floating = true)
=> UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);
    }
}
