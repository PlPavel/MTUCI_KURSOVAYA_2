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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros12(listBox2, listBox3, listBox4);
            if (!(rez == -1))
            {
                Form16 f16 = new Form16();
                this.Hide();
                f16.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(11);
            Form16 f16 = new Form16();
            this.Hide();
            f16.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
