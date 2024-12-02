namespace Window_Project
{
    partial class START_SCREEN
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
            this.start_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.title_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.start_button.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_button.Location = new System.Drawing.Point(412, 248);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(150, 40);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exit_button.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exit_button.Location = new System.Drawing.Point(412, 348);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(150, 40);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "EXIT";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // title_textbox
            // 
            this.title_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title_textbox.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_textbox.Location = new System.Drawing.Point(337, 93);
            this.title_textbox.Name = "title_textbox";
            this.title_textbox.Size = new System.Drawing.Size(300, 45);
            this.title_textbox.TabIndex = 2;
            this.title_textbox.Text = "Ticketing Simulation";
            this.title_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // START_SCREEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.title_textbox);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.start_button);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "START_SCREEN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "START_SCREEN";
            this.Load += new System.EventHandler(this.START_SCREEN_Load);
            this.Resize += new System.EventHandler(this.START_SCREEN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.TextBox title_textbox;
    }
}

