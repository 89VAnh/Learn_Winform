using Data.TransferObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data.DataAccess
{
    public class StudentDAO
    {
        DataHelper dh = new DataHelper();
        public List<Student> GetStudents()
        {
            SqlDataReader dr = dh.ExecuteReader("Select * from SinhVien");
            List<Student> students = new List<Student>();
            while (dr.Read())
            {
                Student st = new Student();
                st.MaSV = dr["MaSV"].ToString().Trim();
                st.MaLop = dr["MaLop"].ToString().Trim();
                st.HoTen = dr["HoTen"].ToString().Trim();
                st.QueQuan = dr["QueQuan"].ToString().Trim();
                st.NgaySinh = (DateTime)dr["NgaySinh"];
                students.Add(st);
            }
            dh.Close();
            return students;
        }
        public Student GetStudent(string id)
        {
            SqlDataReader dr = dh.ExecuteReader($"Select * from SinhVien where MaSV = '{id}'");
            Student st = null;
            while (dr.Read())
            {
                st = new Student();
                st.MaSV = dr["MaSV"].ToString().Trim();
                st.MaLop = dr["MaLop"].ToString().Trim();
                st.HoTen = dr["HoTen"].ToString().Trim();
                st.QueQuan = dr["QueQuan"].ToString().Trim();
                st.NgaySinh = (DateTime)dr["NgaySinh"];
                break;
            }
            dh.Close();
            return st;
        }

        public void Add(Student st)
        {
            string query = $"Insert into SinhVien values('{st.MaSV}','{st.MaLop}',N'{st.HoTen}',N'{st.QueQuan}','{st.NgaySinh}')";
            dh.ExecuteNonQuery(query);
        }
        public void Update(Student st)
        {
            string query = $"Update SinhVien set  MaSV = '{st.MaSV}', MaLop = '{st.MaLop}', HoTen = N'{st.HoTen}' where NgaySinh = {st.NgaySinh}";
            dh.ExecuteNonQuery(query);
        }

        public void Delete(Student st)
        {
            string query = $"Delete SinhVien where MaSV = '{st.MaSV}'";
            dh.ExecuteNonQuery(query);
        }


    }
}
