using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Module;
using SYN_TEK;

namespace Entity
{

    #region DI定義

    /// <summary>
    /// IO模組輸入腳位列舉
    /// </summary>
    public enum emDI : ushort
    {
        /// <summary>
        /// 緊急停止按鈕
        /// </summary>
        stop = 000,
        /// <summary>
        /// 機台氣壓偵測
        /// </summary>
        airdetect = 001,
        /// <summary>
        /// 安全門偵測
        /// </summary>
        gatedetect = 003,
        /// <summary>
        /// 手臂真空建立
        /// </summary>
        buildvacuum = 004,
        /// <summary>
        /// 自動料片偵測1
        /// </summary>
        waferdetect1 = 005,
        /// <summary>
        /// 雷射就緒
        /// </summary>
        laserready = 010,
        /// <summary>
        /// 雷射打印結束
        /// </summary>
        laserdone = 011,
        /// <summary>
        /// 雷射結批
        /// </summary>
        laserbatch = 012,
        /// <summary>
        /// 自動料片偵測2
        /// </summary>
        waferdetect2 = 015,
        /// <summary>
        /// 料盒1偵測
        /// </summary>
        ldbox1 = 100,
        /// <summary>
        /// 料盒2偵測
        /// </summary>
        ldbox2 = 101,
        /// <summary>
        /// 料盒3偵測
        /// </summary>
        ulbox1 = 104,
        /// <summary>
        /// 料盒4偵測
        /// </summary>
        ulbox2 = 105,
        /// <summary>
        /// 料盒1確認按鈕
        /// </summary>
        ldbox1firm = 110,
        /// <summary>
        /// 料盒2確認按鈕
        /// </summary>
        ldbox2firm = 111,
        /// <summary>
        /// 料盒3確認按鈕
        /// </summary>
        ulbox1firm = 114,
        /// <summary>
        /// 料盒4確認按鈕
        /// </summary>
        ulbox2firm = 115,
    };

    #endregion

    #region DO定義

    /// <summary>
    /// IO模組輸出腳位列舉
    /// </summary>
    public enum emDO : ushort
    {
        /// <summary>
        /// 三色燈-紅燈
        /// </summary>
        LampRed = 020,
        /// <summary>
        /// 三色燈-黃燈
        /// </summary>
        LampYellow = 021,
        /// <summary>
        /// 三色燈-綠燈
        /// </summary>
        LampGreed = 022,
        /// <summary>
        /// 蜂嗚器
        /// </summary>
        Buzzer = 023,
        /// <summary>
        /// 日光燈
        /// </summary>
        Lamp = 024,
        /// <summary>
        /// 手臂真空電磁閥
        /// </summary>
        armrelay = 026,
        /// <summary>
        /// 集塵吹氣電磁閥
        /// </summary>
        dustrelay = 027,
        /// <summary>
        /// 雷射觸發(單面)
        /// </summary>
        lasersig = 030,
        /// <summary>
        /// 真空馬達電源
        /// </summary>
        vacuummotor = 032,
        /// <summary>
        /// 鼓風機電源
        /// </summary>
        blower = 033,
        /// <summary>
        /// 手臂緊急停止
        /// </summary>
        armstop = 037,
        /// <summary>
        /// 料盒1按鈕指示燈
        /// </summary>
        ldboxsign1 = 120,
        /// <summary>
        /// 料盒2按鈕指示燈
        /// </summary>
        ldboxsign2 = 121,
        /// <summary>
        /// 料盒3按鈕指示燈
        /// </summary>
        ulboxsign1 = 124,
        /// <summary>
        /// 料盒4按鈕指示燈
        /// </summary>
        ulboxsign2 = 125,
        /// <summary>
        /// 雷射觸發(正面)
        /// </summary>
        lasertrigF = 130,
        /// <summary>
        /// 雷射觸發(反面)
        /// </summary>
        lasertrigB = 131,

        LightSwitch
    };

    #endregion

    class clsDIO
    {
        private const ushort Ring = CMNet.First_Ring;

        public static List<DIO32Card> DeviceList = new List<DIO32Card>();

        public static void Init()
        {
            DIO32Card Item;
            Item = new DIO32Card(0, EnDIOType.DIO_16Bit);
            DeviceList.Add(Item);
            Item = new DIO32Card(1, EnDIOType.DIO_16Bit);
            DeviceList.Add(Item);
            // CreationIODataTable();
        }

        /// <summary>
        /// 取得輸入狀態
        /// </summary>
        /// <param name="_Target"></param>
        /// <returns></returns>
        public static bool GetDI(emDI _Target)
        {
            ushort Target = (ushort)_Target;
            byte SIP = (byte)(Target / 100);
            byte Port = (byte)(Target % 100 / 10);
            byte Bit = (byte)(Target % 100 % 10);
            return DeviceList[SIP].GetInPut(Port, Bit);
        }

        /// <summary>
        /// 直接取得IO模組上的輸入布林值
        /// </summary>
        /// <param name="Sip">IO模組的IP</param>
        /// <param name="Port">埠口</param>
        /// <param name="Bit">腳位</param>
        /// <returns></returns>
        public static bool GetDIByCmd(emDI _Target)
        {
            ushort Target = (ushort)_Target;
            byte SIP = (byte)(Target / 100);
            byte Port = (byte)(Target % 100 / 10);
            byte Bit = (byte)(Target % 100 % 10);
            byte On_Off = 0x00;
            CMNet.CS_mnet_bit_io_input(Ring, SIP, Port, Bit, ref On_Off);
            return On_Off == 0x01 ? true : false;
        }

        /// <summary>
        /// 取得輸出狀態
        /// </summary>
        /// <param name="_Target">腳位列舉</param>
        /// <returns></returns>
        public static bool GetDO(emDO _Target)
        {
            ushort Target = (ushort)_Target;
            byte SIP = (byte)(Target / 100);
            byte Port = (byte)(Target % 100 / 10);
            byte Bit = (byte)(Target % 100 % 10);
            return DeviceList[SIP].GetOutPut(Port, Bit);
        }

        /// <summary>
        /// 設定輸出
        /// </summary>
        /// <param name="_Target">腳位列舉</param>
        /// <param name="_value">true;false</param>
        public static void SetDO(emDO _Target, bool _value)
        {
            ushort Target = (ushort)_Target;
            byte SIP = (byte)(Target / 100);
            byte Port = (byte)(Target % 100 / 10);
            byte Bit = (byte)(Target % 100 % 10);
            DeviceList[SIP].SetOutPut(Port, Bit, _value);
        }

        /// <summary>
        /// 直接設定IO模組上的輸出狀態
        /// </summary>
        /// <param name="_Target"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static void SetDOByCmd(emDO _Target, bool _value)
        {
            ushort Target = (ushort)_Target;
            byte SIP = (byte)(Target / 100);
            byte Port = (byte)(Target % 100 / 10);
            byte Bit = (byte)(Target % 100 % 10);
            byte On_Off = (byte)(_value ? 1 : 0);
            DeviceList[SIP].SetOutPut(Port, Bit, _value);
            CMNet.CS_mnet_bit_io_output(Ring, SIP, Port, Bit, On_Off);
        }

        public static void DoWork()
        {
            while (true)
            {
                Thread.Sleep(15);
                if (!CMNet.IsRingWork)
                {
                    Thread.Sleep(200);
                    continue;
                }
                Update();
            }
        }

        private static void Update()
        {
            foreach (Module.DIO32Card Item in DeviceList)
            {
                Item.UpDate();
            }
        }
    }
}
