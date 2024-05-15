using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master_project
{
    public partial class Form4 : Form
    {
        private double omega;
        private double m;
        private double periodDouble;
        private double[,] columnSums;
        private double[] xValues;

        private double[] transitXValues;
        //private double[] omegaThing;
        private double[] a1coefficients;
        private double[] b1coefficients;

        private double mysteriousThing;
        private double[] Amplitudes;
        private double[] percentages;

        private double[] newAmplitudes;
        private double[] newA1coefficients;
        private double[] newB1coefficients;
        private double[] newPercentages;

        public Form4(double omega, double m, double periodDouble, double[,] columnSums, double[] xValues)
        {
            InitializeComponent();

            this.omega = omega;
            this.m = m;
            this.periodDouble = periodDouble;
            this.columnSums = columnSums;
            this.xValues = xValues;

            this.mysteriousThing = 2 / periodDouble;
            // Ініціалізуємо масиви для амплітуд у конструкторі
            a1coefficients = new double[(int)m];
            b1coefficients = new double[(int)m];
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            InitializeTrackBar();
            TransitXValues();

            //CalculateOmegaThing();
            //DisplayOmegaThing();

            CalculateAandBcoefficients();
            DisplayCoefficients();

            CalculateAmplitudes();
            DisplayAmplitudes();

            UpdateArraysFromDataGridViews();

            CalculatePercentages();
            DisplayPercentages();
        }

        //private void CalculateOmegaThing()
        //{
        //    // Ініціалізуємо масив omegaThing заздалегідь
        //    omegaThing = new double[(int)m]; // m може бути неціле, тому приводимо до int
        //    for (int i = 0; i < omegaThing.Length; i++)
        //    {
        //        omegaThing[i] = (i + 1) * omega;
        //    }
        //}

        //private void DisplayOmegaThing()
        //{
        //    // Очистимо dataGridView1 перед додаванням нових даних
        //    dataGridView1.Rows.Clear();

        //    // Додамо стовпець для значень omegaThing
        //    dataGridView1.Columns.Add("OmegaThing", "OmegaThing");

        //    // Додамо значення з масиву omegaThing до dataGridView1
        //    for (int i = 0; i < omegaThing.Length; i++)
        //    {
        //        dataGridView1.Rows.Add(omegaThing[i]);
        //    }
        //}

        private double[] TransitXValues()
        {
            // Ініціалізуємо новий масив для транзитних значень xValues
            transitXValues = new double[xValues.Length];

            // Переписуємо значення з xValues в transitXValues
            Array.Copy(xValues, transitXValues, xValues.Length);

            return transitXValues;
        }

        private void CalculateAandBcoefficients()
        {
            // Ініціалізуємо масиви амплітуд
            a1coefficients = new double[columnSums.GetLength(1) / 2];
            b1coefficients = new double[columnSums.GetLength(1) / 2];

            // Обчислюємо амплітуди для кожного елемента масиву columnSums
            for (int j = 0; j < columnSums.GetLength(1); j += 2)
            {
                // Обчислюємо значення амплітуд за новою формулою
                int harmonicNumber = j / 2 + 1;
                a1coefficients[harmonicNumber - 1] = mysteriousThing * columnSums[0, j];
                b1coefficients[harmonicNumber - 1] = mysteriousThing * columnSums[0, j + 1];
            }
        }

        private void DisplayCoefficients()
        {
            // Очищаємо дані відповідних стовпців dataGridView2 та dataGridView3 перед оновленням
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            // Перевіряємо, чи існують коефіцієнти для відображення
            if (a1coefficients != null && b1coefficients != null)
            {
                // Оновлюємо значення відповідних стовпців dataGridView2 та dataGridView3
                for (int i = 0; i < a1coefficients.Length; i++)
                {
                    // Додаємо значення коефіцієнтів до відповідних рядків dataGridView2 та dataGridView3
                    dataGridView2.Rows.Add(a1coefficients[i]);
                    dataGridView3.Rows.Add(b1coefficients[i]);
                }
            }
        }

        private void CalculateAmplitudes()
        {
            // Ініціалізуємо масив амплітуд
            Amplitudes = new double[a1coefficients.Length];

            // Обчислюємо амплітуди для кожного індексу
            for (int i = 0; i < a1coefficients.Length; i++)
            {
                // Обчислюємо квадрат суми коефіцієнтів за формулою і беремо його квадратний корінь
                Amplitudes[i] = Math.Sqrt(Math.Pow(a1coefficients[i], 2) + Math.Pow(b1coefficients[i], 2));
            }
        }

        private void DisplayAmplitudes()
        {
            // Очищаємо дані відповідного стовпця dataGridView1 перед оновленням
            dataGridView1.Rows.Clear();

            // Перевіряємо, чи існують амплітуди для відображення
            if (Amplitudes != null)
            {
                // Оновлюємо значення відповідного стовпця dataGridView1
                for (int i = 0; i < Amplitudes.Length; i++)
                {
                    // Додаємо значення амплітуди до відповідного рядка dataGridView1
                    dataGridView1.Rows.Add(Amplitudes[i]);
                }
            }
        }

        private void CalculatePercentages()
        {
            // Ініціалізуємо масив для відсотків
            percentages = new double[Amplitudes.Length];

            // Перший елемент завжди 100%
            percentages[0] = 100;

            // Обчислюємо відсотки для кожного елемента, крім першого
            for (int i = 1; i < Amplitudes.Length; i++)
            {
                percentages[i] = (Amplitudes[i] / Amplitudes[0]) * 100;
            }
        }

        private void DisplayPercentages()
        {
            // Очищаємо дані відповідного стовпця dataGridView4 перед оновленням
            dataGridView4.Rows.Clear();

            // Перевіряємо, чи існують відсотки для відображення
            if (percentages != null)
            {
                // Оновлюємо значення відповідного стовпця dataGridView4
                for (int i = 0; i < percentages.Length; i++)
                {
                    // Додаємо значення відсотків до відповідного рядка dataGridView4
                    dataGridView4.Rows.Add(percentages[i]);
                }
            }
        }

        //видалення рядку за кліком
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView4.SelectedCells[0].RowIndex;

            if (selectedIndex >= 0 && selectedIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.RemoveAt(selectedIndex);
            }

            if (selectedIndex >= 0 && selectedIndex < dataGridView2.Rows.Count)
            {
                dataGridView2.Rows.RemoveAt(selectedIndex);
            }

            if (selectedIndex >= 0 && selectedIndex < dataGridView3.Rows.Count)
            {
                dataGridView3.Rows.RemoveAt(selectedIndex);
            }

            if (selectedIndex >= 0 && selectedIndex < dataGridView4.Rows.Count)
            {
                dataGridView4.Rows.RemoveAt(selectedIndex);
            }
        }

        private void RemoveRowsLessThanValue(int value)
        {
            List<int> rowsToDelete = new List<int>();

            // Проходимося по всім рядкам dataGridView4 знизу вгору
            for (int i = dataGridView4.Rows.Count - 1; i >= 0; i--)
            {
                // Отримуємо значення комірки у відповідному рядку dataGridView4
                int cellValue;
                if (dataGridView4.Rows[i].Cells[0].Value != null && int.TryParse(dataGridView4.Rows[i].Cells[0].Value.ToString(), out cellValue))
                {
                    // Перевіряємо, чи значення менше вибраного користувачем значення
                    if (cellValue < value)
                    {
                        // Зберігаємо індекс рядка для видалення
                        rowsToDelete.Add(i);
                    }
                }
            }

            // Видаляємо рядки у зворотньому порядку, щоб уникнути проблем з індексацією
            for (int i = rowsToDelete.Count - 1; i >= 0; i--)
            {
                int rowIndex = rowsToDelete[i];

                // Видаляємо відповідні рядки у всіх DataGridView
                if (rowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
                if (rowIndex < dataGridView2.Rows.Count)
                {
                    dataGridView2.Rows.RemoveAt(rowIndex);
                }
                if (rowIndex < dataGridView3.Rows.Count)
                {
                    dataGridView3.Rows.RemoveAt(rowIndex);
                }
                dataGridView4.Rows.RemoveAt(rowIndex);
            }
        }

        private void InitializeTrackBar()
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.Value = 25; // Значення за замовчуванням
            trackBar1.TickStyle = TickStyle.None; // Відключаємо відображення позначок
            trackBar1.ValueChanged += trackBar1_ValueChanged; // Додаємо обробник події
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Отримуємо нове значення з повзунка
            int newValue = trackBar1.Value;

            // Відображаємо нове значення в мітці або іншому елементі для відображення
            label1.Text = "" + newValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                // Отримуємо поточне значення на повзунку
                int currentValue = trackBar1.Value;

                // Викликаємо метод для видалення рядків з усіх DataGridView
                RemoveRowsLessThanValue(currentValue);
            }
        }

        private void UpdateArraysFromDataGridViews()
        {
            // Оновлюємо масив newAmplitudes з dataGridView1
            newAmplitudes = new double[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double value;
                if (double.TryParse(dataGridView1.Rows[i].Cells[0].Value?.ToString(), out value))
                {
                    newAmplitudes[i] = value;
                }
            }

            // Оновлюємо масив newA1coefficients з dataGridView2
            newA1coefficients = new double[dataGridView2.Rows.Count];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                double value;
                if (double.TryParse(dataGridView2.Rows[i].Cells[0].Value?.ToString(), out value))
                {
                    newA1coefficients[i] = value;
                }
            }

            // Оновлюємо масив newB1coefficients з dataGridView3
            newB1coefficients = new double[dataGridView3.Rows.Count];
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                double value;
                if (double.TryParse(dataGridView3.Rows[i].Cells[0].Value?.ToString(), out value))
                {
                    newB1coefficients[i] = value;
                }
            }

            // Оновлюємо масив newPercentages з dataGridView4
            newPercentages = new double[dataGridView4.Rows.Count];
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                double value;
                if (double.TryParse(dataGridView4.Rows[i].Cells[0].Value?.ToString(), out value))
                {
                    newPercentages[i] = value;
                }
            }

            // Видаляємо елементи зі значенням строго 0
            RemoveZeroElements();
        }

        private void RemoveZeroElements()
        {
            // Видаляємо елементи зі значенням строго 0 з масивів
            newAmplitudes = newAmplitudes.Where(value => value != 0).ToArray();
            newA1coefficients = newA1coefficients.Where(value => value != 0).ToArray();
            newB1coefficients = newB1coefficients.Where(value => value != 0).ToArray();
            newPercentages = newPercentages.Where(value => value != 0).ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateArraysFromDataGridViews();

            // Повідомлення про успішне оновлення масивів
            MessageBox.Show("Масиви даних з DataGridView були успішно оновлені.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayAmplitudes();
            DisplayPercentages();
            DisplayCoefficients();
        }

        private void обрахунокГармонікToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(newA1coefficients, newB1coefficients, transitXValues);
            form5.Show();
        } 
    }
}