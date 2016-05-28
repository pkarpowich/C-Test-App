using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestForm

{
    class CallRepository
    {
        SQLConn sql = new SQLConn();



        public void SaveCall(string txtShip, string txtPort, DateTime txtDate)
        {
            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Call_Insert]", sql.SQLConnReturn());

            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ship", SqlDbType.VarChar).Value = txtShip;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = txtDate;
            cmd.Parameters.Add("@FK_PortID", SqlDbType.VarChar).Value = txtPort;
            cmd.ExecuteNonQuery();

            sql.SQLClose();
        }


        public void DeleteCall(string txtID)
        {
            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Call_Delete]", sql.SQLConnReturn());

            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtID;
            cmd.ExecuteNonQuery();

            sql.SQLClose();
        }

        public DataTable ReturnAllCalls()
        {

            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Call_Get_All]", sql.SQLConnReturn());
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            sql.SQLClose();
            return dt;
        }
    }
}
