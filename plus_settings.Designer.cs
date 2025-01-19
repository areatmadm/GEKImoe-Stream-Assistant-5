namespace AreaTM_acbas
{
    partial class plus_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(plus_settings));
            this.lbl_d_n_m = new System.Windows.Forms.Label();
            this.gb_other = new System.Windows.Forms.GroupBox();
            this.btn_rebang_real = new System.Windows.Forms.Button();
            this.btn_rebang = new System.Windows.Forms.Button();
            this.lbl_gb_other = new System.Windows.Forms.Label();
            this.btn_UpdateLog = new System.Windows.Forms.Button();
            this.gb_other.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_d_n_m
            // 
            this.lbl_d_n_m.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_d_n_m.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 22F);
            this.lbl_d_n_m.Location = new System.Drawing.Point(0, 0);
            this.lbl_d_n_m.Name = "lbl_d_n_m";
            this.lbl_d_n_m.Size = new System.Drawing.Size(500, 55);
            this.lbl_d_n_m.TabIndex = 0;
            this.lbl_d_n_m.Text = "GEKImoe Stream Assistant 5 설정";
            this.lbl_d_n_m.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gb_other
            // 
            this.gb_other.Controls.Add(this.btn_rebang_real);
            this.gb_other.Controls.Add(this.btn_rebang);
            this.gb_other.Controls.Add(this.lbl_gb_other);
            this.gb_other.Location = new System.Drawing.Point(13, 72);
            this.gb_other.Name = "gb_other";
            this.gb_other.Size = new System.Drawing.Size(475, 75);
            this.gb_other.TabIndex = 3;
            this.gb_other.TabStop = false;
            // 
            // btn_rebang_real
            // 
            this.btn_rebang_real.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.btn_rebang_real.ForeColor = System.Drawing.Color.Black;
            this.btn_rebang_real.Location = new System.Drawing.Point(152, 25);
            this.btn_rebang_real.Name = "btn_rebang_real";
            this.btn_rebang_real.Size = new System.Drawing.Size(130, 30);
            this.btn_rebang_real.TabIndex = 4;
            this.btn_rebang_real.Text = "리방하기";
            this.btn_rebang_real.UseVisualStyleBackColor = true;
            this.btn_rebang_real.Click += new System.EventHandler(this.btn_rebang_real_Click);
            // 
            // btn_rebang
            // 
            this.btn_rebang.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.btn_rebang.ForeColor = System.Drawing.Color.Black;
            this.btn_rebang.Location = new System.Drawing.Point(16, 25);
            this.btn_rebang.Name = "btn_rebang";
            this.btn_rebang.Size = new System.Drawing.Size(130, 30);
            this.btn_rebang.TabIndex = 3;
            this.btn_rebang.Text = "에러픽스 | 캠조정";
            this.btn_rebang.UseVisualStyleBackColor = true;
            this.btn_rebang.Click += new System.EventHandler(this.btn_rebang_Click);
            // 
            // lbl_gb_other
            // 
            this.lbl_gb_other.AutoSize = true;
            this.lbl_gb_other.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.lbl_gb_other.Location = new System.Drawing.Point(12, 0);
            this.lbl_gb_other.Name = "lbl_gb_other";
            this.lbl_gb_other.Size = new System.Drawing.Size(68, 17);
            this.lbl_gb_other.TabIndex = 2;
            this.lbl_gb_other.Text = "기타 설정";
            // 
            // btn_UpdateLog
            // 
            this.btn_UpdateLog.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.btn_UpdateLog.ForeColor = System.Drawing.Color.Black;
            this.btn_UpdateLog.Location = new System.Drawing.Point(13, 153);
            this.btn_UpdateLog.Name = "btn_UpdateLog";
            this.btn_UpdateLog.Size = new System.Drawing.Size(130, 30);
            this.btn_UpdateLog.TabIndex = 4;
            this.btn_UpdateLog.Text = "업데이트 로그";
            this.btn_UpdateLog.UseVisualStyleBackColor = true;
            this.btn_UpdateLog.Click += new System.EventHandler(this.btn_UpdateLog_Click);
            // 
            // plus_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(500, 196);
            this.Controls.Add(this.btn_UpdateLog);
            this.Controls.Add(this.gb_other);
            this.Controls.Add(this.lbl_d_n_m);
            this.Font = new System.Drawing.Font("굴림", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "plus_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GEKImoe Stream Assistant 5 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.plus_settings_FormClosing);
            this.Load += new System.EventHandler(this.plus_settings_Load);
            this.Shown += new System.EventHandler(this.plus_settings_Shown);
            this.gb_other.ResumeLayout(false);
            this.gb_other.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_d_n_m;
        private System.Windows.Forms.GroupBox gb_other;
        private System.Windows.Forms.Label lbl_gb_other;
        private System.Windows.Forms.Button btn_rebang;
        private System.Windows.Forms.Button btn_rebang_real;
        private System.Windows.Forms.Button btn_UpdateLog;
    }
}