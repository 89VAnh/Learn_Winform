using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

        DbSet<Sach> books;
        BookBUS bookBUS = new BookBUS();
        public void LoadDB()
        {
            books = bookBUS.GetBooks();
            var displayBooks = (from b in books select new { b.MaSach, b.LoaiSach.TenLoaiSach, b.TieuDe, b.Gia, b.SoLuong }).ToList();
            dgvBook.DataSource = displayBooks;
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            List<LoaiSach> categories = bookBUS.GetCategories().ToList();
            cboCategoryBook.DataSource = categories;
            cboCategoryBook.ValueMember = "MaLoaiSach";
            cboCategoryBook.DisplayMember = "TenLoaiSach";
            LoadDB();
        }
        Sach getBookFromForm()
        {
            Sach book = new Sach();
            book.MaSach = txtId.Text.Trim();
            book.MaLoaiSach = cboCategoryBook.SelectedValue.ToString();
            book.TieuDe = txtDescription.Text.Trim();
            book.Gia = int.Parse(txtPrice.Text);
            book.SoLuong = int.Parse(txtQuantity.Text);

            return book;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (bookBUS.Add(getBookFromForm()))
            {
                LoadDB();
                MessageBox.Show("Thêm thành công!");
            }
            else
                MessageBox.Show("Mã sách đã tồn tại");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bookBUS.Update(getBookFromForm()))
            {
                LoadDB();
                MessageBox.Show("Sửa thành công!");
            }
            else
                MessageBox.Show("Mã sách không tồn tại");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (bookBUS.Delete(getBookFromForm()))
            {
                LoadDB();
                MessageBox.Show("Xoá thành công!");
            }
            else
                MessageBox.Show("Mã sách không tồn tại");
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[0].Value).Trim();
            txtDescription.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[2].Value).Trim();
            txtPrice.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[3].Value).Trim();
            txtQuantity.Text = Convert.ToString(dgvBook.Rows[e.RowIndex].Cells[4].Value).Trim();
        }

        private void cboCategoryBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var displayBooks = (from b in bookBUS.GetBookByCategory(cboCategoryBook.SelectedValue.ToString()) select new { b.MaSach, b.LoaiSach.TenLoaiSach, b.TieuDe, b.Gia, b.SoLuong }).ToList();
            dgvBook.DataSource = displayBooks;
        }
    }
}
