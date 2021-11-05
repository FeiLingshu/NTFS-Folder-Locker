namespace NTFS_Folder_Locker
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
            this.panel_title_detail = new System.Windows.Forms.Panel();
            this.label_path = new System.Windows.Forms.Label();
            this.label_break_01 = new System.Windows.Forms.Label();
            this.picturebox_closebutton = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.picturebox_icon = new System.Windows.Forms.PictureBox();
            this.label_detailinfo = new System.Windows.Forms.Label();
            this.label_detail_04 = new System.Windows.Forms.Label();
            this.label_detail_03 = new System.Windows.Forms.Label();
            this.label_detail_02 = new System.Windows.Forms.Label();
            this.label_detail_01 = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.panel_password = new System.Windows.Forms.Panel();
            this.checkbox_password = new System.Windows.Forms.CheckBox();
            this.label_password_tips = new System.Windows.Forms.Label();
            this.panel_copyright = new System.Windows.Forms.Panel();
            this.picturebox_copyright = new System.Windows.Forms.PictureBox();
            this.label_copyright = new System.Windows.Forms.Label();
            this.label_break_02 = new System.Windows.Forms.Label();
            this.label_readme = new System.Windows.Forms.Label();
            this.timer_password = new System.Windows.Forms.Timer(this.components);
            this.picturebox_password = new System.Windows.Forms.PictureBox();
            this.panel_title_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_closebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_icon)).BeginInit();
            this.panel_password.SuspendLayout();
            this.panel_copyright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_copyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_password)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_title_detail
            // 
            this.panel_title_detail.BackColor = System.Drawing.Color.Transparent;
            this.panel_title_detail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_title_detail.Controls.Add(this.label_path);
            this.panel_title_detail.Controls.Add(this.label_break_01);
            this.panel_title_detail.Controls.Add(this.picturebox_closebutton);
            this.panel_title_detail.Controls.Add(this.label_title);
            this.panel_title_detail.Controls.Add(this.picturebox_icon);
            this.panel_title_detail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title_detail.Location = new System.Drawing.Point(0, 0);
            this.panel_title_detail.Margin = new System.Windows.Forms.Padding(0);
            this.panel_title_detail.Name = "panel_title_detail";
            this.panel_title_detail.Padding = new System.Windows.Forms.Padding(6);
            this.panel_title_detail.Size = new System.Drawing.Size(300, 73);
            this.panel_title_detail.TabIndex = 0;
            // 
            // label_path
            // 
            this.label_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(112)))));
            this.label_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_path.Location = new System.Drawing.Point(9, 43);
            this.label_path.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(282, 20);
            this.label_path.TabIndex = 0;
            this.label_path.Tag = "路径：未获取到合法路径 ...";
            this.label_path.Text = "路径：未获取到合法路径 ...";
            this.label_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_break_01
            // 
            this.label_break_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_break_01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_break_01.Location = new System.Drawing.Point(5, 69);
            this.label_break_01.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.label_break_01.Name = "label_break_01";
            this.label_break_01.Size = new System.Drawing.Size(290, 2);
            this.label_break_01.TabIndex = 0;
            // 
            // picturebox_closebutton
            // 
            this.picturebox_closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebox_closebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.picturebox_closebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox_closebutton.ErrorImage = null;
            this.picturebox_closebutton.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_closebutton.Image")));
            this.picturebox_closebutton.InitialImage = null;
            this.picturebox_closebutton.Location = new System.Drawing.Point(243, 17);
            this.picturebox_closebutton.Margin = new System.Windows.Forms.Padding(0);
            this.picturebox_closebutton.Name = "picturebox_closebutton";
            this.picturebox_closebutton.Size = new System.Drawing.Size(48, 24);
            this.picturebox_closebutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_closebutton.TabIndex = 1;
            this.picturebox_closebutton.TabStop = false;
            // 
            // label_title
            // 
            this.label_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(112)))));
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_title.Location = new System.Drawing.Point(47, 17);
            this.label_title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_title.Name = "label_title";
            this.label_title.Padding = new System.Windows.Forms.Padding(4);
            this.label_title.Size = new System.Drawing.Size(190, 24);
            this.label_title.TabIndex = 0;
            this.label_title.Tag = "NTFS文件夹锁定工具";
            this.label_title.Text = "NTFS文件夹锁定工具";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picturebox_icon
            // 
            this.picturebox_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(112)))));
            this.picturebox_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox_icon.ErrorImage = null;
            this.picturebox_icon.Image = global::NTFS_Folder_Locker.Properties.Resources.icon32;
            this.picturebox_icon.InitialImage = null;
            this.picturebox_icon.Location = new System.Drawing.Point(9, 9);
            this.picturebox_icon.Margin = new System.Windows.Forms.Padding(0);
            this.picturebox_icon.Name = "picturebox_icon";
            this.picturebox_icon.Size = new System.Drawing.Size(32, 32);
            this.picturebox_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_icon.TabIndex = 0;
            this.picturebox_icon.TabStop = false;
            // 
            // label_detailinfo
            // 
            this.label_detailinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detailinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label_detailinfo.Location = new System.Drawing.Point(9, 186);
            this.label_detailinfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.label_detailinfo.Name = "label_detailinfo";
            this.label_detailinfo.Padding = new System.Windows.Forms.Padding(2);
            this.label_detailinfo.Size = new System.Drawing.Size(282, 62);
            this.label_detailinfo.TabIndex = 0;
            this.label_detailinfo.Text = "日志信息：\r\n—— Code_0b0000\r\n—— 暂无错误信息...";
            // 
            // label_detail_04
            // 
            this.label_detail_04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detail_04.Location = new System.Drawing.Point(9, 157);
            this.label_detail_04.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label_detail_04.Name = "label_detail_04";
            this.label_detail_04.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_detail_04.Size = new System.Drawing.Size(282, 20);
            this.label_detail_04.TabIndex = 0;
            this.label_detail_04.Text = "自动操作信息：未知";
            this.label_detail_04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_detail_03
            // 
            this.label_detail_03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detail_03.Location = new System.Drawing.Point(9, 131);
            this.label_detail_03.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label_detail_03.Name = "label_detail_03";
            this.label_detail_03.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_detail_03.Size = new System.Drawing.Size(282, 20);
            this.label_detail_03.TabIndex = 0;
            this.label_detail_03.Text = "密钥匹配：未知";
            this.label_detail_03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_detail_02
            // 
            this.label_detail_02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detail_02.Location = new System.Drawing.Point(9, 105);
            this.label_detail_02.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label_detail_02.Name = "label_detail_02";
            this.label_detail_02.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_detail_02.Size = new System.Drawing.Size(282, 20);
            this.label_detail_02.TabIndex = 0;
            this.label_detail_02.Text = "目标状态：未知";
            this.label_detail_02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_detail_01
            // 
            this.label_detail_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detail_01.Location = new System.Drawing.Point(9, 79);
            this.label_detail_01.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label_detail_01.Name = "label_detail_01";
            this.label_detail_01.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_detail_01.Size = new System.Drawing.Size(282, 20);
            this.label_detail_01.TabIndex = 0;
            this.label_detail_01.Text = "路径合法性检查：未知";
            this.label_detail_01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textbox_password
            // 
            this.textbox_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_password.Location = new System.Drawing.Point(3, 3);
            this.textbox_password.MaxLength = 32;
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '█';
            this.textbox_password.ShortcutsEnabled = false;
            this.textbox_password.Size = new System.Drawing.Size(238, 16);
            this.textbox_password.TabIndex = 0;
            this.textbox_password.TabStop = false;
            this.textbox_password.Tag = "";
            this.textbox_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_password
            // 
            this.panel_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.panel_password.Controls.Add(this.checkbox_password);
            this.panel_password.Controls.Add(this.label_password_tips);
            this.panel_password.Controls.Add(this.textbox_password);
            this.panel_password.Enabled = false;
            this.panel_password.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.panel_password.ForeColor = System.Drawing.Color.DarkGray;
            this.panel_password.Location = new System.Drawing.Point(9, 258);
            this.panel_password.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel_password.Name = "panel_password";
            this.panel_password.Size = new System.Drawing.Size(244, 43);
            this.panel_password.TabIndex = 0;
            // 
            // checkbox_password
            // 
            this.checkbox_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbox_password.BackColor = System.Drawing.Color.Transparent;
            this.checkbox_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkbox_password.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.checkbox_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.checkbox_password.Location = new System.Drawing.Point(66, 22);
            this.checkbox_password.Margin = new System.Windows.Forms.Padding(66, 0, 66, 0);
            this.checkbox_password.Name = "checkbox_password";
            this.checkbox_password.Padding = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.checkbox_password.Size = new System.Drawing.Size(112, 21);
            this.checkbox_password.TabIndex = 0;
            this.checkbox_password.TabStop = false;
            this.checkbox_password.Tag = "显示密钥明文...";
            this.checkbox_password.Text = "显示密钥明文...";
            this.checkbox_password.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkbox_password.ThreeState = true;
            this.checkbox_password.UseVisualStyleBackColor = false;
            // 
            // label_password_tips
            // 
            this.label_password_tips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_password_tips.BackColor = System.Drawing.Color.Transparent;
            this.label_password_tips.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_password_tips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label_password_tips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_password_tips.Location = new System.Drawing.Point(3, 3);
            this.label_password_tips.Margin = new System.Windows.Forms.Padding(3);
            this.label_password_tips.Name = "label_password_tips";
            this.label_password_tips.Size = new System.Drawing.Size(238, 17);
            this.label_password_tips.TabIndex = 0;
            this.label_password_tips.Tag = "输入32位以内的密钥";
            this.label_password_tips.Text = "输入32位以内的密钥";
            this.label_password_tips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_copyright
            // 
            this.panel_copyright.BackColor = System.Drawing.Color.Transparent;
            this.panel_copyright.Controls.Add(this.picturebox_copyright);
            this.panel_copyright.Controls.Add(this.label_copyright);
            this.panel_copyright.Controls.Add(this.label_break_02);
            this.panel_copyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_copyright.Location = new System.Drawing.Point(0, 443);
            this.panel_copyright.Margin = new System.Windows.Forms.Padding(0);
            this.panel_copyright.Name = "panel_copyright";
            this.panel_copyright.Padding = new System.Windows.Forms.Padding(6);
            this.panel_copyright.Size = new System.Drawing.Size(300, 43);
            this.panel_copyright.TabIndex = 0;
            // 
            // picturebox_copyright
            // 
            this.picturebox_copyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(112)))));
            this.picturebox_copyright.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox_copyright.ErrorImage = null;
            this.picturebox_copyright.Image = global::NTFS_Folder_Locker.Properties.Resources.copyright;
            this.picturebox_copyright.InitialImage = null;
            this.picturebox_copyright.Location = new System.Drawing.Point(9, 17);
            this.picturebox_copyright.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.picturebox_copyright.Name = "picturebox_copyright";
            this.picturebox_copyright.Size = new System.Drawing.Size(20, 20);
            this.picturebox_copyright.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_copyright.TabIndex = 1;
            this.picturebox_copyright.TabStop = false;
            // 
            // label_copyright
            // 
            this.label_copyright.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_copyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(112)))));
            this.label_copyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_copyright.Location = new System.Drawing.Point(35, 17);
            this.label_copyright.Margin = new System.Windows.Forms.Padding(0);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Size = new System.Drawing.Size(256, 20);
            this.label_copyright.TabIndex = 0;
            this.label_copyright.Tag = "Copyright 2021 By FeiLingshu ...";
            this.label_copyright.Text = "Copyright 2021 By FeiLingshu ...";
            this.label_copyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_break_02
            // 
            this.label_break_02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_break_02.BackColor = System.Drawing.Color.Transparent;
            this.label_break_02.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.label_break_02.Location = new System.Drawing.Point(5, 9);
            this.label_break_02.Margin = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.label_break_02.Name = "label_break_02";
            this.label_break_02.Size = new System.Drawing.Size(290, 2);
            this.label_break_02.TabIndex = 0;
            // 
            // label_readme
            // 
            this.label_readme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_readme.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_readme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.label_readme.Location = new System.Drawing.Point(9, 310);
            this.label_readme.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.label_readme.Name = "label_readme";
            this.label_readme.Size = new System.Drawing.Size(282, 133);
            this.label_readme.TabIndex = 0;
            this.label_readme.Text = "++ 程序基于MS .NET Framework 4.0 编写\r\n++ 程序利用Windows系统遗留特性实现文件夹锁定/解锁操作\r\n++ 程序未对任何实体文件进" +
    "行更改，不会泄漏任何文件内容，但同时也无法保证文件的绝对安全，请勿对任何重要文件进行锁定操作";
            this.label_readme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer_password
            // 
            this.timer_password.Interval = 600;
            // 
            // picturebox_password
            // 
            this.picturebox_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebox_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.picturebox_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox_password.Enabled = false;
            this.picturebox_password.ErrorImage = null;
            this.picturebox_password.Image = global::NTFS_Folder_Locker.Properties.Resources.password;
            this.picturebox_password.InitialImage = null;
            this.picturebox_password.Location = new System.Drawing.Point(259, 258);
            this.picturebox_password.Margin = new System.Windows.Forms.Padding(6, 5, 0, 0);
            this.picturebox_password.Name = "picturebox_password";
            this.picturebox_password.Size = new System.Drawing.Size(32, 43);
            this.picturebox_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_password.TabIndex = 2;
            this.picturebox_password.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(300, 486);
            this.Controls.Add(this.label_detail_02);
            this.Controls.Add(this.label_detail_01);
            this.Controls.Add(this.label_detail_03);
            this.Controls.Add(this.label_detail_04);
            this.Controls.Add(this.label_detailinfo);
            this.Controls.Add(this.panel_password);
            this.Controls.Add(this.label_readme);
            this.Controls.Add(this.picturebox_password);
            this.Controls.Add(this.panel_copyright);
            this.Controls.Add(this.panel_title_detail);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NTFS文件夹锁定工具";
            this.TopMost = true;
            this.panel_title_detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_closebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_icon)).EndInit();
            this.panel_password.ResumeLayout(false);
            this.panel_password.PerformLayout();
            this.panel_copyright.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_copyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_password)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_title_detail;
        private System.Windows.Forms.PictureBox picturebox_icon;
        private System.Windows.Forms.PictureBox picturebox_closebutton;
        private System.Windows.Forms.Label label_break_01;
        private System.Windows.Forms.Label label_detail_01;
        private System.Windows.Forms.Label label_detailinfo;
        private System.Windows.Forms.Label label_detail_04;
        private System.Windows.Forms.Label label_detail_03;
        private System.Windows.Forms.Label label_detail_02;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Panel panel_password;
        private System.Windows.Forms.PictureBox picturebox_password;
        private System.Windows.Forms.Panel panel_copyright;
        private System.Windows.Forms.Label label_copyright;
        private System.Windows.Forms.Label label_break_02;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_password_tips;
        private System.Windows.Forms.CheckBox checkbox_password;
        private System.Windows.Forms.PictureBox picturebox_copyright;
        internal System.Windows.Forms.Label label_readme;
        private System.Windows.Forms.Timer timer_password;
    }
}

