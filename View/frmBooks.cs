using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Business;
using Data.DataAccess;

namespace Data.View
{
    public partial class frmBooks : Form
    {
        public frmBooks()
        {
            InitializeComponent();
        }

        List<Sach> books = new List<Sach>();
        BookBUS bookBUS = new BookBUS();
        public void LoadDB()
        {
            books = bookBUS.GetBooks();
            List<Sach> displayBooks = new List<Sach>();
            dgvBook.DataSource = books;

        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            List<LoaiSach> categories = bookBUS.GetCategories();
            cboCategoryBook.DataSource = categories;
            cboCategoryBook.ValueMember = "MaLoaiSach";
            cboCategoryBook.DisplayMember = "TenLoaiSach";
            LoadDB();
        }
        Sach getBookFromForm()
        {
            Sach book = new Sach();
            book.MaSach = txtId.Text;
            book.MaLoaiSach = cboCategoryBook.SelectedValue.ToString();
            book.TieuDe = txtDescription.Text;
            book.Gia = int.Parse(txtPrice.Text);
            book.SoLuong = int.Parse(txtQuantity.Text);

            return book;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bookBUS.Add(getBookFromForm());
            LoadDB();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bookBUS.Update(getBookFromForm());
            LoadDB();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bookBUS.Delete(getBookFromForm());
            LoadDB();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[0].Value);
            cboCategoryBook.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[1].Value);
            txtDescription.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[2].Value);
            txtPrice.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[3].Value);
            txtQuantity.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[4].Value);
        }

        private void cboCategoryBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
