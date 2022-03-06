using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SYN_TEK;
using Module;

namespace Entity
{
    /// <summary>
    /// 系統設定頁面命令
    /// </summary>
    public enum SysParManualCmd
    {

    }

    public enum emAxID
    {
        Step00 = 0,
    }

    /// <summary>
    /// 軸控教導頁面命令列舉
    /// </summary>
    public enum MotionTeachCmd
    {
        /// <summary>
        /// 平台X軸SVON
        /// </summary>
        Ax00SVON = 1001,
        /// <summary>
        /// 平台X軸復歸
        /// </summary>
        Ax00Home,
        /// <summary>
        /// 作業平台X軸移動到鑽頭戳黏土的位置
        /// </summary>
        Ax00MoveToDrillPokeClayPos,
        /// <summary>
        /// 作業平台X軸移動到鑽頭測高的位置
        /// </summary>
        Ax00MoveToDrillDetectHeightPos,
        /// <summary>
        /// 作業平台X軸移動到取放料盤的位置
        /// </summary>
        Ax00MoveToPnPTrayPos,
        /// <summary>
        /// 作業平台X軸移動到手動取放料盤位置
        /// </summary>
        Ax00MoveToManualTakePos,
        /// <summary>
        /// 作業平台Y軸移動到鑽頭戳黏土的位置
        /// </summary>
        Ax01MoveToDrillPokeClayPos,
        /// <summary>
        /// 作業平台Y軸移動到鑽頭測高的位置
        /// </summary>
        Ax01MoveToDrillDetectHeightPos,
        /// <summary>
        /// 作業平台Y軸移動到取放料盤的位置
        /// </summary>
        Ax01MoveToPnPTrayPos,
        /// <summary>
        /// 作業平台Y軸移動到手動取放料盤位置
        /// </summary>
        Ax01MoveToManualTakePos,
        /// <summary>
        /// 鑽頭移動到待命位置
        /// </summary>
        Ax02MoveToStandbyPos,
        /// <summary>
        /// 鑽頭移動到更換鑽頭的位置
        /// </summary>
        Ax02MoveToChangeKitPos,
        /// <summary>
        /// 鑽頭移動到戳黏土位置
        /// </summary>
        Ax02MoveToPokeClayPos,
        /// <summary>
        /// 鑽頭移動到接觸平台位置
        /// </summary>
        Ax02MoveToTouchTablePos,
        /// <summary>
        /// 搬移臂移動到平台取料盤位置
        /// </summary>
        Ax03MoveToPnPTrayPos,
        /// <summary>
        /// 搬移臂移動到入料盒位置
        /// </summary>
        Ax03MoveToLoadCSTPos,
        /// <summary>
        /// 搬移臂移動到收料盒位置
        /// </summary>
        Ax03MoveToUnLoadCSTPos,
        /// <summary>
        /// 平台U軸移動到平台基準位置
        /// </summary>
        Ax04MoveTo0DegPos,
        /// <summary>
        /// 探針Z軸剎車控制
        /// </summary>
        Ax05BreakOnOff,
        /// <summary>
        /// 量測Z軸移動到更換探針的位置
        /// </summary>
        Ax05MoveToChangeKitPos,
        /// <summary>
        /// 量測Z軸移動到待命的位置
        /// </summary>
        Ax05MoveToStandbyPos,
        /// <summary>
        /// 量測Z軸移動到探針接觸平台的位置
        /// </summary>
        Ax05MoveToTouchTablePos,
        /// <summary>
        /// 鑽頭X軸移動到待命位置
        /// </summary>
        Ax06MoveToStandbyPos,
        /// <summary>
        /// 搬移臂吸嘴上下氣缸向下
        /// </summary>
        CarryArmDown,
        /// <summary>
        /// 搬移臂吸嘴上下氣缸向上
        /// </summary>
        CarryArmUP,
        /// <summary>
        /// 搬移臂入料吸嘴真空吸取
        /// </summary>
        PickerVacuum,
        /// <summary>
        /// 搬移臂入料吸嘴吹氣
        /// </summary>
        PickerBlow,
        /// <summary>
        /// 入料料盒產品頂昇馬達往上移動-直到上極限ON
        /// </summary>
        LDLifterUpToLimit,
        /// <summary>
        /// 入料料盒產品頂昇馬達往下移動-直到下極限ON
        /// </summary>
        LDLifterDownToLimit,
        /// <summary>
        /// 收料料盒產品頂昇馬達往上移動-直到上極限ON
        /// </summary>
        ULDLifterMoveToUpLimit,
        /// <summary>
        /// 入料料盒產品頂昇馬達往下移動-直到下極限ON
        /// </summary>
        ULDLifterDownToLimit,
        /// <summary>
        /// 作業平台真空吸取
        /// </summary>
        TableVacuum,
        /// <summary>
        /// 作業平台破真空吹氣
        /// </summary>
        TableBlow,
        /// <summary>
        /// 入料料盒防止黏料吹氣
        /// </summary>
        LDCSTBlow,
        /// <summary>
        /// 鑽頭控制器開關
        /// </summary>
        DrillControlOnOff,
        /// <summary>
        /// 鑽頭測高動作
        /// </summary>
        DrillDetectHeight,

    };

    public enum SpeedItems
    {
        HomeMaxVel = 0,
        HomeStrVel = 1,
        HomeTacc = 2,
        HomeTdcc = 3,
        MoveMaxVel = 4,
        MoveStrVel = 5,
        MoveTacc = 6,
        MoveTdcc = 7,
        JogMaxVel = 8,
        JogStrVel = 9,
        JogTacc = 10,
        JogTdcc = 11,
    }

    public enum PosItems
    {
        /// <summary>
        /// A點位
        /// </summary>
        LDMoveXA = 0,
        /// <summary>
        /// B點位
        /// </summary>
        LDMoveXB = 1,
        /// <summary>
        /// C點位
        /// </summary>
        LDMoveXC = 2,
    }

    class clsMotor
    {
        public static List<MotionCard> Devices = new List<MotionCard>();

        /// <summary>
        /// 軸卡初始化
        /// </summary>
        public static void Init()
        {
            DeviceInit();
            if (CMNet.IsDebugMode == true) return;
            if (CMNet.IsRingWork == false) return;
            SetMotionInit();
        }

        /// <summary>
        /// 初始化DeviceList
        /// </summary>
        private static void DeviceInit()
        {
            MotionCard Item = new MotionCard();

            Item.DeviceType = EnAxisCardType.M1;
            Item.MotorType = EnMotorType.Step;
            Item.ReductionRatio = 1;
            Item.AxisDir = EnAxisDir.U;
            Item.SIP = 0x0A;
            Item.Port = 0;
            Devices.Add(Item);
        }

        ///<summary>
        ///馬達參數設定
        ///</summary>
        private static void SetMotionInit()
        {
            clsStep00.SetMotionPara();
        }
    }
}
