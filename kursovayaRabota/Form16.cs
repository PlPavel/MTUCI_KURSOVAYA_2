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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros13(comboBox1, comboBox2, comboBox3);
            if (!(rez == -1))
            {
                Form17 f17 = new Form17();
                this.Hide();
                f17.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(12);
            Form17 f17 = new Form17();
            this.Hide();
            f17.Show();
        }
    }
}
