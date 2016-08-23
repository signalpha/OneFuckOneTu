namespace BingWallpaper
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置图片为背景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片到目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示美图故事ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置图片为背景ToolStripMenuItem,
            this.保存图片到目录ToolStripMenuItem,
            this.显示美图故事ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 136);
            // 
            // 设置图片为背景ToolStripMenuItem
            // 
            this.设置图片为背景ToolStripMenuItem.Name = "设置图片为背景ToolStripMenuItem";
            this.设置图片为背景ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置图片为背景ToolStripMenuItem.Text = "设置图片为背景";
            this.设置图片为背景ToolStripMenuItem.Click += new System.EventHandler(this.设置图片为背景ToolStripMenuItem_Click);
            // 
            // 保存图片到目录ToolStripMenuItem
            // 
            this.保存图片到目录ToolStripMenuItem.Name = "保存图片到目录ToolStripMenuItem";
            this.保存图片到目录ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.保存图片到目录ToolStripMenuItem.Text = "保存图片到相册";
            this.保存图片到目录ToolStripMenuItem.Click += new System.EventHandler(this.保存图片到目录ToolStripMenuItem_Click);
            // 
            // 显示美图故事ToolStripMenuItem
            // 
            this.显示美图故事ToolStripMenuItem.Name = "显示美图故事ToolStripMenuItem";
            this.显示美图故事ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.显示美图故事ToolStripMenuItem.Text = "显示美图故事";
            this.显示美图故事ToolStripMenuItem.Click += new System.EventHandler(this.显示美图故事ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(880, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.BorderColor = System.Drawing.Color.Silver;
            this.skinPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 511);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(880, 29);
            this.skinPanel1.TabIndex = 2;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.skinLabel1.AutoEllipsis = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.skinLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skinLabel1.Location = new System.Drawing.Point(0, -1);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.skinLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinLabel1.Size = new System.Drawing.Size(878, 28);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = ".............................";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 540);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bing每日美图";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置图片为背景ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图片到目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.ToolStripMenuItem 显示美图故事ToolStripMenuItem;
    }
}

