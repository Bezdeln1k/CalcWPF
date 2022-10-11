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
        int num1 = 0;
        int num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnt_num_Click(object sender, RoutedEventArgs e) //Функция обработки числовых кнопок
        {
            Button button = (Button)sender;
            String str = button.Content.ToString();
            int num = Int32.Parse(str);

            if(op == "")
            {
                num1 = num1 * 10 + num;
                txtValue.Text = num1.ToString();
        }
            else
            {
                num2 = num2 * 10 + num;
                txtValue.Text = num2.ToString();
            }
        }

        private void bnt_op_Click(object sender, RoutedEventArgs e) //Функция обработки кнопок операций
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
        }

        private void bnt_eq_Click(object sender, RoutedEventArgs e) //Кнопка "равно"
        {
            int result = 0;
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
            }

            txtValue.Text = result.ToString();
            op = "";
            num1 = result;
        }
    }
}
