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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum= 1000;
            progressBar1.Value= 0;
            for (int i = 0; i <= progressBar1.Maximum - 1; i++)
            {
                progressBar1.Increment(1);
                label1.Text=progressBar1.Value.ToString();
                label1.Refresh();
            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                Form21 f21 = new Form21();
                this.Hide();
                f21.ShowDialog();
            }
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }
    }
}
