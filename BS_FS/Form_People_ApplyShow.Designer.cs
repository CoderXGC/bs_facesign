﻿
namespace BS_FS
{
    partial class Form_People_ApplyShow
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
            this.components = new System.ComponentModel.Container();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiListBox1 = new Sunny.UI.UIListBox();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiListBox1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(-2, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1063, 524);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            // 
            // uiListBox1
            // 
            this.uiListBox1.FillColor = System.Drawing.Color.White;
            this.uiListBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiListBox1.FormatString = "";
            this.uiListBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiListBox1.Location = new System.Drawing.Point(246, 24);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox1.Size = new System.Drawing.Size(527, 475);
            this.uiListBox1.TabIndex = 1;
            this.uiListBox1.Text = "uiListBox1";
            // 
            // Form_People_ApplyShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 503);
            this.Controls.Add(this.uiPanel1);
            this.Name = "Form_People_ApplyShow";
            this.Text = "Form_People_ApplyShow";
            this.Load += new System.EventHandler(this.Form_People_ApplyShow_Load);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIListBox uiListBox1;
        private Sunny.UI.UIStyleManager uiStyleManager1;
    }
}