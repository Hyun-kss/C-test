namespace Window_Project
{
    partial class TicketingChoice
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
            this.panel_easy = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel_medium = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel_hard = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel_chaos = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.userpoints_label = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.panel_easy.SuspendLayout();
            this.panel_medium.SuspendLayout();
            this.panel_hard.SuspendLayout();
            this.panel_chaos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_easy
            // 
            this.panel_easy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_easy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel_easy.Controls.Add(this.textBox1);
            this.panel_easy.Location = new System.Drawing.Point(125, 50);
            this.panel_easy.Name = "panel_easy";
            this.panel_easy.Size = new System.Drawing.Size(290, 155);
            this.panel_easy.TabIndex = 0;
            this.panel_easy.Click += new System.EventHandler(this.panel_easy_Click);
            this.panel_easy.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_easy_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("HY견고딕", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(0, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Ticket";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.UseWaitCursor = true;
            // 
            // panel_medium
            // 
            this.panel_medium.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_medium.Controls.Add(this.textBox2);
            this.panel_medium.Font = new System.Drawing.Font("Stencil", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_medium.Location = new System.Drawing.Point(555, 50);
            this.panel_medium.Name = "panel_medium";
            this.panel_medium.Size = new System.Drawing.Size(290, 155);
            this.panel_medium.TabIndex = 1;
            this.panel_medium.Click += new System.EventHandler(this.panel_medium_Click);
            this.panel_medium.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_medium_Paint);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("HY견고딕", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(0, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(290, 30);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Ticket(20000$)";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_hard
            // 
            this.panel_hard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_hard.Controls.Add(this.textBox4);
            this.panel_hard.Location = new System.Drawing.Point(125, 295);
            this.panel_hard.Name = "panel_hard";
            this.panel_hard.Size = new System.Drawing.Size(290, 155);
            this.panel_hard.TabIndex = 2;
            this.panel_hard.Click += new System.EventHandler(this.panel_hard_Click);
            this.panel_hard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_hard_Paint);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("HY견고딕", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(0, 125);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(290, 30);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Ticket(35000$)";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_chaos
            // 
            this.panel_chaos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_chaos.Controls.Add(this.textBox3);
            this.panel_chaos.Location = new System.Drawing.Point(555, 295);
            this.panel_chaos.Name = "panel_chaos";
            this.panel_chaos.Size = new System.Drawing.Size(290, 155);
            this.panel_chaos.TabIndex = 3;
            this.panel_chaos.Click += new System.EventHandler(this.panel_chaos_Click);
            this.panel_chaos.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_chaos_Paint);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("HY견고딕", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(0, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(290, 30);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Ticket(70000$)";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userpoints_label
            // 
            this.userpoints_label.AutoSize = true;
            this.userpoints_label.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userpoints_label.Location = new System.Drawing.Point(12, 9);
            this.userpoints_label.Name = "userpoints_label";
            this.userpoints_label.Size = new System.Drawing.Size(78, 26);
            this.userpoints_label.TabIndex = 4;
            this.userpoints_label.Text = "label1";
            this.userpoints_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitButton.Location = new System.Drawing.Point(834, 492);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(136, 49);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "☞ EXIT ☜\r\n";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitStartScreen_Click);
            // 
            // TicketingChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.userpoints_label);
            this.Controls.Add(this.panel_chaos);
            this.Controls.Add(this.panel_hard);
            this.Controls.Add(this.panel_medium);
            this.Controls.Add(this.panel_easy);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "TicketingChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicketingChoice";
            this.panel_easy.ResumeLayout(false);
            this.panel_easy.PerformLayout();
            this.panel_medium.ResumeLayout(false);
            this.panel_medium.PerformLayout();
            this.panel_hard.ResumeLayout(false);
            this.panel_hard.PerformLayout();
            this.panel_chaos.ResumeLayout(false);
            this.panel_chaos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_easy;
        private System.Windows.Forms.Panel panel_medium;
        private System.Windows.Forms.Panel panel_hard;
        private System.Windows.Forms.Panel panel_chaos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label userpoints_label;
        private System.Windows.Forms.Button ExitButton;
    }
}