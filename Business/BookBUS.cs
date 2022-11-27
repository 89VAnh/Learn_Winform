using Data.DataAccess;
using Data.TransferObjects;
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
        public List<Book> GetBooks()
        {
            return bookDAO.GetBooks();
        }
        public List<Category> GetCategories()
        {
            return bookDAO.GetCategories();
        }
        public void Add(Book book)
        {
            bookDAO.Add(book);
        }
        public void Delete(Book book)
        {
            bookDAO.Delete(book);
        }
        public void Update(Book book)
        {
            bookDAO.Update(book);
        }
    }
}
