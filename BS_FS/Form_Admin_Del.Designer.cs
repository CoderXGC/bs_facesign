
namespace BS_FS
{
    partial class Form_Admin_Del
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTextBox1);
            this.uiPanel1.Controls.Add(this.uiLabel1);
            this.uiPanel1.Controls.Add(this.uiButton1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(-11, -8);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(813, 469);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(533, 44);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 10;
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "删除";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(42, 44);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(211, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "请输入删除用户的ID:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox1.Location = new System.Drawing.Point(260, 44);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.Size = new System.Drawing.Size(150, 34);
            this.uiTextBox1.TabIndex = 2;
            // 
            // Form_Admin_Del
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiPanel1);
            this.Name = "Form_Admin_Del";
            this.Text = "Form_Admin_Del";
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox uiTextBox1;
    }
}