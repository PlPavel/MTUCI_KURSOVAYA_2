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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros6(hScrollBar1);
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = string.Format("Проценты: {0}%", hScrollBar1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(5);
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }
    }
}
