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
    public partial class Ships : Form
    {
        ShipRepository ships = new ShipRepository();
        public static string ID = "";
        public static string shipName = "";
        public static string cruiseLine = "";

        public Ships()
        {
            InitializeComponent();
        }

        private void Ports_Load(object sender, EventArgs e)
        {
            DataTable dt = ships.ReturnAllShips();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  // ignore header row and any column
                return;

            ID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["PK_ShipID"].Value);
            shipName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["shipName"].Value);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (txtPortID.Text != "" && txtPortName.Text != "")
            {
                try
                {
                    ships.SaveShip(txtPortID.Text, txtPortName.Text, ID);
                    MessageBox.Show("You have saved Port " + txtPortID.Text + ".");
                    txtPortID.Text = "";
                    txtPortName.Text = "";
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
            DataTable dt = ships.ReturnAllShips();
            dataGridView1.DataSource = dt;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // code below to create a confirmation message box yes/no
            string MessageBoxTitle = "Confirmation";
            string MessageBoxContent = "Are you sure you want to delete port" + ID;

            DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ships.DeleteShip(ID);
                MessageBox.Show("You have deleted employee #" + ID + ".");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            DataTable dt = ships.ReturnAllShips();
            dataGridView1.DataSource = dt;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
