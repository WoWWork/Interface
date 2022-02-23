using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Manage;

namespace CM_100
{
    public partial class fmCreateUser : Form
    {
        private static fmCreateUser m_Singleton;

        public static fmCreateUser GetSingleton()
        {
            if(m_Singleton == null)
            {
                m_Singleton = new fmCreateUser();
            }
            return m_Singleton;
        }

        public fmCreateUser()
        {
            InitializeComponent();
            this.Size = new Size(431, 265);
        }
        ~fmCreateUser()
        {

        }

        public DialogResult ShowDialog(IWin32Window owner, Manage.emLangType lang)
        {
            this.Size = new Size(431, 265);

            if (lang == Manage.emLangType.CHT)
            {
                lbNameTitle.Text = "使用者名稱";
                lbAuthTitle.Text = "權限";
                btnOK.Text = "確定";
                btnCancel.Text = "取消";
            }
            else
            {
                btnOK.Text = "OK";
                btnCancel.Text = "Cancel";
                lbNameTitle.Text = "User Name";
                lbAuthTitle.Text = "Authority";
                lbPW1Title.Text = "Pass Word";
                lbPW2Title.Text = "Conform Pass Word";
            }

            tbUserName.Text = string.Empty;
            tbPW1.Text = string.Empty;
            tbPW2.Text = string.Empty;
            cbAuth.SelectedIndex = 0;
            DialogResult dr = this.ShowDialog(owner);

            return dr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = tbUserName.Text.Trim();
            string pws1 = tbPW1.Text.Trim();
            string pws2 = tbPW2.Text.Trim();
            tbUserName.Text = string.Empty;
            tbPW1.Text = string.Empty;
            tbPW2.Text = string.Empty;

            if (name == string.Empty)
            {
                if (clsLang.Type == emLangType.ENG)
                    MessageBox.Show("User Name Can't Empty", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("名稱不得空白", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name.Length > 20)
            {
                if (clsLang.Type == emLangType.ENG)
                    MessageBox.Show("User Name Can't Over Characters ", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("名稱不得超過 20 字元", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char ch in name)
            {
                if ((char.IsNumber(ch) != true) && (char.IsLetter(ch) != true))
                {
                    if (clsLang.Type == emLangType.ENG)
                        MessageBox.Show("The Name Only Use 0~9, A~Z, a~z", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("名稱只能使用數字及大小寫母字", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

                        if ((pws1 == string.Empty) || (pws2 == string.Empty))
            {
                if (clsLang.Type == emLangType.ENG)
                    MessageBox.Show("Pass Word Can't Empty", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("密碼不得空白", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pws1 != pws2)
            {
                if (clsLang.Type == emLangType.ENG)
                    MessageBox.Show("Pass Word Siffer", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("密碼不一致", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char ch in pws1)
            {
                if ((char.IsNumber(ch) != true) && (char.IsLetter(ch) != true))
                {
                    if (clsLang.Type == emLangType.ENG)
                        MessageBox.Show("Pass Word Only Use 0~9, A~Z, a~z", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("密碼只能使用數字及大小寫母字", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            Source.clsDictionary<string, Manage.Type> list = clsUser.GetNameList();

            foreach (string key in list.Keys)
            {
                if (name.ToLower() == key.ToLower())
                {
                    if (clsLang.Type == emLangType.ENG)
                        MessageBox.Show("The Same User Name Exist!(Case Insensitive)", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("相同的使用者名稱已存在(不分大小寫)", "建立失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            clsUser.Create(name, pws1, (Manage.Type)cbAuth.SelectedIndex);

            this.Visible = false;
        }

        private void tbUserName_Click(object sender, EventArgs e)
        {
            DialogResult kw = fmKeyBox.GetSingleton().ShowDialog(this, "", false);

            if (kw != DialogResult.OK) return;

            tbUserName.Text = fmKeyBox.GetSingleton().KeyBoxValue;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            DialogResult kw = fmKeyBox.GetSingleton().ShowDialog(this, "", false);

            if (kw != DialogResult.OK) return;

            ((TextBox)sender).Text = fmKeyBox.GetSingleton().KeyBoxValue;
        }
    }
}
