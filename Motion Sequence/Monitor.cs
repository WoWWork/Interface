using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Motion_Sequence
{
    class Monitor
    {
        private const string Name = "clsEQMonitor";
        private static Report.clsErrFlag Error;

        private static void SetError(int err, uint opt, DateTime t)
        {
            Report.ErrFunction.HookUp(Name, err, opt, t);
        }

        public static void Task()
        {
            int err;

            Error = Report.ErrFunction.SingIn(Name);

            while (true)
            {
                Thread.Sleep(100);

                if (!SYN_TEK.CMNet.IsRingWork) continue;

                if ((err = SafetyCheck()) != 0x00)
                {
                    SetError(err, Report.ErrorType.Retry, DateTime.Now);
                    while (Error.IsHookUp) Thread.Sleep(500);
                }

            }
        }

        public static int SafetyCheck()
        {
            //#region //==========  氣壓偵測 ==============
            //if (clsDIO.GetDI(emDI.AirSource) == false) return (clsErrNo.IO.AirSourceLowPressure);
            //#endregion

            //#region 安全門偵測
            //if (((clsEQM.AutoRun == true) || (clsEQM.InitRun == true))
            //    && (!clsSysPar.SaftyDoorByPass))
            //{
            //    if (clsDIO.GetDI(emDI.SaftyDoorClose) == false) return (clsErrNo.IO.SaftyDoorOpen);
            //}
            //#endregion
            return 0x00;
        }
    }

}
