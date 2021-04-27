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
    public partial class Form_People_Apply : Form
    {
        public Form_People_Apply(string id)
        {
            InitializeComponent();
            this.Text = id;
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
            uiComboBox1.Items.Add("事假");//选择项1
            uiComboBox1.Items.Add("调休");
            uiComboBox1.Items.Add("病假");
            uiComboBox1.Items.Add("年假");
            uiComboBox1.Items.Add("产假");
            uiComboBox1.Items.Add("陪产假");
            uiComboBox1.Items.Add("婚假");
            uiComboBox1.Items.Add("例假");
            uiComboBox1.Items.Add("哺乳假");
        }
    }
}
