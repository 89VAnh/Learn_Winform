using Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Business
{
    public class BookBUS
    {
        BookDAO bookDAO = new BookDAO();
        public List<Sach> GetBooks()
        {
            return bookDAO.GetBooks();
        }
        public List<LoaiSach> GetCategories()
        {
            return bookDAO.GetCategories();
        }
        public void Add(Sach book)
        {
            bookDAO.Add(book);
        }
        public void Delete(Sach book)
        {
            bookDAO.Delete(book);
        }
        public void Update(Sach book)
        {
            bookDAO.Update(book);
        }
    }
}
