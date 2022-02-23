namespace CM_100
{
    partial class FmInit
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
            this.tmrUpdata = new System.Windows.Forms.Timer(this.components);
            this.pbInitProgress = new System.Windows.Forms.ProgressBar();
            this.lbInitMessage = new System.Windows.Forms.Label();
            this.mqlEQMState = new MarqueeLabel.MarqueeLabel();
            this.SuspendLayout();
            // 
            // pbInitProgress
            // 
            this.pbInitProgress.Location = new System.Drawing.Point(107, 131);
            this.pbInitProgress.Maximum = 120;
            this.pbInitProgress.Name = "pbInitProgress";
            this.pbInitProgress.Size = new System.Drawing.Size(288, 32);
            this.pbInitProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbInitProgress.TabIndex = 0;
            // 
            // lbInitMessage
            // 
            this.lbInitMessage.AutoSize = true;
            this.lbInitMessage.Location = new System.Drawing.Point(103, 218);
            this.lbInitMessage.Name = "lbInitMessage";
            this.lbInitMessage.Size = new System.Drawing.Size(54, 20);
            this.lbInitMessage.TabIndex = 15;
            this.lbInitMessage.Text = "label1";
            // 
            // mqlEQMState
            // 
            this.mqlEQMState.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mqlEQMState.EnableMarquee = false;
            this.mqlEQMState.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mqlEQMState.GradientTextEndColor = System.Drawing.Color.Red;
            this.mqlEQMState.GradientTextStartColor = System.Drawing.Color.Red;
            this.mqlEQMState.Location = new System.Drawing.Point(25, 37);
            this.mqlEQMState.Name = "mqlEQMState";
            this.mqlEQMState.Size = new System.Drawing.Size(475, 67);
            this.mqlEQMState.TabIndex = 13;
            this.mqlEQMState.Text = "Not Init";
            this.mqlEQMState.TickInterval = 250;
            // 
            // FmInit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(521, 268);
            this.Controls.Add(this.mqlEQMState);
            this.Controls.Add(this.lbInitMessage);
            this.Controls.Add(this.pbInitProgress);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FmInit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdata;
        private System.Windows.Forms.ProgressBar pbInitProgress;
        private System.Windows.Forms.Label lbInitMessage;
        private MarqueeLabel.MarqueeLabel mqlEQMState;
    }
}