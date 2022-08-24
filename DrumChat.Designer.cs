namespace AreaTM_acbas
{
    partial class DrumChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrumChat));
            this.chatreload = new System.Windows.Forms.Button();
            this.lbl_LINECUSTIOM = new System.Windows.Forms.Label();
            this.txt_onelinetext = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.RestartedTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // chatreload
            // 
            this.chatreload.BackColor = System.Drawing.Color.Transparent;
            this.chatreload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.chatreload.FlatAppearance.BorderSize = 3;
            this.chatreload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chatreload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.chatreload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatreload.Font = new System.Drawing.Font("카카오 Bold", 12F);
            this.chatreload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.chatreload.Location = new System.Drawing.Point(155, 10);
            this.chatreload.Name = "chatreload";
            this.chatreload.Size = new System.Drawing.Size(115, 32);
            this.chatreload.TabIndex = 106;
            this.chatreload.Text = "채팅창 리로드";
            this.chatreload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chatreload.UseVisualStyleBackColor = false;
            this.chatreload.Click += new System.EventHandler(this.chatreload_Click);
            // 
            // lbl_LINECUSTIOM
            // 
            this.lbl_LINECUSTIOM.AutoSize = true;
            this.lbl_LINECUSTIOM.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LINECUSTIOM.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.lbl_LINECUSTIOM.Location = new System.Drawing.Point(52, 613);
            this.lbl_LINECUSTIOM.Name = "lbl_LINECUSTIOM";
            this.lbl_LINECUSTIOM.Size = new System.Drawing.Size(182, 16);
            this.lbl_LINECUSTIOM.TabIndex = 107;
            this.lbl_LINECUSTIOM.Text = "한줄문구 입력 - 방송화면에 반영";
            // 
            // txt_onelinetext
            // 
            this.txt_onelinetext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txt_onelinetext.Font = new System.Drawing.Font("카카오 Regular", 12F);
            this.txt_onelinetext.ForeColor = System.Drawing.Color.White;
            this.txt_onelinetext.Location = new System.Drawing.Point(54, 632);
            this.txt_onelinetext.Name = "txt_onelinetext";
            this.txt_onelinetext.Size = new System.Drawing.Size(180, 26);
            this.txt_onelinetext.TabIndex = 108;
            // 
            // btn_ok
            // 
            this.btn_ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_ok.FlatAppearance.BorderSize = 3;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.btn_ok.Location = new System.Drawing.Point(240, 623);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(42, 32);
            this.btn_ok.TabIndex = 109;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // RestartedTimer
            // 
            this.RestartedTimer.Enabled = true;
            this.RestartedTimer.Interval = 1000;
            this.RestartedTimer.Tick += new System.EventHandler(this.RestartedTimer_Tick);
            // 
            // DrumChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(350, 660);
            this.ControlBox = false;
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_onelinetext);
            this.Controls.Add(this.lbl_LINECUSTIOM);
            this.Controls.Add(this.chatreload);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1170, 220);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrumChat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "upch";
            this.Load += new System.EventHandler(this.SpecialNotice_Load);
            this.Shown += new System.EventHandler(this.DrumChat_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chatreload;
        private System.Windows.Forms.Label lbl_LINECUSTIOM;
        private System.Windows.Forms.TextBox txt_onelinetext;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Timer RestartedTimer;
    }
}

