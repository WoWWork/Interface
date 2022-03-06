namespace CM_100
{
    partial class fmUserLogin
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
            this.cbUserList = new System.Windows.Forms.ComboBox();
            this.lbPWTitle = new System.Windows.Forms.Label();
            this.tbPSW = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbNameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUserList
            // 
            this.cbUserList.FormattingEnabled = true;
            this.cbUserList.Items.AddRange(new object[] {
            "Operator",
            "Engineer",
            "Administrator"});
            this.cbUserList.Location = new System.Drawing.Point(134, 18);
            this.cbUserList.Name = "cbUserList";
            this.cbUserList.Size = new System.Drawing.Size(225, 28);
            this.cbUserList.TabIndex = 16;
            // 
            // lbPWTitle
            // 
            this.lbPWTitle.Location = new System.Drawing.Point(12, 67);
            this.lbPWTitle.Name = "lbPWTitle";
            this.lbPWTitle.Size = new System.Drawing.Size(116, 20);
            this.lbPWTitle.TabIndex = 15;
            this.lbPWTitle.Text = "Pass Word";
            this.lbPWTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPSW
            // 
            this.tbPSW.BackColor = System.Drawing.Color.White;
            this.tbPSW.Location = new System.Drawing.Point(134, 61);
            this.tbPSW.Name = "tbPSW";
            this.tbPSW.PasswordChar = '*';
            this.tbPSW.ReadOnly = true;
            this.tbPSW.Size = new System.Drawing.Size(225, 28);
            this.tbPSW.TabIndex = 14;
            this.tbPSW.Click += new System.EventHandler(this.tbPSW_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(253, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 43);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(123, 103);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 43);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // lbNameTitle
            // 
            this.lbNameTitle.Location = new System.Drawing.Point(12, 21);
            this.lbNameTitle.Name = "lbNameTitle";
            this.lbNameTitle.Size = new System.Drawing.Size(116, 20);
            this.lbNameTitle.TabIndex = 11;
            this.lbNameTitle.Text = "User Name";
            this.lbNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fmUserLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(371, 164);
            this.ControlBox = false;
            this.Controls.Add(this.cbUserList);
            this.Controls.Add(this.lbPWTitle);
            this.Controls.Add(this.tbPSW);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbNameTitle);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "fmUserLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUserList;
        private System.Windows.Forms.Label lbPWTitle;
        private System.Windows.Forms.TextBox tbPSW;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbNameTitle;
    }
}