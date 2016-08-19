namespace BingWallpaper
{
    partial class Form2
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
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.skinCheckBox1 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox2 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox3 = new CCWin.SkinControl.SkinCheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.skinTextBox1 = new CCWin.SkinControl.SkinTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.skinCheckBox4 = new CCWin.SkinControl.SkinCheckBox();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(12, 24);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(12, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = " ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // skinCheckBox1
            // 
            this.skinCheckBox1.AutoSize = true;
            this.skinCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox1.DownBack = null;
            this.skinCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox1.Location = new System.Drawing.Point(15, 98);
            this.skinCheckBox1.MouseBack = null;
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.NormlBack = null;
            this.skinCheckBox1.SelectedDownBack = null;
            this.skinCheckBox1.SelectedMouseBack = null;
            this.skinCheckBox1.SelectedNormlBack = null;
            this.skinCheckBox1.Size = new System.Drawing.Size(87, 21);
            this.skinCheckBox1.TabIndex = 4;
            this.skinCheckBox1.Text = "开机自启动";
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox2
            // 
            this.skinCheckBox2.AutoSize = true;
            this.skinCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox2.DownBack = null;
            this.skinCheckBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox2.Location = new System.Drawing.Point(15, 127);
            this.skinCheckBox2.MouseBack = null;
            this.skinCheckBox2.Name = "skinCheckBox2";
            this.skinCheckBox2.NormlBack = null;
            this.skinCheckBox2.SelectedDownBack = null;
            this.skinCheckBox2.SelectedMouseBack = null;
            this.skinCheckBox2.SelectedNormlBack = null;
            this.skinCheckBox2.Size = new System.Drawing.Size(135, 21);
            this.skinCheckBox2.TabIndex = 5;
            this.skinCheckBox2.Text = "自动保存浏览的图片";
            this.skinCheckBox2.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox3
            // 
            this.skinCheckBox3.AutoSize = true;
            this.skinCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox3.DownBack = null;
            this.skinCheckBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox3.Location = new System.Drawing.Point(15, 158);
            this.skinCheckBox3.MouseBack = null;
            this.skinCheckBox3.Name = "skinCheckBox3";
            this.skinCheckBox3.NormlBack = null;
            this.skinCheckBox3.SelectedDownBack = null;
            this.skinCheckBox3.SelectedMouseBack = null;
            this.skinCheckBox3.SelectedNormlBack = null;
            this.skinCheckBox3.Size = new System.Drawing.Size(135, 21);
            this.skinCheckBox3.TabIndex = 6;
            this.skinCheckBox3.Text = "更新壁纸后自动退出";
            this.skinCheckBox3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // skinTextBox1
            // 
            this.skinTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox1.DownBack = null;
            this.skinTextBox1.Icon = null;
            this.skinTextBox1.IconIsButton = false;
            this.skinTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.IsPasswordChat = '\0';
            this.skinTextBox1.IsSystemPasswordChar = false;
            this.skinTextBox1.Lines = new string[] {
        "skinTextBox1"};
            this.skinTextBox1.Location = new System.Drawing.Point(15, 48);
            this.skinTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox1.MaxLength = 32767;
            this.skinTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox1.MouseBack = null;
            this.skinTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Multiline = false;
            this.skinTextBox1.Name = "skinTextBox1";
            this.skinTextBox1.NormlBack = null;
            this.skinTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox1.ReadOnly = true;
            this.skinTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox1.Size = new System.Drawing.Size(355, 28);
            // 
            // 
            // 
            this.skinTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox1.SkinTxt.Name = "BaseText";
            this.skinTextBox1.SkinTxt.ReadOnly = true;
            this.skinTextBox1.SkinTxt.Size = new System.Drawing.Size(345, 18);
            this.skinTextBox1.SkinTxt.TabIndex = 0;
            this.skinTextBox1.SkinTxt.Text = "skinTextBox1";
            this.skinTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.SkinTxt.WaterText = "";
            this.skinTextBox1.TabIndex = 7;
            this.skinTextBox1.Text = "skinTextBox1";
            this.skinTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.WaterText = "";
            this.skinTextBox1.WordWrap = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(368, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "应用";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // skinCheckBox4
            // 
            this.skinCheckBox4.AutoSize = true;
            this.skinCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox4.DownBack = null;
            this.skinCheckBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox4.Location = new System.Drawing.Point(15, 189);
            this.skinCheckBox4.MouseBack = null;
            this.skinCheckBox4.Name = "skinCheckBox4";
            this.skinCheckBox4.NormlBack = null;
            this.skinCheckBox4.SelectedDownBack = null;
            this.skinCheckBox4.SelectedMouseBack = null;
            this.skinCheckBox4.SelectedNormlBack = null;
            this.skinCheckBox4.Size = new System.Drawing.Size(123, 21);
            this.skinCheckBox4.TabIndex = 9;
            this.skinCheckBox4.Text = "有新版本自动推送";
            this.skinCheckBox4.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 224);
            this.Controls.Add(this.skinCheckBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.skinTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.skinCheckBox3);
            this.Controls.Add(this.skinCheckBox2);
            this.Controls.Add(this.skinCheckBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.skinLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public CCWin.SkinControl.SkinCheckBox skinCheckBox1;
        public CCWin.SkinControl.SkinCheckBox skinCheckBox2;
        public CCWin.SkinControl.SkinCheckBox skinCheckBox3;
        private System.Windows.Forms.Button button2;
        public CCWin.SkinControl.SkinTextBox skinTextBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button3;
        public CCWin.SkinControl.SkinCheckBox skinCheckBox4;
    }
}