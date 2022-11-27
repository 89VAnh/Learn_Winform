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
    public partial class frmClasses : Form
    {
        List<Class> cls;
        ClassManageBUS cm = new ClassManageBUS();
        public frmClasses()
        {
            InitializeComponent();
        }

        private void LoadDB()
        {
            cls = cm.GetClasses();
            dgvClasses.DataSource = cls;
        }

        private void frmClasses_Load(object sender, EventArgs e)
        {
            LoadDB();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtTotal.Clear();
            txtNote.Clear();
        }
        private bool CheckTextBoxes()
        {
            if (!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtTotal.Text))
            {
                int total;
                if (!int.TryParse(txtTotal.Text, out total))
                {
                    errorProvider.SetError(txtTotal, "Ký tự nhập không chính xác");
                    return false;
                }
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtId.Text)) errorProvider.SetError(txtId, "Vui lòng nhập trường này!");
                if (string.IsNullOrEmpty(txtName.Text)) errorProvider.SetError(txtName, "Vui lòng nhập trường này!");
                if (string.IsNullOrEmpty(txtTotal.Text)) errorProvider.SetError(txtTotal, "Vui lòng nhập trường này!");
                return false;
            }
        }
        private Class getClassFromForm()
        {
            Class cl = null;
            if (CheckTextBoxes())
            {
                cl = new Class();
                cl.MaLop = txtId.Text.Trim();
                cl.TenLop = txtName.Text.Trim();
                cl.SiSo = int.Parse(txtTotal.Text);
                cl.GhiChu = txtNote.Text;
            }
            return cl;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Class cl = getClassFromForm();
            if (cl != null)
            {
                cm.Add(cl);
                MessageBox.Show("Thêm thành công !");
                cls.Add(cl);
                dgvClasses.DataSource = null;
                dgvClasses.DataSource = cls;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Class cl = getClassFromForm();
            if (cl != null)
            {
                cm.Update(cl);
                MessageBox.Show("Sửa thành công !");
                LoadDB();
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            Class cl = getClassFromForm();
            if (cl != null)
            {
                cm.Delete(getClassFromForm());
                MessageBox.Show("Xoá thành công !");
                cls.Remove(cl);
                dgvClasses.DataSource = null;
                dgvClasses.DataSource = cls;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadDB();
        }
        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = Convert.ToString(dgvClasses.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = Convert.ToString(dgvClasses.Rows[e.RowIndex].Cells[1].Value);
            txtTotal.Text = Convert.ToString(dgvClasses.Rows[e.RowIndex].Cells[2].Value);
            txtNote.Text = Convert.ToString(dgvClasses.Rows[e.RowIndex].Cells[3].Value);
        }


    }
}
