namespace BS_FS
{
    partial class Form_Loading
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
            this.LblMessage = new System.Windows.Forms.Label();
            this.PnlImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LblMessage
            // 
            this.LblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMessage.BackColor = System.Drawing.Color.Transparent;
            this.LblMessage.ForeColor = System.Drawing.Color.White;
            this.LblMessage.Location = new System.Drawing.Point(7, 255);
            this.LblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(497, 80);
            this.LblMessage.TabIndex = 2;
            this.LblMessage.Text = "正在处理中，请稍候……";
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblMessage.Click += new System.EventHandler(this.LblMessage_Click);
            // 
            // PnlImage
            // 
            this.PnlImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlImage.BackColor = System.Drawing.Color.Transparent;
            this.PnlImage.Location = new System.Drawing.Point(123, -10);
            this.PnlImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PnlImage.Name = "PnlImage";
            this.PnlImage.Size = new System.Drawing.Size(267, 250);
            this.PnlImage.TabIndex = 3;
            this.PnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlImage_Paint);
            this.PnlImage.Resize += new System.EventHandler(this.PnlImage_Resize);
            // 
            // Form_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(512, 326);
            this.Controls.Add(this.LblMessage);
            this.Controls.Add(this.PnlImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Loading";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Loding";
            this.Load += new System.EventHandler(this.Form_Loding_Load);
            this.Shown += new System.EventHandler(this.Form_Loding_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Panel PnlImage;
    }
}