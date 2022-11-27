using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Business;
using Data.TransferObjects;

namespace Data.DataAccess
{
    public class BookDAO
    {
        DataHelper dh = new DataHelper();

        public List<Book> GetBooks()
        {
            SqlDataReader dr = dh.ExecuteReader("SELECT * FROM Sach");
            List<Book> books = new List<Book>();

            while (dr.Read())
            {
                Book b = new Book();
                b.MaSach = dr["MaSach"].ToString().Trim();
                b.MaLoaiSach = dr["MaLoaiSach"].ToString().Trim();
                b.TieuDe = dr["TieuDe"].ToString().Trim();
                b.Gia = int.Parse(dr["Gia"].ToString());
                b.SoLuong = int.Parse(dr["SoLuong"].ToString());
                books.Add(b);
            }
            dh.Close();
            return books;
        }
        public List<Category> GetCategories()
        {
            SqlDataReader dr = dh.ExecuteReader("SELECT * FROM LoaiSach");
            List<Category> categories = new List<Category>();

            while (dr.Read())
            {
                Category c = new Category();
                c.MaLoaiSach = dr["MaLoaiSach"].ToString().Trim();
                c.TenLoaiSach = dr["TenLoaiSach"].ToString().Trim();
                categories.Add(c);
            }
            dh.Close();
            return categories;
        }
        public void Add(Book book)
        {
            string query = $"Insert into Sach values('{book.MaSach.Trim()}','{book.MaLoaiSach.Trim()}',N'{book.TieuDe}',{book.Gia},{book.SoLuong})";
            dh.ExecuteNonQuery(query);
        }
        public void Update(Book book)
        {
            string query = $"Update Sach set MaLoaiSach = '{book.MaLoaiSach}', TieuDe = N'{book.TieuDe}', Gia = {book.Gia},SoLuong = {book.SoLuong} where MaSach = '{book.MaSach.Trim()}'";
            dh.ExecuteNonQuery(query);
        }

        public void Delete(Book book)
        {
            string query = $"Delete Sach where MaSach = '{book.MaSach.Trim()}'";
            dh.ExecuteNonQuery(query);
        }

    }
}
