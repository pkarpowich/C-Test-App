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
    public partial class Employee : Form
    {
        public static String ID = "";
        public static String firstName = "";
        public static String lastName = "";
        public static String email = "";

        EmployeeRepository employees = new EmployeeRepository();

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DataTable dt = employees.ReturnAllEmployees();
            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1 )  // ignore header row and any column
                return;

            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_EmpID"].Value);
            firstName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value);
            lastName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value);
            email = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["EmailAddress"].Value);
            txtSelected.Text = ID;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtID.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "")
            {

                try
                {
                    EmployeeRepository saveEmployee = new EmployeeRepository();
                    saveEmployee.SaveEmployee(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtID.Text);
                    MessageBox.Show("You have saved employee #" + txtID.Text + ".");
                    //clear text boxes after sucessufll save.
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtID.Text = "";

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
            DataTable dt = employees.ReturnAllEmployees();

            //Clear fields after save
            dataGridView1.DataSource = dt;
            

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete employee" + ID;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                employees.DeleteEmployee(ID);
                MessageBox.Show("You have deleted employee #" + ID + ".");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            DataTable dt = employees.ReturnAllEmployees();
            dataGridView1.DataSource = dt;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = employees.ReturnEmployeeByLastName(txtSearch.Text);
            dataGridView1.DataSource = dt;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                EmployeeEdit m = new EmployeeEdit();
                m.Show();
            }

            else
            {
                MessageBox.Show("Please select an Employee");
            }
        }

        private void Employee_Activated(object sender, EventArgs e)
        {
            DataTable dt = employees.ReturnAllEmployees();
            dataGridView1.DataSource = dt;
        }
    }
}
