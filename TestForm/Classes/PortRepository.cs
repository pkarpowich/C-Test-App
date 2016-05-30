using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class PortRepository
    {

        SQLConn sql = new SQLConn();

        public void SavePort(string txtPortID, string txtPortName)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Port_Insert]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PortID", SqlDbType.VarChar).Value = txtPortID;
                cmd.Parameters.Add("@PortName", SqlDbType.VarChar).Value = txtPortName;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }


       public void DeletePort(string txtPortID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Port_Delete]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@portID", SqlDbType.VarChar).Value = txtPortID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

       
        public DataTable ReturnAllPorts()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Port_Get_All]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

    }
}
