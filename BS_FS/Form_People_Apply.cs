using BS_FS.Utils;
using System;
using System.Windows.Forms;

namespace BS_FS
{
    public partial class Form_People_Apply : Form
    {
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

        }
    }
}
