using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestForm
{
    public partial class EditEmployee : Form
    {
        String ID = "";

        SQLConn sql = new SQLConn();
        EmployeeRepository employees = new EmployeeRepository();

        public EditEmployee()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {

            DataTable dt = employees.ReturnAllEmployees();
            dataGridView1.DataSource = dt;
            

        }

        private void button1_Click(object sender, EventArgs e)
       {
            DataTable dt = employees.ReturnEmployeeByLastName(textBox1.Text);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employees.DeleteEmployee(ID);
            MessageBox.Show("You have deleted employee #" + ID + ".");

            DataTable dt = employees.ReturnAllEmployees();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_EmpID"].Value);
        }
    }
}
