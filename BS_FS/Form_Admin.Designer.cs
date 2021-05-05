namespace BS_FS
{
    partial class Form_Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.首页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.签到签退ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入员工信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除人员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看签到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.发送反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.技术支持ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首页ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 首页ToolStripMenuItem
            // 
            this.首页ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.签到签退ToolStripMenuItem});
            this.首页ToolStripMenuItem.Name = "首页ToolStripMenuItem";
            this.首页ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.首页ToolStripMenuItem.Text = "首页";
            // 
            // 签到签退ToolStripMenuItem
            // 
            this.签到签退ToolStripMenuItem.Name = "签到签退ToolStripMenuItem";
            this.签到签退ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.签到签退ToolStripMenuItem.Text = "签到签退";
            this.签到签退ToolStripMenuItem.Click += new System.EventHandler(this.签到签退ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.录入员工信息ToolStripMenuItem,
            this.修改密码ToolStripMenuItem,
            this.删除人员信息ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 录入员工信息ToolStripMenuItem
            // 
            this.录入员工信息ToolStripMenuItem.Name = "录入员工信息ToolStripMenuItem";
            this.录入员工信息ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.录入员工信息ToolStripMenuItem.Text = "录入员工信息";
            this.录入员工信息ToolStripMenuItem.Click += new System.EventHandler(this.录入员工信息ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.修改密码ToolStripMenuItem.Text = "修改账户密码";
            // 
            // 删除人员信息ToolStripMenuItem
            // 
            this.删除人员信息ToolStripMenuItem.Name = "删除人员信息ToolStripMenuItem";
            this.删除人员信息ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.删除人员信息ToolStripMenuItem.Text = "删除人员信息";
            this.删除人员信息ToolStripMenuItem.Click += new System.EventHandler(this.删除人员信息ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看签到ToolStripMenuItem,
            this.查看申请ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 查看签到ToolStripMenuItem
            // 
            this.查看签到ToolStripMenuItem.Name = "查看签到ToolStripMenuItem";
            this.查看签到ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.查看签到ToolStripMenuItem.Text = "查看签到";
            this.查看签到ToolStripMenuItem.Click += new System.EventHandler(this.查看签到ToolStripMenuItem_Click);
            // 
            // 查看申请ToolStripMenuItem
            // 
            this.查看申请ToolStripMenuItem.Name = "查看申请ToolStripMenuItem";
            this.查看申请ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.查看申请ToolStripMenuItem.Text = "查看申请";
            this.查看申请ToolStripMenuItem.Click += new System.EventHandler(this.查看申请ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.发送反馈ToolStripMenuItem,
            this.技术支持ToolStripMenuItem,
            this.检查更新ToolStripMenuItem,
            this.关于系统ToolStripMenuItem,
            this.数据备份ToolStripMenuItem,
            this.系统设置ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.toolStripMenuItem1.Text = "查看帮助";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 发送反馈ToolStripMenuItem
            // 
            this.发送反馈ToolStripMenuItem.Name = "发送反馈ToolStripMenuItem";
            this.发送反馈ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.发送反馈ToolStripMenuItem.Text = "发送反馈";
            this.发送反馈ToolStripMenuItem.Click += new System.EventHandler(this.发送反馈ToolStripMenuItem_Click);
            // 
            // 技术支持ToolStripMenuItem
            // 
            this.技术支持ToolStripMenuItem.Name = "技术支持ToolStripMenuItem";
            this.技术支持ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.技术支持ToolStripMenuItem.Text = "技术支持";
            this.技术支持ToolStripMenuItem.Click += new System.EventHandler(this.技术支持ToolStripMenuItem_Click);
            // 
            // 检查更新ToolStripMenuItem
            // 
            this.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem";
            this.检查更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.检查更新ToolStripMenuItem.Text = "检查更新";
            this.检查更新ToolStripMenuItem.Click += new System.EventHandler(this.检查更新ToolStripMenuItem_Click);
            // 
            // 关于系统ToolStripMenuItem
            // 
            this.关于系统ToolStripMenuItem.Name = "关于系统ToolStripMenuItem";
            this.关于系统ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.关于系统ToolStripMenuItem.Text = "关于系统";
            this.关于系统ToolStripMenuItem.Click += new System.EventHandler(this.关于系统ToolStripMenuItem_Click);
            // 
            // 数据备份ToolStripMenuItem
            // 
            this.数据备份ToolStripMenuItem.Name = "数据备份ToolStripMenuItem";
            this.数据备份ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.数据备份ToolStripMenuItem.Text = "数据备份";
            this.数据备份ToolStripMenuItem.Click += new System.EventHandler(this.数据备份ToolStripMenuItem_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            this.系统设置ToolStripMenuItem.Click += new System.EventHandler(this.系统设置ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(939, 536);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "欢迎使用人脸考勤系统~";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.pictureBox1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 31);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1067, 531);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(390, 163);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.uiPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Admin";
            this.Text = "欢迎登录考勤后台管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Admin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Admin_FormClosed);
            this.Load += new System.EventHandler(this.Form_Admin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入员工信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看签到ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 发送反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 技术支持ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于系统ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 查看申请ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据备份ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 首页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 签到签退ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除人员信息ToolStripMenuItem;
    }
}