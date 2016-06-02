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
    public partial class Main : Form
    {
         
        public Main()
        {
            InitializeComponent();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            Employee m = new Employee();
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ports m = new Ports();
            m.ShowDialog();
        }

        private void buttonTours_Click(object sender, EventArgs e)
        {
            Tours m = new Tours();
            m.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Calls m = new Calls();
            m.ShowDialog();



        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PayrollHeader m = new PayrollHeader();
            m.ShowDialog();
        }
    }
}
