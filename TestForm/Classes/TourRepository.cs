using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestForm
{
    class TourRepository
    {
        SQLConn sql = new SQLConn();

        public void SaveTour(string txtTourID, string txtPort, string txtTourName, decimal decimalRate)
        {
            Math.Round(decimalRate, 2);

            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Tour_Insert]", sql.SQLConnReturn());
            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tourID", SqlDbType.VarChar).Value = txtTourID;
            cmd.Parameters.Add("@port", SqlDbType.VarChar).Value = txtPort;
            cmd.Parameters.Add("@tourName", SqlDbType.VarChar).Value = txtTourName;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = decimalRate;

            cmd.ExecuteNonQuery();

            sql.SQLClose();

        }


        public void DeleteTour(string txtID)
        {
            SqlCommand cmd = new SqlCommand("payroll.dbo.sp_tour_delete", sql.SQLConnReturn());
            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtID;

            cmd.ExecuteNonQuery();
            sql.SQLClose();
        }

        public DataTable  ReturnAllTours()
        {

            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Tour_Get_All]", sql.SQLConnReturn());
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            sql.SQLClose();
            return dt;
        }

        public DataTable ReturnToursByPort(string txtPort)
        {

            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Tour_Search_Port]", sql.SQLConnReturn());
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@port", SqlDbType.VarChar).Value = txtPort;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            sql.SQLClose();
            return dt;
        }

        public DataTable ReturnToursByTourName(string txtTourName)
        {

            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Tour_Search_Tour_Name]", sql.SQLConnReturn());
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tourName", SqlDbType.VarChar).Value = txtTourName;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            sql.SQLClose();
            return dt;
        }

        public void UpdateTour(string txtTourID, string txtPort, string txtTourName, decimal decimalRate)
        {
            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Tour_Update]", sql.SQLConnReturn());

            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtTourID;
            cmd.Parameters.Add("@port", SqlDbType.VarChar).Value = txtPort;
            cmd.Parameters.Add("@tourName", SqlDbType.VarChar).Value = txtTourName;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = decimalRate;

            cmd.ExecuteNonQuery();
            sql.SQLClose();
        }
    }
}
