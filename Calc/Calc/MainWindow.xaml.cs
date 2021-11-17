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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, res;
        SelectOperator selectOperator;

        public MainWindow()
        {
            InitializeComponent();
            result.Content = 0;
        }

        private void numbersBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            Button btn = sender as Button;
            if (btn != null)
            {
                selectedValue = int.Parse(btn.Content.ToString());
            }

            if (result.Content.ToString() == "0")
            {
                result.Content = $"{selectedValue}";
            }
            else
            {
                result.Content = $"{result.Content}{selectedValue}";
            }


        }


        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result.Content.ToString(), out lastNumber))
            {
                result.Content = "0";
            }

            if (sender == plusBtn)
                selectOperator = SelectOperator.Addition;
            if (sender == minusBtn)
                selectOperator = SelectOperator.Substruction;
            if (sender == divisionBtn)
                selectOperator = SelectOperator.Divide;
            if (sender == multiplyBtn)
                selectOperator = SelectOperator.Multiplication;

        }


        private void acBtn_Click(object sender, RoutedEventArgs e)
        {
            result.Content = 0;
            res = 0;
            lastNumber = 0;
        }

        private void negativeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void percentageBtn_Click(object sender, RoutedEventArgs e)
        {
            double tmpNumber;
            if (double.TryParse(result.Content.ToString(), out tmpNumber)){
                tmpNumber = (tmpNumber / 100);
                if(lastNumber != 0)
                {
                    tmpNumber *= lastNumber;
                }
                result.Content = tmpNumber.ToString();
            }
        }


        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (result.Content.ToString().Contains("."))
            {

            }
            else
            {
                result.Content = $"{result.Content}";
            }
        }

        private void equelBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(result.Content.ToString(), out newNumber))
            {
                switch (selectOperator)
                {
                    case SelectOperator.Addition:
                        res = Calculate.Plus(lastNumber, newNumber);
                        break;
                }
            }

            result.Content = res;
        }
    }

    public enum SelectOperator
    {
        Addition,
        Substruction,
        Multiplication,
        Divide
    }

    public class Calculate
    {
        public static double Plus(double n1, double n2)
        {
            return n1 + n2;
        }
    }
}
