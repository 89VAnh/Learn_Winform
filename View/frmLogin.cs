using Data.Business;
using Data.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public partial class frmLogin : Form
    {
        LoginBUS loginBUS = new LoginBUS();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUN.TextLength == 0 || txtPW.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");

                if (txtUN.TextLength == 0)
                {
                    txtUN.Focus();
                    errorProvider.SetError(txtUN, "Vui lòng nhập tên tài khoản");
                }
                if (txtPW.TextLength == 0)
                {
                    txtPW.Focus();
                    errorProvider.SetError(txtPW, "Vui lòng nhập mật khẩu");
                }

                return;
            }

            PublicModule.us = loginBUS.GetUser(txtUN.Text);
            if (PublicModule.us == null)
            {
                MessageBox.Show("Ten tai khoan sai");
                errorProvider.SetError(txtUN, "Tên tài khoản sai");
                txtUN.SelectionStart = 0; txtUN.SelectionLength = txtUN.TextLength;
                txtUN.Focus();
            }
            else
            {

                PublicModule.us = loginBUS.GetUser(txtUN.Text, txtPW.Text);
                if (PublicModule.us == null)
                {
                    MessageBox.Show("Mật khẩu sai");
                    errorProvider.SetError(txtPW, "Mật khẩu sai");
                    txtPW.SelectionStart = 0; txtPW.SelectionLength = txtPW.TextLength;
                    txtPW.Focus();
                }
                else
                {
                    this.Hide();
                    MDIApp f = new MDIApp();
                    f.ShowDialog();
                    this.Close();

                }

            }
        }

        private void txtUN_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSignin f = new frmSignin();
            f.ShowDialog();
            this.Close();
        }
    }
}
