using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class CruiseLineRepository
    {

        SQLConn sql = new SQLConn();

        public void SaveCL(string txtShipID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_CL_Insert]", sql.SQLConnReturn()))
            {
                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtShipID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }


       public void DeleteCL(string txtShipID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_CL_Delete]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtShipID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

       
        public DataTable ReturnAllCL()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_CL_Get_All]", sql.SQLConnReturn()))
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
