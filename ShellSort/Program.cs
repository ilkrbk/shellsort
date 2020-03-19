using System;
using System.Collections.Generic;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>();
            Console.WriteLine("Размер масива?");
            int sizeArr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Какой тип упорядочивания?");
            Console.WriteLine("1 Упорядочений массив");
            Console.WriteLine("2 Обратно упорядочений массив");
            Console.WriteLine("3 Рандомно упорядочений массив");
            int typeSort = Convert.ToInt32(Console.ReadLine());
            switch (typeSort)
            {
                case 1:
                    {
                        for (int i = 0; i < sizeArr; i++)
                        {
                            array.Add(i + 1);
                        }
                    }
                    break;
                case 2:
                    {
                        for (int i = sizeArr; i > 0; i--)
                        {
                            array.Add(i);
                        }
                    }
                    break;
                case 3:
                    {
                        Random rand = new Random();
                        for (int i = 0; i < sizeArr; i++)
                        {
                            array.Add(rand.Next(50000));
                        }
                    }
                    break;
                default: break;
            }
            //ArrayShow(array);
            List<int> arraySort = ShellSort(array);
            //ArrayShow(arraySort);
        }
        static List<int> ShellSort(List<int> array)
        {
            List<int> step = new List<int>();
            int elemStep;
            int countTrans = 0, countCheck = 0;
            int x = 0;
            do
            { 
                elemStep = (int) Math.Ceiling((((9*(Math.Pow(2.25, x)))-4)/5));
                step.Add(elemStep);
                x++;
            } while (step[step.Count - 1] < array.Count);
            step.RemoveAt(step.Count - 1);
            for (int i = step.Count - 1; i >= 0; --i)
            {
                for (int t = 0; t < (array.Count - step[i]); t++)
                {
                    int j = t;
                    countCheck++;
                    while ((j >= 0) && (array[j] > array[j + step[i]]))
                    {
                        countTrans++;
                        int temp = array[j + step[i]];
                        array[j + step[i]] = array[j];
                        array[j] = temp;
                        j = j - step[i];
                    }
                }
            }
            Console.WriteLine($"Кол-во сравнений: {countCheck}");
            Console.WriteLine($"Кол-во перестановок: {countTrans}");
            return array;
        }

        static void ArrayShow(List<int> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}