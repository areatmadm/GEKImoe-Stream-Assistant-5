namespace AreaTM_acbas
{
    partial class Authorize_acbas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorize_acbas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_0 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AreaTM_acbas.Properties.Resources.aast_f1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_0
            // 
            this.lbl_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbl_0.Location = new System.Drawing.Point(12, 128);
            this.lbl_0.Name = "lbl_0";
            this.lbl_0.Size = new System.Drawing.Size(697, 46);
            this.lbl_0.TabIndex = 1;
            this.lbl_0.Text = "Genuine Authorizing...";
            this.lbl_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_status
            // 
            this.lbl_status.Location = new System.Drawing.Point(13, 174);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(696, 35);
            this.lbl_status.TabIndex = 2;
            this.lbl_status.Text = "{GET_STATUS}";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_status.Click += new System.EventHandler(this.lbl_status_Click);
            // 
            // Authorize_acbas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(721, 231);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_0);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authorize_acbas";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AreaTM GEKImoe Stream Assistant 5 - Genuine Authorizing...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Authrize_acbas_Load);
            this.Shown += new System.EventHandler(this.Authrize_acbas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_0;
        private System.Windows.Forms.Label lbl_status;
    }
}