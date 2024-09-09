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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros3(radioButton1, radioButton2, radioButton3, radioButton4);
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(2);
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }
    }
}
