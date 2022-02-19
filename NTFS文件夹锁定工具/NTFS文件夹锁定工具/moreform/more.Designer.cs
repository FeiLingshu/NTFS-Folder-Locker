
namespace NTFS_Folder_Locker.moreform
{
    partial class more
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(more));
            this.label_title = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancle = new System.Windows.Forms.Button();
            this.treeview_list = new System.Windows.Forms.TreeView();
            this.menu_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.folderbrowserdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_info3 = new System.Windows.Forms.Label();
            this.label_info2 = new System.Windows.Forms.Label();
            this.label_info1 = new System.Windows.Forms.Label();
            this.label_infoF = new System.Windows.Forms.Label();
            this.label_info0 = new System.Windows.Forms.Label();
            this.menuitem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Margin = new System.Windows.Forms.Padding(0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(280, 24);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "◪  选 择 目 标  ◪";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.button_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.button_ok.FlatAppearance.BorderSize = 0;
            this.button_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(174)))), ((int)(((byte)(103)))));
            this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(174)))), ((int)(((byte)(103)))));
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_ok.Location = new System.Drawing.Point(0, 376);
            this.button_ok.Margin = new System.Windows.Forms.Padding(0);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(280, 24);
            this.button_ok.TabIndex = 0;
            this.button_ok.TabStop = false;
            this.button_ok.Text = "◪  确 认  ◪";
            this.button_ok.UseCompatibleTextRendering = true;
            this.button_ok.UseVisualStyleBackColor = false;
            // 
            // button_cancle
            // 
            this.button_cancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_cancle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_cancle.FlatAppearance.BorderSize = 0;
            this.button_cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.button_cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.button_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_cancle.Location = new System.Drawing.Point(0, 352);
            this.button_cancle.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.button_cancle.Name = "button_cancle";
            this.button_cancle.Size = new System.Drawing.Size(280, 24);
            this.button_cancle.TabIndex = 1;
            this.button_cancle.TabStop = false;
            this.button_cancle.Text = "◪  取 消  ◪";
            this.button_cancle.UseCompatibleTextRendering = true;
            this.button_cancle.UseVisualStyleBackColor = false;
            // 
            // treeview_list
            // 
            this.treeview_list.AllowDrop = true;
            this.treeview_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeview_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.treeview_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeview_list.ContextMenuStrip = this.menu_list;
            this.treeview_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.treeview_list.FullRowSelect = true;
            this.treeview_list.ImageIndex = 0;
            this.treeview_list.ImageList = this.imagelist;
            this.treeview_list.ItemHeight = 21;
            this.treeview_list.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.treeview_list.Location = new System.Drawing.Point(12, 36);
            this.treeview_list.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.treeview_list.Name = "treeview_list";
            this.treeview_list.Scrollable = false;
            this.treeview_list.SelectedImageIndex = 0;
            this.treeview_list.ShowLines = false;
            this.treeview_list.ShowNodeToolTips = true;
            this.treeview_list.ShowPlusMinus = false;
            this.treeview_list.ShowRootLines = false;
            this.treeview_list.Size = new System.Drawing.Size(256, 188);
            this.treeview_list.TabIndex = 0;
            this.treeview_list.TabStop = false;
            // 
            // menu_list
            // 
            this.menu_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menu_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu_list.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menu_list.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.menu_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitem1,
            this.menuitem2,
            this.menuitem3});
            this.menu_list.Name = "menu_list";
            this.menu_list.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu_list.ShowItemToolTips = false;
            this.menu_list.Size = new System.Drawing.Size(206, 70);
            // 
            // imagelist
            // 
            this.imagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist.ImageStream")));
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist.Images.SetKeyName(0, "logomini.png");
            // 
            // folderbrowserdialog
            // 
            this.folderbrowserdialog.Description = "选择要添加的文件夹\\n不要选择除桌面以外的系统盘文件夹 和 包含软件安装目录的文件夹";
            this.folderbrowserdialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderbrowserdialog.ShowNewFolderButton = false;
            // 
            // label_info3
            // 
            this.label_info3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.label_info3.Location = new System.Drawing.Point(12, 324);
            this.label_info3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_info3.Name = "label_info3";
            this.label_info3.Size = new System.Drawing.Size(256, 19);
            this.label_info3.TabIndex = 2;
            this.label_info3.Text = "红色 —— 路径不合法";
            this.label_info3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_info2
            // 
            this.label_info2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.label_info2.Location = new System.Drawing.Point(12, 302);
            this.label_info2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_info2.Name = "label_info2";
            this.label_info2.Size = new System.Drawing.Size(256, 19);
            this.label_info2.TabIndex = 3;
            this.label_info2.Text = "蓝色 —— 路径未锁定";
            this.label_info2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_info1
            // 
            this.label_info1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(174)))), ((int)(((byte)(103)))));
            this.label_info1.Location = new System.Drawing.Point(12, 280);
            this.label_info1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_info1.Name = "label_info1";
            this.label_info1.Size = new System.Drawing.Size(256, 19);
            this.label_info1.TabIndex = 4;
            this.label_info1.Text = "绿色 —— 路径已锁定";
            this.label_info1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_infoF
            // 
            this.label_infoF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_infoF.ForeColor = System.Drawing.Color.Gray;
            this.label_infoF.Location = new System.Drawing.Point(12, 258);
            this.label_infoF.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_infoF.Name = "label_infoF";
            this.label_infoF.Size = new System.Drawing.Size(256, 19);
            this.label_infoF.TabIndex = 5;
            this.label_infoF.Text = "————————————————";
            this.label_infoF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_info0
            // 
            this.label_info0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_info0.Location = new System.Drawing.Point(12, 236);
            this.label_info0.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_info0.Name = "label_info0";
            this.label_info0.Size = new System.Drawing.Size(256, 19);
            this.label_info0.TabIndex = 6;
            this.label_info0.Text = "最多同时设置6个目标文件夹";
            this.label_info0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuitem1
            // 
            this.menuitem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.menuitem1.Image = global::NTFS_Folder_Locker.Properties.Resources.add;
            this.menuitem1.Name = "menuitem1";
            this.menuitem1.Size = new System.Drawing.Size(205, 22);
            this.menuitem1.Text = "添加目标文件夹...";
            // 
            // menuitem2
            // 
            this.menuitem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.menuitem2.Image = global::NTFS_Folder_Locker.Properties.Resources.del;
            this.menuitem2.Name = "menuitem2";
            this.menuitem2.Size = new System.Drawing.Size(205, 22);
            this.menuitem2.Text = "移除目标文件夹...";
            // 
            // menuitem3
            // 
            this.menuitem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.menuitem3.Image = global::NTFS_Folder_Locker.Properties.Resources.clear;
            this.menuitem3.Name = "menuitem3";
            this.menuitem3.Size = new System.Drawing.Size(205, 22);
            this.menuitem3.Text = "即时清除所有历史记录...";
            // 
            // more
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button_cancle;
            this.ClientSize = new System.Drawing.Size(280, 400);
            this.Controls.Add(this.label_info0);
            this.Controls.Add(this.label_infoF);
            this.Controls.Add(this.label_info1);
            this.Controls.Add(this.label_info2);
            this.Controls.Add(this.label_info3);
            this.Controls.Add(this.treeview_list);
            this.Controls.Add(this.button_cancle);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "more";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.menu_list.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        internal System.Windows.Forms.Button button_ok;
        internal System.Windows.Forms.Button button_cancle;
        private System.Windows.Forms.TreeView treeview_list;
        private System.Windows.Forms.ContextMenuStrip menu_list;
        private System.Windows.Forms.ToolStripMenuItem menuitem1;
        private System.Windows.Forms.ToolStripMenuItem menuitem2;
        private System.Windows.Forms.FolderBrowserDialog folderbrowserdialog;
        private System.Windows.Forms.ImageList imagelist;
        private System.Windows.Forms.Label label_info3;
        private System.Windows.Forms.Label label_info2;
        private System.Windows.Forms.Label label_info1;
        private System.Windows.Forms.Label label_infoF;
        private System.Windows.Forms.Label label_info0;
        private System.Windows.Forms.ToolStripMenuItem menuitem3;
    }
}