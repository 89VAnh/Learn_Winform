using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Business;

namespace Data.DataAccess
{
    public class BookDAO
    {
        QLSVEntities db = new QLSVEntities();

        public List<Sach> GetBooks()
        {
            return db.Saches.ToList();
        }
        public List<LoaiSach> GetCategories()
        {
            return db.LoaiSaches.ToList();
        }
        public void Add(Sach book)
        {
            db.Saches.Add(book);
            db.SaveChanges();
        }
        public void Update(Sach book)
        {
            Sach s = db.Saches.Find(book.MaSach);
            s.MaLoaiSach = book.MaLoaiSach;
            s.TieuDe = book.TieuDe;
            s.Gia = book.Gia;
            s.SoLuong = book.SoLuong;
            db.SaveChanges();
        }

        public void Delete(Sach book)
        {
            Sach s = db.Saches.Find(book.MaSach);
            db.Saches.Remove(s);
            db.SaveChanges();
        }

    }
}
