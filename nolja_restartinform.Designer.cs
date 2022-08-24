namespace AreaTM_acbas
{
    partial class nolja_restartinform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nolja_restartinform));
            this.lbl_blank_0 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_resettime = new System.Windows.Forms.Button();
            this.browserarea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_blank_0
            // 
            this.lbl_blank_0.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_blank_0.Location = new System.Drawing.Point(0, 0);
            this.lbl_blank_0.Name = "lbl_blank_0";
            this.lbl_blank_0.Size = new System.Drawing.Size(545, 16);
            this.lbl_blank_0.TabIndex = 0;
            this.lbl_blank_0.Text = " ";
            // 
            // lbl_name
            // 
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_name.Font = new System.Drawing.Font("카카오 Bold", 25F);
            this.lbl_name.Location = new System.Drawing.Point(0, 16);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(545, 44);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "프로그램 업데이트 준비 완료";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_update
            // 
            this.btn_update.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(255)))), ((int)(((byte)(158)))));
            this.btn_update.FlatAppearance.BorderSize = 3;
            this.btn_update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(215)))), ((int)(((byte)(108)))));
            this.btn_update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))), ((int)(((byte)(158)))));
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("카카오 Bold", 18F);
            this.btn_update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_update.Location = new System.Drawing.Point(12, 344);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(301, 43);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "지금 업데이트하기";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbl_timer
            // 
            this.lbl_timer.Location = new System.Drawing.Point(12, 60);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(521, 56);
            this.lbl_timer.TabIndex = 3;
            this.lbl_timer.Text = "5분 0초 이후 프로그램 업데이트를 진행합니다.\r\n업데이트 중에는 프로그램 사용이 불가합니다.";
            this.lbl_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_resettime
            // 
            this.btn_resettime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_resettime.FlatAppearance.BorderSize = 3;
            this.btn_resettime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(100)))), ((int)(((byte)(192)))));
            this.btn_resettime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btn_resettime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resettime.Font = new System.Drawing.Font("카카오 Bold", 18F);
            this.btn_resettime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_resettime.Location = new System.Drawing.Point(319, 344);
            this.btn_resettime.Name = "btn_resettime";
            this.btn_resettime.Size = new System.Drawing.Size(214, 43);
            this.btn_resettime.TabIndex = 4;
            this.btn_resettime.Text = "시간 연장";
            this.btn_resettime.UseVisualStyleBackColor = true;
            this.btn_resettime.Click += new System.EventHandler(this.btn_resettime_Click);
            // 
            // browserarea
            // 
            this.browserarea.Location = new System.Drawing.Point(12, 127);
            this.browserarea.Name = "browserarea";
            this.browserarea.Size = new System.Drawing.Size(521, 207);
            this.browserarea.TabIndex = 5;
            this.browserarea.Text = "BROWSERAREA";
            this.browserarea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nolja_restartinform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(545, 399);
            this.ControlBox = false;
            this.Controls.Add(this.browserarea);
            this.Controls.Add(this.btn_resettime);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_blank_0);
            this.Font = new System.Drawing.Font("카카오 Regular", 15F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nolja_restartinform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "업데이트 알리미";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.nolja_restartinform_FormClosing);
            this.Load += new System.EventHandler(this.nolja_restartinform_Load);
            this.Shown += new System.EventHandler(this.nolja_restartinform_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_blank_0;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_resettime;
        private System.Windows.Forms.Label browserarea;
    }
}