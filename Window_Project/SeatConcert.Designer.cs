namespace Window_Project
{
    partial class SeatConcert
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
            System.Windows.Forms.Button settleButton;
            this.userpoints_label = new System.Windows.Forms.Label();
            settleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settleButton
            // 
            settleButton.BackColor = System.Drawing.Color.IndianRed;
            settleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            settleButton.Font = new System.Drawing.Font("한컴 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            settleButton.Location = new System.Drawing.Point(630, 353);
            settleButton.Name = "settleButton";
            settleButton.Size = new System.Drawing.Size(140, 44);
            settleButton.TabIndex = 1;
            settleButton.Text = "정산하기";
            settleButton.UseVisualStyleBackColor = false;
            settleButton.Click += new System.EventHandler(this.SettleButton_Click);
            // 
            // userpoints_label
            // 
            this.userpoints_label.AutoSize = true;
            this.userpoints_label.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userpoints_label.Location = new System.Drawing.Point(12, 460);
            this.userpoints_label.Name = "userpoints_label";
            this.userpoints_label.Size = new System.Drawing.Size(92, 32);
            this.userpoints_label.TabIndex = 0;
            this.userpoints_label.Text = "label1";
            // 
            // SeatConcert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(settleButton);
            this.Controls.Add(this.userpoints_label);
            this.Name = "SeatConcert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeatConcert";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SeatConcert_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userpoints_label;
    }
}