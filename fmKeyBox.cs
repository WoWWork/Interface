using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CM_100
{
    public partial class fmKeyBox : Form
    {
        private static fmKeyBox m_cSingleton = null;
        private string m_strKeyBoxValue = "";
        private static bool m_bCapsLock = false;
        private static bool m_bShift = false;
        private static bool m_bPassWord = false;
        private static bool m_bPressBtnProced = false;
        private static string m_SourceString = "";
        private List<Button> lsbtnKeyWords = new List<Button>();

        public const int _KEY_BOX_MAX_LENGTH = 50;

        public string KeyBoxValue
        {
            get { return m_strKeyBoxValue; }
            set { m_strKeyBoxValue = value; }
        }

        public fmKeyBox()
        {
            InitializeComponent();
            lsbtnKeyWords.AddRange(new Button[] {btn_A, btn_B, btn_C, btn_D, btn_E, btn_F, btn_G, btn_H, btn_I, btn_J, btn_K,
                btn_L, btn_M, btn_N, btn_O, btn_P, btn_Q, btn_R, btn_S, btn_T, btn_U, btn_V, btn_W, btn_X, btn_Y, btn_Z});
        }

        public DialogResult ShowDialog(IWin32Window p_objControl, string p_strSource, bool p_bInputPassword)
        {
            m_SourceString = p_strSource;
            m_bPassWord = p_bInputPassword;

            btn_00.Enabled = true;
            btn_01.Enabled = true;
            btn_02.Enabled = true;
            btn_03.Enabled = true;
            btn_04.Enabled = true;
            btn_05.Enabled = true;

            if (p_bInputPassword)
            {
                textBox_Result.PasswordChar = '*';
                btn_00.Enabled = false;
                btn_01.Enabled = false;
                btn_02.Enabled = false;
                btn_03.Enabled = false;
                btn_04.Enabled = false;
                btn_05.Enabled = false;
            }
            else
            {
                textBox_Result.PasswordChar = '\0';
            }
            SetKeyWordsText();

            return this.ShowDialog(p_objControl);
        }

        public static fmKeyBox GetSingleton()
        {
            if(m_cSingleton == null)
            {
                m_cSingleton = new fmKeyBox();
            }
            return m_cSingleton;
        }

        private void RefreshKeyboard()
        {
            if (m_bShift)
            {
                btn_1.Text = "!"; btn_2.Text = "@"; btn_3.Text = "#"; btn_4.Text = "$"; btn_5.Text = "%";
                btn_6.Text = "^"; btn_7.Text = "&&"; btn_8.Text = "*"; btn_9.Text = "("; btn_0.Text = ")";

                SetKeyWordsText();

                btn_00.Text = "`"; btn_00.Text = "-"; btn_02.Text = "["; btn_03.Text = "]"; btn_04.Text = "_";
                btn_05.Text = ".";

            }
            else
            {
                btn_1.Text = "1"; btn_2.Text = "2"; btn_3.Text = "3"; btn_4.Text = "4"; btn_5.Text = "5";
                btn_6.Text = "6"; btn_7.Text = "7"; btn_8.Text = "8"; btn_9.Text = "9"; btn_0.Text = "0";

                SetKeyWordsText();

                btn_00.Text = "`"; btn_00.Text = "-"; btn_02.Text = "["; btn_03.Text = "]"; btn_04.Text = "_";
                btn_05.Text = ".";
            }
        }

        private void SetKeyWordsText()
        {
            m_bCapsLock = Console.CapsLock;
            if (m_bCapsLock)
            {
                btn_CL.BackColor = Color.Lime;
            }
            else
            {
                btn_CL.BackColor = this.BackColor;
            }

            bool bIsUpper = m_bCapsLock ^ m_bShift;
            for (int ibtnNum = 0; ibtnNum < lsbtnKeyWords.Count; ibtnNum++ )
            {
                if(bIsUpper)
                {
                    lsbtnKeyWords[ibtnNum].Text = lsbtnKeyWords[ibtnNum].Text.ToUpper();
                }
                else
                {
                    lsbtnKeyWords[ibtnNum].Text = lsbtnKeyWords[ibtnNum].Text.ToLower();
                }
            }
        }

        private void btn_Alpha_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text.Length < _KEY_BOX_MAX_LENGTH)
            {
                textBox_Result.Text = textBox_Result.Text + ((Button)sender).Text;
            }
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            m_strKeyBoxValue = textBox_Result.Text;
            this.Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Visible = false;
        }

        private void btn_BS_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text.Length > 0)
            {
                textBox_Result.Text = textBox_Result.Text.Remove(textBox_Result.Text.Length - 1, 1);
            }
        }

        private void btn_CL_Click(object sender, EventArgs e)
        {
            foreach (Button btn in lsbtnKeyWords)
            {
                char ch = btn.Text[0];

                if (char.IsUpper(ch))
                {
                    btn.Text = char.ToLower(ch).ToString();
                }
                else
                {
                    btn.Text = char.ToUpper(ch).ToString();
                }
            }
        }
    }
}
