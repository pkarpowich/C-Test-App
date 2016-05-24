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
    public partial class NewEmployee : Form
    {
        public NewEmployee()
        {
            InitializeComponent();
            
        }

        private void fontDialog2_Apply(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Its all about the Hello World");
            textBox1.Text = "Balls";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string txtFirstName = textBox1.Text;
            string txtLastName = textBox2.Text;
            string txtEmpID = textBox3.Text;
            string txtEmail = textBox4.Text;

            if (txtEmail != "" && txtEmpID != null && txtFirstName != null && txtLastName != null)
            {
 
                try
                {
                    EmployeeRepository saveEmployee = new EmployeeRepository();
                    saveEmployee.SaveEmployee(txtFirstName, txtLastName, txtEmail, txtEmpID);
                    MessageBox.Show("You have saved employee #" + txtEmpID + ".");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("All fields must contain a value.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
