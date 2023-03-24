using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr
{
    public partial class Form1 : Form
    {
        public int[] array = new int[10];
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            string way = "D:\\\\3 курс\\6 семестр\\рпм\\массив.txt";
            string line = File.ReadAllText(way);
            int y = 0;
            foreach (var i in line.Split('*'))
            {
                array[y] = Convert.ToInt32(i);
                y++;
            }
            string outcome = "";
            for (int i = 0; i < array.Length; i++)
            {
                outcome += Convert.ToString(array[i]) + " ";
            }
            MessageBox.Show($"Массив из файла\n{outcome}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string line = "";
            Random numeric = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numeric.Next(1, 100);
                line += Convert.ToString(array[i]) + " ";
            }

            MessageBox.Show($"Массив из случайных чисел:\n{line}");
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string line = textBox2.Text;
                int j = 0;
                foreach (var i in line.Split('*'))
                {
                    array[j] = Convert.ToInt32(i);
                    j++;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат. Попробуйте ввести заново");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string array_line = "";
            Stopwatch time = new Stopwatch();
            time.Start();
            int count = 0;
            for (int i = 1; ; i++)
            {
                if (i == array.Length)
                {
                    i = 1;
                }
                int y = i - 1;
                if (array[y] < array[i])
                {
                    count++;
                }
                if (array[y] > array[i])
                {
                    int changer = array[i];
                    array[i] = array[y];
                    array[y] = changer;
                    count = 0;
                }
                if (count == array.Length)
                {
                    break;
                }
            }
            time.Stop();
            for (int i = 0; i < array.Length; i++)
            {
                array_line += Convert.ToString(array[i]) + " ";
            }
            textBox3.Text = array_line;
            double convert = (double)time.ElapsedTicks;
            textBox4.Text = Convert.ToString(convert);
        }
    }
}
