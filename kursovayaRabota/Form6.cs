using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;

namespace kursovayaRabota
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros5(comboBox1, comboBox2, comboBox3);
            if (!(rez == -1))
            {
                Form7 f7 = new Form7();
                this.Hide();
                f7.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(4);
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }
    }
}
