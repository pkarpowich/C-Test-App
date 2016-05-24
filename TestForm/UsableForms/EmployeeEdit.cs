using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class EmployeeEdit : Form
    {
        EmployeeRepository Repo = new EmployeeRepository();
        String ID = "";

        public EmployeeEdit()
        {
            InitializeComponent();
        }

        private void EmployeeEdit_Load(object sender, EventArgs e)
        {
            labelID.Text = "You are editing " + Employee.firstName + " " + Employee.lastName;
            txtFirstName.Text = Employee.firstName;
            txtLastName.Text = Employee.lastName;
            txtEmail.Text = Employee.email;
            ID = Employee.ID;
        }

        private void Update_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "")
            {

                try
                {
                    Repo.UpdateEmployee(txtFirstName.Text, txtLastName.Text, txtEmail.Text, ID);
                    MessageBox.Show("You have update employee #" + ID + ".");
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
