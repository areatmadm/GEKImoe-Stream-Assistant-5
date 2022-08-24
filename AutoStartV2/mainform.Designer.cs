namespace AutoStartV2
{
    partial class AutoStartV2Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoStartV2Main));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_nowver_txt = new System.Windows.Forms.Label();
            this.lbl_nowver = new System.Windows.Forms.Label();
            this.pg = new System.Windows.Forms.Label();
            this.lbl_information = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Font = new System.Drawing.Font("배달의민족 주아", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_name.Location = new System.Drawing.Point(13, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(874, 48);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "{LOCATE} {GAMENAME} 방송기기 가동 준비 중";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_nowver_txt
            // 
            this.lbl_nowver_txt.AutoSize = true;
            this.lbl_nowver_txt.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_nowver_txt.Location = new System.Drawing.Point(15, 175);
            this.lbl_nowver_txt.Name = "lbl_nowver_txt";
            this.lbl_nowver_txt.Size = new System.Drawing.Size(273, 23);
            this.lbl_nowver_txt.TabIndex = 1;
            this.lbl_nowver_txt.Text = "AutoStart System Version : ";
            // 
            // lbl_nowver
            // 
            this.lbl_nowver.AutoSize = true;
            this.lbl_nowver.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_nowver.Location = new System.Drawing.Point(289, 175);
            this.lbl_nowver.Name = "lbl_nowver";
            this.lbl_nowver.Size = new System.Drawing.Size(102, 21);
            this.lbl_nowver.TabIndex = 2;
            this.lbl_nowver.Text = "{VERSION}";
            // 
            // pg
            // 
            this.pg.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pg.Location = new System.Drawing.Point(12, 222);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(875, 33);
            this.pg.TabIndex = 3;
            this.pg.Text = "label1";
            this.pg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_information
            // 
            this.lbl_information.Font = new System.Drawing.Font("배달의민족 주아", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_information.Location = new System.Drawing.Point(15, 73);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(872, 59);
            this.lbl_information.TabIndex = 4;
            this.lbl_information.Text = "{INFO}";
            this.lbl_information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoStartV2Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(899, 270);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_information);
            this.Controls.Add(this.pg);
            this.Controls.Add(this.lbl_nowver);
            this.Controls.Add(this.lbl_nowver_txt);
            this.Controls.Add(this.lbl_name);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AutoStartV2Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcade Streaming System V2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AutoStartV2Main_Load);
            this.Shown += new System.EventHandler(this.AutoStartV2Main_Activate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_nowver_txt;
        private System.Windows.Forms.Label lbl_nowver;
        private System.Windows.Forms.Label pg;
        private System.Windows.Forms.Label lbl_information;
    }
}

