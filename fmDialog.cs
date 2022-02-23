using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainControl;

namespace CM_100
{
    public partial class fmDialog : Form
    {
        private static fmDialog m_Singleton;
        private ucRecipe HandleForm;
        public DataTable ItemsInfo = new DataTable();
        private static Button Controller { set; get; }

        public static string strFilePath = string.Empty;
        public static string Sort { private set; get; }
        public static fmDialog GetSingleton(ucRecipe f)
        {
            if (m_Singleton == null)
            {
                m_Singleton = new fmDialog(f);
            }

            return m_Singleton;
        }
        public fmDialog(ucRecipe f)
        {
            InitializeComponent();
            this.Size = new Size(490, 390);
            HandleForm = f;
            FormLoad();
        }
        ~fmDialog()
        {

        }
        public DialogResult ShowDialog(IWin32Window onwer, object sender, Manage.emLangType lang)
        {
            Controller = (Button)sender;
            if ((string)Controller.Tag == "ForeView") this.Text = "正面內容";
            else this.Text = "反面內容";
            timer1.Enabled = true;
            DialogResult dr = this.ShowDialog();
            return dr;
        }

        private void FormLoad()
        {
            ItemsInfo.Columns.Add("Name", typeof(string));
            ItemsInfo.Columns.Add("Type", typeof(string));
            ItemsInfo.Columns.Add("Speed", typeof(string));
            ItemsInfo.Columns.Add("Power", typeof(string));
            ItemsInfo.Columns.Add("Frequency", typeof(string));
            ItemsInfo.Columns.Add("Context", typeof(string));
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Number = 0;
            ItemsInfo.Rows.Clear();
            HandleForm.Data_Update((string)Controller.Tag);
            HandleForm.GetItemNumber((string)Controller.Tag, ref Number);
            string[] Datas = new string[ItemsInfo.Columns.Count];
            for(int i = 0; i < Number; i++)
            {
                HandleForm.GetItemData((string)Controller.Tag, i, ref Datas);
                ItemsInfo.Rows.Add(new string[] { Datas[0], Datas[1], Datas[2], Datas[3], Datas[4], Datas[5] });
            }
            dgv_LaserData.DataSource = ItemsInfo;
        }

    }
}
