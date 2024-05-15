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

namespace master_project
{
    public partial class Form3 : Form
    {
        private string[] tDots;
        private double[] AveragesSum;
        private double periodDouble;

        private double[] xValues;
        private double omega; // Оголошуємо поле omega
        private double m;
        private double[,] harmonicCoefficients;

        //sums
        private double[,] columnSums; // Багатовимірний масив для збереження сум елементів стовпчиків harmonicCoefficients
        private double xValuesSum; // Змінна для збереження суми елементів масиву xValues

        public Form3(string[] tDots, double[] AveragesSum, double periodDouble)
        {
            InitializeComponent();
            this.tDots = tDots;
            this.AveragesSum = AveragesSum;
            this.periodDouble = periodDouble;

            // Підрахунок значення omega
            omega = (2 * Math.PI) / periodDouble;

            //підрахунок m
            m = Math.Truncate(periodDouble / 2);
        }

        private void щоРобитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На цьому екрані Ви можете бачити результати обрахунку коефіцієнтів гармонік.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            щоРобитиToolStripMenuItem_Click(sender, e);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CalculateXValues();
            DisplayXValues();
            CalculateHarmonicCoefficients((int)m);
            DisplayHarmonicCoefficients(harmonicCoefficients);
            CalculateColumnSums();
            DisplayColumnSums();
        }

        private void CalculateXValues()
        {
            // Ініціалізуємо xValues як новий масив з довжиною tDots
            xValues = new double[tDots.Length];

            // Обчислюємо значення іксів і записуємо їх у масив xValues
            for (int i = 0; i < tDots.Length; i++)
            {
                xValues[i] = omega * (Convert.ToDouble(tDots[i]) - 1); // Обчислення значення іксів
            }
        }

        private double[,] CalculateHarmonicCoefficients(int m)
        {
            harmonicCoefficients = new double[AveragesSum.Length, 2 * m]; // Оголошення масиву для збереження коефіцієнтів

            for (int i = 0; i < AveragesSum.Length; i++)
            {
                for (int j = 1; j <= m; j++) // Проходимося по всіх гармоніках
                {
                    double cosineCoefficient = AveragesSum[i] * Math.Cos(xValues[i] * j);
                    double sineCoefficient = AveragesSum[i] * Math.Sin(xValues[i] * j);

                    // Запис коефіцієнтів у відповідні стовпці двовимірного масиву
                    harmonicCoefficients[i, (j - 1) * 2] = cosineCoefficient; // Перший стовпчик - косинус
                    harmonicCoefficients[i, (j - 1) * 2 + 1] = sineCoefficient;   // Другий стовпчик - синус
                }
            }

            return harmonicCoefficients; // Повертаємо згенерований масив
        }

        private void CalculateColumnSums()
        {
            // Ініціалізуємо багатовимірний масив для збереження сум елементів стовпчиків harmonicCoefficients
            columnSums = new double[1, harmonicCoefficients.GetLength(1)];

            // Обчислення суми елементів кожного стовпчика в harmonicCoefficients
            for (int j = 0; j < harmonicCoefficients.GetLength(1); j++)
            {
                double sum = 0;
                for (int i = 0; i < harmonicCoefficients.GetLength(0); i++)
                {
                    sum += harmonicCoefficients[i, j];
                }
                columnSums[0, j] = sum;
            }

            // Обчислення суми елементів масиву xValues
            xValuesSum = 0;
            foreach (double value in xValues)
            {
                xValuesSum += value;
            }
        }

        private void DisplayXValues()
        {
            // Визначення кількості рядків у dataGridView1
            int rowCount = xValues.Length;

            // Очищення dataGridView1 перед додаванням нових даних
            dataGridView1.Rows.Clear();

            // Додавання стовпця з назвою "X"
            dataGridView1.Columns.Add("X", "X");

            // Налаштування ширини стовпця "X"
            dataGridView1.Columns["X"].Width = 180;

            // Додавання значень xValues до dataGridView1
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows.Add(xValues[i]);
            }
        }

        private void DisplayHarmonicCoefficients(double[,] harmonicCoefficients)
        {
            // Очистити dataGridView2 перед додаванням нових даних
            dataGridView2.Rows.Clear();

            // Додати стовпці для косинусів та синусів
            for (int j = 0; j < harmonicCoefficients.GetLength(1); j += 2)
            {
                int harmonicNumber = j / 2 + 1;
                dataGridView2.Columns.Add($"Cosine_{harmonicNumber}", $"y * cos({harmonicNumber}x)");
                dataGridView2.Columns.Add($"Sine_{harmonicNumber}", $"y * sin({harmonicNumber}x)");
            }

            // Пройтися по елементам двовимірного масиву harmonicCoefficients і додати їх до dataGridView2
            for (int i = 0; i < harmonicCoefficients.GetLength(0); i++)
            {
                // Додати рядок для кожного рядка масиву
                dataGridView2.Rows.Add();

                // Заповнити дані кожним елементом
                for (int j = 0; j < harmonicCoefficients.GetLength(1); j += 2)
                {
                    dataGridView2.Rows[i].Cells[j].Value = harmonicCoefficients[i, j];
                    dataGridView2.Rows[i].Cells[j + 1].Value = harmonicCoefficients[i, j + 1];
                }
            }
        }


        private void DisplayColumnSums()
        {
            // Очистити dataGridView3 перед додаванням нових даних
            dataGridView3.Rows.Clear();

            // Додати стовпці для сум стовпчиків
            for (int j = 0; j < columnSums.GetLength(1); j++)
            {
                // Визначення номера гармоніки за індексом стовпчика
                int harmonicNumber = j / 2 + 1;

                // Побудова назви стовпця залежно від номера гармоніки та типу (косинус або синус)
                string columnName = $"y*cos  {harmonicNumber}x SUM";
                if (j % 2 == 1)
                {
                    columnName = $"y*sin {harmonicNumber}x SUM";
                }

                dataGridView3.Columns.Add($"ColumnSum_{j}", columnName);
            }

            // Додати рядок для кожного рядка масиву
            dataGridView3.Rows.Add();

            // Заповнити дані кожним елементом
            for (int j = 0; j < columnSums.GetLength(1); j++)
            {
                dataGridView3.Rows[0].Cells[j].Value = columnSums[0, j];
            }

            // Очистити dataGridView4 перед додаванням нових даних
            dataGridView4.Rows.Clear();

            // Додати стовпець для суми елементів масиву xValues
            dataGridView4.Columns.Add("XValuesSum", "XValuesSum");

            // Відображення значення xValuesSum у dataGridView4
            dataGridView4.Rows.Add(xValuesSum);
        }

        private void обрахунокАмплітудToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(omega, m, periodDouble, columnSums, xValues);
            form4.Show();
        }
    }
}