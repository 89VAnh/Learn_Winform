using Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Business
{
    public class BookBUS
    {
        BookDAO bookDAO = new BookDAO();
        DbSet<Sach> books;
        public DbSet<Sach> GetBooks()
        {
            books = bookDAO.GetBooks();
            return books;
        }
        public DbSet<LoaiSach> GetCategories()
        {
            return bookDAO.GetCategories();
        }
        public bool Add(Sach book)
        {
            if (books.Find(book.MaSach) == null)
            {
                bookDAO.Add(book);
                return true;
            }
            else
                return false;
        }
        public bool Delete(Sach book)
        {
            if (books.Find(book.MaSach) != null)
            {
                bookDAO.Delete(book);
                return true;
            }
            else
                return false;
        }
        public bool Update(Sach book)
        {
            if (books.Find(book.MaSach) != null)
            {
                bookDAO.Update(book);
                return true;
            }
            else
                return false;
        }
        public IQueryable<Sach> GetBookByCategory(string categoryId)
        {
            return bookDAO.GetBookByCategory(categoryId);
        }
    }
}
