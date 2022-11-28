using Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Business
{
    public class StudentBUS
    {
        ClassDAO classDAO = new ClassDAO();
        StudentDAO StudentDAO = new StudentDAO();
        List<Lop> classes = new List<Lop>();

        List<SinhVien> students = new List<SinhVien>();

        public List<Lop> GetClasses()
        {
            classes = classDAO.GetClasses();
            return classes;
        }

        public List<SinhVien> GetStudents()
        {
            students = StudentDAO.GetStudents();
            return students;
        }

        public List<SinhVien> GetStudentsByClassId(string classId)
        {
            List<SinhVien> studentsByClassId = new List<SinhVien>();
            foreach (SinhVien st in students)
            {
                if (st.MaLop == classId)
                {
                    studentsByClassId.Add(st);
                }

            }
            return studentsByClassId;

        }
        public string getStudentId(string classId)
        {
            List<SinhVien> studentsInClass = GetStudentsByClassId(classId);
            if (studentsInClass.Count > 0)
            {
                string lastStudentId = studentsInClass[studentsInClass.Count - 1].MaSV;
                string id = lastStudentId.Substring(lastStudentId.Length - 2);
                id = (int.Parse(id) + 1).ToString();
                if (id.Length < 2) id = "0" + id;
                return classId + id;
            }
            else
                return classId + "01";
        }

        public bool Add(SinhVien st)
        {
            string studentId = getStudentId(st.MaLop);
            st.MaSV = studentId;
            SinhVien s = StudentDAO.GetStudent(st.MaSV);

            if (s != null)
            {
                return false;
            }
            else
            {
                StudentDAO.Add(st);
                classDAO.UpdateTotal(st.MaLop, 1);
                return true;
            }
        }

        public bool Delete(SinhVien st)
        {
            SinhVien s = StudentDAO.GetStudent(st.MaLop);
            if (s != null)
            {
                StudentDAO.Delete(st);
                classDAO.UpdateTotal(s.MaLop, -1);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(SinhVien st)
        {
            SinhVien s = students.Find(temp => temp.MaSV == st.MaSV);
            if (s != null)
            {
                if (s.MaLop != st.MaLop)
                {
                    classDAO.UpdateTotal(s.MaLop, 1);
                    classDAO.UpdateTotal(st.MaLop, -1);
                }
                StudentDAO.Update(st);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
