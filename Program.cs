using System;
using System.Linq;

namespace independent_work
{
    internal class Program
    {
        private static void print_array(double[] array)
        {
            foreach (var t in array) Console.Write(t + " ");
            Console.WriteLine();
        }

        private static double get_max_in_array(double[] array)
        {
            double max = 0;
            for (var i = 0; i < array.Length; i++)
                if (array[i] > max)
                    max = array[i];
            return max;
        }

        private static int min_number_in_array(double[] array)
        {
            double min = array[0];
            int minIndex = 0;
            for (int i = 1; i < array.Length; ++i)
                if (array[i] < min)
                {
                    min = array[0];
                    minIndex = i;
                }

            return minIndex;
        }

        private static double sum_between_firsts_negatives(double[] array)
        {
            double sum = 0;
            bool flag = false;
            foreach (var d in array)
                if (d < 0)
                {
                    if (flag) break;
                    flag = true;
                }
                else if (flag) sum += d;

            return sum;
        }

        private static double[] del_from_array_numbers_wich_less_then_averange_value_of(ref double[] array)
        {
            double averange = 0;
            foreach (var d in array) averange += d;
            averange /= array.Length;
            array = array.Where(item => item >= averange).ToArray();
            return array;
        }

        private static double[] insert_max_into_array_betwen_range(ref double[] array, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || secondIndex > array.Length || firstIndex >= secondIndex)
                throw new Exception("Ошибка в диапазоне");
            double max = get_max_in_array(array);
            double[] output = new double[array.Length + secondIndex - firstIndex - 1];
            //     "     "
            // 0 1 2 3 4 5 6
            // 0 1 2 3 6 4 6 5 6

            for (int ai = 0, oi = 0; ai < array.Length; ++ai, ++oi)
            {
                output[oi] = array[ai];
                if (ai > firstIndex && ai < secondIndex) output[++oi] = max;
            }

            return array = output;
        }

        private static double[] bubble_sort_without_Z(ref double[] array, double Z)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].ToString().Contains(Z.ToString())) continue;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[j].ToString().Contains(Z.ToString())) continue;
                    if (array[i] > array[j])
                    {
                        double tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            // 19 6 8 11 3
            // 19 > 6  true
            // 6 19 8 11 3
            // 6 > 8   false
            // 6 > 11  false
            // 6 > 3   true
            // 3 19 8 11 6
            // 19 > 8  true
            // 3 8 19 11 6
            // 8 > 11  false
            // 8 > 6   true
            // 3 6 19 11 8
            // 19 > 11 true
            // 3 6 11 19 8
            // 11 > 8  true
            // 3 6 8 19 11
            // 19 > 11 true
            // 3 6 8 11 19

            return array;
        }
        
        /*
        * Вариант 8
        * В одномерном массиве, состоящем из n вещественных элементов, вычислить:
        * 1) номер минимального элемента массива; ✓
        * 2) сумму элементов массива, расположенных между первым и вторым отрицательными элементами. ✓
        * 3) Удалить из массива все элементы, которые меньше среднего арифметического. ✓
        * 4) Вставить в массив максимальный элемент после каждого числа, принадлежащего заданному диапазону. ✓
        * 5) Отсортировать по возрастанию только элементы массива, в целой части которых не встречается цифра Z ✓
        */

        public static void Main(string[] args)
        {
            double[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 16, -2, 3, -5, -6, -8, -10};
            Console.WriteLine(min_number_in_array(array));
            Console.WriteLine(sum_between_firsts_negatives(array));
            print_array(del_from_array_numbers_wich_less_then_averange_value_of(ref array));
            print_array(insert_max_into_array_betwen_range(ref array, 3, 6));
            print_array(bubble_sort_without_Z(ref array, 0));
            // © PROG
        }
    }
}