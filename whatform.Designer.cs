namespace AreaTM_acbas
{
    partial class whatform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(whatform));
            this.lbl_SelectScene = new System.Windows.Forms.Label();
            this.cb_selectScene = new System.Windows.Forms.ComboBox();
            this.rd_camon = new System.Windows.Forms.RadioButton();
            this.rd_camoff = new System.Windows.Forms.RadioButton();
            this.rd_onlyScreen = new System.Windows.Forms.RadioButton();
            this.btn_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_SelectScene
            // 
            this.lbl_SelectScene.AutoSize = true;
            this.lbl_SelectScene.Location = new System.Drawing.Point(12, 25);
            this.lbl_SelectScene.Name = "lbl_SelectScene";
            this.lbl_SelectScene.Size = new System.Drawing.Size(59, 16);
            this.lbl_SelectScene.TabIndex = 0;
            this.lbl_SelectScene.Text = "장면 선택";
            // 
            // cb_selectScene
            // 
            this.cb_selectScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_selectScene.FormattingEnabled = true;
            this.cb_selectScene.Location = new System.Drawing.Point(77, 22);
            this.cb_selectScene.Name = "cb_selectScene";
            this.cb_selectScene.Size = new System.Drawing.Size(445, 23);
            this.cb_selectScene.TabIndex = 1;
            this.cb_selectScene.SelectedIndexChanged += new System.EventHandler(this.cb_selectScene_SelectedIndexChanged);
            // 
            // rd_camon
            // 
            this.rd_camon.AutoSize = true;
            this.rd_camon.Location = new System.Drawing.Point(15, 61);
            this.rd_camon.Name = "rd_camon";
            this.rd_camon.Size = new System.Drawing.Size(65, 20);
            this.rd_camon.TabIndex = 2;
            this.rd_camon.TabStop = true;
            this.rd_camon.Text = "캠 켜기";
            this.rd_camon.UseVisualStyleBackColor = true;
            // 
            // rd_camoff
            // 
            this.rd_camoff.AutoSize = true;
            this.rd_camoff.Location = new System.Drawing.Point(86, 61);
            this.rd_camoff.Name = "rd_camoff";
            this.rd_camoff.Size = new System.Drawing.Size(65, 20);
            this.rd_camoff.TabIndex = 3;
            this.rd_camoff.TabStop = true;
            this.rd_camoff.Text = "캠 끄기";
            this.rd_camoff.UseVisualStyleBackColor = true;
            // 
            // rd_onlyScreen
            // 
            this.rd_onlyScreen.AutoSize = true;
            this.rd_onlyScreen.Location = new System.Drawing.Point(157, 61);
            this.rd_onlyScreen.Name = "rd_onlyScreen";
            this.rd_onlyScreen.Size = new System.Drawing.Size(152, 20);
            this.rd_onlyScreen.TabIndex = 4;
            this.rd_onlyScreen.TabStop = true;
            this.rd_onlyScreen.Text = "메인 디스플레이만 보기";
            this.rd_onlyScreen.UseVisualStyleBackColor = true;
            // 
            // btn_apply
            // 
            this.btn_apply.ForeColor = System.Drawing.Color.Black;
            this.btn_apply.Location = new System.Drawing.Point(15, 87);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(507, 26);
            this.btn_apply.TabIndex = 5;
            this.btn_apply.Text = "적용 후 창 닫기";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // whatform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(535, 128);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.rd_onlyScreen);
            this.Controls.Add(this.rd_camoff);
            this.Controls.Add(this.rd_camon);
            this.Controls.Add(this.cb_selectScene);
            this.Controls.Add(this.lbl_SelectScene);
            this.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "whatform";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "화면 뷰 선택학기";
            this.Load += new System.EventHandler(this.whatform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectScene;
        private System.Windows.Forms.ComboBox cb_selectScene;
        private System.Windows.Forms.RadioButton rd_camon;
        private System.Windows.Forms.RadioButton rd_camoff;
        private System.Windows.Forms.RadioButton rd_onlyScreen;
        private System.Windows.Forms.Button btn_apply;
    }
}