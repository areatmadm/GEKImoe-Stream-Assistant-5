namespace AreaTM_acbas
{
    partial class plv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(plv));
            this.lbl_info_0 = new System.Windows.Forms.Label();
            this.lbl_info_1 = new System.Windows.Forms.Label();
            this.lbl_streamkey = new System.Windows.Forms.Label();
            this.txt_stream = new System.Windows.Forms.TextBox();
            this.btn_livestart = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_nowstatus = new System.Windows.Forms.Label();
            this.btn_getstreamkey = new System.Windows.Forms.Button();
            this.btn_set_service = new System.Windows.Forms.Button();
            this.url_inform = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_info_0
            // 
            this.lbl_info_0.AutoSize = true;
            this.lbl_info_0.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.lbl_info_0.Location = new System.Drawing.Point(13, 13);
            this.lbl_info_0.Name = "lbl_info_0";
            this.lbl_info_0.Size = new System.Drawing.Size(318, 32);
            this.lbl_info_0.TabIndex = 0;
            this.lbl_info_0.Text = "오락실 스트리밍과 내 스트리밍을 동시에 즐기자!\r\nAreaTM GEKImoe PLIVE MultiStream 서비스 입니다.";
            // 
            // lbl_info_1
            // 
            this.lbl_info_1.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.lbl_info_1.Location = new System.Drawing.Point(13, 56);
            this.lbl_info_1.Name = "lbl_info_1";
            this.lbl_info_1.Size = new System.Drawing.Size(497, 151);
            this.lbl_info_1.TabIndex = 1;
            this.lbl_info_1.Text = resources.GetString("lbl_info_1.Text");
            // 
            // lbl_streamkey
            // 
            this.lbl_streamkey.AutoSize = true;
            this.lbl_streamkey.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.lbl_streamkey.Location = new System.Drawing.Point(11, 244);
            this.lbl_streamkey.Name = "lbl_streamkey";
            this.lbl_streamkey.Size = new System.Drawing.Size(200, 16);
            this.lbl_streamkey.TabIndex = 6;
            this.lbl_streamkey.Text = "라이브 스트리밍 키를 입력해 주세요";
            // 
            // txt_stream
            // 
            this.txt_stream.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txt_stream.Enabled = false;
            this.txt_stream.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.txt_stream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txt_stream.Location = new System.Drawing.Point(12, 264);
            this.txt_stream.Name = "txt_stream";
            this.txt_stream.Size = new System.Drawing.Size(498, 23);
            this.txt_stream.TabIndex = 10;
            this.txt_stream.EnabledChanged += new System.EventHandler(this.NOLJA_Edition_statechange);
            // 
            // btn_livestart
            // 
            this.btn_livestart.Enabled = false;
            this.btn_livestart.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.btn_livestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn_livestart.Location = new System.Drawing.Point(13, 366);
            this.btn_livestart.Name = "btn_livestart";
            this.btn_livestart.Size = new System.Drawing.Size(245, 37);
            this.btn_livestart.TabIndex = 12;
            this.btn_livestart.Text = "MultiStream 시작";
            this.btn_livestart.UseVisualStyleBackColor = true;
            this.btn_livestart.Click += new System.EventHandler(this.btn_livestart_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn_close.Location = new System.Drawing.Point(265, 366);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(245, 37);
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "닫기";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_nowstatus
            // 
            this.lbl_nowstatus.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.lbl_nowstatus.Location = new System.Drawing.Point(9, 331);
            this.lbl_nowstatus.Name = "lbl_nowstatus";
            this.lbl_nowstatus.Size = new System.Drawing.Size(497, 26);
            this.lbl_nowstatus.TabIndex = 12;
            this.lbl_nowstatus.Text = "대기";
            this.lbl_nowstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_getstreamkey
            // 
            this.btn_getstreamkey.Enabled = false;
            this.btn_getstreamkey.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.btn_getstreamkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn_getstreamkey.Location = new System.Drawing.Point(13, 294);
            this.btn_getstreamkey.Name = "btn_getstreamkey";
            this.btn_getstreamkey.Size = new System.Drawing.Size(245, 28);
            this.btn_getstreamkey.TabIndex = 11;
            this.btn_getstreamkey.Text = "라이브 스트리밍 키 받으러 가기";
            this.btn_getstreamkey.UseVisualStyleBackColor = true;
            this.btn_getstreamkey.Click += new System.EventHandler(this.btn_getstreamkey_Click);
            // 
            // btn_set_service
            // 
            this.btn_set_service.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.btn_set_service.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn_set_service.Location = new System.Drawing.Point(12, 210);
            this.btn_set_service.Name = "btn_set_service";
            this.btn_set_service.Size = new System.Drawing.Size(499, 31);
            this.btn_set_service.TabIndex = 15;
            this.btn_set_service.Text = "플랫폼 선택하기";
            this.btn_set_service.UseVisualStyleBackColor = true;
            this.btn_set_service.Click += new System.EventHandler(this.btn_set_service_Click);
            // 
            // url_inform
            // 
            this.url_inform.Enabled = false;
            this.url_inform.Font = new System.Drawing.Font("카카오 Regular", 10F);
            this.url_inform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.url_inform.Location = new System.Drawing.Point(265, 294);
            this.url_inform.Name = "url_inform";
            this.url_inform.Size = new System.Drawing.Size(245, 28);
            this.url_inform.TabIndex = 16;
            this.url_inform.Text = "PLIVE MultiStream 알림서비스";
            this.url_inform.UseVisualStyleBackColor = true;
            this.url_inform.Click += new System.EventHandler(this.url_inform_Click);
            // 
            // plv
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(522, 415);
            this.Controls.Add(this.url_inform);
            this.Controls.Add(this.btn_set_service);
            this.Controls.Add(this.btn_getstreamkey);
            this.Controls.Add(this.lbl_nowstatus);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_livestart);
            this.Controls.Add(this.txt_stream);
            this.Controls.Add(this.lbl_streamkey);
            this.Controls.Add(this.lbl_info_1);
            this.Controls.Add(this.lbl_info_0);
            this.Font = new System.Drawing.Font("나눔고딕", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "plv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AreaTM GEKImoe PLIVE MultiStream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.plv_Closing);
            this.Load += new System.EventHandler(this.plv_Load);
            this.Shown += new System.EventHandler(this.plv_Activate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_info_0;
        private System.Windows.Forms.Label lbl_info_1;
        private System.Windows.Forms.Label lbl_streamkey;
        private System.Windows.Forms.TextBox txt_stream;
        private System.Windows.Forms.Button btn_livestart;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_nowstatus;
        private System.Windows.Forms.Button btn_getstreamkey;
        private System.Windows.Forms.Button btn_set_service;
        private System.Windows.Forms.Button url_inform;
    }
}