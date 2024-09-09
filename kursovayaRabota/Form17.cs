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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Vopros14(hScrollBar1);
            Form18 f18 = new Form18();
            this.Hide();
            f18.Show();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = string.Format("Проценты: {0}%", hScrollBar1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(13);
            Form18 f18 = new Form18();
            this.Hide();
            f18.Show();
        }
    }
}
