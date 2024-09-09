using DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovayaRabota
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros15(trackBar1);
            Form19 f19 = new Form19();
            this.Hide();
            f19.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(14);
            Form19 f19 = new Form19();
            this.Hide();
            f19.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
