namespace myClient
{
    partial class ClientForm
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
            this.InputField = new System.Windows.Forms.TextBox();
            this.EnterBtn = new System.Windows.Forms.Button();
            this.ChatterList = new System.Windows.Forms.ListBox();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.ChatLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // InputField
            // 
            this.InputField.Location = new System.Drawing.Point(12, 417);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(625, 21);
            this.InputField.TabIndex = 1;
            this.InputField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputField_KeyDown);
            // 
            // EnterBtn
            // 
            this.EnterBtn.Location = new System.Drawing.Point(643, 415);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(73, 23);
            this.EnterBtn.TabIndex = 2;
            this.EnterBtn.Text = "전 송";
            this.EnterBtn.UseVisualStyleBackColor = true;
            this.EnterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // ChatterList
            // 
            this.ChatterList.FormattingEnabled = true;
            this.ChatterList.ItemHeight = 12;
            this.ChatterList.Location = new System.Drawing.Point(643, 12);
            this.ChatterList.Name = "ChatterList";
            this.ChatterList.Size = new System.Drawing.Size(145, 388);
            this.ChatterList.TabIndex = 3;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(723, 415);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(65, 23);
            this.QuitBtn.TabIndex = 4;
            this.QuitBtn.Text = "나가기";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.Disconnect);
            // 
            // ChatLog
            // 
            this.ChatLog.Location = new System.Drawing.Point(12, 12);
            this.ChatLog.Name = "ChatLog";
            this.ChatLog.ReadOnly = true;
            this.ChatLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ChatLog.Size = new System.Drawing.Size(625, 388);
            this.ChatLog.TabIndex = 5;
            this.ChatLog.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChatLog);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.ChatterList);
            this.Controls.Add(this.EnterBtn);
            this.Controls.Add(this.InputField);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Disconnect);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.Button EnterBtn;
        private System.Windows.Forms.ListBox ChatterList;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.RichTextBox ChatLog;
    }
}