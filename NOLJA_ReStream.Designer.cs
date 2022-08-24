namespace AreaTM_acbas
{
    partial class NOLJA_ReStream
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NOLJA_ReStream));
            this.lbl_information = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.btn_goReStream = new System.Windows.Forms.Button();
            this.btn_seelate = new System.Windows.Forms.Button();
            this.lbl_restartInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_information
            // 
            this.lbl_information.Font = new System.Drawing.Font("카카오 Bold", 30F);
            this.lbl_information.Location = new System.Drawing.Point(13, 13);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(775, 50);
            this.lbl_information.TabIndex = 0;
            this.lbl_information.Text = "스트리밍 중지 후 재시작 안내";
            this.lbl_information.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_info
            // 
            this.lbl_info.Location = new System.Drawing.Point(13, 67);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(775, 168);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = resources.GetString("lbl_info.Text");
            // 
            // btn_goReStream
            // 
            this.btn_goReStream.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_goReStream.FlatAppearance.BorderSize = 3;
            this.btn_goReStream.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_goReStream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_goReStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_goReStream.Font = new System.Drawing.Font("카카오 Bold", 18F);
            this.btn_goReStream.Location = new System.Drawing.Point(12, 287);
            this.btn_goReStream.Name = "btn_goReStream";
            this.btn_goReStream.Size = new System.Drawing.Size(452, 48);
            this.btn_goReStream.TabIndex = 2;
            this.btn_goReStream.Text = "지금 스트리밍을 재시작 하겠습니다(권장)";
            this.btn_goReStream.UseVisualStyleBackColor = true;
            this.btn_goReStream.Click += new System.EventHandler(this.btn_goReStream_Click);
            // 
            // btn_seelate
            // 
            this.btn_seelate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_seelate.FlatAppearance.BorderSize = 3;
            this.btn_seelate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_seelate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_seelate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seelate.Font = new System.Drawing.Font("카카오 Bold", 18F);
            this.btn_seelate.Location = new System.Drawing.Point(470, 287);
            this.btn_seelate.Name = "btn_seelate";
            this.btn_seelate.Size = new System.Drawing.Size(318, 48);
            this.btn_seelate.TabIndex = 3;
            this.btn_seelate.Text = "나중에 재시작 하겠습니다";
            this.btn_seelate.UseVisualStyleBackColor = true;
            this.btn_seelate.Click += new System.EventHandler(this.btn_seelate_Click);
            // 
            // lbl_restartInfo
            // 
            this.lbl_restartInfo.AutoSize = true;
            this.lbl_restartInfo.Font = new System.Drawing.Font("카카오 Bold", 18F);
            this.lbl_restartInfo.Location = new System.Drawing.Point(17, 235);
            this.lbl_restartInfo.Name = "lbl_restartInfo";
            this.lbl_restartInfo.Size = new System.Drawing.Size(398, 27);
            this.lbl_restartInfo.TabIndex = 4;
            this.lbl_restartInfo.Text = "{N}분 {N}초 이후 자동으로 재시작 됩니다.";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NOLJA_ReStream
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 347);
            this.Controls.Add(this.lbl_restartInfo);
            this.Controls.Add(this.btn_seelate);
            this.Controls.Add(this.btn_goReStream);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_information);
            this.Font = new System.Drawing.Font("카카오 Regular", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NOLJA_ReStream";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "방송 리방 안내";
            this.Load += new System.EventHandler(this.NOLJA_ReStream_Load);
            this.Shown += new System.EventHandler(this.NOLJA_ReStream_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_information;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Button btn_goReStream;
        private System.Windows.Forms.Button btn_seelate;
        private System.Windows.Forms.Label lbl_restartInfo;
        private System.Windows.Forms.Timer timer1;
    }
}