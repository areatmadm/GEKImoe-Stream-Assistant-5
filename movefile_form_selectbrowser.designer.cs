using System;

namespace AreaTM_acbas
{
    partial class movefile_form_selectbrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(movefile_form_selectbrowser));
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.openFirefox = new System.Windows.Forms.Button();
            this.openBrave = new System.Windows.Forms.Button();
            this.openEdge = new System.Windows.Forms.Button();
            this.openWhale = new System.Windows.Forms.Button();
            this.openChrome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbl_name.Location = new System.Drawing.Point(12, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(720, 39);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "사용할 웹 브라우저를 선택해 주세요";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_close
            // 
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_close.FlatAppearance.BorderSize = 3;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(381, 324);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(351, 39);
            this.btn_close.TabIndex = 11;
            this.btn_close.Text = "이 창을 닫을래요";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // openFirefox
            // 
            this.openFirefox.Enabled = false;
            this.openFirefox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openFirefox.FlatAppearance.BorderSize = 3;
            this.openFirefox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openFirefox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openFirefox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFirefox.Location = new System.Drawing.Point(18, 55);
            this.openFirefox.Name = "openFirefox";
            this.openFirefox.Size = new System.Drawing.Size(352, 39);
            this.openFirefox.TabIndex = 12;
            this.openFirefox.Text = "Firefox";
            this.openFirefox.UseVisualStyleBackColor = true;
            this.openFirefox.Click += new System.EventHandler(this.openWhale_Click);
            // 
            // openBrave
            // 
            this.openBrave.Enabled = false;
            this.openBrave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openBrave.FlatAppearance.BorderSize = 3;
            this.openBrave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openBrave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openBrave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openBrave.Location = new System.Drawing.Point(380, 55);
            this.openBrave.Name = "openBrave";
            this.openBrave.Size = new System.Drawing.Size(352, 39);
            this.openBrave.TabIndex = 13;
            this.openBrave.Text = "Brave";
            this.openBrave.UseVisualStyleBackColor = true;
            this.openBrave.Click += new System.EventHandler(this.openBrave_Click);
            // 
            // openEdge
            // 
            this.openEdge.Enabled = false;
            this.openEdge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openEdge.FlatAppearance.BorderSize = 3;
            this.openEdge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openEdge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openEdge.Location = new System.Drawing.Point(18, 100);
            this.openEdge.Name = "openEdge";
            this.openEdge.Size = new System.Drawing.Size(352, 39);
            this.openEdge.TabIndex = 14;
            this.openEdge.Text = "Microsoft Edge";
            this.openEdge.UseVisualStyleBackColor = true;
            this.openEdge.Click += new System.EventHandler(this.openEdge_Click);
            // 
            // openWhale
            // 
            this.openWhale.Enabled = false;
            this.openWhale.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openWhale.FlatAppearance.BorderSize = 3;
            this.openWhale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openWhale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openWhale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openWhale.Location = new System.Drawing.Point(380, 100);
            this.openWhale.Name = "openWhale";
            this.openWhale.Size = new System.Drawing.Size(352, 39);
            this.openWhale.TabIndex = 15;
            this.openWhale.Text = "NAVER Whale";
            this.openWhale.UseVisualStyleBackColor = true;
            this.openWhale.Click += new System.EventHandler(this.openWhale_Click_1);
            // 
            // openChrome
            // 
            this.openChrome.Enabled = false;
            this.openChrome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openChrome.FlatAppearance.BorderSize = 3;
            this.openChrome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openChrome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.openChrome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openChrome.Location = new System.Drawing.Point(18, 145);
            this.openChrome.Name = "openChrome";
            this.openChrome.Size = new System.Drawing.Size(352, 39);
            this.openChrome.TabIndex = 16;
            this.openChrome.Text = "Google Chrome";
            this.openChrome.UseVisualStyleBackColor = true;
            this.openChrome.Click += new System.EventHandler(this.openChrome_Click);
            // 
            // movefile_form_selectbrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(744, 375);
            this.Controls.Add(this.openChrome);
            this.Controls.Add(this.openWhale);
            this.Controls.Add(this.openEdge);
            this.Controls.Add(this.openBrave);
            this.Controls.Add(this.openFirefox);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "movefile_form_selectbrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Browser";
            this.Load += new System.EventHandler(this.movefile_form_selectbrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button openFirefox;
        private System.Windows.Forms.Button openBrave;
        private System.Windows.Forms.Button openEdge;
        private System.Windows.Forms.Button openWhale;
        private System.Windows.Forms.Button openChrome;
    }
}