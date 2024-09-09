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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros10("эксплуатации", "использованию", "документацию", textBox1.Text, textBox2.Text);
            if (!(rez == -1))
            {
                Form14 f14 = new Form14();
                this.Hide();
                f14.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(9);
            Form14 f14 = new Form14();
            this.Hide();
            f14.Show();
        }
    }
}
