using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYN_TEK;
using Manage;
using Module;

namespace Entity
{
    class clsStep00
    {
        public const int ID = (int)emAxID.Step00;
        public const byte INPTolerance = 7;
        private const double Distance = 50;
        private const byte HomeDir = 0;
        public const string Name = "Step00";

        public static Module.MotionCard Device = clsMotor.Devices[ID];

        public static void ResolutionLoad()
        {
            Device.Resolution = clsResolution.Read(ID);
        }

        #region 位置參數方法

        private static double[] m_Pos = new double[Enum.GetNames(typeof(PosItems)).Length]; //unit:Plues

        /// <summary>
        /// 讀取教導點位程序
        /// </summary>
        public static void PosRead()
        {
            clsPosition.Read(ID, Enum.GetNames(typeof(PosItems)), ref m_Pos);
        }

        /// <summary>
        /// 取得點位資料
        /// </summary>
        /// <param name="Item">點位名稱列舉</param>
        /// <param name="Pulse">布林旗標;true 傳回脈波,false 傳回換算後的位置</param>
        /// <returns></returns>
        public static double GetPos(PosItems Item, bool Pulse = false)
        {
            if (Pulse)
                return m_Pos[(int)Item];
            else
                return (m_Pos[(int)Item] * Device.Resolution);
        }

        /// <summary>
        /// 把數值存回陣列並更新點位資訊到資料庫
        /// </summary>
        /// <param name="Item">教導點位列舉</param>
        /// <param name="Value">教導點位數值</param>
        public static void SetPos(PosItems Item, int Value)
        {
            m_Pos[(int)Item] = Value;
            string PosName = Enum.GetName(typeof(PosItems), Item);
            clsPosition.Save(ID, PosName, Value);
        }
        #endregion

        #region 速度參數方法

        private static double[] m_Speed = new double[Enum.GetNames(typeof(SpeedItems)).Length]; //unit:um

        public static void SpeedLoad()
        {
            clsSpeedPara.Read(ID, Enum.GetNames(typeof(SpeedItems)), ref m_Speed);
        }

        /// <summary>
        /// 取得指定的速度參數資料
        /// </summary>
        /// <param name="Item">速度參數列舉</param>
        /// <returns></returns>
        public static double GetSpeed(SpeedItems Item)
        {   return m_Speed[(int)Item];}

        /// <summary>
        /// 儲存速度參數值
        /// </summary>
        /// <param name="it">速度參數列舉</param>
        /// <param name="value">數值</param>
        public static void SaveSpeedValue(SpeedItems Item, double value)
        {
            m_Speed[(int)Item] = value;
            string SpeedName = Enum.GetName(typeof(SpeedItems), Item);
            clsSpeedPara.Save(ID, SpeedName, value);
        }

        /// <summary>
        /// 速度參數預設值
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static double SpeedItemDefaultData(string Name)
        {
            SpeedItems it = (SpeedItems)Enum.Parse(typeof(SpeedItems), Name);
            double value = 0x00;
            switch (it)
            {
                case SpeedItems.HomeMaxVel:
                    value = 100;
                    break;
                case SpeedItems.HomeStrVel:
                    value = 10;
                    break;
                case SpeedItems.HomeTacc:
                    value = 0.1;
                    break;
                case SpeedItems.HomeTdcc:
                    value = 0.1;
                    break;
                case SpeedItems.JogMaxVel:
                    value = 200;
                    break;
                case SpeedItems.JogStrVel:
                    value = 10;
                    break;
                case SpeedItems.JogTacc:
                    value = 0.1;
                    break;
                case SpeedItems.JogTdcc:
                    value = 0.1;
                    break;
                case SpeedItems.MoveMaxVel:
                    value = 200;
                    break;
                case SpeedItems.MoveStrVel:
                    value = 10;
                    break;
                case SpeedItems.MoveTacc:
                    value = 0.06;
                    break;
                case SpeedItems.MoveTdcc:
                    value = 0.06;
                    break;
            }
            return value;
        }
        #endregion

        #region 設定馬達參數

