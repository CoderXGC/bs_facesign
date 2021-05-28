
namespace BS_FS
{
    partial class Form_User_Main
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点3");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User_Main));
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.主页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiNavBar1 = new Sunny.UI.UINavBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiNavBar2 = new Sunny.UI.UINavBar();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.uiNavBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiNavBar2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Location = new System.Drawing.Point(2, 145);
            this.Aside.ShowOneNode = true;
            this.Aside.ShowSecondBackColor = true;
            this.Aside.ShowTips = true;
            this.Aside.Size = new System.Drawing.Size(250, 573);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Header
            // 
            this.Header.Controls.Add(this.uiNavBar1);
            this.Header.Location = new System.Drawing.Point(2, 35);
            treeNode1.Name = "节点0";
            treeNode1.Text = "节点0";
            treeNode2.Name = "节点1";
            treeNode2.Text = "节点1";
            treeNode3.Name = "节点2";
            treeNode3.Text = "节点2";
            treeNode4.Name = "节点3";
            treeNode4.Text = "节点3";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.Header.Size = new System.Drawing.Size(1020, 110);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主页ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(125, 68);
            // 
            // 主页ToolStripMenuItem
            // 
            this.主页ToolStripMenuItem.Name = "主页ToolStripMenuItem";
            this.主页ToolStripMenuItem.Size = new System.Drawing.Size(124, 32);
            this.主页ToolStripMenuItem.Text = "主页";
            this.主页ToolStripMenuItem.Click += new System.EventHandler(this.主页ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(124, 32);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click_1);
            // 
            // uiNavBar1
            // 
            this.uiNavBar1.BackColor = System.Drawing.Color.White;
            this.uiNavBar1.Controls.Add(this.pictureBox1);
            this.uiNavBar1.Controls.Add(this.uiNavBar2);
            this.uiNavBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiNavBar1.Location = new System.Drawing.Point(0, 0);
            this.uiNavBar1.MenuHoverColor = System.Drawing.Color.White;
            this.uiNavBar1.MenuSelectedColor = System.Drawing.Color.White;
            this.uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar1.Name = "uiNavBar1";
            this.uiNavBar1.Size = new System.Drawing.Size(1020, 110);
            this.uiNavBar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavBar1.TabIndex = 0;
            this.uiNavBar1.Text = "uiNavBar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BS_FS.Properties.Resources._94x94;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiNavBar2
            // 
            this.uiNavBar2.BackColor = System.Drawing.Color.White;
            this.uiNavBar2.Controls.Add(this.uiLabel1);
            this.uiNavBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiNavBar2.Location = new System.Drawing.Point(0, 0);
            this.uiNavBar2.MenuHoverColor = System.Drawing.Color.White;
            this.uiNavBar2.MenuSelectedColor = System.Drawing.Color.White;
            this.uiNavBar2.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar2.Name = "uiNavBar2";
            this.uiNavBar2.Size = new System.Drawing.Size(1020, 110);
            this.uiNavBar2.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavBar2.TabIndex = 1;
            this.uiNavBar2.Text = "uiNavBar2";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("杨任东竹石体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(113, 15);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(270, 82);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "考勤管理系统";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // Form_User_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_User_Main";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "Form_User_Main";
            this.Selecting += new Sunny.UI.UIMainFrame.OnSelecting(this.FMain_Selecting);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Header.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.uiNavBar1.ResumeLayout(false);
            this.uiNavBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiNavBar2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIStyleManager uiStyleManager1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UINavBar uiNavBar1;
        private System.Windows.Forms.ToolStripMenuItem 主页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UINavBar uiNavBar2;
        private Sunny.UI.UILabel uiLabel1;
    }
}