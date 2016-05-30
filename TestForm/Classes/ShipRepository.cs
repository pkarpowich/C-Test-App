using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class ShipRepository
    {

        SQLConn sql = new SQLConn();

        public void SaveShip(string txtShipID, string txtShipName, string txtCrsuiseLine)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Ship_Insert]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtShipID;
                cmd.Parameters.Add("@ShipName", SqlDbType.VarChar).Value = txtShipName;
                cmd.Parameters.Add("@CruiseLine", SqlDbType.VarChar).Value = txtCrsuiseLine;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }


       public void DeleteShip(string txtShipID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Ship_Delete]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtShipID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

       
        public DataTable ReturnAllShips()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Ship_Get_All]", sql.SQLConnReturn()))
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
