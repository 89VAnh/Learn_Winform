using Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Business
{
    public class LoginBUS
    {
        UserDAO userDAO = new UserDAO();
        public Acount GetUser(string us, string pw)
        {
            Acount user = userDAO.GetUser(us, pw);
            return user;
        }
        public Acount GetUser(string us)
        {
            Acount user = userDAO.GetUser(us);
            return user;
        }

        public bool CreateAccount(Acount us)
        {
            Acount user = userDAO.GetUser(us.username);
            if (user != null)
            {
                return false;
            }
            else
            {
                userDAO.Add(us);
                return true;
            }

        }
    }
}
