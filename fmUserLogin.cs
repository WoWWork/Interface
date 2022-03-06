using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CM_100;
using Source;
using Manage;
using MainControl;

namespace CM_100
{
    public partial class fmUserLogin : Form
    {
        private static fmUserLogin m_Singleton;

        public static fmUserLogin GetSingleton()
        {
            if (m_Singleton == null)
            {
                m_Singleton = new fmUserLogin();
            }
            return m_Singleton;
        }

        public fmUserLogin()
        {
            InitializeComponent();
            this.Size = new Size(377, 189);
        }
        ~fmUserLogin()
        {

        }

        public DialogResult ShowDialog(IWin32Window owner, emLangType lang)
        {
            this.Size = new Size(377, 189);

            if(lang == emLangType.CHT)
            {
                lbNameTitle.Text = "使用者";
                btnOK.Text = "確定";
                btnCancel.Text = "取消";
                lbPWTitle.Text = "密碼";
            }
            else
            {
                btnOK.Text = "OK";
                btnCancel.Text = "Cancel";
                lbNameTitle.Text = "User Name";
                lbPWTitle.Text = "Pass Word";
            }
            cbUserList.Items.Clear();
            clsDictionary<string, Manage.Type> list = clsUser.GetNameList();

            foreach(string key in list.Keys)
            {
                cbUserList.Items.Add(key);
            }
            cbUserList.SelectedIndex = 0;
            list.Clear();
            tbPSW.Text = string.Empty;

            DialogResult dr = this.ShowDialog(owner);

            cbUserList.Items.Clear();
            return dr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void tbPSW_Click(object sender, EventArgs e)
        {
            DialogResult kw = fmKeyBox.GetSingleton().ShowDialog(this, "", false);

            if (kw != DialogResult.OK) return;

            ((TextBox)sender).Text = fmKeyBox.GetSingleton().KeyBoxValue;
        }
    }
}
