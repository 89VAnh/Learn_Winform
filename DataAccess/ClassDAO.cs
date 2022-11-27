using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.TransferObjects;

namespace Data.DataAccess
{
    public class ClassDAO
    {
        DataHelper dh = new DataHelper();
        public List<Class> GetClasses()
        {
            SqlDataReader dr = dh.ExecuteReader("Select * from Lop");
            List<Class> classes = new List<Class>();
            while (dr.Read())
            {
                Class cl = new Class();
                cl.MaLop = dr["MaLop"].ToString().Trim();
                cl.TenLop = dr["TenLop"].ToString().Trim();
                cl.SiSo = int.Parse(dr["SiSo"].ToString());
                cl.GhiChu = dr["GhiChu"].ToString().Trim();
                classes.Add(cl);
            }
            dh.Close();
            return classes;
        }
        public Class GetClass(string id)
        {
            SqlDataReader dr = dh.ExecuteReader($"Select * from Lop where MaLop = '{id}'");
            Class cl = null;
            while (dr.Read())
            {
                cl = new Class();
                cl.MaLop = dr["MaLop"].ToString().Trim();
                cl.TenLop = dr["TenLop"].ToString().Trim();
                cl.SiSo = int.Parse(dr["SiSo"].ToString());
                cl.GhiChu = dr["GhiChu"].ToString().Trim();
                break;
            }
            dh.Close();
            return cl;
        }

        public void Add(Class cl)
        {
            string query = $"Insert into Lop values('{cl.MaLop.Trim()}','{cl.TenLop.Trim()}',{cl.SiSo},N'{cl.GhiChu}')";
            dh.ExecuteNonQuery(query);
        }
        public void Update(Class cl)
        {
            string query = $"Update Lop set TenLop = '{cl.TenLop.Trim()}', SiSo = {cl.SiSo}, GhiChu = N'{cl.GhiChu}' where MaLop = '{cl.MaLop.Trim()}'";
            dh.ExecuteNonQuery(query);
        }

        public void Delete(Class cl)
        {
            string query = $"Delete Lop where MaLop = '{cl.MaLop.Trim()}'";
            dh.ExecuteNonQuery(query);
        }
        public void UpdateTotal(string classId, int changeValue)
        {
            string query = $"update Lop set SiSo = SiSo + {changeValue} where MaLop='{classId}'";
            dh.ExecuteNonQuery(query);
        }
    }
}
