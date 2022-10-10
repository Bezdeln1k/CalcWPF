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

        private void bnt_7_Click(object sender, RoutedEventArgs e)
        {
            if(op == "")
            {
                num1 = num1 * 10 + 7;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + 7;
                txtValue.Text = num1.ToString();
            }
        }

        private void bnt_8_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 = num1 * 10 + 8;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + 8;
                txtValue.Text = num2.ToString();
            }
        }

        private void bnt_plus_Click(object sender, RoutedEventArgs e)
        {
            op = "+";
        }

        private void bnt_eq_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
            }

            txtValue.Text = result.ToString();
            op = "";
            num1 = result;
        }
    }
}
