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
    public partial class Form_Admin_Audit : Form
    {
        public Form_Admin_Audit()
        {
            InitializeComponent();
        }

        private void Form_Admin_Audit_Load(object sender, EventArgs e)
        {
            uiListBox1.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                uiListBox1.Items.Add(i);
            }
        }

        private void uiListBox1_ItemClick(object sender, EventArgs e)
        {
            uiListBox1.SelectedItem.ToString();
        }
    }
}
