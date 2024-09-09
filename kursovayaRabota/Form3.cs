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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros2("программ", "задачи", "проблемы", textBox1.Text, textBox2.Text);
            if (!(rez == -1))
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(1);
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }
    }
}
