﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class EmployeeRepository
    {

        SQLConn sql = new SQLConn();

        public void SaveEmployee(string txtFirstName, string txtLastName, string txtEmail, string txtEmpID, string txtEmpType)
        {
            SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Insert]", sql.SQLConnReturn());

            sql.SQLOpen();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName;
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = txtLastName;
            cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = txtEmail;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtEmpID;
            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value =  txtEmpType;
            cmd.ExecuteNonQuery();

            sql.SQLClose();
        }


       public void DeleteEmployee(string txtEmpID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Delete]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtEmpID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

        public void UpdateEmployee(string txtFirstName, string txtLastName, string txtEmail, string txtEmpID)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Update]", sql.SQLConnReturn()))
            {

                sql.SQLOpen();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = txtLastName;
                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = txtEmail;
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtEmpID;
                cmd.ExecuteNonQuery();

                sql.SQLClose();
            }
        }

        public DataTable ReturnAllEmployees()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Get_All]", sql.SQLConnReturn()))
            {
                sql.SQLOpen();

                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public DataTable ReturnAllEmployeesConcat()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Get_All_concat]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public DataTable ReturnEmployeeByLastName(string lastName)
        {
            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_Employees_Search_LastName]", sql.SQLConnReturn()))
            {
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastName;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                sql.SQLClose();
                return dt;
            }
        }

        public DataTable ReturnAllEmployeeTypes()
        {

            using (SqlCommand cmd = new SqlCommand("payroll.[dbo].[sp_EmployeesType_Get_All]", sql.SQLConnReturn()))
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
