using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainControl;

namespace CM_100
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(1366, 768);
            this.pnlMain.Size = new Size(1366, 745);
            this.statusStrip1.Size = new Size(1366,30);
        }

        public void ChangePage(string str)
        {
            foreach (Control ctl in pnlMain.Controls)
            {
                if (ctl is UserControl)
                {
                    ((UserControl)ctl).Visible = (((UserControl)ctl).Name.ToString() == str) ? true : false;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Add(ucMainPage.GetSingleton(this));
            ucMainPage.GetSingleton(this).Visible = true;

            this.pnlMain.Controls.Add(ucMotionTeach.GetSingleton(this));
            ucMotionTeach.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucFMIOPage.GetSingleton(this));
            ucFMIOPage.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucUserLevel.GetSingleton(this));
            ucUserLevel.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucRecipe.GetSingleton(this));
            ucRecipe.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucSysPar.GetSingleton(this));
            ucSysPar.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucHistory.GetSingleton(this));
            ucHistory.GetSingleton(this).Visible = false;

            this.pnlMain.Controls.Add(ucLASER.GetSingleton(this));
            ucLASER.GetSingleton(this).Visible = false;
        }

        private void tsslUserName_Click(object sender, EventArgs e)
        {

        }

        private void tmDataTime_Tick(object sender, EventArgs e)
        {
            toolsslDateTime.Text = DateTime.Now.ToString("MM-dd HH:mm:ss");
        }

    }
}
