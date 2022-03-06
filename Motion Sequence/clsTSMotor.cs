using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Entity;

namespace Motion_Sequence
{
    partial class clsTS
    {
        private static void ServoTeach()
        {
            int Cmd = 0x00;
            bool flag = true;

            while(flag)
            {
                Thread.Sleep(150);
                if (CmdIndex == 0) continue;
                CmdDoing = true;
                Cmd = CmdIndex;
                if (Cmd >= 9999) { flag = false; continue; }
                CmdIndex = 0x00;
                if(!SYN_TEK.CMNet.IsRingWork)
                {
                    CmdErrNumber = Report.ErrDefine.MotionNetRingStop;
                    Manage.clsLogAdmin.AddLogItem(Manage.LogType.SEQ, Report.ErrFunction.GetText(CmdErrNumber, Manage.emLangType.ENG));
                    CmdDoing = false;
                    continue;
                }

                switch(MainControl.ucMotionTeach.SelectPageIndex)
                {
                    case 0:
                        TeachLoadZone((MotionTeachCmd)Cmd);
                        break;
                    case 1:

                        break;
                }

                CmdDoing = false;
            }
            CmdDoing = false;
        }

        private static void TeachLoadZone(MotionTeachCmd Cmd)
        {
            switch(Cmd)
            {
                case MotionTeachCmd.Ax00Home:
                    CmdErrNumber = clsStep00.Home();
                    break;
                case MotionTeachCmd.Ax00MoveToDrillDetectHeightPos:

                    break;
            }
        }
    }
}
