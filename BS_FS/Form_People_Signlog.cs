using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using BS_FS.net;
using Newtonsoft.Json;
using Sunny.UI;
namespace BS_FS
{
    public partial class Form_People_Signlog : Form
    {
        public Form_People_Signlog(String id)
        {
            InitializeComponent();
            this.Text = id;


        }

        private void Form_People_Signlog_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//设置列标题文字居中
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//设置单元格内容居中
            dataGridView1.AllowUserToResizeColumns = false;//禁止用户改变DataGridView1的所有列的列宽
            dataGridView1.AllowUserToResizeRows = false;//禁止用户改变DataGridView1の所有行的行高
            dataGridView1.RowHeadersVisible = false;//第一列空白
            uiSymbolButton1.Enabled = false;//禁止导出按钮
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            while (this.dataGridView1.Rows.Count!= 0)
            {

                this.dataGridView1.Rows.RemoveAt(0);
            }

            dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int compNum = DateTime.Compare(dateTimePicker1.Value.Date, DateTime.Now);
            if (compNum > 0)
            {
                MessageBox.Show("查询错误，请选择比当前日期小的时间。");
                uiSymbolButton1.Enabled = false;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                Net n = new Net();

                //这个需要引入Newtonsoft.Json这个DLL并using
                //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
                JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Findsign(this.Text, this.Text + dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                if (rt.code.ToString() == "200")
                {

                    this.dataGridView1.Rows.Add(rt.data.user_id, "徐广超", rt.data.signintime, rt.data.signouttime);
                    //     DataGridView1.Columns[0].
                    //   dataGridView1.DataSource = rt.data.signintime;
                    uiSymbolButton1.Enabled = true;

                }
                else if (rt.code.ToString() == "-1")
                {
                    MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd") + "当天您没有签到哦");
                    uiSymbolButton1.Enabled = false;

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
                /*    DataMysql data = new DataMysql();
                    data.dataCon();
                    //查询数据库
                    string cmdStr = "Select signlog.id,user.name,signlog.signintime from user,signlog where daytime='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and signlog.id=user.id ";
                    MySqlConnection con = new MySqlConnection("server=116.62.110.115;port=3306;user=facesign;password=99d44172db8d6d58;database=facesign");
                    MySqlCommand sqlCmd = new MySqlCommand(cmdStr, con);
                    MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "sign");
                    ds = data.getDataSet(cmdStr);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd") + "当天没有人员签到哦");
                        button1.Enabled = false;
                    }
                    else
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                        button1.Enabled = true;
                    }*/

            }
        }


        //引用登录提示框架弹出气泡
        public void ShowSuccessTip(string text, int delay = 500, bool floating = true)
    => UIMessageTip.ShowOk(text, delay, floating);
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowWarning(text, delay, floating);
        public void ShowErrorTip(string text, int delay = 1000, bool floating = true)
    => UIMessageTip.ShowError(text, delay, floating);

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";

            DateTime now = DateTime.Now;
            saveFileDialog.FileName = dateTimePicker1.Value.ToString("yyyy-MM-dd") + "人员签到情况表";
            saveFileDialog.ShowDialog();

            Stream myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //写标题     
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += this.dataGridView1.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                //写内容   
                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < this.dataGridView1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += this.dataGridView1.Rows[j].Cells[k].Value.ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
            while (this.uiDataGridView1.Rows.Count != 0)
            {
                if (uiDataGridView1.Rows.Count > 1)
                {
                    this.uiDataGridView1.Rows.RemoveAt(0);
                }
            }


            uiDatePicker1.Value.ToString("yyyy-MM-dd");
            int compNum = DateTime.Compare(uiDatePicker1.Value.Date, DateTime.Now);
            if (compNum > 0)
            {
                UIStyle style = (UIStyle)1;
                uiStyleManager1.Style = style;
                UIMessageDialog.ShowMessageDialog("查询错误，请选择比当前日期小的时间。", UILocalize.InfoTitle, false, style);
               // UIMessageDialog.ShowMessageDialog("查询错误，请选择比当前日期小的时间。", UILocalize.InfoTitle, false, Style);
             //   MessageBox.Show("查询错误，请选择比当前日期小的时间。");
                uiSymbolButton1.Enabled = false;
            }
            else
            {
               uiDataGridView1.ReadOnly = true;
                Net n = new Net();

                //这个需要引入Newtonsoft.Json这个DLL并using
                //传入实体类还有需要解析的JSON字符串这样就OK了。然后就可以通过实体类使用数据了。
                JsonBean rt = JsonConvert.DeserializeObject<JsonBean>(n.Findsign(this.Text, this.Text + dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                if (rt.code.ToString() == "200")
                {

                    this.uiDataGridView1.Rows.Add(rt.data.user_id, "徐广超", rt.data.signintime, rt.data.signouttime);
                    //     DataGridView1.Columns[0].
                    //   dataGridView1.DataSource = rt.data.signintime;
                    uiSymbolButton1.Enabled = true;

                }
                else if (rt.code.ToString() == "-1")
                {
                    MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd") + "当天您没有签到哦");
                    uiSymbolButton1.Enabled = false;

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
        }
    }
}
