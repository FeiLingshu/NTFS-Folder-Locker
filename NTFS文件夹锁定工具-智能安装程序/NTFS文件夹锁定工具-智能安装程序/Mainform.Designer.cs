namespace NTFS_Folder_Locker_Installer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label_state = new System.Windows.Forms.Label();
            this.button_version = new System.Windows.Forms.Button();
            this.groupbox_pginfo = new System.Windows.Forms.GroupBox();
            this.textbox_info = new System.Windows.Forms.TextBox();
            this.label_title = new System.Windows.Forms.Label();
            this.picturebox_icon = new System.Windows.Forms.PictureBox();
            this.groupbox_install = new System.Windows.Forms.GroupBox();
            this.label_path = new System.Windows.Forms.Label();
            this.button_setpath = new System.Windows.Forms.Button();
            this.button_install = new System.Windows.Forms.Button();
            this.groupbox_uninstall = new System.Windows.Forms.GroupBox();
            this.checkbox_delete = new System.Windows.Forms.CheckBox();
            this.button_uninstall = new System.Windows.Forms.Button();
            this.folder_picker = new System.Windows.Forms.FolderBrowserDialog();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupbox_pginfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_icon)).BeginInit();
            this.groupbox_install.SuspendLayout();
            this.groupbox_uninstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_state
            // 
            this.label_state.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_state.BackColor = System.Drawing.Color.Transparent;
            this.label_state.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_state.Location = new System.Drawing.Point(12, 9);
            this.label_state.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(395, 21);
            this.label_state.TabIndex = 0;
            this.label_state.Tag = "";
            this.label_state.Text = "StateTest";
            this.label_state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_version
            // 
            this.button_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_version.Location = new System.Drawing.Point(413, 8);
            this.button_version.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.button_version.Name = "button_version";
            this.button_version.Size = new System.Drawing.Size(95, 23);
            this.button_version.TabIndex = 0;
            this.button_version.TabStop = false;
            this.button_version.Text = "更新日志";
            this.button_version.UseVisualStyleBackColor = true;
            // 
            // groupbox_pginfo
            // 
            this.groupbox_pginfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_pginfo.BackColor = System.Drawing.Color.Transparent;
            this.groupbox_pginfo.Controls.Add(this.textbox_info);
            this.groupbox_pginfo.Controls.Add(this.label_title);
            this.groupbox_pginfo.Controls.Add(this.picturebox_icon);
            this.groupbox_pginfo.Location = new System.Drawing.Point(12, 36);
            this.groupbox_pginfo.Name = "groupbox_pginfo";
            this.groupbox_pginfo.Size = new System.Drawing.Size(343, 189);
            this.groupbox_pginfo.TabIndex = 0;
            this.groupbox_pginfo.TabStop = false;
            this.groupbox_pginfo.Text = "程序功能说明";
            // 
            // textbox_info
            // 
            this.textbox_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_info.BackColor = System.Drawing.Color.White;
            this.textbox_info.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textbox_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.textbox_info.Location = new System.Drawing.Point(6, 93);
            this.textbox_info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_info.Multiline = true;
            this.textbox_info.Name = "textbox_info";
            this.textbox_info.ReadOnly = true;
            this.textbox_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_info.Size = new System.Drawing.Size(331, 89);
            this.textbox_info.TabIndex = 0;
            this.textbox_info.TabStop = false;
            this.textbox_info.Text = "++ 程序基于MS .NET Framework 4.0 编写\r\n++ 程序利用Windows系统遗留特性实现文件夹锁定/解锁操作\r\n++ 程序未对任何实体文件进" +
    "行更改，不会泄漏任何文件内容，但同时也无法保证文件的绝对安全，请勿对任何重要文件进行锁定操作\r\n\r\n程序仅供学习使用，禁止用于商业用途\r\nBy FeiLings" +
    "hu";
            // 
            // label_title
            // 
            this.label_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.label_title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.Location = new System.Drawing.Point(76, 22);
            this.label_title.Margin = new System.Windows.Forms.Padding(3);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(261, 64);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "    欢迎使用\r\nNTFS文件夹锁定工具-智能安装程序";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picturebox_icon
            // 
            this.picturebox_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox_icon.ErrorImage = null;
            this.picturebox_icon.Image = global::NTFS_Folder_Locker_Installer.Properties.Resources.icon64;
            this.picturebox_icon.InitialImage = null;
            this.picturebox_icon.Location = new System.Drawing.Point(6, 22);
            this.picturebox_icon.Name = "picturebox_icon";
            this.picturebox_icon.Size = new System.Drawing.Size(64, 64);
            this.picturebox_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_icon.TabIndex = 0;
            this.picturebox_icon.TabStop = false;
            // 
            // groupbox_install
            // 
            this.groupbox_install.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_install.BackColor = System.Drawing.Color.Transparent;
            this.groupbox_install.Controls.Add(this.label_path);
            this.groupbox_install.Controls.Add(this.button_setpath);
            this.groupbox_install.Controls.Add(this.button_install);
            this.groupbox_install.Location = new System.Drawing.Point(361, 36);
            this.groupbox_install.Name = "groupbox_install";
            this.groupbox_install.Size = new System.Drawing.Size(147, 108);
            this.groupbox_install.TabIndex = 0;
            this.groupbox_install.TabStop = false;
            this.groupbox_install.Text = "智能安装";
            // 
            // label_path
            // 
            this.label_path.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_path.BackColor = System.Drawing.Color.Transparent;
            this.label_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.label_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_path.Location = new System.Drawing.Point(6, 51);
            this.label_path.Margin = new System.Windows.Forms.Padding(3);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(135, 22);
            this.label_path.TabIndex = 0;
            this.label_path.Text = "— 安装目录未识别 —";
            this.label_path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_setpath
            // 
            this.button_setpath.Location = new System.Drawing.Point(6, 22);
            this.button_setpath.Name = "button_setpath";
            this.button_setpath.Size = new System.Drawing.Size(95, 23);
            this.button_setpath.TabIndex = 0;
            this.button_setpath.TabStop = false;
            this.button_setpath.Text = "选择安装目录";
            this.button_setpath.UseVisualStyleBackColor = true;
            // 
            // button_install
            // 
            this.button_install.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(174)))), ((int)(((byte)(103)))));
            this.button_install.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_install.Location = new System.Drawing.Point(46, 79);
            this.button_install.Name = "button_install";
            this.button_install.Size = new System.Drawing.Size(95, 23);
            this.button_install.TabIndex = 0;
            this.button_install.TabStop = false;
            this.button_install.Text = "安 装";
            this.button_install.UseVisualStyleBackColor = false;
            // 
            // groupbox_uninstall
            // 
            this.groupbox_uninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_uninstall.BackColor = System.Drawing.Color.Transparent;
            this.groupbox_uninstall.Controls.Add(this.checkbox_delete);
            this.groupbox_uninstall.Controls.Add(this.button_uninstall);
            this.groupbox_uninstall.Location = new System.Drawing.Point(361, 150);
            this.groupbox_uninstall.Name = "groupbox_uninstall";
            this.groupbox_uninstall.Size = new System.Drawing.Size(147, 75);
            this.groupbox_uninstall.TabIndex = 0;
            this.groupbox_uninstall.TabStop = false;
            this.groupbox_uninstall.Text = "智能卸载";
            // 
            // checkbox_delete
            // 
            this.checkbox_delete.AutoSize = true;
            this.checkbox_delete.BackColor = System.Drawing.Color.Transparent;
            this.checkbox_delete.Checked = true;
            this.checkbox_delete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(174)))), ((int)(((byte)(103)))));
            this.checkbox_delete.Location = new System.Drawing.Point(6, 22);
            this.checkbox_delete.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.checkbox_delete.Name = "checkbox_delete";
            this.checkbox_delete.Size = new System.Drawing.Size(123, 21);
            this.checkbox_delete.TabIndex = 0;
            this.checkbox_delete.TabStop = false;
            this.checkbox_delete.Text = "卸载时移除主程序";
            this.checkbox_delete.UseVisualStyleBackColor = false;
            // 
            // button_uninstall
            // 
            this.button_uninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_uninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.button_uninstall.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_uninstall.Location = new System.Drawing.Point(46, 46);
            this.button_uninstall.Name = "button_uninstall";
            this.button_uninstall.Size = new System.Drawing.Size(95, 23);
            this.button_uninstall.TabIndex = 0;
            this.button_uninstall.TabStop = false;
            this.button_uninstall.Text = "卸 载";
            this.button_uninstall.UseVisualStyleBackColor = false;
            // 
            // folder_picker
            // 
            this.folder_picker.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 0;
            this.tooltip.AutoPopDelay = 30000;
            this.tooltip.InitialDelay = 500;
            this.tooltip.ReshowDelay = 100;
            this.tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.tooltip.ToolTipTitle = "错误信息提示：";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(520, 237);
            this.Controls.Add(this.groupbox_uninstall);
            this.Controls.Add(this.groupbox_install);
            this.Controls.Add(this.groupbox_pginfo);
            this.Controls.Add(this.button_version);
            this.Controls.Add(this.label_state);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NTFS文件夹锁定工具-智能安装程序";
            this.groupbox_pginfo.ResumeLayout(false);
            this.groupbox_pginfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_icon)).EndInit();
            this.groupbox_install.ResumeLayout(false);
            this.groupbox_uninstall.ResumeLayout(false);
            this.groupbox_uninstall.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Button button_version;
        private System.Windows.Forms.GroupBox groupbox_pginfo;
        private System.Windows.Forms.TextBox textbox_info;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.PictureBox picturebox_icon;
        private System.Windows.Forms.GroupBox groupbox_install;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_setpath;
        private System.Windows.Forms.Button button_install;
        private System.Windows.Forms.GroupBox groupbox_uninstall;
        private System.Windows.Forms.CheckBox checkbox_delete;
        private System.Windows.Forms.Button button_uninstall;
        private System.Windows.Forms.FolderBrowserDialog folder_picker;
        private System.Windows.Forms.ToolTip tooltip;
    }
}

