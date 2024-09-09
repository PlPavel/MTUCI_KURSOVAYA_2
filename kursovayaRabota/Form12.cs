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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros9(checkBox1, checkBox2, checkBox3, checkBox4);
            if (!(rez == -1))
            {
                Form13 f13 = new Form13();
                this.Hide();
                f13.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(8);
            Form13 f13 = new Form13();
            this.Hide();
            f13.Show();
        }
    }
}
