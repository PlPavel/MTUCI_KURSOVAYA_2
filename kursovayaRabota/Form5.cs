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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.chooseListBox(listBox1, listBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.chooseListBox(listBox1, listBox3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.chooseListBox(listBox1, listBox4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros4(listBox2, listBox3, listBox4);
            if (!(rez == -1))
            {
                Form6 f6 = new Form6();
                this.Hide();
                f6.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(3);
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
        }
    }
}
