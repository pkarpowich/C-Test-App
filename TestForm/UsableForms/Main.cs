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
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ports m = new Ports();
            m.Show();
        }

        private void buttonTours_Click(object sender, EventArgs e)
        {
            Tours m = new Tours();
            m.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ships m = new Ships();
            m.Show();
        }
    }
}
