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
    public partial class frmStudents : Form
    {
        List<Student> sts;
        List<Class> cls;
        StudentBUS stm = new StudentBUS();
        public frmStudents()
        {
            InitializeComponent();
        }
        private void LoadDB()
        {
            sts = stm.GetStudents();
            dgvStudents.DataSource = sts;
        }
        private void frmStudents_Load(object sender, EventArgs e)
        {
            cls = stm.GetClasses();
            cboClass.DataSource = cls.ToList();
            cboClass.ValueMember = "MaLop";
            cboClass.DisplayMember = "TenLop";
            LoadDB();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            cboClass.SelectedIndex = 0;
            dtpBirthday.Value = DateTime.Now;
            LoadDB();
        }
        private bool CheckTextBoxes()
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text)) errorProvider.SetError(txtName, "Vui lòng nhập trường này!");
                if (string.IsNullOrEmpty(txtAddress.Text)) errorProvider.SetError(txtId, "Vui lòng nhập trường này!");
                return false;
            }
        }
        private Student getStudentFromForm()
        {
            Student st = null;
            if (CheckTextBoxes())
            {
                st = new Student();
                st.MaSV = txtId.Text.Trim();
                st.MaLop = cboClass.SelectedValue.ToString().Trim();
                st.HoTen = txtName.Text.Trim();
                st.QueQuan = txtAddress.Text.Trim();
                st.NgaySinh = dtpBirthday.Value;
            }
            return st;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student st = getStudentFromForm();
            if (st != null)
            {
                stm.Add(st);
                MessageBox.Show("Thêm thành công !");
                sts.Add(st);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = sts;
                //if (dgvStudents.RowCount > 0)
                //{

                dgvStudents.CurrentCell = dgvStudents.Rows[dgvStudents.RowCount - 1].Cells[0];
                //}
                //else
                //    dgvStudents.CurrentCell = dgvStudents.Rows[0].Cells[0];
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStudents.DataSource = stm.GetStudentsByClassId(cboClass.SelectedValue.ToString());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Student s = getStudentFromForm();
            if (s != null)
            {
                stm.Delete(s);
                MessageBox.Show("Xoá thành công !");
                sts.Remove(s);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = sts;
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = Convert.ToString(dgvStudents.Rows[e.RowIndex].Cells[0].Value);
            cboClass.Text = Convert.ToString(dgvStudents.Rows[e.RowIndex].Cells[1].Value);
            txtName.Text = Convert.ToString(dgvStudents.Rows[e.RowIndex].Cells[2].Value);
            txtAddress.Text = Convert.ToString(dgvStudents.Rows[e.RowIndex].Cells[3].Value);
            dtpBirthday.Text = ((DateTime)dgvStudents.Rows[e.RowIndex].Cells[4].Value).ToShortDateString();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (sts.Find(st => st.MaSV == id) == null)
            {
                btnAdd.Enabled = true;
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

    }
}
