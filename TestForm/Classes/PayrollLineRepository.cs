using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TestForm
{
    class PayrollLineRepository
    {
        SQLConn sql = new SQLConn();


        public void SavePayrollLine(string intHeader, string txtCallID, string txtEmployeeID, string txtTourID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollLine_Insert]", sql.SQLConnReturn()))
            {
                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@HeaderID", SqlDbType.VarChar).Value = intHeader;
                cmd.Parameters.Add("@callId", SqlDbType.VarChar).Value = txtCallID;
                cmd.Parameters.Add("@employeeID", SqlDbType.VarChar).Value = txtEmployeeID;
                cmd.Parameters.Add("@tourID", SqlDbType.VarChar).Value = txtTourID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }


        public void SavePayrollLineAdj(string intHeader, string txtCallID, string txtEmployeeID, decimal amount)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollLine_Insert_Adjustment]", sql.SQLConnReturn()))
            {
                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@HeaderID", SqlDbType.VarChar).Value = intHeader;
                cmd.Parameters.Add("@callId", SqlDbType.VarChar).Value = txtCallID;
                cmd.Parameters.Add("@employeeID", SqlDbType.VarChar).Value = txtEmployeeID;
                cmd.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

        public DataTable ReturnAllLinesByJournal(string intHeader)
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollLine_Search_JournalID]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@HeaderID", SqlDbType.VarChar).Value = intHeader;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public void DeletePayrollLine(string txtID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_PayrollLine_Delete]", sql.SQLConnReturn()))
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
