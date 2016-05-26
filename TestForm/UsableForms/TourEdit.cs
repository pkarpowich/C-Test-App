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
    public partial class TourEdit : Form
    {
        PortRepository ports = new PortRepository();
        TourRepository tours = new TourRepository();
        String ID = "";
        Decimal rate = 0;

        public TourEdit()
        {
            InitializeComponent();
        }

        private void EmployeeEdit_Load(object sender, EventArgs e)
        {
            DataTable dt = ports.ReturnAllPorts();
            comboBoxPort.DataSource = dt;
            comboBoxPort.ValueMember = "PK_PortID";
            comboBoxPort.DisplayMember = "PortName";

            labelID.Text = "You are editing " + Tours.ID;
            ID = Tours.ID;
            comboBoxPort.SelectedValue = Tours.port;
            txtRate.Text = Convert.ToString(Tours.rate);
            txtTourName.Text = Tours.tourName;




        }

        private void Update_Click(object sender, EventArgs e)
        {

            if (comboBoxPort.Text != "" && txtRate.Text != "" && txtTourName.Text != "")
            {

                try
                {
                    rate = Convert.ToDecimal(txtRate.Text);
                    tours.UpdateTour(ID, comboBoxPort.SelectedValue.ToString(), txtTourName.Text, rate);
                    MessageBox.Show(ID + " " + comboBoxPort.SelectedValue.ToString() + " " + txtTourName.Text + " " + rate);
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

        private void TourEdit_Activated(object sender, EventArgs e)
        {
            DataTable dt = ports .ReturnAllPorts();
            comboBoxPort.DataSource = dt;
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
