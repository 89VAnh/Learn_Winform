using Data.Business;
using Data.TransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data.View
{
    public partial class frmSignin : Form
    {
        LoginBUS loginBUS = new LoginBUS();
        public frmSignin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            f.ShowDialog();
            this.Close();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (txtUN.TextLength == 0 || txtPW.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");

                if (txtUN.TextLength == 0) errorProvider.SetError(txtUN, "Vui lòng nhập tên tài khoản");
                if (txtPW.TextLength == 0) errorProvider.SetError(txtPW, "Vui lòng nhập mật khẩu");

                return;
            }
            if (txtPW.Text == txtRePW.Text)
            {

                User user = new User();
                user.UserName = txtUN.Text;
                user.Password = txtPW.Text;
                if (loginBUS.CreateAccount(user))
                {
                    MessageBox.Show("Tạo tài khoản thành công !");
                    this.Hide();
                    frmLogin f = new frmLogin();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại !");
                    txtUN.SelectionStart = 0;
                    txtUN.SelectionLength = txtUN.TextLength;

                }
            }
            else
            {
                errorProvider.SetError(txtRePW, "PassWord and RePassWord must equal");
            }
        }

        private void txtUN_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtRePW_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
