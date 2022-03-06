using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Source
{
    class DataSQL
    {
        private static string DBSetting =
            "Provider = Microsoft.Jet.Oledb.4.0;Data Source = DataBase.mdb;Persist Security Info = False";
        private static OleDbConnection DBConnection = new OleDbConnection(DBSetting);

        public static bool ConnectOpen
        {
            set
            {
                if (value)
                {
                    try
                    {
                        if (DBConnection.State == ConnectionState.Closed)
                        {
                            DBConnection.Open();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("資料庫無法開啟！");
                    }
                }
                else { DBConnection.Close(); }
            }
        }

        /// <summary>
        /// 取得查詢資料庫內的資料
        /// </summary>
        /// <param name="StrSQL">查詢字串</param>
        /// <returns>傳回資料表</returns>
        public static DataTable GetDataTable(string StrSQL)
        {
            DataTable Table = new DataTable();
            OleDbDataReader DataReader;
            using (OleDbCommand Command = new OleDbCommand(StrSQL, DBConnection))
            {
                try
                {
                    ConnectOpen = true;
                    DataReader = Command.ExecuteReader();
                    Table.Load(DataReader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            return Table;
        }

        /// <summary>
        /// 資料庫查詢的資料填入至資料表
        /// </summary>
        /// <param name="StrSQL"></param>
        /// <param name="Table"></param>
        public static void DataTableLoad(string StrSQL, ref DataTable Table)
        {
            OleDbDataReader DataReader;
            using (OleDbCommand Command = new OleDbCommand(StrSQL, DBConnection))
            {
                try
                {
                    ConnectOpen = true;
                    DataReader = Command.ExecuteReader();
                    Table.Load(DataReader);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }

        /// <summary>
        /// 執行執行Insert、Delete，Update三命令函數
        /// </summary>
        /// <param name="StrSQL"></param>
        /// <returns>傳回受影響的筆數</returns>
        public static int ExecuteSQL(string StrSQL)
        {
            int rs = 0;
            using (OleDbCommand Command = new OleDbCommand(StrSQL, DBConnection))
            {
                try
                {
                    ConnectOpen = true;
                    rs = Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(StrSQL.ToString());
                }
            }

            return rs;
        }

        /// <summary>
        /// 執行Selection命令,傳回第一筆第一行的資料
        /// </summary>
        /// <param name="StrSQL"></param>
        /// <returns></returns>
        public static Object ExecuteScalar(string StrSQL)
        {
            Object rs = null;
            using (OleDbCommand Command = new OleDbCommand(StrSQL, DBConnection))
            {
                try
                {
                    ConnectOpen = true;
                    rs = Command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return rs;
        }

        /// <summary>
        /// 資料庫交易
        /// </summary>
        /// <param name="StrSQL"></param>
        /// <returns></returns>
        public static bool Transaction(string[] StrSQL)
        {
            bool rs = true;
            ConnectOpen = true;
            OleDbTransaction DataBaseTransaction = DBConnection.BeginTransaction();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DBConnection;
            cmd.Transaction = DataBaseTransaction;
            try
            {

                foreach (string SQl in StrSQL)
                {
                    cmd.CommandText = SQl;
                    cmd.ExecuteNonQuery();
                }

                DataBaseTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                rs = false;
                DataBaseTransaction.Rollback();
            }
            finally
            {
                ConnectOpen = false;
            }

            return rs;
        }

        /// <summary>
        /// 測試資料庫連線
        /// </summary>
        public static bool ConnectionTest()
        {
            bool RS = false;
            try
            {
                DBConnection.Open();
                RS = true;
            }
            catch
            {
                MessageBox.Show("資料庫無法開啟！程式即將中斷");
            }
            return RS;
        }
    }
}
