using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] arr;
            int sum = 0, size = 0, max = 0, min = 0, middle_sum = 0;

            Console.WriteLine("Введите размер массива: ");
            size = Convert.ToInt32(Console.ReadLine());

            arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-100, 100);
                Console.Write(arr[i]);
                Console.Write(" ");
                sum += arr[i];

                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            middle_sum = sum / size;

            Console.WriteLine();

            Console.WriteLine("Сумма элементов массива = {0}.\nМаксимальный элемент в массиве = {1}.\nМинимальный элемент в массиве = {2}", sum, max, min);
            Console.WriteLine("Среднее арифметическое = {0}", middle_sum);
        }
    }
}
