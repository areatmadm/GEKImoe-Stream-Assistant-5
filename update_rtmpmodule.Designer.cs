namespace NoljaBroadcast
{
    partial class update_rtmpmodule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update_rtmpmodule));
            this.lbl_n_0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_n_0
            // 
            this.lbl_n_0.AutoSize = true;
            this.lbl_n_0.Font = new System.Drawing.Font("카카오 Bold", 24F);
            this.lbl_n_0.Location = new System.Drawing.Point(15, 12);
            this.lbl_n_0.Name = "lbl_n_0";
            this.lbl_n_0.Size = new System.Drawing.Size(404, 36);
            this.lbl_n_0.TabIndex = 0;
            this.lbl_n_0.Text = "놀자 PLVIE Module Updater";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("카카오 Regular", 12F);
            this.label1.Location = new System.Drawing.Point(18, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 95);
            this.label1.TabIndex = 1;
            this.label1.Text = "놀자 PLIVE Module을 다운로드하는 중입니다...\r\n다운로드 중에는 녹화장비 컨트롤이 불가합니다.\r\n\r\n간혹 응답없음이 표시되더라도 당황하" +
    "지 마세요.\r\n프로그램은 정상적으로 작동 중입니다.";
            // 
            // update_rtmpmodule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(520, 176);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_n_0);
            this.Font = new System.Drawing.Font("굴림", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update_rtmpmodule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "update_rtmpmodule";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.update_rtmpmodule_Load);
            this.Shown += new System.EventHandler(this.update_rtmpmodule_Active);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_n_0;
        private System.Windows.Forms.Label label1;
    }
}