using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class to store and return SQL connection string.


namespace TestForm
{
    class SQLConn
    {

        SqlConnection sc = new SqlConnection("Data Source=PHIL-THINK;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void SQLOpen()
        {
            sc.Open();

        }

        public void SQLClose()
        {
            sc.Close();
        }

        public SqlConnection SQLConnReturn()
        {
            return(sc);
        }
    }
}
