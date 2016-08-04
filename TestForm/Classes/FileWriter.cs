using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestForm
{
    class FileWriter
    {
            
        public void test()
        {

            using (StreamWriter writer = new StreamWriter("C:\\Users\\phil\\Documents\\payroll.txt"))
            {
                writer.WriteLine("test2");

                SQLConn sql = new SQLConn();

                sql.SQLOpen();

                SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Get_All]", sql.SQLConnReturn());

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    writer.WriteLine(reader["FirstName"]);
                }
            }

        }


        public void generatePayrollFile(string ID)
        {



            //string text = System.IO.File.ReadAllText("C:\\Payroll\\FileLoaction.txt");
            //using (StreamWriter writer = new StreamWriter(text + "payroll_" + DateTime.Now.ToString("yyyy-dd-M") + ".txt"))
             using (StreamWriter writer = new StreamWriter("C:\\Users\\phil\\Documents\\payroll_" + DateTime.Now.ToString("yyyy-dd-M") + ".txt"))


            {

                SQLConn sql = new SQLConn();

                sql.SQLOpen();

                SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollTotal_Get]", sql.SQLConnReturn());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ID;

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    writer.WriteLine(reader["employeeID"] + "," + reader["1099"] + "," + reader["w-2"] + "," + reader["salary"]);
                }
            }
        }

    }
}
