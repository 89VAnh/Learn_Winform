using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<Sach> GetBooks()
        {
            return db.Saches;
        }
        public DbSet<LoaiSach> GetCategories()
        {
            return db.LoaiSaches;
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
        public IQueryable<Sach> GetBookByCategory(string categoryId)
        { return db.Saches.Where(s => s.MaLoaiSach == categoryId); }
    }
}
