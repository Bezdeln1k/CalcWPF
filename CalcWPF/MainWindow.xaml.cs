using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnt_num_Click(object sender, RoutedEventArgs e) //Функция обработки числовых кнопок
        {
            Button button = (Button)sender;
            String num = button.Content.ToString();
            if (txtValue.Text == "0")
                txtValue.Text = num;
            else
                txtValue.Text += num;

            if(op == "")
            {
                num1 = Double.Parse(txtValue.Text);
            }
            else
            {
                num2 = Double.Parse(txtValue.Text);
            }
        }

        private void bnt_op_Click(object sender, RoutedEventArgs e) //Функция обработки кнопок операций
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            txtValue.Text = "0";
        }

        private void bnt_eq_Click(object sender, RoutedEventArgs e) //Кнопка "равно"
        {
            double result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    break;
                case "x^y":
                    result = Pow(num1, (int) num2);
                    break;
                
            }

            txtValue.Text = result.ToString();
            op = "";
            num1 = result;
            num2 = 0;
        }

        //x^4 = x * x * x * x = x^3 * x;
        //x^3 = x * x * x = x^2 * x;
        //x^2 = x * x = x^1 * x;
        //x^1 = x = x^0 * x;
        //x^0 = 1;
        private double Pow(double x, int y)
        {
            if (y == 0)
                return 1;

            return Pow(x, y - 1) * x;

            //int result = 1;                   //реализация возведения в степень через цикл
            //for(int i = 1; i <= y; i++)
            //{
            //    result *= x;
            //}
            //return result;
        }

        private void bnt_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            op = "";
            txtValue.Text = "0";
        }

        private void bnt_CE_Click(object sender, RoutedEventArgs e)     //CE - clean entry - обнуляет num1 либо num2, смотря что вводится
        {
            if (op == "")
            {
                num1 = 0;
            }
            else
            {
                num2 = 0;
            }
            txtValue.Text = "0";
        }

        private void bnt_backspace_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Text = DropLastChar(txtValue.Text);
            if (op == "")
            {
                num1 = Double.Parse(txtValue.Text);
            }
            else
            {
                num2 = Double.Parse(txtValue.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
                text = "0";
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }

            return text;
        }

        private void bnt_plusminus_Click(object sender, RoutedEventArgs e) //переводит положительное число в отрицательное
        {
            if (op == "")
            {
                num1 *= -1;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtValue.Text = num2.ToString();
            }
        }

        private void bnt_comma_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                SetComma(num1);
            else
                SetComma(num2);

        }

        private void SetComma(double num1) //Ф-я нажатия запятой и проверки повторных нажатий
        {

            if (txtValue.Text.Contains(','))
                return;

            txtValue.Text += ',';
        }
    }
}
