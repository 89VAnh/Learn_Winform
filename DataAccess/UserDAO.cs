using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Data.TransferObjects;
using System.Windows.Forms;

namespace Data.DataAccess
{
    internal class UserDAO
    {
        DataHelper dh = new DataHelper();
        public User GetUser(string us)
        {
            string query = $"Select * from Acount where username = '{us}'";
            SqlDataReader dr = dh.ExecuteReader(query);

            User user = null;
            while (dr.Read())
            {
                user = new User();
                user.UserID = (short)dr["id"];
                user.UserName = dr["username"].ToString();
                user.Password = dr["password"].ToString();

                break;
            }
            dh.Close();
            return user;
        }
        public User GetUser(string us, string pw)
        {
            string query = $"Select * from Acount where username = '{us}' and password = '{pw}'";
            SqlDataReader dr = dh.ExecuteReader(query);

            User user = null;
            while (dr.Read())
            {
                user = new User();
                user.UserID = (short)dr["id"];
                user.UserName = dr["username"].ToString();
                user.Password = dr["password"].ToString();

                break;
            }
            dh.Close();
            return user;
        }

        public void Add(User user)
        {
            string query = $"Insert into Acount(username,password) values('{user.UserName}','{user.Password}')";
            dh.ExecuteNonQuery(query);
        }
        public void Update(User user)
        {
            string query = $"Update Acount set password = '{user.Password}' where username = '{user.UserName}'";
            dh.ExecuteNonQuery(query);
        }

        public void Delete(User user)
        {
            string query = $"Delete Acount where id = {user.UserID}";
            dh.ExecuteNonQuery(query);
        }

    }
}
