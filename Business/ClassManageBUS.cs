using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.TransferObjects;
using Data.DataAccess;

namespace Data.Business
{

    public class ClassManageBUS
    {
        ClassDAO classDAO = new ClassDAO();

        public List<Class> GetClasses()
        {
            return classDAO.GetClasses();
        }

        public bool Add(Class cl)
        {
            Class l = classDAO.GetClass(cl.MaLop);
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

        public bool Delete(Class cl)
        {
            Class l = classDAO.GetClass(cl.MaLop);
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
        public bool Update(Class cl)
        {
            Class l = classDAO.GetClass(cl.MaLop);
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
