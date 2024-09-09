using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DLL
{
    public class Class1
    {
        //создание массива и счетчика, в который будет добавлятся правильные и неправильные решения
        public static int n = 0;
        public static string[] mass = new string[16];
        public static int[] massNum = new int[16];
        //система авторизации
        public static void Avtoriz(Form A, Form B, TextBox t1, TextBox t2)
        {
            string Log = t1.Text;
            string Pass = t2.Text;
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Users1.mdb");
            p.Open();
            var c = new OleDbCommand("SELECT [Логин], [Пароль] FROM [users]", p);
            OleDbDataReader reader = c.ExecuteReader();
            bool f = true;
            while (reader.Read() & (f))
            {
                if ((Log == reader[0].ToString()) & (Pass == reader[1].ToString()))
                {
                    MessageBox.Show("Вы авторизованы!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f = false;
                    A.Hide();
                    B.Show();
                }
            }

            reader.Close();
            if (f)
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //пропуск вопроса
        public static void Skip_question(int numb_q)
        {
            mass[numb_q] = "Неверно";
            massNum[numb_q] = 0;
        }
        //проверка 1 вопроса с элементом CheckBox
        public static int Vopros1(CheckBox CB1, CheckBox CB2, CheckBox CB3, CheckBox CB4)
        {
            if ((!CB1.Checked) && (!CB2.Checked) && (!CB3.Checked) && (!CB4.Checked))
            {
                MessageBox.Show("Вы не выбрали ни один из вариантов", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((!CB1.Checked) && (!CB2.Checked) && (CB3.Checked) && (!CB4.Checked))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[0] = "Верно";
                massNum[0] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);       
                mass[0] = "Неверно";
                massNum[0] = 0;
                return 0;
            }
        }
        //проверка 9 вопроса с элементом CheckBox
        public static int Vopros9(CheckBox CB1, CheckBox CB2, CheckBox CB3, CheckBox CB4)
        {
            if ((!CB1.Checked) && (!CB2.Checked) && (!CB3.Checked) && (!CB4.Checked))
            {
                MessageBox.Show("Вы не выбрали ни один из вариантов", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((CB1.Checked) && (!CB2.Checked) && (!CB3.Checked) && (!CB4.Checked))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[8] = "Верно";
                massNum[8] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[8] = "Неверно";
                massNum[8] = 0;
                return 0;
            }
        }
        //проверка 2 вопроса с элементом TextBox
        public static int Vopros2(string right_ans_1, string right_ans_2_1, string right_ans_2_2, string ans_1, string ans_2)
        {
            if ((ans_1 == "") || (ans_2 == ""))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((ans_1 == right_ans_1) && ((ans_2 == right_ans_2_1)|| (ans_2 == right_ans_2_2)))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[1] = "Верно";
                massNum[1] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[1] = "Неверно";
                massNum[1] = 0;
                return 0;
            }
        }
        //проверка 10 вопроса с элементом TextBox
        public static int Vopros10(string right_ans_1_1, string right_ans_1_2, string right_ans_2, string ans_1, string ans_2)
        {
            if ((ans_1 == "") || (ans_2 == ""))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if (((ans_1 == right_ans_1_1) || (ans_1 == right_ans_1_2)) && (ans_2 == right_ans_2))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[9] = "Верно";
                massNum[9] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[9] = "Неверно";
                massNum[9] = 0;
                return 0;
            }
        }
        //проверка 3 вопроса с элементом RadioButton
        public static void Vopros3(RadioButton RB1, RadioButton RB2, RadioButton RB3, RadioButton RB4)
        {
            if ((!RB1.Checked) && (!RB2.Checked) && (RB3.Checked) && (!RB4.Checked))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[2] = "Верно";
                massNum[2] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[2] = "Неверно";
                massNum[2] = 0;
            }
        }
        //проверка 11 вопроса с элементом RadioButton
        public static void Vopros11(RadioButton RB1, RadioButton RB2, RadioButton RB3, RadioButton RB4)
        {
            if ((!RB1.Checked) && (!RB2.Checked) && (!RB3.Checked) && (RB4.Checked))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[10] = "Верно";
                massNum[10] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[10] = "Неверно";
                massNum[10] = 0;
            }
        }
        //перемещение вариантов ответа из элемента listBox1 в другие
        public static void chooseListBox(ListBox LB1, ListBox LB2)
        {
            if (LB1.SelectedIndex == 0)
            {
                LB2.Items.Add(LB1.Text);
                LB2.Text = Convert.ToString(LB1.SelectedIndex);
                LB1.Items.RemoveAt(0);
            }
            if (LB1.SelectedIndex == 1)
            {
                LB2.Items.Add(LB1.Text);
                LB2.Text = Convert.ToString(LB1.SelectedIndex);
                LB1.Items.RemoveAt(1);
            }
            if (LB1.SelectedIndex == 2)
            {
                LB2.Items.Add(LB1.Text);
                LB2.Text = Convert.ToString(LB1.SelectedIndex);
                LB1.Items.RemoveAt(2);
            }
        }
        //проверка 4 вопроса с элементом ListBox
        public static int Vopros4(ListBox LB1, ListBox LB2, ListBox LB3)
        {
            if ((LB1.Text == "") || (LB2.Text == "") || (LB3.Text == ""))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((LB1.Items[0] == "c) Теоретическая и практическая деятельность, связанная с созданием программ;") && 
                (LB2.Items[0] == "b) Программная реализация задачи, решенная на компьютере;") && (LB3.Items[0] == "a) Проблема, подлежащая решению;"))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[3] = "Верно";
                massNum[3] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[3] = "Неверно";
                massNum[3] = 0;
                return 0;
            }
        }
        //проверка 12 вопроса с элементом ListBox
        public static int Vopros12(ListBox LB1, ListBox LB2, ListBox LB3)
        {
            if ((LB1.Text == "") || (LB2.Text == "") || (LB3.Text == ""))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((LB1.Items[0] == "a) Специальные средства, встроенные в пакеты прикладных программ;") && (LB2.Items[0] == "c) Выполняет пооперационную обработку и выполнение программы;") && (LB3.Items[0] == "b) Транслирует всю программу без ее выполнения;"))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[11] = "Верно";
                massNum[11] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[11] = "Неверно";
                massNum[11] = 0;
                return 0;
            }
        }
        //проверка 5 вопроса с элементом ComboBox
        public static int Vopros5(ComboBox CB1, ComboBox CB2, ComboBox CB3)
        {
            if ((CB1.SelectedIndex == -1) || (CB2.SelectedIndex == -1) || (CB3.SelectedIndex == -1))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((CB1.SelectedIndex == 1) && (CB2.SelectedIndex == 2) && (CB3.SelectedIndex == 0))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[4] = "Верно";
                massNum[4] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[4] = "Неверно";
                massNum[4] = 0;
                return 0;
            }
        }
        //проверка 13 вопроса с элементом ComboBox
        public static int Vopros13(ComboBox CB1, ComboBox CB2, ComboBox CB3)
        {
            if ((CB1.SelectedIndex == -1) || (CB2.SelectedIndex == -1) || (CB3.SelectedIndex == -1))
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else if ((CB1.SelectedIndex == 0) && (CB2.SelectedIndex == 2) && (CB3.SelectedIndex == 1))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[12] = "Верно";
                massNum[12] = 1;
                return 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[12] = "Неверно";
                massNum[12] = 0;
                return 0;
            }
        }
        //проверка 6 вопроса с элементом HScrollBar
        public static void Vopros6(HScrollBar SB)
        {
            if (SB.Value == 30)
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[5] = "Верно";
                massNum[5] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[5] = "Неверно";
                massNum[5] = 0;
            }
        }
        //проверка 14 вопроса с элементом HScrollBar
        public static void Vopros14(HScrollBar SB)
        {
            if (SB.Value == 10)
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[13] = "Верно";
                massNum[13] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[13] = "Неверно";
                massNum[13] = 0;
            }
        }
        //проверка 7 вопроса с элементом TrackBar
        public static void Vopros7(TrackBar TB)
        {
            if ((TB.Value == 2) || (TB.Value == 3) || (TB.Value == 4))
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[6] = "Верно";
                massNum[6] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[6] = "Неверно";
                massNum[6] = 0;
            }
        }
        //проверка 15 вопроса с элементом TrackBar
        public static void Vopros15(TrackBar TB)
        {
            if (TB.Value == 1)
            {
                MessageBox.Show("Вы ответили правильно", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                n = n + 1;
                mass[14] = "Верно";
                massNum[14] = 1;
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mass[14] = "Неверно";
                massNum[14] = 0;
            }
        }
        //проверка 8 вопроса с элементом CheckedListBox
        public static int Vopros8(CheckedListBox CLB)
        {
            if (CLB.CheckedItems.Count == 0)
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else
            {
                int count = 0;
                foreach(string index in CLB.CheckedItems)
                    //подсчитываем сколько выбрано правильных ответов
                {
                    if ((index == "Машинные языки;") || (index == "Процедурно-ориентированные языки;") || (index == "Машинно-оринтированные языки;") || (index == "Проблемно-ориентированные языки;"))
                        count += 1;
                    //если ответ неверный то счетчик уменьшается на 1
                    else if (index == "Компьютерные языки;")
                        count -= 1;
                }
                //сравниваем количество выбранных ответов с правильным
                if (count == 4)
                {
                    MessageBox.Show("Вы ответили правильно ", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n = n + 1;
                    mass[7] = "Верно";
                    massNum[7] = 1;
                    return 1;
                }
                else
                {
                    MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mass[7] = "Неверно";
                    massNum[7] = 0;
                    return 0;
                }
            }
        }
        //проверка 16 вопроса с элементом CheckedListBox
        public static int Vopros16(CheckedListBox CLB)
        {
            if (CLB.CheckedItems.Count == 0)
            {
                MessageBox.Show("Вы не ответили на вопрос", "Нет ответа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            else
            {
                int count = 0;
                foreach (string index in CLB.CheckedItems)
                {
                    //подсчитываем сколько выбрано правильных ответов
                    if ((index == "Автоматическая генерация кода;") || (index == "Автоматический контроль проекта;") || (index == "Основные силы на анализ и проектирование;"))
                        count += 1;
                    //если ответ неверный то счетчик уменьшается на 1
                    else if ((index == "Ручное документирование;") || (index == "Тестирование кодов;"))
                        count -= 1;
                }
                //сравниваем количество выбранных ответов с правильным
                if (count == 3)
                {
                    MessageBox.Show("Вы ответили правильно ", "Правильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n = n + 1;
                    mass[15] = "Верно";
                    massNum[15] = 1;
                    return 1;
                }
                else
                {
                    MessageBox.Show("Вы ответили неправильно ", "Неправильный ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mass[15] = "Неверно";
                    massNum[15] = 0;
                    return 0;
                }
            }
        }
        //вывод результатов теста в DataGridView в строчку
        public static void Vivod_DGV(DataGridView grid)
        {

            grid.ColumnCount = mass.Length;
            grid.RowCount = 2;
            for (int i = 0; i<mass.Length; i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + (i+1) + "]";
                grid.Rows[1].Cells[i].Value = mass[i];
            }
        }
        //передает первый элемент массива в Vivid_DGV
        public static void Result_DGV(DataGridView DGV)
        {
            for (int i = 0; i<mass.Length; i++)
            {
                Vivod_DGV(DGV);
            }
        }
        //вывод результатов теста в DataGridView в ряд
        public static void Result_DGV_ROW(DataGridView DGV)
        {
            for (int i = 0; i<massNum.Length;i++)
            {
                DGV.Rows.Add(i + 1, massNum[i]);
            }
        }
        //создание диаграммы
        public static void Diagram(Chart C, TextBox TB1, TextBox TB2)
        {
            C.Series[0].Points.AddXY(1, n);
            C.Series[1].Points.AddXY(2, Math.Abs(n-16));
            Vivod(TB1, n);
            Vivod(TB2, 16-n);
        }
        //конвертирует в строковый тип для заполнения TextBox в диаграмме
        public static void Vivod(TextBox t, double c)
        {
            t.Text = Convert.ToString(c);
        }
        //запись в блокнот
        public static void ZapisBloknot()
        {
            StreamWriter rez = File.CreateText("Исходный массив.txt");
            for (int i = 0; i < massNum.Length; i++)
            {
                rez.WriteLine((i+1).ToString() + " - " + massNum[i]);
            }
            rez.Close();
            System.Diagnostics.Process.Start("Исходный массив.txt");
        }
        //после удаления элемента записывает получившийся массив в DataGridView в ряд
        public static void New_Mas(int[] rezmas, DataGridView DGV)
        {
            for (int i = 0; i<rezmas.Length; i++)
            {
                DGV.Rows.Add(i+1, rezmas[i]);
            }
            
        }
        //удаление выбранного элемента и запись получившегося массива
        public static void Del_El(ref int[] mas, int a)
        {
            int max = mas.GetLength(0);
            for (int i = 0; i< mas.GetLength(0); i++)
            {
                if (i == a)
                    max = i;
            }
            for (int i = max; i < mas.GetLength(0) - 1; i++)
                mas[i] = mas[i + 1];
            Array.Resize(ref mas, mas.GetLength(0)-1);
        }
        //создание массива для удаления элементов
        public static void Get_Delmas(ref int[] mas)
        {
            for (int i = 0; i < massNum.Length; i++)
            {
                mas[i] = massNum[i];
            }
        }
        //сортировка простым выбором
        public static void Sort_Prost(ref int[] mas)
        {
            //запись элементов массива с результатами в новый массив, для того чтобы при удалении элементов, не сбивался порядок
            for (int i = 0; i<massNum.Length;i++)
            {
                mas[i] = massNum[i];
            }
            for (int i = 0; i<mas.Length-1; i++)
            {
                int k = i;
                int x = mas[i];
                for (int j=i+1; j<mas.Length; j++)
                {
                    if (mas[j] < x)
                    {
                        k = j;
                        x = mas[j];
                    }
                }
                mas[k] = mas[i];
                mas[i] = x;
            }
        }
        //запись результатов в pdf файл
        public static void Add_pdf()
        {
            var document = new Document();
            var zap = PdfWriter.GetInstance(document, new System.IO.FileStream("ZapPDF.pdf", System.IO.FileMode.Create));
            document.Open();
            var Shrift = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);
            var font = new Font(Shrift, 10, Font.NORMAL, BaseColor.BLUE);
            var tabl = new PdfPTable(1);
            var cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Colspan = 2;
            cell.Border = 0;
            cell.FixedHeight = 16.0F;
            cell.Phrase = new Phrase("Исходный массив", font);
            tabl.AddCell(cell);
            cell.BackgroundColor = BaseColor.WHITE;
            cell.Colspan = 1;
            cell.Border = 15;
            for (int i = 0; i< massNum.Length; i++)
            {
                cell.Phrase = new Phrase((i+1).ToString() + " - " + massNum[i].ToString(), font);
                tabl.AddCell(cell);
            }
            tabl.TotalWidth = document.PageSize.Width - 500;
            tabl.WriteSelectedRows(0, -1, 150, 750, zap.DirectContent);
            document.Close();
            zap.Close();
            System.Diagnostics.Process.Start("msedge.exe", System.IO.Directory.GetCurrentDirectory() + @"\ZapPDF.pdf");
        }
        //сброс всех результатов теста
        public static void BackToStart()
        {
            n = 0;
            mass = new string[16];
            massNum = new int[16];
        }
    }
}
