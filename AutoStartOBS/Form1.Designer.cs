namespace AutoStartOBS
{
    partial class AutoStart_Nolja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoStart_Nolja));
            this.label1 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.pg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 153);
            this.label1.TabIndex = 0;
            this.label1.Text = "이 창이 닫히기 전까지 절대로 PC를 건들지 마세요 Do not distrub this PC before this window is closing" +
    ".";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(23, 222);
            this.pb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(511, 34);
            this.pb.TabIndex = 1;
            // 
            // pg
            // 
            this.pg.AutoSize = true;
            this.pg.Location = new System.Drawing.Point(23, 195);
            this.pg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(54, 18);
            this.pg.TabIndex = 2;
            this.pg.Text = "label2";
            // 
            // AutoStart_Nolja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 274);
            this.Controls.Add(this.pg);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AutoStart_Nolja";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NOLJA_AUTOSTART";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Nolja_AutoStart_Load);
            this.Shown += new System.EventHandler(this.Nolja_AutoStart_Activate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label pg;
    }
}

