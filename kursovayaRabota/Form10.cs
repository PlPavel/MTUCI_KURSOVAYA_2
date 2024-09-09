using DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Microsoft.VisualBasic;
using Microsoft.Office.Interop.Excel;
using Axis = Microsoft.Office.Interop.Excel.Axis;


namespace kursovayaRabota
{
    public partial class Form10 : Form
    {
        int[] mas = Class1.massNum;
        int[] delMas = new int[16];
        public Form10()
        {
            InitializeComponent();
            Class1.Get_Delmas(ref delMas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Result_DGV(dataGridView1);
            dataGridView1.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Diagram(chart1, textBox1, textBox2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            Class1.Result_DGV_ROW(dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.ZapisBloknot();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string number = Interaction.InputBox("Введите номер строки, которую хотите удалить", "Удаление элемента", "", 500, 300);
            int n = Convert.ToInt32(number);
            dataGridView2.Rows.Clear();
            Class1.Del_El(ref delMas, n-1);
            Class1.New_Mas(delMas, dataGridView2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            var t = Type.Missing;
            var Book = excelApp.Workbooks.Add(t);
            var Lists = Book.Worksheets;
            Worksheet List = Lists.Item[1];
            List.Cells[1, 1] = "Результаты тестирования";
            List.Range["A2", t].Value2 = "Вопрос 1";
            List.Range["A3", t].Value2 = "Вопрос 2";
            List.Range["A4", t].Value2 = "Вопрос 3";
            List.Range["A5", t].Value2 = "Вопрос 4";
            List.Range["A6", t].Value2 = "Вопрос 5";
            List.Range["A7", t].Value2 = "Вопрос 6";
            List.Range["A8", t].Value2 = "Вопрос 7";
            List.Range["A9", t].Value2 = "Вопрос 8";
            List.Range["A10", t].Value2 = "Вопрос 9";
            List.Range["A11", t].Value2 = "Вопрос 10";
            List.Range["A12", t].Value2 = "Вопрос 11";
            List.Range["A13", t].Value2 = "Вопрос 12";
            List.Range["A14", t].Value2 = "Вопрос 13";
            List.Range["A15", t].Value2 = "Вопрос 14";
            List.Range["A16", t].Value2 = "Вопрос 15";
            List.Range["A17", t].Value2 = "Вопрос 16";
            List.Range["B1", t].Value2 = "Ответ";
            List.Range["B2", t].Value2 = mas[0];
            List.Range["B3", t].Value2 = mas[1];
            List.Range["B4", t].Value2 = mas[2];
            List.Range["B5", t].Value2 = mas[3];
            List.Range["B6", t].Value2 = mas[4];
            List.Range["B7", t].Value2 = mas[5];
            List.Range["B8", t].Value2 = mas[6];
            List.Range["B9", t].Value2 = mas[7];
            List.Range["B10", t].Value2 = mas[8];
            List.Range["B11", t].Value2 = mas[9];
            List.Range["B12", t].Value2 = mas[10];
            List.Range["B13", t].Value2 = mas[11];
            List.Range["B14", t].Value2 = mas[12];
            List.Range["B15", t].Value2 = mas[13];
            List.Range["B16", t].Value2 = mas[14];
            List.Range["B17", t].Value2 = mas[15];
            Microsoft.Office.Interop.Excel.Chart Diagr = excelApp.Charts.Add(t, t, t, t);
            Diagr.SetSourceData(List.Range["A2", "B17"],
                Microsoft.Office.Interop.Excel.XlRowCol.xlColumns);
            Diagr.ChartType = XlChartType.xlColumnClustered;
            Diagr.HasLegend = false;
            Axis Goriz_Os = Diagr.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory,
                Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
            Goriz_Os.HasTitle = true;
            Goriz_Os.AxisTitle.Text = "ОТВЕТЫ";
            Axis Vertic_Os = Diagr.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue,
                Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
            Vertic_Os.HasTitle = true;
            Vertic_Os.AxisTitle.Text = "ВОПРОСЫ";
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = System.IO.Path.GetDirectoryName(location);
            string file = path + "\\Excel.jpg";
            excelApp.ActiveChart.Export(file, t, t);
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.jpg";
            otkr.Filter = "Файлы изображений (*.jpg)|*.jpg";
            otkr.Title = "Выберите полученный скриншот диаграммы";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            int[] mas = new int[16];
            Class1.Sort_Prost(ref mas);
            Class1.New_Mas(mas, dataGridView3);
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            Class1.Add_pdf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.BackToStart();
            Form21 f21 = new Form21();
            this.Hide();
            f21.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
