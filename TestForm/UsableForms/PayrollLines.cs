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
    public partial class PayrollLines : Form
    {

        CallRepository calls = new CallRepository();
        TourRepository tours = new TourRepository();
        EmployeeRepository employee = new EmployeeRepository();
        PayrollLineRepository payrollLines = new PayrollLineRepository();

        public static string ID;
        public static string lineID;

        public PayrollLines()
        {
            InitializeComponent();
        }

        private void PayrollLines_Load(object sender, EventArgs e)
        {
            ID = PayrollHeader.ID;
            DataTable dt = calls.ReturnCallsByJournal(ID);
            comboBoxCall.DataSource = dt;
            comboBoxCall.ValueMember = "concatinatedView";
            comboBoxCall.DisplayMember = "concatinatedView";

            DataTable dt2 = employee.ReturnAllEmployeesConcat();
            comboBoxEmployee.DataSource = dt2;
            comboBoxEmployee.ValueMember = "PK_EmpID";
            comboBoxEmployee.DisplayMember = "fullName";


            DataTable dt3 = payrollLines.ReturnAllLinesByJournal(ID);
            dataGridView1.DataSource = dt3;

            if(PayrollHeader.paid ==1)
            {
                buttonSave.Enabled = false;
                buttonDelete.Enabled = false;
                buttonAdjustment.Enabled = false;
            }

        }


        private void comboBoxCall_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTour.DataSource = null;

            DataTable dt = tours.ReturnToursByCall(comboBoxCall.SelectedValue.ToString());
            comboBoxTour.DataSource = dt;
            comboBoxTour.ValueMember = "PK_TourID";
            comboBoxTour.DisplayMember = "Tour_Name";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxCall.SelectedValue.ToString() != "" && comboBoxEmployee.SelectedValue.ToString() != "" &&  comboBoxTour.SelectedValue.ToString() != "")
             {

                try
                {
                   payrollLines.SavePayrollLine(ID, comboBoxCall.SelectedValue.ToString(), comboBoxEmployee.SelectedValue.ToString(), comboBoxTour.SelectedValue.ToString());
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
             
            DataTable dt3 = payrollLines.ReturnAllLinesByJournal(ID);
            dataGridView1.DataSource = dt3;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete Payroll Journal #" + lineID;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                payrollLines.DeletePayrollLine(lineID);
                MessageBox.Show("You have deleted Payroll Journal #" + lineID + ".");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            DataTable dt3 = payrollLines.ReturnAllLinesByJournal(ID);
            dataGridView1.DataSource = dt3;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)  // ignore header row and any column
                return;

            lineID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_ParollLine"].Value);
        }

        private void buttonAdjustment_Click(object sender, EventArgs e)
        {
            Payroll_Adjustment m = new Payroll_Adjustment();
            m.ShowDialog();
        }

        private void PayrollLines_Activated(object sender, EventArgs e)
        {
            DataTable dt3 = payrollLines.ReturnAllLinesByJournal(ID);
            dataGridView1.DataSource = dt3;
        }
    }


}
