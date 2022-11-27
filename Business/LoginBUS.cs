using Data.DataAccess;
using Data.TransferObjects;
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
        public User GetUser(string us, string pw)
        {
            User user = userDAO.GetUser(us, pw);
            return user;
        }
        public User GetUser(string us)
        {
            User user = userDAO.GetUser(us);
            return user;
        }

        public bool CreateAccount(User us)
        {
            User user = userDAO.GetUser(us.UserName);
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
