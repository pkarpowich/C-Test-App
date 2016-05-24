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
    public partial class EmployeeMain : Form
    {
        public EmployeeMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewEmployee m = new NewEmployee();

            m.Show();
        }

        private void Payroll_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditEmployee m = new EditEmployee();
            m.Show();
        }
    }
}
