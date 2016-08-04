using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestForm
{
    class PayrollHeaderRepository
    {

        SQLConn sql = new SQLConn();


        public void SavePayrollHeader(DateTime dateFrom, DateTime dateTo, string description)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollHeader_Insert]", sql.SQLConnReturn()))
            {
                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date_from", SqlDbType.Date).Value = dateFrom;
                cmd.Parameters.Add("@date_to", SqlDbType.Date).Value = dateTo;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

        public void DeletePayrollHeader(string txtID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollHeader_Delete]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txtID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }


        public DataTable ReturnAllPayrollHeaders()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollHeader_Get_All]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public DataTable ReturnPayrollHeaderByJournal(string ID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollHeader_Search_JournalID]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public void UpdateIsPayed(string txtID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollHeader_paid]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txtID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

    }
}
