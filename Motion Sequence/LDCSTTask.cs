using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Motion_Sequence
{
    class LDCSTTask
    {
        private const string Name = "clsFilpPnPTask";
        public static Manage.emMDStates Status = Manage.emMDStates.Null;
        public static Report.clsErrFlag Error;

        public static bool Empty
        {
            set;
            get;
        }

        public static uint Step
        {
            get;
            private set;
        }

        private static void SetError(int Err, uint opt, uint next_step, DateTime t)
        {
            Step = next_step;
            Report.ErrFunction.HookUp(Name, Err, opt, t);
        }

        public static void Task()
        {
            Error = Report.ErrFunction.SingIn(Name);
            int Err = 0x00;

            while(true)
            {
                Thread.Sleep(15);

                if (InitTask.Status != Manage.emMDStates.Ready) WaitInit();

                if (!SYN_TEK.CMNet.IsRingWork || (!Manage.clsEQM.AutoRun && !Manage.clsEQM.OneCycleRun) ||
                    Report.ErrFunction.Flagged.IsHookUp)
                {
                    Thread.Sleep(200);
                    continue;
                }

                switch(Step)
                {
                    case 0:
                        //if (Entity.clsDIO.GetDI()) Step = 0x01;
                        break;
                    case 1:

                        Step = 0x00;
                        break;
                }
            }
        }

        private static void WaitInit()
        {
            while (InitTask.Status != Manage.emMDStates.Ready)
            {
                ClearFlag();
                Thread.Sleep(200);
            }
            Step = 0x00;
            Status = Manage.emMDStates.Busy;
        }

        private static void ClearFlag()
        {
            Error.Clear();
            Step = 0x00;
            Status = Manage.emMDStates.Init;
            Empty = false;
        }
    }
}