        public static void SetMotionPara()
        {
            /// <summary>
            /// 設定位置計數值
            /// </summary>
            CMNet.CS_mnet_m1_set_position(CMNet.First_Ring, Device.SIP, 0);
            /// <summary>
            /// 設定命令計數值
            /// </summary>
            CMNet.CS_mnet_m1_set_command(CMNet.First_Ring, Device.SIP, 0);
            /// <summary>
            ///設定輸入脈波型式
            /// </summary>
            CMNet.CS_mnet_m1_set_pls_iptmode(0, Device.SIP, 2, 0);
            /// <summary>
            ///設定輸出脈波型式
            /// </summary>
            CMNet.CS_mnet_m1_set_pls_outmode(0, Device.SIP, 0);
            /// <summary>
            ///設定 Clear Count 工作模式
            /// </summary>
            CMNet.CS_mnet_m1_set_erc(0, Device.SIP, 1, 6, 3);
            /// <summary>
            ///設定 設定歸原模式 及 ORG EZ 準位
            /// </summary>
            CMNet.CS_mnet_m1_set_home_config(0, Device.SIP, 1, 1, 1, 0, 1);
            /// <summary>
            ///設定 ALM
            /// </summary>
            CMNet.CS_mnet_m1_set_alm(0, Device.SIP, 1, 1);
            /// <summary>
            ///設定輸入計數模式
            /// </summary>
            CMNet.CS_mnet_m1_set_feedback_src(0, Device.SIP, 1);
        }

        #endregion

