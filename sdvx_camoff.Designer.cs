namespace AreaTM_acbas
{
    partial class sdvx_camoff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sdvx_camoff));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_why = new System.Windows.Forms.Label();
            this.btn_off = new System.Windows.Forms.Button();
            this.btn_offon = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_name.Font = new System.Drawing.Font("카카오 Bold", 24F);
            this.lbl_name.Location = new System.Drawing.Point(0, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(640, 52);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "사운드볼텍스 캠 끄기 시스템 한시적 변경 안내";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbl_why
            // 
            this.lbl_why.Location = new System.Drawing.Point(8, 63);
            this.lbl_why.Name = "lbl_why";
            this.lbl_why.Size = new System.Drawing.Size(620, 195);
            this.lbl_why.TabIndex = 1;
            this.lbl_why.Text = resources.GetString("lbl_why.Text");
            // 
            // btn_off
            // 
            this.btn_off.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_off.FlatAppearance.BorderSize = 3;
            this.btn_off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_off.Location = new System.Drawing.Point(12, 264);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(117, 34);
            this.btn_off.TabIndex = 2;
            this.btn_off.Text = "12분간 캠 끄기";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // btn_offon
            // 
            this.btn_offon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_offon.FlatAppearance.BorderSize = 3;
            this.btn_offon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_offon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_offon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_offon.Location = new System.Drawing.Point(135, 264);
            this.btn_offon.Name = "btn_offon";
            this.btn_offon.Size = new System.Drawing.Size(98, 34);
            this.btn_offon.TabIndex = 3;
            this.btn_offon.Text = "캠이 안나옴";
            this.btn_offon.UseVisualStyleBackColor = true;
            this.btn_offon.Click += new System.EventHandler(this.btn_offon_Click);
            // 
            // btn_close
            // 
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_close.FlatAppearance.BorderSize = 3;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(372, 264);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(256, 34);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "창을 닫습니다";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sdvx_camoff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(640, 310);
            this.ControlBox = false;
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_offon);
            this.Controls.Add(this.btn_off);
            this.Controls.Add(this.lbl_why);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("카카오 Regular", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sdvx_camoff";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "캠 끄기 팝업창";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.howtochat_Load);
            this.Shown += new System.EventHandler(this.howtochat_activate);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_why;
        private System.Windows.Forms.Button btn_off;
        private System.Windows.Forms.Button btn_offon;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Timer timer1;
    }
}