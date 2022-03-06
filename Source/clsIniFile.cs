using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Source
{
    class clsIniFile
    {
        public const int MaxSectionSize = 196608;

        private string m_path;

        /// <summary>
        /// A static class that provides the win32 P/Invoke signatures 
        /// used by this class.
        /// </summary>
        /// <remarks>
        /// Note:  In each of the declarations below, we explicitly set CharSet to 
        /// Auto.  By default in C#, CharSet is set to Ansi, which reduces 
        /// performance on windows 2000 and above due to needing to convert strings
        /// from Unicode (the native format for all .Net strings) to Ansi before 
        /// marshalling.  Using Auto lets the marshaller select the Unicode version of 
        /// these functions when available.
        /// </remarks>
        [System.Security.SuppressUnmanagedCodeSecurity]
        private static class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer,
                                                                                     uint nSize,
                                                                                     string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern uint GetPrivateProfileString(string lpAppName,
                                                                              string lpKeyName,
                                                                              string lpDefault,
                                                                              StringBuilder lpReturnedString,
                                                                              int nSize,
                                                                              string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern uint GetPrivateProfileString(string lpAppName,
                                                                              string lpKeyName,
                                                                              string lpDefault,
                                                                              [In, Out] char[] lpReturnedString,
                                                                              int nSize,
                                                                              string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileString(string lpAppName,
                                                                             string lpKeyName,
                                                                             string lpDefault,
                                                                             IntPtr lpReturnedString,
                                                                             uint nSize,
                                                                             string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileInt(string lpAppName,
                                                                         string lpKeyName,
                                                                         int lpDefault,
                                                                         string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetPrivateProfileSection(string lpAppName,
                                                                              IntPtr lpReturnedString,
                                                                              uint nSize,
                                                                              string lpFileName);

            //We explicitly enable the SetLastError attribute here because
            // WritePrivateProfileString returns errors via SetLastError.
            // Failure to set this can result in errors being lost during 
            // the marshal back to managed code.
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool WritePrivateProfileString(string lpAppName,
                                                                                 string lpKeyName,
                                                                                 string lpString,
                                                                                 string lpFileName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="clsIniFile"/> class.
        /// </summary>
        /// <param name="path">The ini file to read and write from.</param>
        public clsIniFile(string path)
        {
            //Convert to the full path.  Because of backward compatibility, 
            // the win32 functions tend to assume the path should be the 
            // root Windows directory if it is not specified.  By calling 
            // GetFullPath, we make sure we are always passing the full path
            // the win32 functions.

            if (path == null)
                throw new ArgumentNullException("File Path is NULL");

            m_path = System.IO.Path.GetFullPath(path);

            string strDir = m_path.Substring(0, m_path.LastIndexOf("\\"));
            if (!System.IO.Directory.Exists(strDir))
            {
                if (System.IO.Directory.Exists(System.IO.Directory.GetDirectoryRoot(strDir)))
                {
                    System.IO.Directory.CreateDirectory(strDir);
                }
            }
        }

        # region GetData

        /// <summary>
        /// Gets the full path of ini file this object instance is operating on.
        /// </summary>
        /// <value>A file path.</value>
        public string Path
        {
            get
            {
                return m_path;
            }
        }

        /// <summary>
        /// Gets the value of a setting in an ini file as a <see cref="T:System.Int16"/>.
        /// </summary>
        public string GetString(string sectionName, string keyName, string defaultValue)
        {
            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            if (keyName == null)
                throw new ArgumentNullException("keyName");

            StringBuilder retval = new StringBuilder(clsIniFile.MaxSectionSize);

            NativeMethods.GetPrivateProfileString(sectionName,
                                                              keyName,
                                                              defaultValue,
                                                              retval,
                                                              clsIniFile.MaxSectionSize,
                                                              m_path);

            return retval.ToString();
        }

        /// <summary>
        /// Gets the value of a setting in an ini file as a <see cref="T:System.Int32"/>.
        /// </summary>
        public int GetInt32(string sectionName, string keyName, int defaultValue)
        {
            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            if (keyName == null)
                throw new ArgumentNullException("keyName");


            return NativeMethods.GetPrivateProfileInt(sectionName, keyName, defaultValue, m_path);
        }

        /// <summary>
        /// Gets the value of a setting in an ini file as a <see cref="T:System.Double"/>.
        /// </summary>
        public double GetDouble(string sectionName,
                                    string keyName,
                                    double defaultValue)
        {
            string retval = GetString(sectionName, keyName, "");

            if (retval == null || retval.Length == 0)
            {
                return defaultValue;
            }

            return Convert.ToDouble(retval, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets all of the values in a section as a list.
        /// </summary>
        public List<KeyValuePair<string, string>> GetSectionValuesAsList(string sectionName)
        {
            List<KeyValuePair<string, string>> retval;
            string[] keyValuePairs;
            string key, value;
            int equalSignPos;

            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            //Allocate a buffer for the returned section names.
            IntPtr ptr = Marshal.AllocCoTaskMem(clsIniFile.MaxSectionSize);

            try
            {
                //Get the section key/value pairs into the buffer.
                int len = NativeMethods.GetPrivateProfileSection(sectionName,
                                                                                 ptr,
                                                                                 clsIniFile.MaxSectionSize,
                                                                                 m_path);

                keyValuePairs = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                //Free the buffer
                Marshal.FreeCoTaskMem(ptr);
            }

            //Parse keyValue pairs and add them to the list.
            retval = new List<KeyValuePair<string, string>>(keyValuePairs.Length);

            for (int i = 0; i < keyValuePairs.Length; ++i)
            {
                //Parse the "key=value" string into its constituent parts
                equalSignPos = keyValuePairs[i].IndexOf('=');

                key = keyValuePairs[i].Substring(0, equalSignPos);

                value = keyValuePairs[i].Substring(equalSignPos + 1,
                                                              keyValuePairs[i].Length - equalSignPos - 1);

                retval.Add(new KeyValuePair<string, string>(key, value));
            }

            return retval;
        }

        /// <summary>
        /// Converts the null seperated pointer to a string into a string array.
        /// </summary>
        private static string[] ConvertNullSeperatedStringToStringArray(IntPtr ptr, int valLength)
        {
            string[] retval;

            if (valLength == 0)
            {
                //Return an empty array.
                retval = new string[0];
            }
            else
            {
                //Convert the buffer into a string.  Decrease the length 
                //by 1 so that we remove the second null off the end.
                string buff = Marshal.PtrToStringAuto(ptr, valLength - 1);

                //Parse the buffer into an array of strings by searching for nulls.
                retval = buff.Split('\0');
            }

            return retval;
        }

        #endregion

        #region WriteData

        /// <summary>
        /// Writes a <see cref="T:System.String"/> value to the ini file.
        /// </summary>
        private void WriteValueInternal(string sectionName, string keyName, string value)
        {
            if (!NativeMethods.WritePrivateProfileString(sectionName, keyName, value, m_path))
            {
                throw new System.ComponentModel.Win32Exception();
            }
        }

        /// <summary>
        /// Writes a <see cref="T:System.String"/> value to the ini file.
        /// </summary>
        public void WriteValue(string sectionName, string keyName, string value)
        {
            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            if (keyName == null)
                throw new ArgumentNullException("keyName");

            if (value == null)
            {              
                value = "";
                throw new ArgumentNullException("value");
            }

            WriteValueInternal(sectionName, keyName, value);
        }

        /// <summary>
        /// Writes an <see cref="T:System.Int16"/> value to the ini file.
        /// </summary>
        public void WriteValue(string sectionName, string keyName, short value)
        {
            WriteValue(sectionName, keyName, (int)value);
        }

        /// <summary>
        /// Writes an <see cref="T:System.Int32"/> value to the ini file.
        /// </summary>
        public void WriteValue(string sectionName, string keyName, int value)
        {
            WriteValue(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Writes an <see cref="T:System.Single"/> value to the ini file.
        /// </summary>
        public void WriteValue(string sectionName, string keyName, float value)
        {
            WriteValue(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Writes an <see cref="T:System.Double"/> value to the ini file.
        /// </summary>
        public void WriteValue(string sectionName, string keyName, double value)
        {
            WriteValue(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture));
        }

        #endregion

        #region DeleteData

        /// <summary>
        /// Deletes the specified key from the specified section.
        /// </summary>
        public void DeleteKey(string sectionName, string keyName)
        {
            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            if (keyName == null)
                throw new ArgumentNullException("keyName");

            WriteValueInternal(sectionName, keyName, null);
        }

        /// <summary>
        /// Deletes a section from the ini file.
        /// </summary>
        public void DeleteSection(string sectionName)
        {
            if (sectionName == null)
                throw new ArgumentNullException("sectionName");

            WriteValueInternal(sectionName, null, null);
        }

        /// <summary>
        /// Deletes All Info from the ini file.
        /// </summary>
        public void DeleteAll()
        {
            System.IO.StreamWriter ClearInfo = new System.IO.StreamWriter(m_path);
            ClearInfo.Write("");
            ClearInfo.Close();
            ClearInfo.Dispose();
        }

        #endregion

        #region Get Key/Section Names

        /// <summary>
        /// Gets the names of all sections in the ini file.
        /// </summary>
        /// <returns>An array of section names.</returns>
        /// <remarks>
        /// The total length of all section names in the section must be 
        /// less than 32KB in length.
        /// </remarks>
        public string[] GetSectionNames()
        {
            string[] retval;
            int len;

            //Allocate a buffer for the returned section names.
            IntPtr ptr = Marshal.AllocCoTaskMem(clsIniFile.MaxSectionSize);

            try
            {
                //Get the section names into the buffer.
                len = NativeMethods.GetPrivateProfileSectionNames(ptr,
                     clsIniFile.MaxSectionSize, m_path);

                retval = ConvertNullSeperatedStringToStringArray(ptr, len);
            }
            finally
            {
                //Free the buffer
                Marshal.FreeCoTaskMem(ptr);
            }

            return retval;
        }

        /// <summary>
        /// Gets all of the values in a section as a dictionary.
        /// </summary>
        /// <param name="sectionName">
        /// Name of the section to retrieve values from.
        /// </param>
        /// <returns>
        /// A <see cref="Dictionary{T, T}"/> containing the key/value 
        /// pairs found in this section.  
        /// </returns>
        /// <remarks>
        /// If a section contains more than one key with the same name, 
        /// this function only returns the first instance.  If you need to 
        /// get all key/value pairs within a section even when keys have the 
        /// same name, use <see cref="GetSectionValuesAsList"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sectionName"/> is a null reference  (Nothing in VB)
        /// </exception>
        public Dictionary<string, string> GetSectionValues(string sectionName)
        {
            List<KeyValuePair<string, string>> keyValuePairs;
            Dictionary<string, string> retval;

            keyValuePairs = GetSectionValuesAsList(sectionName);

            //Convert list into a dictionary.
            retval = new Dictionary<string, string>(keyValuePairs.Count);

            foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
            {
                //Skip any key we have already seen.
                if (!retval.ContainsKey(keyValuePair.Key))
                {
                    retval.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return retval;
        }

        #endregion

    }
}