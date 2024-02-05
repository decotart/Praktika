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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Praktika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetResultEx1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(tbValueEx1.Text);

                if (Ex1.IsSummOfDigitsDoubleDigit(value))
                {
                    MessageBox.Show("Сумма цифр является двухзначным числом");
                }
                else MessageBox.Show("Сумма цифр не является двухзначным числом");
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        private void btnGetResult2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int value1 = Convert.ToInt32(tbEx2Value1.Text),
                    value2 = Convert.ToInt32(tbEx2Value2.Text),
                    value3 = Convert.ToInt32(tbEx2Value3.Text);

                int result = Ex2.GetSummOfTwoMaxValues(value1, value2, value3);

                MessageBox.Show($"Сумма двух наибольших чисел равна {result}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }

        }

        int[,] matrix3;

        private void btnCreateEx3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(tbNEx3.Text),
                m = Convert.ToInt32(tbMEx3.Text);
                matrix3 = new int[m, n];

                DataGridEx3.ItemsSource = VisualArray.ToDataTable(matrix3).DefaultView;
            }
            catch (FormatException) 
            { 
                MessageBox.Show("Вводите только целочисленные значения!"); 
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnFillEx3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new();

                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix3.GetLength(1); j++)
                    {
                        matrix3[i, j] = rnd.Next(0, 10);
                    }
                }

                DataGridEx3.ItemsSource = VisualArray.ToDataTable(matrix3).DefaultView;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для начала создайте таблицу!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnGetResultEx3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = Ex3.GetNearestToAverage(matrix3);
                
                tbResultEx3.Text = result.ToString();

                MessageBox.Show($"Среднее значение: {Ex3.GetAverage(matrix3)}");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void DataGridEx3_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int index0 = e.Column.DisplayIndex;
                int index1 = e.Row.GetIndex();

                int value = int.Parse(((TextBox)e.EditingElement).Text);
                matrix3[index1, index0] = value;
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }

            tbResultEx3.Clear();
        }


        //ex4

        int[,] matrix4;
        int[] result;

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int index0 = e.Column.DisplayIndex;
                int index1 = e.Row.GetIndex();

                int value = int.Parse(((TextBox)e.EditingElement).Text);
                matrix4[index1, index0] = value;
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnGetResultEx4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result = Ex4.CreateArray(matrix4);

                DataGridResultEx4.ItemsSource = VisualArray.ToDataTable(result).DefaultView;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnFillEx4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new();

                for (int i = 0; i < matrix4.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix4.GetLength(1); j++)
                    {
                        matrix4[i, j] = rnd.Next(-10, 10);
                    }
                }

                DataGridEx4.ItemsSource = VisualArray.ToDataTable(matrix4).DefaultView;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для начала создайте таблицу!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnCreateEx4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(tbNEx4.Text),
                m = Convert.ToInt32(tbMEx4.Text);
                matrix4 = new int[m, n];

                DataGridEx4.ItemsSource = VisualArray.ToDataTable(matrix4).DefaultView;
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");

            }
        }
    }
}
