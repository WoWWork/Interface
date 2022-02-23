namespace CM_100
{
    partial class fmCreateUser
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
            this.lbPW2Title = new System.Windows.Forms.Label();
            this.lbPW1Title = new System.Windows.Forms.Label();
            this.tbPW2 = new System.Windows.Forms.TextBox();
            this.tbPW1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbAuth = new System.Windows.Forms.ComboBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbAuthTitle = new System.Windows.Forms.Label();
            this.lbNameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPW2Title
            // 
            this.lbPW2Title.Location = new System.Drawing.Point(12, 104);
            this.lbPW2Title.Name = "lbPW2Title";
            this.lbPW2Title.Size = new System.Drawing.Size(169, 20);
            this.lbPW2Title.TabIndex = 20;
            this.lbPW2Title.Text = "Confirm Pass Word ";
            this.lbPW2Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPW1Title
            // 
            this.lbPW1Title.Location = new System.Drawing.Point(65, 61);
            this.lbPW1Title.Name = "lbPW1Title";
            this.lbPW1Title.Size = new System.Drawing.Size(116, 20);
            this.lbPW1Title.TabIndex = 19;
            this.lbPW1Title.Text = "Pass Word";
            this.lbPW1Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPW2
            // 
            this.tbPW2.BackColor = System.Drawing.Color.White;
            this.tbPW2.Location = new System.Drawing.Point(187, 98);
            this.tbPW2.Name = "tbPW2";
            this.tbPW2.PasswordChar = '*';
            this.tbPW2.ReadOnly = true;
            this.tbPW2.Size = new System.Drawing.Size(225, 28);
            this.tbPW2.TabIndex = 18;
            this.tbPW2.Click += new System.EventHandler(this.tbPW_Click);
            // 
            // tbPW1
            // 
            this.tbPW1.BackColor = System.Drawing.Color.White;
            this.tbPW1.Location = new System.Drawing.Point(187, 55);
            this.tbPW1.Name = "tbPW1";
            this.tbPW1.PasswordChar = '*';
            this.tbPW1.ReadOnly = true;
            this.tbPW1.Size = new System.Drawing.Size(225, 28);
            this.tbPW1.TabIndex = 17;
            this.tbPW1.Click += new System.EventHandler(this.tbPW_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(306, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 43);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(187, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 43);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbAuth
            // 
            this.cbAuth.FormattingEnabled = true;
            this.cbAuth.Items.AddRange(new object[] {
            "Operator",
            "Engineer",
            "Administrator"});
            this.cbAuth.Location = new System.Drawing.Point(187, 141);
            this.cbAuth.Name = "cbAuth";
            this.cbAuth.Size = new System.Drawing.Size(225, 28);
            this.cbAuth.TabIndex = 14;
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.White;
            this.tbUserName.Location = new System.Drawing.Point(187, 12);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(225, 28);
            this.tbUserName.TabIndex = 13;
            this.tbUserName.Click += new System.EventHandler(this.tbUserName_Click);
            // 
            // lbAuthTitle
            // 
            this.lbAuthTitle.Location = new System.Drawing.Point(65, 145);
            this.lbAuthTitle.Name = "lbAuthTitle";
            this.lbAuthTitle.Size = new System.Drawing.Size(116, 20);
            this.lbAuthTitle.TabIndex = 12;
            this.lbAuthTitle.Text = "Authority";
            this.lbAuthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNameTitle
            // 
            this.lbNameTitle.Location = new System.Drawing.Point(65, 15);
            this.lbNameTitle.Name = "lbNameTitle";
            this.lbNameTitle.Size = new System.Drawing.Size(116, 20);
            this.lbNameTitle.TabIndex = 11;
            this.lbNameTitle.Text = "User Name";
            this.lbNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fmCreateUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(425, 240);
            this.Controls.Add(this.lbPW2Title);
            this.Controls.Add(this.lbPW1Title);
            this.Controls.Add(this.tbPW2);
            this.Controls.Add(this.tbPW1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbAuth);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbAuthTitle);
            this.Controls.Add(this.lbNameTitle);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "fmCreateUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPW2Title;
        private System.Windows.Forms.Label lbPW1Title;
        private System.Windows.Forms.TextBox tbPW2;
        private System.Windows.Forms.TextBox tbPW1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbAuth;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbAuthTitle;
        private System.Windows.Forms.Label lbNameTitle;
    }
}