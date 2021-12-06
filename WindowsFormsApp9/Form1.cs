using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private Color color;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            double a = -50, b = 50, c = 10, x, y;
            x = a;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            c = Convert.ToDouble(textBox3.Text);
            this.chart1.Series[0].Points.Clear();
            while (x <= b)
            {
                y = Math.Sin(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += c;

            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //кнопка увеличения
            Axis ax = chart1.ChartAreas[0].AxisX;
            ax.ScaleView.Size = double.IsNaN(ax.ScaleView.Size) ?
                                (ax.Maximum - ax.Minimum) / 2 : ax.ScaleView.Size /= 2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // кнопка уменьшения
            Axis ax = chart1.ChartAreas[0].AxisX;
            ax.ScaleView.Size = double.IsNaN(ax.ScaleView.Size) ?
                                ax.Maximum : ax.ScaleView.Size *= 2;
            if (ax.ScaleView.Size > ax.Maximum - ax.Minimum)
            {
                ax.ScaleView.Size = ax.Maximum;
                ax.ScaleView.Position = 0;
            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа построение графика функции у=х.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить изображение как ...";
                sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                        case 2: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                        case 3: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(textBox1.Text); ; //Задаем максимальные значения координат
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(textBox2.Text); ;
             
            
            this.chart1.Series[0].Points.Clear();

            chart1.ChartAreas[0].AxisX.Interval = 1; // и можно интервалы настроить по своему усмотрению

        }
    }
    
}
