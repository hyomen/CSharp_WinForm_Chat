namespace myClient
{
    partial class EnterID
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
            this.IDInputField = new System.Windows.Forms.TextBox();
            this.IDbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDInputField
            // 
            this.IDInputField.Location = new System.Drawing.Point(12, 26);
            this.IDInputField.Name = "IDInputField";
            this.IDInputField.Size = new System.Drawing.Size(377, 21);
            this.IDInputField.TabIndex = 0;
            this.IDInputField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDInputField_KeyDown);
            // 
            // IDbtn
            // 
            this.IDbtn.Location = new System.Drawing.Point(395, 26);
            this.IDbtn.Name = "IDbtn";
            this.IDbtn.Size = new System.Drawing.Size(75, 21);
            this.IDbtn.TabIndex = 1;
            this.IDbtn.Text = "ID 입력";
            this.IDbtn.UseVisualStyleBackColor = true;
            this.IDbtn.Click += new System.EventHandler(this.IDbtn_Click);
            // 
            // EnterID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 59);
            this.Controls.Add(this.IDbtn);
            this.Controls.Add(this.IDInputField);
            this.Name = "EnterID";
            this.Text = "Enter your ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDInputField;
        private System.Windows.Forms.Button IDbtn;
    }
}

