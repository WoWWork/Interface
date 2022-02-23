using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace CM_100
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Source.DataSQL.ConnectionTest()) Environment.Exit(0);
            Manage.clsLogAdmin.CreateDirectory();
            SYN_TEK.CMNet.Init();
            Entity.clsDIO.Init();
            Entity.clsMotor.Init();
            SYN_TEK.ARM.Init();
            SYN_TEK.LASER.Init();
            new Thread( SYN_TEK.CMNet.MonitorRing).Start();
            new Thread( Entity.clsDIO.DoWork).Start();
            new Thread( Motion_Sequence.InitTask.Task).Start();
            new Thread( Motion_Sequence.LampTask.Task).Start();
            new Thread( Motion_Sequence.clsTS.Task).Start();
            Application.Run(new MainForm());
        }
    }
}
