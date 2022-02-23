using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source
{
    class clsDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> m_dctTempLib = new Dictionary<TKey, TValue>();

        /// <summary>
        /// 建立clsDictionary 並帶入指定的資料字典
        /// </summary>
        /// <param name="p_dctData">要帶入指定的資料字典</param>
        public clsDictionary(Dictionary<TKey, TValue> p_dctData)
        {
            m_dctTempLib = p_dctData;
        }

        /// <summary>
        /// 取得或設定 Dictionary
        /// </summary>
        public Dictionary<TKey, TValue> Dictionary
        {
            get
            {
                return m_dctTempLib;
            }

            set
            {
                m_dctTempLib = value;
            }
        }

        /// <summary>
        /// 傳回序列中的項目
        /// </summary>
        public int Count
        {
            get
            {
                return m_dctTempLib.Count();
            }
        }

        /// <summary>
        /// 取得索引鍵
        /// </summary>
        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                return m_dctTempLib.Keys;
            }
        }

        /// <summary>
        /// 取得值
        /// </summary>
        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                return m_dctTempLib.Values;
            }
        }

        /// <summary>
        /// 取得或設定指定的索引鍵的相關聯的值
        /// </summary>
        /// <param name="p_key">要取得或設定值的索引鍵</param>
        /// <returns>回傳指定值</returns>
        public TValue this[TKey p_key]
        {
            get
            {
                return m_dctTempLib[p_key];
            }
            set
            {
                m_dctTempLib[p_key] = value;
            }
        }

        /// <summary>
        /// 取得或設定指定的Index的相關聯的值，注意Index 不要Overflow，以免程式異常
        /// </summary>
        /// <param name="p_index">要取得或設定值的Index</param>
        /// <returns>回傳指定值</returns>
        public TValue this[int p_index]
        {
            get
            {
                return m_dctTempLib.ElementAt(p_index).Value;
            }
            set
            {
                m_dctTempLib[m_dctTempLib.ElementAt(p_index).Key] = value;
            }
        }

        /// <summary>
        /// 建立空的 clsDictionary
        /// </summary>
        public clsDictionary()
        {

        }

        /// <summary>
        /// 將指定的索引鍵和值加入字典
        /// </summary>
        /// <param name="p_objKey">索引鍵</param>
        /// <param name="p_objValue">值</param>
        /// <returns>回傳是否新增成功 true:新增成功 false:新增失敗</returns>
        public virtual bool Add(TKey p_objKey, TValue p_objValue)
        {
            if (!m_dctTempLib.ContainsKey(p_objKey))
            {
                m_dctTempLib.Add(p_objKey, p_objValue);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 移除指定的索引鍵和值
        /// </summary>
        /// <param name="p_objKey">索引鍵</param>
        /// <returns>回傳是否移除成功 true:移除成功 false:移除失敗</returns>
        public virtual bool Remove(TKey p_objKey)
        {
            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                m_dctTempLib.Remove(p_objKey);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 移除所有索引鍵和值
        /// </summary>
        public virtual void Clear()
        {
            m_dctTempLib.Clear();
        }

        /// <summary>
        /// 傳回序列中指定的索引處的項目
        /// </summary>
        /// <param name="p_iIndex"></param>
        /// <returns></returns>
        public virtual KeyValuePair<TKey, TValue> ElementAt(int p_iIndex)
        {
            return m_dctTempLib.ElementAt(p_iIndex);
        }

        /// <summary>
        /// 判斷是否包含指定的索引鍵
        /// </summary>
        /// <param name="p_objKey">索引鍵</param>
        /// <returns>回傳是否包含 true:包含 false:不包含</returns>
        public virtual bool ContainsKey(TKey p_objKey)
        {
            return m_dctTempLib.ContainsKey(p_objKey);
        }

        /// <summary>
        /// 判斷是否包含特定值
        /// </summary>
        /// <param name="p_objValue">特定值</param>
        /// <returns>回傳是否包含 true:包含 false:不包含</returns>
        public virtual bool ContainsValue(TValue p_objValue)
        {
            return m_dctTempLib.ContainsValue(p_objValue);
        }

        /// <summary>
        /// 傳回序列中指定的物件
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_objDefault">預設值</param>
        /// <returns>回傳值</returns>
        public virtual object ValueObject(TKey p_objKey, object p_objDefault)
        {
            object objTemp = p_objDefault;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                objTemp = m_dctTempLib[p_objKey];
            }
            return objTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 Int
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_iDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual int ValueInt(TKey p_objKey, int p_iDefult)
        {
            int iTemp = p_iDefult;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                iTemp = Convert.ToInt32(m_dctTempLib[p_objKey]);
            }
            return iTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 Long
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_lDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual long ValueLong(TKey p_objKey, long p_lDefult)
        {
            long lTemp = p_lDefult;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                lTemp = Convert.ToInt64(m_dctTempLib[p_objKey]);
            }
            return lTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 Double
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_dDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual double ValueDouble(TKey p_objKey, double p_dDefult)
        {
            double dTemp = p_dDefult;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                dTemp = Convert.ToDouble(m_dctTempLib[p_objKey]);
            }
            return dTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 Decimal
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_dimDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual decimal ValueDecimal(TKey p_objKey, decimal p_dimDefult)
        {
            decimal dimTemp = p_dimDefult;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                dimTemp = Convert.ToDecimal(m_dctTempLib[p_objKey]);
            }
            return dimTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 bool(只能轉換"true","false")
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_dimDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual bool ValueBool(TKey p_objKey, bool p_bDefult)
        {
            bool bTemp = p_bDefult;
            try
            {
                if (m_dctTempLib.ContainsKey(p_objKey))
                {
                    bTemp = Convert.ToBoolean(m_dctTempLib[p_objKey]);
                }
            }
            catch
            {
                bTemp = p_bDefult;
            }
            return bTemp;
        }

        /// <summary>
        /// 傳回序列中指定的 String
        /// </summary>
        /// <param name="p_objKey">索引值</param>
        /// <param name="p_strDefult">預設值</param>
        /// <returns>回傳值</returns>
        public virtual string ValueString(TKey p_objKey, string p_strDefult)
        {
            string strTemp = p_strDefult;

            if (m_dctTempLib.ContainsKey(p_objKey))
            {
                strTemp = Convert.ToString(m_dctTempLib[p_objKey]);
            }
            return strTemp;
        }

    }
}

