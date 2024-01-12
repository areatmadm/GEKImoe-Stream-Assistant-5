namespace AutoStartV2
{
    partial class update_noljabroadcast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update_noljabroadcast));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("나눔바른고딕", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_name.Location = new System.Drawing.Point(13, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(587, 39);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "GEKImoe Stream Assistant 5 Updater";
            // 
            // lbl_status
            // 
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_status.Font = new System.Drawing.Font("나눔바른고딕", 14F);
            this.lbl_status.Location = new System.Drawing.Point(0, 69);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(612, 44);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "label1";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // update_noljabroadcast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(612, 113);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("굴림", 14F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update_noljabroadcast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AreaTM GEKImoe Stream Assistant 5 AutoUpdater";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.update_noljabroadcast_Load);
            this.Shown += new System.EventHandler(this.update_noljabroadcast_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_status;
    }
}