using Data.DataAccess;
using Data.TransferObjects;
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
        List<Class> classes = new List<Class>();

        List<Student> students = new List<Student>();

        public List<Class> GetClasses()
        {
            classes = classDAO.GetClasses();
            return classes;
        }

        public List<Student> GetStudents()
        {
            students = StudentDAO.GetStudents();
            for (int i = 0; i < students.Count; i++)
            {
                students[i].STT = i + 1;
            }
            return students;
        }

        public List<Student> GetStudentsByClassId(string classId)
        {
            List<Student> studentsByClassId = new List<Student>();
            foreach (Student st in students)
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
            List<Student> studentsInClass = GetStudentsByClassId(classId);
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

        public bool Add(Student st)
        {
            string studentId = getStudentId(st.MaLop);
            st.MaSV = studentId;
            Student s = StudentDAO.GetStudent(st.MaSV);

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

        public bool Delete(Student st)
        {
            Student s = StudentDAO.GetStudent(st.MaLop);
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
        public bool Update(Student st)
        {
            Student s = students.Find(temp => temp.MaSV == st.MaSV);
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