        #region 復歸方法
        public static int Home(bool WaitDone = true)
        {
            Device.Homed = false;
            double MaxVel, StrVel, Tacc, Tdcc;
            int err = 0x00;
            clsLogAdmin.AddLogItem(LogType.SEQ, Name + "Start Home Moving ");
            if ((err = IOCheck()) != 0x00) return err;
            if ((err = SafetyCheck()) != 0x00) return err;

            MaxVel = GetSpeed(SpeedItems.HomeMaxVel);
            StrVel = GetSpeed(SpeedItems.HomeStrVel);
            Tacc = GetSpeed(SpeedItems.HomeTacc);
            Tdcc = GetSpeed(SpeedItems.HomeTdcc);
            int timeout = TimeOut.GetValue(TimeOut.Items.Axis00SeachHomeTimeout);

            if (!WaitDone)
            {
                Device.Serach_Home_Move(StrVel, MaxVel, HomeDir, Tacc, Tdcc, Distance);
                return 0x00;
            }

            if (!Device.Serach_Home_Move(StrVel, MaxVel, HomeDir, Tacc, Tdcc, timeout, 200, Distance))
            {
                err = Report.ErrDefine.InitFail(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            if (Device.IO_Alarm)
            {
                err = Report.ErrDefine.Alarm(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return 0x00;
            }
            clsLogAdmin.AddLogItem(LogType.SEQ, Name + " Home Move Done ! ");
            return 0x00;
        }

        #endregion

        #region 絕對點位移動操作

        /// <summary>
        /// 馬達移動到指定點位
        /// </summary>
        /// <returns></returns>
        public static int MoveToTarget(double target)
        {
            double MaxVel = GetSpeed(SpeedItems.MoveMaxVel); ;
            double StrVel = GetSpeed(SpeedItems.MoveStrVel);
            double Tacc = GetSpeed(SpeedItems.MoveTacc);
            double Tdcc = GetSpeed(SpeedItems.MoveTdcc);

            return ABSMove(target, StrVel, MaxVel, Tacc, Tdcc);
        }

        /// <summary>
        /// 絕對點位移動操作
        /// </summary>
        /// <param name="target">點位資料,單位：pulse/s</param>
        /// <param name="MaxVel">最大速度,單位：pulse/s</param>
        /// <param name="StrVel">起始速度,單位：pulse/s</param>
        /// <param name="Tacc">加速時間,單位：sec</param>
        /// <param name="Tdcc">減速時間,單位：sec</param>
        /// <returns></returns>
        public static int ABSMove(double target, double StrVel, double MaxVel, double Tacc, double Tdcc)
        {
            int err = 0x00;
            double Dist = Math.Abs(Device.CurPosition - target);
            if(!Device.Homed)
            {
                err = Report.ErrDefine.NotInit(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }
            if ((err = IOCheck()) != 0x00) return err;
            if ((err = SafetyCheck()) != 0x00) return err;
            int timeout = TimeOut.GetMoveTimeOutData(StrVel, MaxVel, Tacc, Tdcc, Dist);

            if (!Device.ABSMove(StrVel, MaxVel, target, Tacc, Tdcc, timeout, 50))
            {
                err = Report.ErrDefine.NotReachTarget(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }
            if ((err = IOCheck()) != 0x00) return err;
            clsLogAdmin.AddLogItem(LogType.SEQ, Name + " Move Done ! ");
            return 0x00;
        }

        #endregion

        #region 相對點位移動操作

        public static int RELMove(double Dist)
        {
            double MaxVel = GetSpeed(SpeedItems.MoveMaxVel);
            double StrVel = GetSpeed(SpeedItems.MoveStrVel);
            double Tacc = GetSpeed(SpeedItems.MoveTacc);
            double Tdcc = GetSpeed(SpeedItems.MoveTdcc);

            return RELMove(Dist, MaxVel, StrVel, Tacc, Tdcc);
        }

        /// <summary>
        /// 相對距離移動操作
        /// </summary>
        /// <param name="Dist">距離,單位:Angle</param>
        /// <param name="MaxVel">最大速度,單位:angle/sec</param>
        /// <param name="StrVel">起始速度,單位:angle/sec</param>
        /// <param name="Tacc">加速時間,單位:sec</param>
        /// <param name="Tdcc">減速時間,單位:sec</param>
        /// <returns></returns>
        public static int RELMove(double Dist, double MaxVel, double StrVel, double Tacc, double Tdcc)
        {
            int err = 0x00;
            string Message = string.Format(Name + " Start REL Moving,Dist = {0}", Dist);
            clsLogAdmin.AddLogItem(LogType.SEQ, Message);
            if(!Device.Homed)
            {
                err = Report.ErrDefine.NotInit(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }
            if ((err = IOCheck()) != 0x00) return err;
            if ((err = SafetyCheck()) != 0x00) return err;
            int timeout = TimeOut.GetMoveTimeOutData(StrVel, MaxVel, Tacc, Tdcc, Dist);
            if(!Device.RELMove(StrVel, MaxVel, Dist, Tacc, Tdcc, timeout, 50))
            {
                err = Report.ErrDefine.NotReachTarget(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }
            if ((err = IOCheck()) != 0x00) return err;
            clsLogAdmin.AddLogItem(LogType.SEQ, Name + "Move Done ! ");
            return 0x00;
        }
        #endregion

        /// <summary>
        /// 驅動器激磁控制
        /// </summary>
        /// <param name="value"></param>
        public static void SVON(bool value)
        {
            ushort On_Off;
            switch (Device.MotorType)
            {
                case EnMotorType.Servo:
                    On_Off = (ushort)(value ? 1 : 0);
                    Device.SVON(On_Off);
                    break;
                case EnMotorType.Step:
                    On_Off = (ushort)(value ? 0 : 1);
                    Device.SVON(On_Off);
                    Device.StepExcitationRelex = !value;
                    break;
            }
        }

        public static int IOCheck()
        {
            uint IO_Status = Device.IOStatus;
            int err = 0x00;

            if((IO_Status & (uint)EnIOMask.Ready) == 0x00)
            {
                err = Report.ErrDefine.NotReady(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            if((IO_Status & (uint)EnIOMask.SVON) == 0x00)
            {
                err = Report.ErrDefine.NotEnable(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            if((IO_Status & (uint)EnIOMask.Alarm) > 0x00)
            {
                err = Report.ErrDefine.Alarm(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            if((IO_Status & (uint)EnIOMask.PEL) > 0x00)
            {
                err = Report.ErrDefine.LimitP(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            if((IO_Status & (uint)EnIOMask.NEL) > 0x00)
            {
                err = Report.ErrDefine.LimitN(ID);
                clsLogAdmin.AddLogItem(LogType.SEQ, Report.ErrFunction.GetText(err, emLangType.ENG));
                return err;
            }

            return err;
        }

        public static int SafetyCheck()
        {
            return 0x00;
        }


    }
}
