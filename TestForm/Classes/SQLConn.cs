using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Class to store and return SQL connection string.


namespace TestForm
{
    class SQLConn
    {

        static string text = System.IO.File.ReadAllText("C:\\Payroll\\SqlConnectionString.txt");
        SqlConnection sc = new SqlConnection(text);

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
            return (sc);
        }
    }
}
