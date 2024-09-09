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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros7(trackBar1);
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(6);
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }
    }
}
