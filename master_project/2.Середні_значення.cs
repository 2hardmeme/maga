using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace master_project
{
    public partial class Form2 : Form
    {
        private double period;
        private string[] yDots;
        private string[] xDots;

        private double periodDouble; // Нова змінна для періоду у форматі double
        private double[] AveragesSum;
        private string[] tDots; // Оголошуємо як поле класу
        private double Suma; // Поле для зберігання суми всіх елементів масиву AveragesSum

        public Form2(double period, string[] yDots, string[] xDots)
        {
            InitializeComponent();
            this.period = period;
            this.yDots = yDots;
            this.xDots = xDots;

            periodDouble = (double)period;
            // Викликаємо метод, щоб ініціалізувати tDots
            InitializeTDots();
        }

        private void InitializeTDots()
        {
            tDots = new string[(int)periodDouble];
            // Викликаємо метод CopyArray, передаючи масиви xDots і tDots
            CopyArray(xDots, tDots);
        }

        private void обрахунокКоефіцієнтівГармонікToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(tDots, AveragesSum, periodDouble);
            form3.Show();
        }

        private void щоРобитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На вашому екрані знаходяться середні значення та їх сума. Також зображено графік середніх значень періодичної функції. Наступним етапом є обрахунок коефіцієнтів гармонік, для того щоб це зробити - просто натисніть на відповідну кнопку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double[][] ConvertToAverages(string[] yDots, double periodDouble)
        {
            int rowCount = (int)Math.Ceiling((double)yDots.Length / periodDouble);
            double[][] Averages = new double[rowCount][]; // Змінюємо розмірність масиву

            int currentIndex = 0; // Поточний індекс у вихідному масиві yDots

            // Заповнення багатовимірного масиву Averages
            for (int j = 0; j < rowCount; j++) // Змінюємо змінну в циклі з `i` на `j`
            {
                // Кількість стовпчиків у поточному рядку
                int currentColumnCount = (int)Math.Min(periodDouble, yDots.Length - currentIndex);
                Averages[j] = new double[currentColumnCount]; // Змінюємо індекс масиву

                // Заповнення стовпчиків поточного рядка
                for (int i = 0; i < currentColumnCount; i++) // Змінюємо змінну в циклі з `j` на `i`
                {
                    // Конвертуємо значення в double і записуємо у масив `Averages`
                    if (double.TryParse(yDots[currentIndex], out double value))
                    {
                        Averages[j][i] = value; // Змінюємо індекс масиву
                    }
                    else
                    {
                        // Повідомлення про невідому помилку
                        MessageBox.Show("Сталася невідома помилка при конвертації значення у тип double.");
                        // Або можна використати логування помилки
                        // Console.WriteLine("Сталася невідома помилка при конвертації значення у тип double.");
                    }

                    currentIndex++; // Інкрементуємо індекс для переходу до наступного елемента в yDots
                }
            }
            return Averages;
        }

        private double[] CalculateRowAverages(double[][] Averages)
        {
            int rowCount = Averages.Length; // Кількість рядків у багатовимірному масиві

            // Знаходимо максимальну кількість стовпчиків серед усіх рядків
            int maxColumnCount = 0;
            foreach (double[] row in Averages)
            {
                if (row.Length > maxColumnCount)
                {
                    maxColumnCount = row.Length;
                }
            }

            AveragesSum = new double[maxColumnCount]; // Ініціалізація масиву

            // Проходимося по кожному стовпчику
            for (int j = 0; j < maxColumnCount; j++)
            {
                double sum = 0; // Змінна для обчислення суми значень у стовпчику
                int count = 0; // Кількість доданків у поточному стовпчику

                // Обчислюємо суму значень у поточному стовпчику
                for (int i = 0; i < rowCount; i++)
                {
                    // Перевіряємо, чи існує стовпчик з індексом j у поточному рядку
                    if (j < Averages[i].Length)
                    {
                        sum += Averages[i][j]; // Додаємо значення у суму
                        count++; // Збільшуємо кількість доданків
                    }
                }

                // Обчислюємо середнє значення для поточного стовпчика
                if (count > 0)
                {
                    AveragesSum[j] = sum / count; // Ділимо суму на кількість доданків
                }
                else
                {
                    AveragesSum[j] = 0; // Якщо кількість доданків 0, встановлюємо середнє значення на 0
                }
            }

            return AveragesSum;
        }

        private void CopyArray(string[] xDots, string[] tDots)
        {
            // Перевірка на коректність вхідних даних
            if (xDots == null || xDots.Length == 0 || tDots == null || tDots.Length == 0)
            {
                // Якщо один із масивів порожній, повертаємо
                return;
            }

            // Обмежуємо копіювання до перших `period` елементів масиву xDots
            int copyLength = Math.Min(xDots.Length, (int)periodDouble);

            // Копіювання значень з xDots в tDots
            Array.Copy(xDots, tDots, copyLength);
        }

        private void CreateNewChart(string[] tDots, double[] AveragesSum)
        {
            // Видалення попереднього графіка, якщо він існує
            if (chart1.Series.Count > 0)
                chart1.Series.Clear();

            // Створення серії для графіка
            Series series = new Series("Середні значення");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4; // Встановлення товщини лінії

            // Додавання точок з масиву даних
            for (int i = 0; i < Math.Min(tDots.Length, AveragesSum.Length); i++)
            {
                double x = double.Parse(tDots[i]); // Перший стовпець масиву tDots
                double y = AveragesSum[i]; // Другий стовпець масиву AveragesSum

                // Додавання точок до серії
                series.Points.AddXY(x, y);
            }

            // Встановлення стилю точок (червоний колір)
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerColor = Color.Red;

            // Додавання серії до графіка
            chart1.Series.Add(series);

            // Масштабування осей
            // Налаштування мінімального та максимального значення осі X в залежності від даних
            double minX = tDots.Min(val => double.Parse(val));
            double maxX = tDots.Max(val => double.Parse(val));
            chart1.ChartAreas[0].AxisX.Minimum = minX;
            chart1.ChartAreas[0].AxisX.Maximum = maxX;

            // Масштабування осі Y
            // Налаштування мінімального та максимального значення осі Y в залежності від даних
            double minY = AveragesSum.Min();
            double maxY = AveragesSum.Max();
            chart1.ChartAreas[0].AxisY.Minimum = minY;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;

            // Встановлення формату міток осі Y як цілих чисел
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0";
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("На вашому екрані знаходяться середні значення та їх сума. Також зображено графік середніх значень періодичної функції. Наступним етапом є обрахунок коефіцієнтів гармонік, для того щоб це зробити - просто натисніть на відповідну кнопку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            double[][] Averages = ConvertToAverages(yDots, periodDouble); // Перетворення у багатовимірний масив

            // Обчислення середніх значень для кожної стрічки
            double[] AveragesSum = CalculateRowAverages(Averages);

            // Вивід масиву AveragesSum на форму (наприклад, у DataGridView)
            dataGridView1.Rows.Clear(); // Очистити всі рядки перед вставкою нових

            // Додати значення з масиву AveragesSum у dataGridView1
            foreach (double avg in AveragesSum)
            {
                dataGridView1.Rows.Add(avg); // Додати значення середнього до нового рядка
            }

            Suma = 0;
            foreach (double value in AveragesSum)
            {
                Suma += value;
            }

            CreateNewChart(tDots, AveragesSum);
        }
    }
}