using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Motion_Sequence
{
    partial class clsTS
    {
        #region 類別變數
        /// <summary>
        /// 命令代碼
        /// </summary>
        private static int CmdIndex = 0x00;
        /// <summary>
        /// 是否正在執行命令旗標
        /// </summary>
        private static bool CmdDoing = false;
        /// <summary>
        /// Alarm視窗按鈕選項
        /// </summary>
        private static uint AlarmOpt = 0x00;
        /// <summary>
        /// 錯誤代碼
        /// </summary>
        private static int CmdErrNumber = 0x00;
        /// <summary>
        /// 相對移動的距離
        /// </summary>
        public static double Distance = 0x00;
        /// <summary>
        /// 軸卡狀態更新執行緒工作旗標
        /// </summary>
        public static bool ForceIOFlag = false;
        #endregion

        public static void Task()
        {
            int Cmd = 0x00;
            CmdIndex = 0x00;
            CmdDoing = false;
            CmdErrNumber = 0x00;
        
            while(true)
            {
                Thread.Sleep(150);
                if (CmdIndex == 0x00 || CmdIndex == 9999) continue;

                CmdDoing = true;
                Cmd = CmdIndex;
                CmdIndex = 0x00;
                switch (Cmd)
                {
                    case 1:
                        CmdDoing = false;
                        ForceIOFlag = true;
                        ServoTeach();
                        ForceIOFlag = false;
                        break;
                    case 2 :
                        CmdDoing = false;
                        ForceIOFlag = true;
                        Diag();
                        ForceIOFlag = false;
                        break;
                    case 3:
                        if (Manage.clsEQM.AutoRun == true) break;
                        Entity.clsDIO.SetDO(Entity.emDO.LightSwitch, true);
                        Manage.clsEQM.InitRun = true;
                        Manage.clsEQM.Status = Manage.emEQStates.Init;
                        Motion_Sequence.InitTask.Status = Manage.emMDStates.Init;
                        break;
                    case 4:
                        if (Manage.clsEQM.InitRun == true) break;
                        Entity.clsDIO.SetDO(Entity.emDO.LightSwitch, false);
                        if(MainControl.ucMainPage.GetEntity().Alarm)
                        {
                            Report.ErrFunction.UpdateAlarmHistory();
                            MainControl.ucMainPage.GetEntity().Alarm = false;
                        }
                        Manage.clsEQM.AutoRun = true;
                        Manage.clsEQM.Status = Manage.emEQStates.Run;
                        break;
                    case 5:
                        Manage.clsEQM.AutoRun = false;
                        Manage.clsEQM.OneCycleRun = false;
                        Manage.clsEQM.Status = Manage.emEQStates.Stop;
                        break;
                    case 6:
                        Report.ErrFunction.Clear(AlarmOpt);
                        break;
                    case 7:
                        if (Manage.clsEQM.InitRun == true) break;
                        if (Manage.clsEQM.CloseLot == false) Manage.clsEQM.CloseLot = true;
                        Manage.clsEQM.AutoRun = true;
                        Manage.clsEQM.Status = Manage.emEQStates.Run;
                        break;
                    case 8:

                        break;
                    case 9:
                        Entity.clsDIO.SetDO(Entity.emDO.LightSwitch, false);
                        if (Manage.clsEQM.OneCycleRun == false) Manage.clsEQM.OneCycleRun = true;
                        break;
                    case 10:
                        Entity.clsDIO.SetDO(Entity.emDO.LightSwitch, !Entity.clsDIO.GetDO(Entity.emDO.LightSwitch));
                        break;
                    default :
                        CmdDoing = false;
                        break;
                }
                CmdDoing = false;
            }
        }

        public static int DoCommand(int index)
        {
            CmdDoing = true;
            CmdIndex = index;
            int Err;
            while(CmdDoing)
            {
                Application.DoEvents();
                Thread.Sleep(50);
            }
            Err = CmdErrNumber;
            CmdErrNumber = 0x00;
            return Err;
        }

        public static int DoCommand(int index, uint opt)
        {
            AlarmOpt = opt;
            return DoCommand(index);
        }

        private static void Diag()
        {
            int Cmd = 0x00;
            bool flag = true;

            while(flag)
            {
                Thread.Sleep(150);
                if(CmdIndex == 0x00) continue;
                CmdDoing = true;
                Cmd = CmdIndex;
                if (Cmd >= 9999) { flag = false; continue; }
                CmdIndex = 0x00;
                if (!SYN_TEK.CMNet.IsRingWork)
                {
                    CmdErrNumber = Report.ErrDefine.MotionNetRingStop;
                    Manage.clsLogAdmin.AddLogItem(Manage.LogType.SEQ, Report.ErrFunction.GetText(CmdErrNumber, Manage.emLangType.ENG));
                    CmdDoing = false;
                    continue;
                }

                CmdDoing = false;
            }
            CmdDoing = false;
        }
    }
}
