namespace NTFS_Folder_Locker.reportform
{
    partial class report
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
            this.label_title = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_detail = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.picturebox_tips = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_tips)).BeginInit();
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
            this.label_title.Text = "◪  操 作 提 示  ◪";
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
            this.button_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(169)))));
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_ok.Location = new System.Drawing.Point(0, 116);
            this.button_ok.Margin = new System.Windows.Forms.Padding(0);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(280, 24);
            this.button_ok.TabIndex = 0;
            this.button_ok.TabStop = false;
            this.button_ok.Text = "◪  确 认  ◪";
            this.button_ok.UseCompatibleTextRendering = true;
            this.button_ok.UseVisualStyleBackColor = false;
            // 
            // label_detail
            // 
            this.label_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_detail.Location = new System.Drawing.Point(9, 30);
            this.label_detail.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.label_detail.Name = "label_detail";
            this.label_detail.Size = new System.Drawing.Size(262, 80);
            this.label_detail.TabIndex = 0;
            this.label_detail.Text = "state string";
            this.label_detail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 0;
            this.tooltip.AutoPopDelay = 5000;
            this.tooltip.InitialDelay = 500;
            this.tooltip.IsBalloon = true;
            this.tooltip.ReshowDelay = 500;
            this.tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tooltip.ToolTipTitle = "发生错误的目标列表：";
            // 
            // picturebox_tips
            // 
            this.picturebox_tips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebox_tips.ErrorImage = null;
            this.picturebox_tips.Image = global::NTFS_Folder_Locker.Properties.Resources.tips;
            this.picturebox_tips.InitialImage = null;
            this.picturebox_tips.Location = new System.Drawing.Point(247, 30);
            this.picturebox_tips.Name = "picturebox_tips";
            this.picturebox_tips.Size = new System.Drawing.Size(24, 24);
            this.picturebox_tips.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_tips.TabIndex = 1;
            this.picturebox_tips.TabStop = false;
            // 
            // report
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button_ok;
            this.ClientSize = new System.Drawing.Size(280, 140);
            this.Controls.Add(this.picturebox_tips);
            this.Controls.Add(this.label_detail);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_tips)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        internal System.Windows.Forms.Label label_detail;
        internal System.Windows.Forms.Button button_ok;
        internal System.Windows.Forms.ToolTip tooltip;
        internal System.Windows.Forms.PictureBox picturebox_tips;
    }
}