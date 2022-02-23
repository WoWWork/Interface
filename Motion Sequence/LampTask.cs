using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Manage;

namespace Motion_Sequence
{
    class LampTask
    {
        public static Stopwatch BuzzTimer = new Stopwatch();
        private static int RunStatusLamp = 0x04; // green lamp
        private static int AlarmStatusLamp = 0x99; // red lamp
        private static int StopStatusLamp = 0x26; // no lamp
        private static int WaitStatusLamp = 0x02; // yellow lamp
        private static int InitStatusLamp = 0x22; // yellow lamp blinking
        private static int EmptyWarningStatusLamp = 0x24; // yellow lamp blinking
        private static int NoInitStatusLamp = 0x77; // red yellow green

        private static void Cycle(emEQStates state, int lamp)
        {
            int lamp_cnt, period, blink_mask, lamp_status;

            period = 3;

            blink_mask = (lamp >> 4) & 0x0f;
            lamp_status = (lamp & 0x0f);

            Entity.clsDIO.SetDO(Entity.emDO.LampRed, (lamp_status & 0x01) > 0x00);
            Entity.clsDIO.SetDO(Entity.emDO.LampYellow, (lamp_status & 0x02) > 0x00);
            Entity.clsDIO.SetDO(Entity.emDO.LampGreed, (lamp_status & 0x04) > 0x00);
            Entity.clsDIO.SetDO(Entity.emDO.Buzzer, (lamp_status & 0x08) > 0x00);

            lamp_cnt = period;
            if (BuzzTimer.IsRunning) BuzzTimer.Restart();
            else
            {
                BuzzTimer.Reset();
                BuzzTimer.Start();
            }

            while(clsEQM.Status == state)
            {
                while (clsTS.ForceIOFlag == true) Thread.Sleep(500);
                Thread.Sleep(200);
                if(BuzzTimer.IsRunning)
                {
                    if (BuzzTimer.ElapsedMilliseconds > 20000)
                    {
                        BuzzTimer.Stop();
                    }
                }
                if(lamp_cnt-- <= 0x00)
                {
                    lamp_status ^= blink_mask;
                    if (BuzzTimer.IsRunning == false) lamp_status &= 0x07;
                    Entity.clsDIO.SetDO(Entity.emDO.LampRed, (lamp_status & 0x01) > 0x00);
                    Entity.clsDIO.SetDO(Entity.emDO.LampYellow, (lamp_status & 0x02) > 0x00);
                    Entity.clsDIO.SetDO(Entity.emDO.LampGreed, (lamp_status & 0x04) > 0x00);
                    Entity.clsDIO.SetDO(Entity.emDO.Buzzer, (lamp_status & 0x08) > 0x00);
                    lamp_cnt = period;
                }
            }
        }
        public static void Task()
        {
            while(true)
            {
                Thread.Sleep(200);
                if (!SYN_TEK.CMNet.IsRingWork) continue;

                switch (clsEQM.Status)
                {
                    case emEQStates.Run:
                        Cycle(clsEQM.Status, RunStatusLamp);
                        break;
                    case emEQStates.Alarm:
                        Cycle(clsEQM.Status, AlarmStatusLamp);
                        break;
                    case emEQStates.Wait:
                        Cycle(clsEQM.Status, WaitStatusLamp);
                        break;
                    case emEQStates.Stop:
                        Cycle(clsEQM.Status, StopStatusLamp);
                        break;
                    case emEQStates.Empty:
                        Cycle(clsEQM.Status, EmptyWarningStatusLamp);
                        break;
                    case emEQStates.Init:
                        Cycle(clsEQM.Status, InitStatusLamp);
                        break;
                    case emEQStates.NoInit:
                        Cycle(clsEQM.Status, NoInitStatusLamp);
                        break;
                }
            }
        }
    }
}
