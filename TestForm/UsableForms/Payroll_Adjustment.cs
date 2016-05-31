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
    public partial class Payroll_Adjustment : Form
    {

        CallRepository calls = new CallRepository();
        TourRepository tours = new TourRepository();
        EmployeeRepository employee = new EmployeeRepository();
        PayrollLineRepository payrollLines = new PayrollLineRepository();
        public static string ID;

        public Payroll_Adjustment()
        {
            InitializeComponent();
        }

        private void Payroll_Adjustment_Load(object sender, EventArgs e)
        {
            ID = PayrollLines.ID;
            DataTable dt = calls.ReturnCallsByJournal(ID);
            comboBoxCall.DataSource = dt;
            comboBoxCall.ValueMember = "concatinatedView";
            comboBoxCall.DisplayMember = "concatinatedView";

            DataTable dt2 = employee.ReturnAllEmployeesConcat();
            comboBoxEmployee.DataSource = dt2;
            comboBoxEmployee.ValueMember = "PK_EmpID";
            comboBoxEmployee.DisplayMember = "fullName";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        {
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxCall.SelectedValue.ToString() != "" && comboBoxEmployee.SelectedValue.ToString() != "" && txtAmt.Text != "")
            {
                try
                {
                    if (checkBoxCredit.Checked) //check box to multiple the txtAmount by -1 if the adjustment is a credit
                    {
                        payrollLines.SavePayrollLineAdj(ID, comboBoxCall.SelectedValue.ToString(), comboBoxEmployee.SelectedValue.ToString(), (Convert.ToDecimal(txtAmt.Text) * -1));
                    }
                    else
                    {
                        payrollLines.SavePayrollLineAdj(ID, comboBoxCall.SelectedValue.ToString(), comboBoxEmployee.SelectedValue.ToString(), Convert.ToDecimal(txtAmt.Text));
                    }
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

            this.Close();
        }
    }
}
