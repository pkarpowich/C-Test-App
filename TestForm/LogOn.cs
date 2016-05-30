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
    public partial class LogOn : Form
    {

        public static string userName;

        public LogOn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBox1.Text;

            Main m = new Main();
            m.Show();
        }

        private void LogOn_Load(object sender, EventArgs e)
        {

        }
    }
}
