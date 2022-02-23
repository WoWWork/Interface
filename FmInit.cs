using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CM_100
{
    public partial class FmInit : Form
    {
        private static FmInit m_Singleton;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        public static FmInit GetSingleton()
        {
            if (m_Singleton == null)
            {
                m_Singleton = new FmInit();
            }
            return m_Singleton;
        }
        public FmInit()
        {
            InitializeComponent();
            this.Size = new Size(527, 296);
        }
        ~FmInit()
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;

                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;

                return myCp;
            }
        }

        public DialogResult ShowDialog(IWin32Window owner, Manage.emLangType Lang)
        {
            this.Size = new Size(527, 296);

            mqlEQMState.EnableMarquee = true;
            tmrUpdata.Enabled = true;
            DialogResult dr = this.ShowDialog(owner);
            tmrUpdata.Enabled = false;
            mqlEQMState.EnableMarquee = false;

            return dr;
        }

        private void tmrUpdata_Tick(object sender, EventArgs e)
        {
            #region 走馬燈資訊更新
            switch (Manage.clsEQM.Status)
            {
                case Manage.emEQStates.Run:
                    if (mqlEQMState.Text != "RUN") mqlEQMState.Text = "RUN";
                    break;
                case Manage.emEQStates.Stop:
                    if (mqlEQMState.Text != "STOP") mqlEQMState.Text = "STOP";
                    break;
                case Manage.emEQStates.Init:
                    if (mqlEQMState.Text != "INIT.") mqlEQMState.Text = "INIT.";
                    break;
                case Manage.emEQStates.NoInit:
                    if (mqlEQMState.Text != "ON INIT.") mqlEQMState.Text = "ON INIT.";
                    break;
                case Manage.emEQStates.Empty:
                    if (mqlEQMState.Text != "EMPTY") mqlEQMState.Text = "EMPTY";
                    break;
                case Manage.emEQStates.Alarm:
                    if (mqlEQMState.Text != "ALARM") mqlEQMState.Text = "ALARM";
                    break;
                case Manage.emEQStates.Wait:
                    if (mqlEQMState.Text != "WAIT") mqlEQMState.Text = "WAIT";
                    break;
            }
            #endregion
            lbInitMessage.Text = Motion_Sequence.InitTask.InitMessage;

            pbInitProgress.Value = (int)Motion_Sequence.InitTask.ProcessValue;

            if(Motion_Sequence.InitTask.Status == Manage.emMDStates.Ready)
            {
                this.Visible = false;
                return;
            }

            if(Report.ErrFunction.Flagged.IsHookUp)
            {
                this.Visible = false;
                return;
            }
        }
    }
}
