using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class ClassDAO
    {
        QLSVEntities db = new QLSVEntities();
        public List<Lop> GetClasses()
        {
            return db.Lops.ToList();
        }
        public Lop GetClass(string id)
        {

            return db.Lops.Find(id);
        }

        public void Add(Lop l)
        {
            db.Lops.Add(l);
            db.SaveChanges();
        }
        public void Update(Lop l)
        {
            Lop lop = db.Lops.Find(l.MaLop);
            lop.TenLop = l.MaLop;
            db.SaveChanges();
        }

        public void Delete(Lop l)
        {
            db.Lops.Remove(l);
            db.SaveChanges();
        }
        public void UpdateTotal(string classId, int changeValue)
        {
            Lop lop = db.Lops.Find(classId);
            lop.SiSo = lop.SiSo + changeValue;
            db.SaveChanges();
        }
    }
}
