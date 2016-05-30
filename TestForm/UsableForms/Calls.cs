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
    public partial class Calls : Form
    {

        ShipRepository ship = new ShipRepository();
        PortRepository port = new PortRepository();
        CallRepository call = new CallRepository();

        public static String ID = "";

        public Calls()
        {
            InitializeComponent();
        }

        private void Calls_Load(object sender, EventArgs e)
        {
            DataTable dt = port.ReturnAllPorts();
            comboBoxPort.DataSource = dt;
            comboBoxPort.ValueMember = "PK_PortID";
            comboBoxPort.DisplayMember = "PortName";

            DataTable dt2 = ship.ReturnAllShips();
            comboBoxShip.DataSource = dt2;
            comboBoxShip.ValueMember = "PK_ShipID";
            comboBoxShip.DisplayMember = "ShipName";

            DataTable dt3 = call.ReturnAllCalls();
            dataGridView1.DataSource = dt3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                comboBoxShip.Text != "" &&
                comboBoxPort.Text != "" &&
                dateTimePicker1.Text != ""
                )
            {
                try
                {
                   call.SaveCall(comboBoxShip.SelectedValue.ToString(), comboBoxPort.SelectedValue.ToString(), dateTimePicker1.Value);
                   comboBoxShip.Text = "";
                   comboBoxPort.Text = "";
                   dateTimePicker1.Text = "";
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
            DataTable dt_grid = call.ReturnAllCalls();
            dataGridView1.DataSource = dt_grid;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)  // ignore header row and any column
                return;

            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["concatinatedView"].Value);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete call " + ID;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                call.DeleteCall(ID);
                MessageBox.Show("You have deleted call " + ID + ".");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            DataTable dt = call.ReturnAllCalls();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ports m = new Ports();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ships m = new Ships();
            m.Show();

        }

        private void Calls_Activated(object sender, EventArgs e)
        {
            DataTable dt = port.ReturnAllPorts();
            comboBoxPort.DataSource = dt;
            comboBoxPort.ValueMember = "PK_PortID";
            comboBoxPort.DisplayMember = "PortName";

            DataTable dt2 = ship.ReturnAllShips();
            comboBoxShip.DataSource = dt2;
            comboBoxShip.ValueMember = "PK_ShipID";
            comboBoxShip.DisplayMember = "ShipName";

            DataTable dt3 = call.ReturnAllCalls();
            dataGridView1.DataSource = dt3;
        }
    }
}
