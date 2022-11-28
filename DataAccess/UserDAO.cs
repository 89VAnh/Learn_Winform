using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data.DataAccess
{
    internal class UserDAO
    {
        QLSVEntities db = new QLSVEntities();
        public Acount GetUser(string us)
        {
            return db.Acounts.SingleOrDefault(a => a.username == us);
        }
        public Acount GetUser(string us, string pw)
        {
            return db.Acounts.SingleOrDefault(a => a.username == us && a.password == pw);
        }

        public void Add(Acount user)
        {
            db.Acounts.Add(user);
        }
        public void Update(Acount user)
        {
            Acount u = db.Acounts.Find(user.Id);
            u.username = user.username;
            u.password = user.password;
            db.SaveChanges();
        }

        public void Delete(Acount user)
        {
            db.Acounts.Remove(user);
        }

    }
}
