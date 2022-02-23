using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report
{
    class ErrDefine
    {
        #region Alarm常數碼

        private const int Axis00_Not_Enable = 2001;
        private const int Axis00_Not_Ready = 2002;
        private const int Axis00_Alarm = 2003;
        private const int Axis00_Limit_P = 2004;
        private const int Axis00_Limit_N = 2005;
        private const int Axis00_Not_Init = 2006;
        private const int Axis00_Seach_Home_Sensor_Timeout = 2007;
        private const int Axis00_Home_Sensor_Still_ON = 2008;
        private const int Axis00_Init_Failure = 2009;
        private const int Axis00_Not_Reach_Target_Position = 2010;

        //private const int Axis01_Not_Enable = 2021;
        //private const int Axis01_Not_Ready = 2022;
        //private const int Axis01_Alarm = 2023;
        //private const int Axis01_Limit_P = 2024;
        //private const int Axis01_Limit_N = 2025;
        //private const int Axis01_Not_Init = 2026;
        //private const int Axis01_Seach_Home_Sensor_Timeout = 2027;
        //private const int Axis01_Home_Sensor_Still_ON = 2028;
        //private const int Axis01_Init_Failure = 2029;
        //private const int Axis01_Not_Reach_Target_Position = 2030;

        //private const int Axis02_Not_Enable = 2041;
        //private const int Axis02_Not_Ready = 2042;
        //private const int Axis02_Alarm = 2043;
        //private const int Axis02_Limit_P = 2044;
        //private const int Axis02_Limit_N = 2045;
        //private const int Axis02_Not_Init = 2046;
        //private const int Axis02_Seach_Home_Sensor_Timeout = 2047;
        //private const int Axis02_Home_Sensor_Still_ON = 2048;
        //private const int Axis02_Init_Failure = 2049;
        //private const int Axis02_Not_Reach_Target_Position = 2050;

        //private const int Axis03_Not_Enable = 2061;
        //private const int Axis03_Not_Ready = 2062;
        //private const int Axis03_Alarm = 2063;
        //private const int Axis03_Limit_P = 2064;
        //private const int Axis03_Limit_N = 2065;
        //private const int Axis03_Not_Init = 2066;
        //private const int Axis03_Seach_Home_Sensor_Timeout = 2067;
        //private const int Axis03_Home_Sensor_Still_ON = 2068;
        //private const int Axis03_Init_Failure = 2069;
        //private const int Axis03_Not_Reach_Target_Position = 2070;

        //private const int Axis04_Not_Enable = 2081;
        //private const int Axis04_Not_Ready = 2082;
        //private const int Axis04_Alarm = 2083;
        //private const int Axis04_Limit_P = 2084;
        //private const int Axis04_Limit_N = 2085;
        //private const int Axis04_Not_Init = 2086;
        //private const int Axis04_Seach_Home_Sensor_Timeout = 2087;
        //private const int Axis04_Home_Sensor_Still_ON = 2088;
        //private const int Axis04_Init_Failure = 2089;
        //private const int Axis04_Not_Reach_Target_Position = 2090;

        //private const int Axis05_Not_Enable = 2101;
        //private const int Axis05_Not_Ready = 2102;
        //private const int Axis05_Alarm = 2103;
        //private const int Axis05_Limit_P = 2104;
        //private const int Axis05_Limit_N = 2105;
        //private const int Axis05_Not_Init = 2106;
        //private const int Axis05_Seach_Home_Sensor_Timeout = 2107;
        //private const int Axis05_Home_Sensor_Still_ON = 2108;
        //private const int Axis05_Init_Failure = 2109;
        //private const int Axis05_Not_Reach_Target_Position = 2110;

        //private const int Axis06_Not_Enable = 2121;
        //private const int Axis06_Not_Ready = 2122;
        //private const int Axis06_Alarm = 2123;
        //private const int Axis06_Limit_P = 2124;
        //private const int Axis06_Limit_N = 2125;
        //private const int Axis06_Not_Init = 2126;
        //private const int Axis06_Seach_Home_Sensor_Timeout = 2127;
        //private const int Axis06_Home_Sensor_Still_ON = 2128;
        //private const int Axis06_Init_Failure = 2129;
        //private const int Axis06_Not_Reach_Target_Position = 2130;

        //private const int Axis07_Not_Enable = 2141;
        //private const int Axis07_Not_Ready = 2142;
        //private const int Axis07_Alarm = 2143;
        //private const int Axis07_Limit_P = 2144;
        //private const int Axis07_Limit_N = 2145;
        //private const int Axis07_Not_Init = 2146;
        //private const int Axis07_Seach_Home_Sensor_Timeout = 2147;
        //private const int Axis07_Home_Sensor_Still_ON = 2148;
        //private const int Axis07_Init_Failure = 2149;
        //private const int Axis07_Not_Reach_Target_Position = 2150;

        //private const int Axis08_Not_Enable = 2161;
        //private const int Axis08_Not_Ready = 2162;
        //private const int Axis08_Alarm = 2163;
        //private const int Axis08_Limit_P = 2164;
        //private const int Axis08_Limit_N = 2165;
        //private const int Axis08_Not_Init = 2166;
        //private const int Axis08_Seach_Home_Sensor_Timeout = 2167;
        //private const int Axis08_Home_Sensor_Still_ON = 2168;
        //private const int Axis08_Init_Failure = 2169;
        //private const int Axis08_Not_Reach_Target_Position = 2170;

        //private const int Axis09_Not_Enable = 2181;
        //private const int Axis09_Not_Ready = 2182;
        //private const int Axis09_Alarm = 2183;
        //private const int Axis09_Limit_P = 2184;
        //private const int Axis09_Limit_N = 2185;
        //private const int Axis09_Not_Init = 2186;
        //private const int Axis09_Seach_Home_Sensor_Timeout = 2187;
        //private const int Axis09_Home_Sensor_Still_ON = 2188;
        //private const int Axis09_Init_Failure = 2189;
        //private const int Axis09_Not_Reach_Target_Position = 2190;

        //private const int Axis10_Not_Enable = 2201;
        //private const int Axis10_Not_Ready = 2202;
        //private const int Axis10_Alarm = 2203;
        //private const int Axis10_Limit_P = 2204;
        //private const int Axis10_Limit_N = 2205;
        //private const int Axis10_Not_Init = 2206;
        //private const int Axis10_Seach_Home_Sensor_Timeout = 2207;
        //private const int Axis10_Home_Sensor_Still_ON = 2208;
        //private const int Axis10_Init_Failure = 2209;
        //private const int Axis10_Not_Reach_Target_Position = 2210;

        //private const int Axis11_Not_Enable = 2221;
        //private const int Axis11_Not_Ready = 2222;
        //private const int Axis11_Alarm = 2223;
        //private const int Axis11_Limit_P = 2224;
        //private const int Axis11_Limit_N = 2225;
        //private const int Axis11_Not_Init = 2226;
        //private const int Axis11_Seach_Home_Sensor_Timeout = 2227;
        //private const int Axis11_Home_Sensor_Still_ON = 2228;
        //private const int Axis11_Init_Failure = 2229;
        //private const int Axis11_Not_Reach_Target_Position = 2230;

        //private const int Axis12_Not_Enable = 2241;
        //private const int Axis12_Not_Ready = 2242;
        //private const int Axis12_Alarm = 2243;
        //private const int Axis12_Limit_P = 2244;
        //private const int Axis12_Limit_N = 2245;
        //private const int Axis12_Not_Init = 2246;
        //private const int Axis12_Seach_Home_Sensor_Timeout = 2247;
        //private const int Axis12_Home_Sensor_Still_ON = 2248;
        //private const int Axis12_Init_Failure = 2249;
        //private const int Axis12_Not_Reach_Target_Position = 2250;

        //private const int Axis13_Not_Enable = 2261;
        //private const int Axis13_Not_Ready = 2262;
        //private const int Axis13_Alarm = 2263;
        //private const int Axis13_Limit_P = 2264;
        //private const int Axis13_Limit_N = 2265;
        //private const int Axis13_Not_Init = 2266;
        //private const int Axis13_Seach_Home_Sensor_Timeout = 2267;
        //private const int Axis13_Home_Sensor_Still_ON = 2268;
        //private const int Axis13_Init_Failure = 2269;
        //private const int Axis13_Not_Reach_Target_Position = 2270;

        //private const int Axis14_Not_Enable = 2281;
        //private const int Axis14_Not_Ready = 2282;
        //private const int Axis14_Alarm = 2283;
        //private const int Axis14_Limit_P = 2284;
        //private const int Axis14_Limit_N = 2285;
        //private const int Axis14_Not_Init = 2286;
        //private const int Axis14_Seach_Home_Sensor_Timeout = 2287;
        //private const int Axis14_Home_Sensor_Still_ON = 2288;
        //private const int Axis14_Init_Failure = 2289;
        //private const int Axis14_Not_Reach_Target_Position = 2290;

        //private const int Axis15_Not_Enable = 2301;
        //private const int Axis15_Not_Ready = 2302;
        //private const int Axis15_Alarm = 2303;
        //private const int Axis15_Limit_P = 2304;
        //private const int Axis15_Limit_N = 2305;
        //private const int Axis15_Not_Init = 2306;
        //private const int Axis15_Seach_Home_Sensor_Timeout = 2307;
        //private const int Axis15_Home_Sensor_Still_ON = 2308;
        //private const int Axis15_Init_Failure = 2309;
        //private const int Axis15_Not_Reach_Target_Position = 2310;

        //private const int Axis16_Not_Enable = 2321;
        //private const int Axis16_Not_Ready = 2322;
        //private const int Axis16_Alarm = 2323;
        //private const int Axis16_Limit_P = 2324;
        //private const int Axis16_Limit_N = 2325;
        //private const int Axis16_Not_Init = 2326;
        //private const int Axis16_Seach_Home_Sensor_Timeout = 2327;
        //private const int Axis16_Home_Sensor_Still_ON = 2328;
        //private const int Axis16_Init_Failure = 2329;
        //private const int Axis16_Not_Reach_Target_Position = 2330;

        //private const int Axis17_Not_Enable = 2341;
        //private const int Axis17_Not_Ready = 2342;
        //private const int Axis17_Alarm = 2343;
        //private const int Axis17_Limit_P = 2344;
        //private const int Axis17_Limit_N = 2345;
        //private const int Axis17_Not_Init = 2346;
        //private const int Axis17_Seach_Home_Sensor_Timeout = 2347;
        //private const int Axis17_Home_Sensor_Still_ON = 2348;
        //private const int Axis17_Init_Failure = 2349;
        //private const int Axis17_Not_Reach_Target_Position = 2350;

        //private const int Axis18_Not_Enable = 2361;
        //private const int Axis18_Not_Ready = 2362;
        //private const int Axis18_Alarm = 2363;
        //private const int Axis18_Limit_P = 2364;
        //private const int Axis18_Limit_N = 2365;
        //private const int Axis18_Not_Init = 2366;
        //private const int Axis18_Seach_Home_Sensor_Timeout = 2367;
        //private const int Axis18_Home_Sensor_Still_ON = 2368;
        //private const int Axis18_Init_Failure = 2369;
        //private const int Axis18_Not_Reach_Target_Position = 2370;

        //private const int Axis19_Not_Enable = 2381;
        //private const int Axis19_Not_Ready = 2382;
        //private const int Axis19_Alarm = 2383;
        //private const int Axis19_Limit_P = 2384;
        //private const int Axis19_Limit_N = 2385;
        //private const int Axis19_Not_Init = 2386;
        //private const int Axis19_Seach_Home_Sensor_Timeout = 2387;
        //private const int Axis19_Home_Sensor_Still_ON = 2388;
        //private const int Axis19_Init_Failure = 2389;
        //private const int Axis19_Not_Reach_Target_Position = 2390;
        #endregion

        #region MotionNet通訊停止異常代碼

        public const int MotionNetRingStop = 3001;

        #endregion

        public static int InitFail(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = ErrDefine.Axis00_Init_Failure;
                    break;
                    //case 1:
                    //    code = Axis01_Init_Failure;
                    //    break;
                    //case 2:
                    //    code = Axis02_Init_Failure;
                    //    break;
                    //case 3:
                    //    code = Axis03_Init_Failure;
                    //    break;
                    //case 4:
                    //    code = Axis04_Init_Failure;
                    //    break;
                    //case 5:
                    //    code = Axis05_Init_Failure;
                    //    break;
                    //case 6:
                    //    code = Axis06_Init_Failure;
                    //    break;
                    //case 7:
                    //    code = Axis07_Init_Failure;
                    //    break;
                    //case 8:
                    //    code = Axis08_Init_Failure;
                    //    break;
                    //case 9:
                    //    code = Axis09_Init_Failure;
                    //    break;
                    //case 10:
                    //    code = Axis10_Init_Failure;
                    //    break;
                    //case 11:
                    //    code = Axis11_Init_Failure;
                    //    break;
                    //case 12:
                    //    code = Axis12_Init_Failure;
                    //    break;
                    //case 13:
                    //    code = Axis13_Init_Failure;
                    //    break;
                    //case 14:
                    //    code = Axis14_Init_Failure;
                    //    break;
                    //case 15:
                    //    code = Axis15_Init_Failure;
                    //    break;
                    //case 16:
                    //    code = Axis16_Init_Failure;
                    //    break;
                    //case 17:
                    //    code = Axis17_Init_Failure;
                    //    break;
            }
            return code;
        }

        /// <summary>
        /// 取得指定軸卡驅動器異常警告的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int Alarm(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Alarm;
                    break;
                    //case 1:
                    //    code = Axis01_Alarm;
                    //    break;
                    //case 2:
                    //    code = Axis02_Alarm;
                    //    break;
                    //case 3:
                    //    code = Axis03_Alarm;
                    //    break;
                    //case 4:
                    //    code = Axis04_Alarm;
                    //    break;
                    //case 5:
                    //    code = Axis05_Alarm;
                    //    break;
                    //case 6:
                    //    code = Axis06_Alarm;
                    //    break;
                    //case 7:
                    //    code = Axis07_Alarm;
                    //    break;
                    //case 8:
                    //    code = Axis08_Alarm;
                    //    break;
                    //case 9:
                    //    code = Axis09_Alarm;
                    //    break;
                    //case 10:
                    //    code = Axis10_Alarm;
                    //    break;
                    //case 11:
                    //    code = Axis11_Alarm;
                    //    break;
                    //case 12:
                    //    code = Axis12_Alarm;
                    //    break;
                    //case 13:
                    //    code = Axis13_Alarm;
                    //    break;
                    //case 14:
                    //    code = Axis14_Alarm;
                    //    break;
                    //case 15:
                    //    code = Axis15_Alarm;
                    //    break;
                    //case 16:
                    //    code = Axis16_Alarm;
                    //    break;
                    //case 17:
                    //    code = Axis17_Alarm;
                    //    break;
            }

            return code;
        }

        /// <summary>
        /// 取得指定軸卡沒有SVON的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int NotEnable(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Not_Enable;
                    break;
                    //case 1:
                    //    code = Axis01_Not_Enable;
                    //    break;
                    //case 2:
                    //    code = Axis02_Not_Enable;
                    //    break;
                    //case 3:
                    //    code = Axis03_Not_Enable;
                    //    break;
                    //case 4:
                    //    code = Axis04_Not_Enable;
                    //    break;
                    //case 5:
                    //    code = Axis05_Not_Enable;
                    //    break;
                    //case 6:
                    //    code = Axis06_Not_Enable;
                    //    break;
                    //case 7:
                    //    code = Axis07_Not_Enable;
                    //    break;
                    //case 8:
                    //    code = Axis08_Not_Enable;
                    //    break;
                    //case 9:
                    //    code = Axis09_Not_Enable;
                    //    break;
                    //case 10:
                    //    code = Axis10_Not_Enable;
                    //    break;
                    //case 11:
                    //    code = Axis11_Not_Enable;
                    //    break;
                    //case 12:
                    //    code = Axis12_Not_Enable;
                    //    break;
                    //case 13:
                    //    code = Axis13_Not_Enable;
                    //    break;
                    //case 14:
                    //    code = Axis14_Not_Enable;
                    //    break;
                    //case 15:
                    //    code = Axis15_Not_Enable;
                    //    break;
                    //case 16:
                    //    code = Axis16_Not_Enable;
                    //    break;
                    //case 17:
                    //    code = Axis17_Not_Enable;
                    //    break;
            }
            return code;
        }

        /// <summary>
        /// 取得指定軸卡沒有Ready的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int NotReady(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Not_Ready;
                    break;
                    //case 1:
                    //    code = Axis01_Not_Ready;
                    //    break;
                    //case 2:
                    //    code = Axis02_Not_Ready;
                    //    break;
                    //case 3:
                    //    code = Axis03_Not_Ready;
                    //    break;
                    //case 4:
                    //    code = Axis04_Not_Ready;
                    //    break;
                    //case 5:
                    //    code = Axis05_Not_Ready;
                    //    break;
                    //case 6:
                    //    code = Axis06_Not_Ready;
                    //    break;
                    //case 7:
                    //    code = Axis07_Not_Ready;
                    //    break;
                    //case 8:
                    //    code = Axis08_Not_Ready;
                    //    break;
                    //case 9:
                    //    code = Axis09_Not_Ready;
                    //    break;
                    //case 10:
                    //    code = Axis10_Not_Ready;
                    //    break;
                    //case 11:
                    //    code = Axis11_Not_Ready;
                    //    break;
                    //case 12:
                    //    code = Axis12_Not_Ready;
                    //    break;
                    //case 13:
                    //    code = Axis13_Not_Ready;
                    //    break;
                    //case 14:
                    //    code = Axis14_Not_Ready;
                    //    break;
                    //case 15:
                    //    code = Axis15_Not_Ready;
                    //    break;
                    //case 16:
                    //    code = Axis16_Not_Ready;
                    //    break;
                    //case 17:
                    //    code = Axis17_Not_Ready;
                    //    break;
            }
            return code;
        }

        /// <summary>
        /// 取得指定軸卡正極限警告的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int LimitP(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Limit_P;
                    break;
                    //case 1:
                    //    code = Axis01_Limit_P;
                    //    break;
                    //case 2:
                    //    code = Axis02_Limit_P;
                    //    break;
                    //case 3:
                    //    code = Axis03_Limit_P;
                    //    break;
                    //case 4:
                    //    code = Axis04_Limit_P;
                    //    break;
                    //case 5:
                    //    code = Axis05_Limit_P;
                    //    break;
                    //case 6:
                    //    code = Axis06_Limit_P;
                    //    break;
                    //case 7:
                    //    code = Axis07_Limit_P;
                    //    break;
                    //case 8:
                    //    code = Axis08_Limit_P;
                    //    break;
                    //case 9:
                    //    code = Axis09_Limit_P;
                    //    break;
                    //case 10:
                    //    code = Axis10_Limit_P;
                    //    break;
                    //case 11:
                    //    code = Axis11_Limit_P;
                    //    break;
                    //case 12:
                    //    code = Axis12_Limit_P;
                    //    break;
                    //case 13:
                    //    code = Axis13_Limit_P;
                    //    break;
                    //case 14:
                    //    code = Axis14_Limit_P;
                    //    break;
                    //case 15:
                    //    code = Axis15_Limit_P;
                    //    break;
                    //case 16:
                    //    code = Axis16_Limit_P;
                    //    break;
                    //case 17:
                    //    code = Axis17_Limit_P;
                    //    break;
            }

            return code;
        }

        /// <summary>
        /// 取得指定軸卡負極限警報告的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int LimitN(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Limit_N;
                    break;
                    //case 1:
                    //    code = Axis01_Limit_N;
                    //    break;
                    //case 2:
                    //    code = Axis02_Limit_N;
                    //    break;
                    //case 3:
                    //    code = Axis03_Limit_N;
                    //    break;
                    //case 4:
                    //    code = Axis04_Limit_N;
                    //    break;
                    //case 5:
                    //    code = Axis05_Limit_N;
                    //    break;
                    //case 6:
                    //    code = Axis06_Limit_N;
                    //    break;
                    //case 7:
                    //    code = Axis07_Limit_N;
                    //    break;
                    //case 8:
                    //    code = Axis08_Limit_N;
                    //    break;
                    //case 9:
                    //    code = Axis09_Limit_N;
                    //    break;
                    //case 10:
                    //    code = Axis10_Limit_N;
                    //    break;
                    //case 11:
                    //    code = Axis11_Limit_N;
                    //    break;
                    //case 12:
                    //    code = Axis12_Limit_N;
                    //    break;
                    //case 13:
                    //    code = Axis13_Limit_N;
                    //    break;
                    //case 14:
                    //    code = Axis14_Limit_N;
                    //    break;
                    //case 15:
                    //    code = Axis15_Limit_N;
                    //    break;
                    //case 16:
                    //    code = Axis16_Limit_N;
                    //    break;
                    //case 17:
                    //    code = Axis17_Limit_N;
                    //    break;
            }

            return code;
        }

        /// <summary>
        /// 取得指定軸卡未初始化警告的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int NotInit(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Not_Init;
                    break;
                    //case 1:
                    //    code = Axis01_Not_Init;
                    //    break;
                    //case 2:
                    //    code = Axis02_Not_Init;
                    //    break;
                    //case 3:
                    //    code = Axis03_Not_Init;
                    //    break;
                    //case 4:
                    //    code = Axis04_Not_Init;
                    //    break;
                    //case 5:
                    //    code = Axis05_Not_Init;
                    //    break;
                    //case 6:
                    //    code = Axis06_Not_Init;
                    //    break;
                    //case 7:
                    //    code = Axis07_Not_Init;
                    //    break;
                    //case 8:
                    //    code = Axis08_Not_Init;
                    //    break;
                    //case 9:
                    //    code = Axis09_Not_Init;
                    //    break;
                    //case 10:
                    //    code = Axis10_Not_Init;
                    //    break;
                    //case 11:
                    //    code = Axis11_Not_Init;
                    //    break;
                    //case 12:
                    //    code = Axis12_Not_Init;
                    //    break;
                    //case 13:
                    //    code = Axis13_Not_Init;
                    //    break;
                    //case 14:
                    //    code = Axis14_Not_Init;
                    //    break;
                    //case 15:
                    //    code = Axis15_Not_Init;
                    //    break;
                    //case 16:
                    //    code = Axis16_Not_Init;
                    //    break;
                    //case 17:
                    //    code = Axis17_Not_Init;
                    //    break;
            }

            return code;
        }

        /// <summary>
        /// 取得指定軸卡移動點位失敗警告的Alarm碼
        /// </summary>
        /// <param name="Axid">軸卡ID</param>
        /// <returns></returns>
        public static int NotReachTarget(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Not_Reach_Target_Position;
                    break;
                    //case 1:
                    //    code = Axis01_Not_Reach_Target_Position;
                    //    break;
                    //case 2:
                    //    code = Axis02_Not_Reach_Target_Position;
                    //    break;
                    //case 3:
                    //    code = Axis03_Not_Reach_Target_Position;
                    //    break;
                    //case 4:
                    //    code = Axis04_Not_Reach_Target_Position;
                    //    break;
                    //case 5:
                    //    code = Axis05_Not_Reach_Target_Position;
                    //    break;
                    //case 6:
                    //    code = Axis06_Not_Reach_Target_Position;
                    //    break;
                    //case 7:
                    //    code = Axis07_Not_Reach_Target_Position;
                    //    break;
                    //case 8:
                    //    code = Axis08_Not_Reach_Target_Position;
                    //    break;
                    //case 9:
                    //    code = Axis09_Not_Reach_Target_Position;
                    //    break;
                    //case 10:
                    //    code = Axis10_Not_Reach_Target_Position;
                    //    break;
                    //case 11:
                    //    code = Axis11_Not_Reach_Target_Position;
                    //    break;
                    //case 12:
                    //    code = Axis12_Not_Reach_Target_Position;
                    //    break;
                    //case 13:
                    //    code = Axis13_Not_Reach_Target_Position;
                    //    break;
                    //case 14:
                    //    code = Axis14_Not_Reach_Target_Position;
                    //    break;
                    //case 15:
                    //    code = Axis15_Not_Reach_Target_Position;
                    //    break;
                    //case 16:
                    //    code = Axis16_Not_Reach_Target_Position;
                    //    break;
                    //case 17:
                    //    code = Axis17_Not_Reach_Target_Position;
                    //    break;
            }

            return code;
        }

        /// <summary>
        /// 取得指定軸卡脫離原點失敗警告的Alarm碼
        /// </summary>
        /// <param name="Axid"></param>
        /// <returns></returns>
        public static int EscapeORGFail(int Axid)
        {
            int code = 0x00;
            switch (Axid)
            {
                case 0:
                    code = Axis00_Home_Sensor_Still_ON;
                    break;
                    //case 1:
                    //    code = Axis01_Home_Sensor_Still_ON;
                    //    break;
                    //case 2:
                    //    code = Axis02_Home_Sensor_Still_ON;
                    //    break;
                    //case 3:
                    //    code = Axis03_Home_Sensor_Still_ON;
                    //    break;
                    //case 4:
                    //    code = Axis04_Home_Sensor_Still_ON;
                    //    break;
                    //case 5:
                    //    code = Axis05_Home_Sensor_Still_ON;
                    //    break;
                    //case 6:
                    //    code = Axis06_Home_Sensor_Still_ON;
                    //    break;
                    //case 7:
                    //    code = Axis07_Home_Sensor_Still_ON;
                    //    break;
                    //case 8:
                    //    code = Axis08_Home_Sensor_Still_ON;
                    //    break;
                    //case 9:
                    //    code = Axis09_Home_Sensor_Still_ON;
                    //    break;
                    //case 10:
                    //    code = Axis10_Home_Sensor_Still_ON;
                    //    break;
                    //case 11:
                    //    code = Axis11_Home_Sensor_Still_ON;
                    //    break;
                    //case 12:
                    //    code = Axis12_Home_Sensor_Still_ON;
                    //    break;
                    //case 13:
                    //    code = Axis13_Home_Sensor_Still_ON;
                    //    break;
                    //case 14:
                    //    code = Axis14_Home_Sensor_Still_ON;
                    //    break;
                    //case 15:
                    //    code = Axis15_Home_Sensor_Still_ON;
                    //    break;
                    //case 16:
                    //    code = Axis16_Home_Sensor_Still_ON;
                    //    break;
                    //case 17:
                    //    code = Axis17_Home_Sensor_Still_ON;
                    //    break;
            }
            return code;
        }
    }
}
