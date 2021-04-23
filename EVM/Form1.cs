using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotAgent.DataExporter;

namespace EVM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            double SumElementsX = 0;
            double Sum2ElementsX = 0;

            double SumElementsY = 0;
            double Sum2ElementsY = 0;

            double SumMultiplyElementsXY = 0;

            Excel xl = new Excel();
            xl.FileOpen("ЭВМ_Вариант10.xlsx");

            int CountXY = 91;
            string[] X = new string[CountXY];
            string[] Y = new string[CountXY];
            double[] Fi = new double[CountXY];

            for (int count = 1; count < CountXY; count++) { 
                X[count] = xl.Rows[count][0];
                Y[count] = xl.Rows[count][1];

                SumElementsX += Convert.ToDouble(X[count]);
                SumElementsY += Convert.ToDouble(Y[count]);
                Sum2ElementsX += Math.Pow(Convert.ToDouble(X[count]), 2);
                Sum2ElementsY += Math.Pow(Convert.ToDouble(Y[count]), 2);
                SumMultiplyElementsXY += Convert.ToDouble(X[count]) * Convert.ToDouble(Y[count]);

                listBox1.Items.Add(X[count]);
                listBox2.Items.Add(Y[count]);

                chart1.Series[0].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Y[count]));
            }

            double a = (Sum2ElementsX * SumElementsY - SumElementsX * SumMultiplyElementsXY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            double b = ((CountXY - 1) * SumMultiplyElementsXY - SumElementsX * SumElementsY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            textBox1.Text = Convert.ToString(a);
            textBox2.Text = Convert.ToString(b);

            for (int count = 1; count < CountXY; count++)
            {
                Fi[count] = a + b * Convert.ToDouble(X[count]);
                listBox3.Items.Add(Fi[count]);
                chart1.Series[1].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Fi[count]));

            }

            /*
            textBox1.Text = Convert.ToString(SumMultiplyElementsXY);
            textBox2.Text = Convert.ToString(SumMultiplyElementsXY);
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            double SumElementsX = 0;
            double Sum2ElementsX = 0;

            double SumElementsY = 0;
            double Sum2ElementsY = 0;

            double SumMultiplyElementsXY = 0;

            Excel xl = new Excel();
            xl.FileOpen("ЭВМ_Вариант10.xlsx");

            int CountXY = 91;
            string[] X = new string[CountXY];
            string[] Y = new string[CountXY];
            double[] Fi = new double[CountXY];
            double[] lnX = new double[CountXY];
            double[] lnY = new double[CountXY];

            for (int count = 1; count < CountXY; count++)
            {
                X[count] = xl.Rows[count][0];
                Y[count] = xl.Rows[count][1];

                lnX[count] = Math.Log(Convert.ToDouble(X[count]));
                lnY[count] = Math.Log(Convert.ToDouble(Y[count]));

                SumElementsX += Convert.ToDouble(lnX[count]);
                SumElementsY += Convert.ToDouble(lnY[count]);
                Sum2ElementsX += Math.Pow(Convert.ToDouble(lnX[count]), 2);
                Sum2ElementsY += Math.Pow(Convert.ToDouble(lnY[count]), 2);
                SumMultiplyElementsXY += Convert.ToDouble(lnX[count]) * Convert.ToDouble(lnY[count]);

                listBox1.Items.Add(X[count]);
                listBox2.Items.Add(Y[count]);

                chart1.Series[0].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Y[count]));
            }

            double a = (Sum2ElementsX * SumElementsY - SumElementsX * SumMultiplyElementsXY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            double b = ((CountXY - 1) * SumMultiplyElementsXY - SumElementsX * SumElementsY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            a = Math.Exp(a);
            textBox1.Text = Convert.ToString(a);
            textBox2.Text = Convert.ToString(b);

            for (int count = 1; count < CountXY; count++)
            {
                Fi[count] = a * Math.Pow(Convert.ToDouble(X[count]), b);
                listBox3.Items.Add(Fi[count]);
                chart1.Series[1].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Fi[count]));

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            double SumElementsX = 0;
            double Sum2ElementsX = 0;

            double SumElementsY = 0;
            double Sum2ElementsY = 0;

            double SumMultiplyElementsXY = 0;

            Excel xl = new Excel();
            xl.FileOpen("ЭВМ_Вариант10.xlsx");

            int CountXY = 91;
            string[] X = new string[CountXY];
            string[] Y = new string[CountXY];
            double[] Fi = new double[CountXY];
            double[] lnX = new double[CountXY];
            double[] lnY = new double[CountXY];

            for (int count = 1; count < CountXY; count++)
            {
                X[count] = xl.Rows[count][0];
                Y[count] = xl.Rows[count][1];

                lnX[count] = Math.Log(Convert.ToDouble(X[count]));
                lnY[count] = Math.Log(Convert.ToDouble(Y[count]));

                SumElementsX += Convert.ToDouble(X[count]);
                SumElementsY += Convert.ToDouble(lnY[count]);
                Sum2ElementsX += Math.Pow(Convert.ToDouble(X[count]), 2);
                Sum2ElementsY += Math.Pow(Convert.ToDouble(lnY[count]), 2);
                SumMultiplyElementsXY += Convert.ToDouble(X[count]) * Convert.ToDouble(lnY[count]);

                listBox1.Items.Add(X[count]);
                listBox2.Items.Add(Y[count]);

                chart1.Series[0].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Y[count]));
            }

            double a = (Sum2ElementsX * SumElementsY - SumElementsX * SumMultiplyElementsXY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            double b = ((CountXY - 1) * SumMultiplyElementsXY - SumElementsX * SumElementsY) / ((CountXY - 1) * Sum2ElementsX - Math.Pow(SumElementsX, 2));
            a = Math.Exp(a);
            textBox1.Text = Convert.ToString(a);
            textBox2.Text = Convert.ToString(b);

            for (int count = 1; count < CountXY; count++)
            {
                Fi[count] = a * Math.Exp(Convert.ToDouble(X[count]) * b);
                listBox3.Items.Add(Fi[count]);
                chart1.Series[1].Points.AddXY(Convert.ToDouble(X[count]), Convert.ToDouble(Fi[count]));

            }
        }
    }
}
