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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros11(radioButton1, radioButton2, radioButton3, radioButton4);
            Form15 f15 = new Form15();
            this.Hide();
            f15.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(10);
            Form15 f15 = new Form15();
            this.Hide();
            f15.Show();
        }
    }
}
