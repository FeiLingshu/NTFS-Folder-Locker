
namespace NTFS_Folder_Locker_HotfixTool
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
            this.label_info = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Location = new System.Drawing.Point(12, 12);
            this.label_info.Margin = new System.Windows.Forms.Padding(3);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(416, 84);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "NTFS文件夹锁定工具-热修补(Hotfix)工具，已准备就绪！\r\n";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_state
            // 
            this.label_state.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_state.BackColor = System.Drawing.Color.Transparent;
            this.label_state.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label_state.Location = new System.Drawing.Point(12, 102);
            this.label_state.Margin = new System.Windows.Forms.Padding(3);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(214, 23);
            this.label_state.TabIndex = 2;
            this.label_state.Text = "— 准备就绪，请选择指定操作 —";
            this.label_state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_ok.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_ok.Location = new System.Drawing.Point(232, 102);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(95, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.TabStop = false;
            this.button_ok.Text = "— 是 —";
            this.button_ok.UseVisualStyleBackColor = false;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.BackColor = System.Drawing.Color.Tomato;
            this.button_cancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_cancel.Location = new System.Drawing.Point(333, 102);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(95, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.TabStop = false;
            this.button_cancel.Text = "— 否 —";
            this.button_cancel.UseVisualStyleBackColor = false;
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 0;
            this.tooltip.AutoPopDelay = 30000;
            this.tooltip.InitialDelay = 500;
            this.tooltip.ReshowDelay = 100;
            this.tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.tooltip.ToolTipTitle = "错误信息：";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(440, 137);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label_info);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotfixTool";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ToolTip tooltip;
    }
}

