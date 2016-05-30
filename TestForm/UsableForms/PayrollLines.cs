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
    }


}
