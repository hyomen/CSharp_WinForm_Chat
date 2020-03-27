namespace chattingServer
{
    partial class ChatServerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Enter = new System.Windows.Forms.Button();
            this.ControlInput = new System.Windows.Forms.TextBox();
            this.myConsole = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myConsole);
            this.groupBox1.Controls.Add(this.ClientList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console";
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 12;
            this.ClientList.Location = new System.Drawing.Point(648, 20);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(120, 160);
            this.ClientList.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Enter);
            this.groupBox2.Controls.Add(this.ControlInput);
            this.groupBox2.Location = new System.Drawing.Point(12, 389);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(694, 20);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 1;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.ControlEnter);
            // 
            // ControlInput
            // 
            this.ControlInput.Location = new System.Drawing.Point(7, 21);
            this.ControlInput.Name = "ControlInput";
            this.ControlInput.Size = new System.Drawing.Size(680, 21);
            this.ControlInput.TabIndex = 0;
            this.ControlInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlInput_KeyDown);
            // 
            // myConsole
            // 
            this.myConsole.Location = new System.Drawing.Point(7, 20);
            this.myConsole.Name = "myConsole";
            this.myConsole.ReadOnly = true;
            this.myConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.myConsole.Size = new System.Drawing.Size(635, 344);
            this.myConsole.TabIndex = 2;
            this.myConsole.Text = "";
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChatServerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ChatServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.TextBox ControlInput;
        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.RichTextBox myConsole;
    }
}

