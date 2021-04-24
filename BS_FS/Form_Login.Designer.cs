namespace BS_FS
{
    partial class ControlFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlFm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.id = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiProgressIndicator1 = new Sunny.UI.UIProgressIndicator();
            this.pgbWrite = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(188, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用TL系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(344, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "忘记密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "专属账号登录";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 9;
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(181, 305);
            this.uiButton1.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 20;
            this.uiButton1.Size = new System.Drawing.Size(115, 38);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 10;
            this.uiButton1.Text = "安全登录";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // id
            // 
            this.id.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.id.BackColor = System.Drawing.Color.White;
            this.id.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.id.Location = new System.Drawing.Point(241, 175);
            this.id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(157, 25);
            this.id.TabIndex = 5;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(241, 222);
            this.pwd.Margin = new System.Windows.Forms.Padding(2);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(157, 25);
            this.pwd.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(178, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "账号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(178, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "密码：";
            // 
            // uiButton2
            // 
            this.uiButton2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.Tomato;
            this.uiButton2.FillHoverColor = System.Drawing.Color.Salmon;
            this.uiButton2.FillPressColor = System.Drawing.Color.Salmon;
            this.uiButton2.FillSelectedColor = System.Drawing.Color.Salmon;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(319, 305);
            this.uiButton2.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Radius = 20;
            this.uiButton2.RectColor = System.Drawing.Color.IndianRed;
            this.uiButton2.RectHoverColor = System.Drawing.Color.Salmon;
            this.uiButton2.RectPressColor = System.Drawing.Color.Salmon;
            this.uiButton2.RectSelectedColor = System.Drawing.Color.Salmon;
            this.uiButton2.Size = new System.Drawing.Size(115, 38);
            this.uiButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton2.TabIndex = 14;
            this.uiButton2.Text = "退出系统";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiProgressIndicator1
            // 
            this.uiProgressIndicator1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiProgressIndicator1.Location = new System.Drawing.Point(266, 187);
            this.uiProgressIndicator1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiProgressIndicator1.Name = "uiProgressIndicator1";
            this.uiProgressIndicator1.Radius = 10;
            this.uiProgressIndicator1.Size = new System.Drawing.Size(100, 100);
            this.uiProgressIndicator1.TabIndex = 16;
            this.uiProgressIndicator1.Text = "uiProgressIndicator1";
            // 
            // pgbWrite
            // 
            this.pgbWrite.Location = new System.Drawing.Point(214, 58);
            this.pgbWrite.Name = "pgbWrite";
            this.pgbWrite.Size = new System.Drawing.Size(100, 23);
            this.pgbWrite.TabIndex = 17;
            // 
            // ControlFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 420);
            this.ControlBox = false;
            this.Controls.Add(this.pgbWrite);
            this.Controls.Add(this.uiProgressIndicator1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlFm";
            this.Text = "考勤系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlFm_FormClosed);
            this.Load += new System.EventHandler(this.ControlFm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ControlFm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlFm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlFm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlFm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Sunny.UI.UIButton uiButton1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIProgressIndicator uiProgressIndicator1;
        private System.Windows.Forms.ProgressBar pgbWrite;
    }
}