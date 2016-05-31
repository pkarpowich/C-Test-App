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
    public partial class Tours : Form
    {
        PortRepository ports = new PortRepository();
        TourRepository tours = new TourRepository();

        public static String ID = "";
        public static String tourName = "";
        public static Decimal rate = 0;
        public static String port = "";
        

        public Tours()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Tours_Load(object sender, EventArgs e)
        {

            DataTable dt_grid = tours.ReturnAllTours();
            dataGridView1.DataSource = dt_grid;

            //Using Values from Port table to populate values for the Port Selection Combo Box
            DataTable dt = ports.ReturnAllPorts();
            comboBoxPort.DataSource = dt;
            comboBoxPort.ValueMember = "PK_PortID";
            comboBoxPort.DisplayMember = "PortName";

        }

        private void buttonPorts_Click(object sender, EventArgs e)
        {
            Ports m = new Ports();
            m.ShowDialog();
        }

        private void Tours_Activated(object sender, EventArgs e)
        {
            DataTable dt = ports.ReturnAllPorts();
            comboBoxPort.DataSource = dt;

            DataTable dt_grid = tours.ReturnAllTours();
            dataGridView1.DataSource = dt_grid;

        }

        private void textRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonSearchTourName_Click(object sender, EventArgs e)
        {
            DataTable dt = tours.ReturnToursByTourName(txtSearchName.Text);
            dataGridView1.DataSource = dt;
        }

        private void buttonSearchLocation_Click(object sender, EventArgs e)
        {
            DataTable dt = tours.ReturnToursByPort(txtSearchPort.Text);
            dataGridView1.DataSource = dt;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (txtRate.Text != "" && txtTourCode.Text != "" && comboBoxPort.SelectedValue.ToString() != "" && txtTourName.Text != "")
            {
                try
                {
                    rate = Convert.ToDecimal(txtRate.Text);
                    tours.SaveTour(txtTourCode.Text, comboBoxPort.SelectedValue.ToString(), txtTourName.Text, rate);
                    txtTourName.Text = "";
                    txtTourCode.Text = "";
                    txtRate.Text = "";
                    comboBoxPort.Text = "";
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
            DataTable dt_grid = tours.ReturnAllTours();
            dataGridView1.DataSource = dt_grid;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete " + tourName;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                tours.DeleteTour(ID);
                MessageBox.Show("You have deleted " + tourName + ".");

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            DataTable dt_grid = tours.ReturnAllTours();
            dataGridView1.DataSource = dt_grid;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  // ignore header row and any column
                return;

            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_TourID"].Value);
            tourName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Tour_Name"].Value);
            rate = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value);
            port = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Port"].Value);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
               TourEdit m = new TourEdit();
               m.Show();
            }

            else
            {
                MessageBox.Show("Please select an Employee");
            }
        }
    }
}
