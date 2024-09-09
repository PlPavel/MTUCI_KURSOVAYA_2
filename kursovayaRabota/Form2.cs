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
using kursovayaRabota;

namespace kursovayaRabota
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros1(checkBox1, checkBox2, checkBox3, checkBox4);
            if (!(rez == -1))
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(0);
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
