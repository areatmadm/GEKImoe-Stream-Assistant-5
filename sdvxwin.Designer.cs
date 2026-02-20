namespace AreaTM_acbas
{
    partial class sdvxwin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sdvxwin));
            this.FormsChange = new System.Windows.Forms.Button();
            this.rec_start = new System.Windows.Forms.Button();
            this.nolabel_0 = new System.Windows.Forms.Label();
            this.lbl_linkinfo = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.lbl_rectimer = new System.Windows.Forms.Label();
            this.timer_viewer = new System.Windows.Forms.Timer(this.components);
            this.rec_3mh = new System.Windows.Forms.Button();
            this.btn_more = new System.Windows.Forms.Button();
            this.openexplorer_rec = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sdvxpic = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_cardmove = new System.Windows.Forms.Button();
            this.btn_privacy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sdvxpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // FormsChange
            // 
            this.FormsChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FormsChange.FlatAppearance.BorderSize = 3;
            this.FormsChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormsChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FormsChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormsChange.Font = new System.Drawing.Font("나눔바른고딕OTF", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormsChange.Location = new System.Drawing.Point(12, 166);
            this.FormsChange.Name = "FormsChange";
            this.FormsChange.Size = new System.Drawing.Size(188, 42);
            this.FormsChange.TabIndex = 1;
            this.FormsChange.Text = "FOrmCHange";
            this.FormsChange.UseVisualStyleBackColor = true;
            this.FormsChange.EnabledChanged += new System.EventHandler(this.FormsChange_EnabledChanged);
            this.FormsChange.Click += new System.EventHandler(this.FormsChange_Click);
            // 
            // rec_start
            // 
            this.rec_start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rec_start.FlatAppearance.BorderSize = 3;
            this.rec_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rec_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rec_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rec_start.Font = new System.Drawing.Font("나눔바른고딕OTF", 15F, System.Drawing.FontStyle.Bold);
            this.rec_start.Location = new System.Drawing.Point(206, 166);
            this.rec_start.Name = "rec_start";
            this.rec_start.Size = new System.Drawing.Size(182, 42);
            this.rec_start.TabIndex = 2;
            this.rec_start.Text = "●";
            this.rec_start.UseVisualStyleBackColor = true;
            this.rec_start.EnabledChanged += new System.EventHandler(this.rec_start_EnabledChanged);
            this.rec_start.Click += new System.EventHandler(this.rec_start_Click);
            // 
            // nolabel_0
            // 
            this.nolabel_0.AutoSize = true;
            this.nolabel_0.BackColor = System.Drawing.Color.Transparent;
            this.nolabel_0.Location = new System.Drawing.Point(23, 369);
            this.nolabel_0.Name = "nolabel_0";
            this.nolabel_0.Size = new System.Drawing.Size(0, 14);
            this.nolabel_0.TabIndex = 4;
            // 
            // lbl_linkinfo
            // 
            this.lbl_linkinfo.Font = new System.Drawing.Font("나눔바른고딕OTF", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_linkinfo.Location = new System.Drawing.Point(0, 563);
            this.lbl_linkinfo.Name = "lbl_linkinfo";
            this.lbl_linkinfo.Size = new System.Drawing.Size(400, 30);
            this.lbl_linkinfo.TabIndex = 100;
            this.lbl_linkinfo.Text = "놀자오락실 공식 유튜브 생방송";
            this.lbl_linkinfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("나눔바른고딕OTF", 11F);
            this.lbl_version.Location = new System.Drawing.Point(12, 894);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(50, 17);
            this.lbl_version.TabIndex = 101;
            this.lbl_version.Text = "label1";
            // 
            // timer_rec
            // 
            this.timer_rec.Interval = 1000;
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            // 
            // lbl_rectimer
            // 
            this.lbl_rectimer.Font = new System.Drawing.Font("나눔바른고딕OTF", 11.25F);
            this.lbl_rectimer.Location = new System.Drawing.Point(12, 211);
            this.lbl_rectimer.Name = "lbl_rectimer";
            this.lbl_rectimer.Size = new System.Drawing.Size(376, 30);
            this.lbl_rectimer.TabIndex = 103;
            this.lbl_rectimer.Text = "TIMER LABEL";
            this.lbl_rectimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_viewer
            // 
            this.timer_viewer.Tick += new System.EventHandler(this.timer_viewer_Tick);
            // 
            // rec_3mh
            // 
            this.rec_3mh.Enabled = false;
            this.rec_3mh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rec_3mh.FlatAppearance.BorderSize = 3;
            this.rec_3mh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.rec_3mh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rec_3mh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rec_3mh.Font = new System.Drawing.Font("나눔바른고딕OTF", 14F, System.Drawing.FontStyle.Bold);
            this.rec_3mh.Location = new System.Drawing.Point(12, 244);
            this.rec_3mh.Name = "rec_3mh";
            this.rec_3mh.Size = new System.Drawing.Size(188, 42);
            this.rec_3mh.TabIndex = 4;
            this.rec_3mh.Text = "하이라이트 저장";
            this.rec_3mh.UseVisualStyleBackColor = true;
            this.rec_3mh.EnabledChanged += new System.EventHandler(this.rec_3mh_EnabledChanged);
            this.rec_3mh.Click += new System.EventHandler(this.setpersonalbroadcast_Click);
            // 
            // btn_more
            // 
            this.btn_more.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_more.FlatAppearance.BorderSize = 3;
            this.btn_more.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_more.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_more.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_more.Font = new System.Drawing.Font("나눔바른고딕OTF", 12F, System.Drawing.FontStyle.Bold);
            this.btn_more.Location = new System.Drawing.Point(323, 292);
            this.btn_more.Name = "btn_more";
            this.btn_more.Size = new System.Drawing.Size(65, 32);
            this.btn_more.TabIndex = 7;
            this.btn_more.Text = "더보기";
            this.btn_more.UseVisualStyleBackColor = true;
            this.btn_more.EnabledChanged += new System.EventHandler(this.btn_more_EnabledChanged);
            this.btn_more.Click += new System.EventHandler(this.btn_more_Click);
            // 
            // openexplorer_rec
            // 
            this.openexplorer_rec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.openexplorer_rec.FlatAppearance.BorderSize = 3;
            this.openexplorer_rec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.openexplorer_rec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.openexplorer_rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openexplorer_rec.Font = new System.Drawing.Font("나눔바른고딕OTF", 14F, System.Drawing.FontStyle.Bold);
            this.openexplorer_rec.Location = new System.Drawing.Point(206, 244);
            this.openexplorer_rec.Name = "openexplorer_rec";
            this.openexplorer_rec.Size = new System.Drawing.Size(182, 42);
            this.openexplorer_rec.TabIndex = 5;
            this.openexplorer_rec.Text = "파일 이동";
            this.openexplorer_rec.UseVisualStyleBackColor = true;
            this.openexplorer_rec.EnabledChanged += new System.EventHandler(this.openexplorer_rec_EnabledChanged);
            this.openexplorer_rec.Click += new System.EventHandler(this.openexplorer_rec_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AreaTM_acbas.Properties.Resources.frame;
            this.pictureBox1.Location = new System.Drawing.Point(70, 610);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // sdvxpic
            // 
            this.sdvxpic.Image = global::AreaTM_acbas.Properties.Resources.aast_f;
            this.sdvxpic.Location = new System.Drawing.Point(0, 0);
            this.sdvxpic.Name = "sdvxpic";
            this.sdvxpic.Size = new System.Drawing.Size(400, 160);
            this.sdvxpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sdvxpic.TabIndex = 0;
            this.sdvxpic.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(59, 598);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(269, 273);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 113;
            this.pictureBox2.TabStop = false;
            // 
            // btn_cardmove
            // 
            this.btn_cardmove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_cardmove.FlatAppearance.BorderSize = 3;
            this.btn_cardmove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_cardmove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_cardmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cardmove.Font = new System.Drawing.Font("나눔바른고딕OTF", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cardmove.Location = new System.Drawing.Point(12, 292);
            this.btn_cardmove.Name = "btn_cardmove";
            this.btn_cardmove.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_cardmove.Size = new System.Drawing.Size(154, 32);
            this.btn_cardmove.TabIndex = 6;
            this.btn_cardmove.Text = "게임카드 이전하기";
            this.btn_cardmove.UseVisualStyleBackColor = true;
            this.btn_cardmove.Click += new System.EventHandler(this.btn_cardmove_Click);
            // 
            // btn_privacy
            // 
            this.btn_privacy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_privacy.FlatAppearance.BorderSize = 3;
            this.btn_privacy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_privacy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_privacy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_privacy.Font = new System.Drawing.Font("나눔바른고딕OTF", 12F, System.Drawing.FontStyle.Bold);
            this.btn_privacy.Location = new System.Drawing.Point(172, 292);
            this.btn_privacy.Name = "btn_privacy";
            this.btn_privacy.Size = new System.Drawing.Size(145, 32);
            this.btn_privacy.TabIndex = 117;
            this.btn_privacy.Text = "프라이버시 모드";
            this.btn_privacy.UseVisualStyleBackColor = true;
            this.btn_privacy.Click += new System.EventHandler(this.btn_privacy_Click);
            // 
            // sdvxwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(400, 920);
            this.ControlBox = false;
            this.Controls.Add(this.btn_privacy);
            this.Controls.Add(this.btn_cardmove);
            this.Controls.Add(this.btn_more);
            this.Controls.Add(this.lbl_linkinfo);
            this.Controls.Add(this.rec_3mh);
            this.Controls.Add(this.lbl_rectimer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.nolabel_0);
            this.Controls.Add(this.openexplorer_rec);
            this.Controls.Add(this.rec_start);
            this.Controls.Add(this.FormsChange);
            this.Controls.Add(this.sdvxpic);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1520, 73);
            this.Name = "sdvxwin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "title";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sdvxwin_FormClosing);
            this.Load += new System.EventHandler(this.sdvxwin_Load);
            this.Shown += new System.EventHandler(this.sdvxwin_Activate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sdvxpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sdvxpic;
        private System.Windows.Forms.Button FormsChange;
        private System.Windows.Forms.Button rec_start;
        private System.Windows.Forms.Label nolabel_0;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_linkinfo;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.Label lbl_rectimer;
        private System.Windows.Forms.Timer timer_viewer;
        private System.Windows.Forms.Button rec_3mh;
        private System.Windows.Forms.Button btn_more;
        private System.Windows.Forms.Button openexplorer_rec;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_cardmove;
        private System.Windows.Forms.Button btn_privacy;
    }
}