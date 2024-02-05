using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Praktika
{
    public class Ex1
    {

        /// <summary>
        /// Определяет является ли сумма цифр трехзначного числа двухзначным числом 
        /// </summary>
        /// <param name="value">трехзначное число</param>
        /// <returns>True если сумма цифр - двухзначное число, false - если иначе</returns>
        /// <exception cref="ArgumentException">Число не является трехзначным </exception>
        public static bool IsSummOfDigitsDoubleDigit(int value)
        {
            if (value <= 999 && value >= 100)
            {
                int summ = (value / 100) + (value / 10 % 10) + (value % 10);
                
                if (summ <= 99 && summ >= 10)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                throw new ArgumentException("Число не является трехзначным");
            }
        }
    }

    public class Ex2
    {

        /// <summary>
        /// найти сумму двух наибольших чисел
        /// </summary>
        /// <param name="value1">Первое число</param>
        /// <param name="value2">Второе число</param>
        /// <param name="value3">Третье число</param>
        /// <returns>Сумма двух наибольших из чисел</returns>
        public static int GetSummOfTwoMaxValues(int value1, int value2, int value3)
        {
            var list = new List<int>() { value1, value2, value3 };
            
            return list.OrderByDescending(x => x).Take(2).Sum();
        }
    }
    
    public class Ex3
    {
        /// <summary>
        /// Находит элемент, наиболее близкий к среднему значению всех элементов массива
        /// </summary>
        /// <param name="mas">двухзначный массив</param>
        /// <returns>Наиболее близкий элемент к среднему значению всех элементов массива</returns>
        public static double GetNearestToAverage(int[,] mas)
        {
            double average = GetAverage(mas),
                nearestValue = mas[0,0];

            foreach(int i in mas)
            {
                if (Math.Abs(i - average) < Math.Abs(nearestValue - average))
                {
                    nearestValue = i;
                }
            }

            return nearestValue;
        }


        /// <summary>
        /// Находит среднее значение элементов массива
        /// </summary>
        /// <param name="mas">Двухзначный массив</param>
        /// <returns>Среднее значение всех элементов</returns>
        public static double GetAverage(int[,] mas)
        {
            int sum = 0;

            foreach (int i in mas)
            {
                sum += i;
            }

            return sum / mas.Length;
        }
    }

    public class Ex4
    {
        /// <summary>
        /// Формирует одноменрный массив из количества положительных элементов столбцов матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <returns>Одноменрный массив из количества положительных элементов столбцов матрицы</returns>
        public static int[] CreateArray(int[,] matrix)
        {
            int[] mas = new int[matrix.GetLength(1)];
            int count;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] >= 0)
                    {
                        count++;
                    }
                }
                mas[j] = count;
            }
            return mas;
        }
    }

    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
