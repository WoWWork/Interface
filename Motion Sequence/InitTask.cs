using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Motion_Sequence
{
    class InitTask
    {
        private const string Name = "clsInitTask";

        public static Manage.emMDStates Status = Manage.emMDStates.Busy;
        public static uint Step = 0x01;
        public static Report.clsErrFlag Error;
        public static string InitMessage;
        public static uint ProcessValue;

        private static void SetError(int err, uint opt, uint next_step, DateTime t)
        {
            Step = next_step;
            Report.ErrFunction.HookUp(Name, err, opt, t);
            Manage.clsEQM.InitRun = false;
            Manage.clsEQM.Status = Manage.emEQStates.NoInit;
        }
        private static void ClearFlag()
        {
            Error.Clear();
            Step = 0x00;
        }

        public static void Task()
        {
            Error = Report.ErrFunction.SingIn(Name);

            int Err = 0x00;

            while(true)
            {
                Thread.Sleep(200);
                if (!SYN_TEK.CMNet.IsRingWork) continue;
                if (Manage.clsEQM.AutoRun) continue;
                if (!Manage.clsEQM.InitRun) continue;

                switch (Step)
                {
                    case 0:
                        InitMessage = "";
                        Source.DataSQL.ConnectOpen = false;
                        Step = 0x01;
                        Thread.Sleep(5000);
                        break;
                }
            }
        }
    }
}
