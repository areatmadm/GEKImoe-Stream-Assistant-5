namespace AreaTM_acbas
{
    partial class drumwin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(drumwin));
            this.UPD_NDIdD = new System.Windows.Forms.Label();
            this.lbl_font = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_openlicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UPD_NDIdD
            // 
            this.UPD_NDIdD.AutoSize = true;
            this.UPD_NDIdD.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 36F);
            this.UPD_NDIdD.Location = new System.Drawing.Point(5, 9);
            this.UPD_NDIdD.Name = "UPD_NDIdD";
            this.UPD_NDIdD.Size = new System.Drawing.Size(307, 55);
            this.UPD_NDIdD.TabIndex = 0;
            this.UPD_NDIdD.Text = "업데이트 내역";
            // 
            // lbl_font
            // 
            this.lbl_font.Font = new System.Drawing.Font("나눔고딕", 11.25F);
            this.lbl_font.Location = new System.Drawing.Point(12, 66);
            this.lbl_font.Name = "lbl_font";
            this.lbl_font.Size = new System.Drawing.Size(572, 127);
            this.lbl_font.TabIndex = 1;
            this.lbl_font.Text = "(c) 2019-2020 AreaTM OtogeON";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox1.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.textBox1.Location = new System.Drawing.Point(11, 189);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(572, 261);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "UPDLOG";
            // 
            // btn_openlicense
            // 
            this.btn_openlicense.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.btn_openlicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn_openlicense.Location = new System.Drawing.Point(449, 13);
            this.btn_openlicense.Name = "btn_openlicense";
            this.btn_openlicense.Size = new System.Drawing.Size(134, 23);
            this.btn_openlicense.TabIndex = 3;
            this.btn_openlicense.Text = "License";
            this.btn_openlicense.UseVisualStyleBackColor = true;
            this.btn_openlicense.Click += new System.EventHandler(this.btn_openlicense_Click);
            // 
            // drumwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(596, 462);
            this.Controls.Add(this.btn_openlicense);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_font);
            this.Controls.Add(this.UPD_NDIdD);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1400, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "drumwin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "아레아티엠 GEKImoe Stream Assistant 5 업데이트 내역";
            this.Load += new System.EventHandler(this.drumwin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UPD_NDIdD;
        private System.Windows.Forms.Label lbl_font;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_openlicense;
    }
}