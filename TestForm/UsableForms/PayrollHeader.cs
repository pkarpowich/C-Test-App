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
    public partial class PayrollHeader : Form
    {


        PayrollHeaderRepository payrollHeader = new PayrollHeaderRepository();

        public static string ID = "";
        public static int paid = 0;


        public PayrollHeader()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DataTable dt = payrollHeader.ReturnAllPayrollHeaders();
            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1 )  // ignore header row and any column
                return;

            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_ParollHeader"].Value);
            paid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["isPayed"].Value);
            txtSelected.Text = Convert.ToString(ID);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {


            if (dateTimePickerToDate.Text != "" && dateTimePickerFromDate.Text != "" && txtDescription.Text != "")
                {

                if(dateTimePickerToDate.Value >= dateTimePickerFromDate.Value)
                {
                    try
                    {
                        payrollHeader.SavePayrollHeader(dateTimePickerFromDate.Value, dateTimePickerToDate.Value, txtDescription.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    MessageBox.Show("Date To must be greate than date from.");
                }

                       
                }
            else
                {
                  MessageBox.Show("All fields must contain a value.");
                }

            DataTable dt = payrollHeader.ReturnAllPayrollHeaders();
            dataGridView1.DataSource = dt;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete Payroll Journal #" + ID;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                payrollHeader.DeletePayrollHeader(ID);
                MessageBox.Show("You have deleted Payroll Journal #" + ID + ".");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            DataTable dt = payrollHeader.ReturnAllPayrollHeaders();
            dataGridView1.DataSource = dt;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = payrollHeader.ReturnPayrollHeaderByJournal(txtSearchJournalNumber.Text);
            dataGridView1.DataSource = dt;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
           /* if ()
            {
                EmployeeEdit m = new EmployeeEdit();
                m.Show();
            }

            else
            {
                MessageBox.Show("Please select an Employee");
            }*/
        }

        private void Employee_Activated(object sender, EventArgs e)
        {
           // DataTable dt = employees.ReturnAllEmployees();
           // dataGridView1.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonLines_Click(object sender, EventArgs e)
        {
            PayrollLines m = new PayrollLines();
            m.ShowDialog();
        }
    }
}
