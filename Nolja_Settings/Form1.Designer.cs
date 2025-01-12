namespace GEKImoeStreamAssistant5FixReboot
{
    partial class Nolja_ErrorFix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nolja_ErrorFix));
            this.lbl_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fix = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("나눔바른고딕OTF", 22F, System.Drawing.FontStyle.Bold);
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(411, 34);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "GEKImoe Stream Fixer(Beta)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔바른고딕OTF", 14F);
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(685, 214);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btn_fix
            // 
            this.btn_fix.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fix.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_fix.FlatAppearance.BorderSize = 4;
            this.btn_fix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_fix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_fix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fix.Font = new System.Drawing.Font("나눔바른고딕OTF", 18F, System.Drawing.FontStyle.Bold);
            this.btn_fix.Location = new System.Drawing.Point(12, 266);
            this.btn_fix.Name = "btn_fix";
            this.btn_fix.Size = new System.Drawing.Size(366, 81);
            this.btn_fix.TabIndex = 1;
            this.btn_fix.Text = "카메라 패치";
            this.btn_fix.UseVisualStyleBackColor = true;
            this.btn_fix.EnabledChanged += new System.EventHandler(this.btn_fix_EnabledChanged);
            this.btn_fix.Click += new System.EventHandler(this.btn_fix_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_exit.FlatAppearance.BorderSize = 4;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("나눔바른고딕OTF", 18F, System.Drawing.FontStyle.Bold);
            this.btn_exit.Location = new System.Drawing.Point(384, 266);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(313, 81);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "어시스턴트로 복귀";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.EnabledChanged += new System.EventHandler(this.btn_exit_EnabledChanged);
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Nolja_ErrorFix
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(709, 362);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_fix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nolja_ErrorFix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoljaStreamingSelect";
            this.Load += new System.EventHandler(this.NoljaStreamingSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fix;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Timer timer1;
    }
}

