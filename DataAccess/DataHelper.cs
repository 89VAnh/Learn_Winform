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
    internal class DataHelper
    {
        string strCon = "Data Source=.\\VIETANH;Initial Catalog=QLSV;Integrated Security=True";

        SqlConnection con;
        public DataHelper()
        {
            con = new SqlConnection(strCon);
        }
        public DataHelper(string strCon)
        {
            this.strCon = strCon;
            con = new SqlConnection(strCon);
        }

        /// <summary>
        /// This method to open a connection to database
        /// </summary>
        /// <returns>return True if a connection opened successfull, else False </returns>
        public bool Open()
        {
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        /// <summary>
        /// Thực thi các câu lệnh truy vấn hành động
        /// </summary>
        /// <param name="query">Câu lệnh truy vấn</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string query)
        {
            Open();
            SqlCommand cmd = new SqlCommand(query, con);
            return cmd.ExecuteReader();
        }

        public void ExecuteNonQuery(string query)
        {

            Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Close();
        }
    }


}
