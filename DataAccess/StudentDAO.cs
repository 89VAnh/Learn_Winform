using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class StudentDAO
    {
        QLSVEntities db = new QLSVEntities();
        public List<SinhVien> GetStudents()
        {

            return db.SinhViens.ToList();
        }
        public SinhVien GetStudent(string id)
        {

            return db.SinhViens.Find(id);
        }

        public void Add(SinhVien sv)
        {
            db.SinhViens.Add(sv);
            db.SaveChanges();
        }
        public void Update(SinhVien sv)
        {
            SinhVien sinhVien = db.SinhViens.Find(sv.MaSV);
            sinhVien.MaLop = sv.MaLop;
            sinhVien.HoTen = sv.HoTen;
            sinhVien.QueQuan = sv.QueQuan;
            sinhVien.NgaySinh = sv.NgaySinh;
            db.SaveChanges();
        }

        public void Delete(SinhVien sv)
        {
            db.SinhViens.Remove(sv);
            db.SaveChanges();
        }
    }
}
