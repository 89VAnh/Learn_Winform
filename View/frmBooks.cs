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
using Data.TransferObjects;

namespace Data.View
{
    public partial class frmBooks : Form
    {
        public frmBooks()
        {
            InitializeComponent();
        }

        List<Book> books = new List<Book>();
        BookBUS bookBUS = new BookBUS();
        public void LoadDB()
        {
            books = bookBUS.GetBooks();
            dgvBook.DataSource = books;
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>();
            categories = bookBUS.GetCategories();
            cboCategoryBook.DataSource = categories.ToList();
            cboCategoryBook.ValueMember = "MaLoaiSach";
            cboCategoryBook.DisplayMember = "TenLoaiSach";
            LoadDB();
        }
        Book getBookFromForm()
        {
            Book book = new Book();
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
    }
}
