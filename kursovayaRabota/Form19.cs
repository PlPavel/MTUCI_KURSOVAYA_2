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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = Class1.Vopros16(checkedListBox1);
            if (!(rez == -1))
            {
                Form10 f10 = new Form10();
                this.Hide();
                f10.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Skip_question(15);
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }
    }
}
