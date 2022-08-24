
namespace AreaTM_acbas
{
    partial class getuse_GEKImoe_Stream_safe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getuse_GEKImoe_Stream_safe));
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_openitunes = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_confirm
            // 
            this.btn_confirm.Enabled = false;
            this.btn_confirm.Location = new System.Drawing.Point(12, 321);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(254, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "게키모에 스트림 세이프(Alpha) 이용하기";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_openitunes
            // 
            this.btn_openitunes.Location = new System.Drawing.Point(272, 321);
            this.btn_openitunes.Name = "btn_openitunes";
            this.btn_openitunes.Size = new System.Drawing.Size(97, 23);
            this.btn_openitunes.TabIndex = 1;
            this.btn_openitunes.Text = "iTunes 실행";
            this.btn_openitunes.UseVisualStyleBackColor = true;
            this.btn_openitunes.Click += new System.EventHandler(this.btn_openitunes_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(375, 321);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(82, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "닫기";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // getuse_GEKImoe_Stream_safe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(469, 356);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_openitunes);
            this.Controls.Add(this.btn_confirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "getuse_GEKImoe_Stream_safe";
            this.Text = "게키모에 스트림 세이프 안내";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_openitunes;
        private System.Windows.Forms.Button btn_close;
    }
}