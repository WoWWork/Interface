using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Report
{
    public class ErrorType
    {
        public const uint Null = 0x01;
        public const uint Retry = 0x02;
        public const uint Skip = 0x04;
        public const uint Confirm = 0x08;
        public const uint OK = 0x10;
    }
    class clsErrFlag
    {
        private int m_Index;
        private uint m_Option;
        private DateTime m_Time;

        public clsErrFlag()
        {
            m_Option = 0;
            m_Index = 0;
        }
        public void Set(int idx, uint opt, DateTime T)
        {
            m_Option = opt;
            m_Index = idx;
            m_Time = T;
        }

        public void Clear()
        {
            m_Option = 0;
            m_Index = 0;
        }
        public void Clear(uint opt)
        {
            m_Option = opt;
            m_Index = 0;
        }

        public bool IsHookUp
        {
            get
            {
                return m_Index != 0x00 ? true : false;
            }
        }

        public int Index { get { return m_Index; } }
        public uint Option { get { return m_Option; } }
        public DateTime ReportTime { get { return m_Time; } }
    }

    class ErrFunction
    {
        private static Source.clsDictionary<string, clsErrFlag> dctErrBuf =
            new Source.clsDictionary<string, clsErrFlag>();
        private static Mutex m_Mutex = new Mutex();
        private static StringBuilder SQL = new StringBuilder();
        public static string ModuleName = string.Empty;
        public static clsErrFlag Flagged = new clsErrFlag();

        public static string GetText(int idx, Manage.emLangType lang)
        {
            string str = "This Alarm Code Not Define !";
            SQL.Clear();
            if (lang == Manage.emLangType.CHT)
                SQL.Append("Select CHTText From AlarmMessage ");
            else
                SQL.Append("Select ENGText From AlarmMessage ");
            SQL.Append("Where Code = " + idx + "");
            str = Convert.ToString(Source.DataSQL.ExecuteScalar(SQL.ToString()));
            return str;
        }

        public static Report.clsErrFlag SingIn(string name)
        {
            m_Mutex.WaitOne();
            clsErrFlag flag = new clsErrFlag();
            dctErrBuf.Add(name, flag);
            m_Mutex.ReleaseMutex();
            return flag;
        }

        public static void HookUp(string name, int idx, uint type, DateTime t)
        {
            m_Mutex.WaitOne();
            dctErrBuf[name].Set(idx, type, t);
            if (Flagged.Index == 0x00)
            {
                SetAlarmFlag(name, idx, type, t);
            }
            m_Mutex.ReleaseMutex();
        }

        private static void SetAlarmFlag(string name, int idx, uint type, DateTime t)
        {
            ModuleName = name;
            Flagged.Set(idx, type, t);
            Manage.clsEQM.AutoRun = false;
            Manage.clsEQM.InitRun = false;
            Manage.clsEQM.OneCycleRun = false;
            Manage.clsEQM.Status = Manage.emEQStates.Alarm;
            InsertAlarmHistory(name, idx, t);
        }
        public static void InsertAlarmHistory(string name, int idx, DateTime t)
        {
            SQL.Clear();
            SQL.Append("Insert Into AlarmHistory(ReportTime,AlarmCode,TaskName) ");
            SQL.Append("Value(#" + t.ToString("yyyy/MM/dd HH:mm:ss") + "#," + idx + ",#" + name + "#)");
            Source.DataSQL.ExecuteSQL(SQL.ToString());
        }

        public static void UpdateAlarmHistory()
        {
            SQL.Clear();
            SQL.Append("Update AlarmHistory ");
            SQL.Append("Set RestoreTime = #" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "# ");
            SQL.Append("Where TaskName = '" + ModuleName + "' And ");
            SQL.Append("ReportTime = #" + Flagged.ReportTime.ToString("yyyy/MM/dd HH:mm:ss") + "# And ");
            SQL.Append("RestoreTime = null");
            Source.DataSQL.ExecuteSQL(SQL.ToString());
        }

        public static void Clear(uint opt)
        {
            m_Mutex.WaitOne();
            dctErrBuf[ModuleName].Clear(opt);
            Flagged.Clear();

            Manage.clsEQM.AutoRun = false;
            Manage.clsEQM.InitRun = false;

            //遍歷整個集合, 若還有故障就再掛起
            foreach (string key in dctErrBuf.Keys)
            {
                if (dctErrBuf[key].IsHookUp)
                {
                    SetAlarmFlag(key, dctErrBuf[key].Index, dctErrBuf[key].Option, dctErrBuf[key].ReportTime);
                    InsertAlarmHistory(key, dctErrBuf[key].Index, dctErrBuf[key].ReportTime);
                    m_Mutex.ReleaseMutex();
                    return;
                }
            }
            Manage.clsEQM.Status = Manage.emEQStates.Stop;
            m_Mutex.ReleaseMutex();
        }
    }
}
