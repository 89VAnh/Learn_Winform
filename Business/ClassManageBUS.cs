using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;

namespace Data.Business
{

    public class ClassManageBUS
    {
        ClassDAO classDAO = new ClassDAO();

        public List<Lop> GetClasses()
        {
            return classDAO.GetClasses();
        }

        public bool Add(Lop cl)
        {
            Lop l = classDAO.GetClass(cl.MaLop);
            if (l != null)
            {
                return false;
            }
            else
            {
                classDAO.Add(cl);
                return true;
            }
        }

        public bool Delete(Lop cl)
        {
            Lop l = classDAO.GetClass(cl.MaLop);
            if (l != null)
            {
                classDAO.Delete(cl);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(Lop cl)
        {
            Lop l = classDAO.GetClass(cl.MaLop);
            if (l != null)
            {
                classDAO.Update(cl);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
