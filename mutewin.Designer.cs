namespace AreaTM_acbas
{
    partial class mutewin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mutewin));
            this.mutetimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_whenstop = new System.Windows.Forms.Label();
            this.btn_finishmute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mutetimer
            // 
            this.mutetimer.Tick += new System.EventHandler(this.mutetimer_Tick);
            // 
            // lbl_whenstop
            // 
            this.lbl_whenstop.AutoSize = true;
            this.lbl_whenstop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_whenstop.Location = new System.Drawing.Point(13, 13);
            this.lbl_whenstop.Name = "lbl_whenstop";
            this.lbl_whenstop.Size = new System.Drawing.Size(105, 20);
            this.lbl_whenstop.TabIndex = 0;
            this.lbl_whenstop.Text = "초 후 중단됩니다.";
            // 
            // btn_finishmute
            // 
            this.btn_finishmute.FlatAppearance.BorderColor = System.Drawing.Color.Aquamarine;
            this.btn_finishmute.FlatAppearance.BorderSize = 3;
            this.btn_finishmute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btn_finishmute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            this.btn_finishmute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_finishmute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_finishmute.ForeColor = System.Drawing.Color.White;
            this.btn_finishmute.Location = new System.Drawing.Point(14, 64);
            this.btn_finishmute.Name = "btn_finishmute";
            this.btn_finishmute.Size = new System.Drawing.Size(328, 34);
            this.btn_finishmute.TabIndex = 2;
            this.btn_finishmute.Text = "프라이버시 모드 종료";
            this.btn_finishmute.UseVisualStyleBackColor = true;
            this.btn_finishmute.Click += new System.EventHandler(this.btn_finishmute_Click);
            // 
            // mutewin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(354, 110);
            this.ControlBox = false;
            this.Controls.Add(this.btn_finishmute);
            this.Controls.Add(this.lbl_whenstop);
            this.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mutewin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "프라이버시 모드 작동 중";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.howtochat_Load);
            this.Shown += new System.EventHandler(this.howtochat_activate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mutetimer;
        private System.Windows.Forms.Label lbl_whenstop;
        private System.Windows.Forms.Button btn_finishmute;
    }
}