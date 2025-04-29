using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            Massiv massiv = new Massiv();
            Console.WriteLine("Создание первого массива");
            double[] m1 = massiv.CreateMas();
            Console.WriteLine("Создание второго массива");
            double[] m2 = massiv.CreateMas();
            int i = 1;
            do
            {
                Console.Write("Введите номер метода (сложение и вычитание массивов - 1; умножение массива на одно число - 2; вывод элемента массива по заданному индексу - 3; для завершения программы нажмите любуой другой символ): ");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        massiv.SumRazMas(m1, m2);
                        break;
                    case "2":
                        {
                            do
                            {
                                Console.Write("Введите номер массива, который нужно умножить: ");
                                s = Console.ReadLine();
                                switch (s)
                                {
                                    case "1":
                                        {
                                            massiv.MultiMas(m1);
                                            i = 1;
                                        }
                                        break;
                                    case "2":
                                        {
                                            massiv.MultiMas(m2);
                                            i = 1;
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Вы ввели неверный номер массива");
                                            i = 0;
                                        }
                                        break;
                                }
                            } while (i == 0);
                        }
                        break;
                    case "3":
                        {
                            do
                            {
                                Console.Write("Введите номер массива, чей элемент нужно вывести: ");
                                s = Console.ReadLine();
                                switch (s)
                                {
                                    case "1":
                                        {
                                            massiv.ConclMas(m1);
                                            i = 1;
                                        }
                                        break;
                                    case "2":
                                        {
                                            massiv.ConclMas(m2);
                                            i = 1;
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Вы ввели неверный номер массива");
                                            i = 0;
                                        }
                                        break;
                                }
                            } while (i == 0);
                        }
                        break;
                    default:
                            i = 0;
                        break;
                }
            } while (i == 1);
        }
    }
    public class Massiv
    {
        public double[] CreateMas()
        {
            int n = 0;
            int r = 0;
            int r1 = 0;
            Random rnd = new Random();
            int i = 0;
            do
            {
                try
                {
                    Console.Write("Введите количество элементов массива: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new FormatException("Длина массива не может быть нулевой или отрицательной");
                    }
                    Console.Write("Введите начальную границу рандомных значений массива: ");
                    r = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите конечную границу рандомных значений массива: ");
                    r1 = Convert.ToInt32(Console.ReadLine());
                    if(r1 < r)
                    {
                        throw new FormatException("Конечная граница рандомных значений не может быть меньше начальной");
                    }
                    i = 1;
                }
                catch (FormatException ice)
                {
                    Console.WriteLine(ice.Message);
                }
            }while( i == 0 );
            double[]a = new double[n];
            for(i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(r,r1);
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            return a;
        }
        public void SumRazMas(double[] m1, double[] m2)
        {
            double[] a1 = new double[m1.Length];
            if(m1.Length == m2.Length) 
            {
                int i = 0;
                Console.WriteLine("Сложение массивов");
                for (i = 0;i < m1.Length;i++) 
                {
                    a1[i] = m1[i] + m2[i];
                    Console.Write(a1[i] + " ");
                }
                Console.WriteLine();
                double[] b = new double[m1.Length];
                do
                {
                    Console.Write("Введите номер массива, из которого будет происходить вычитание: ");
                    string s = Console.ReadLine();
                    switch (s)
                    {
                        case "1":
                            {
                                for(i = 0; i < m1.Length; i++)
                                {
                                    a1[i] = m1[i];
                                    b[i] = m2[i];
                                }
                                i = 1;
                            }
                            break;
                        case "2":
                            {
                                for (i = 0; i < m1.Length; i++)
                                {
                                    a1[i] = m2[i];
                                    b[i] = m1[i];
                                }
                                i = 1;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Вы ввели неверный номер массива");
                                i = 0;
                            }
                            break;
                    }
                } while (i == 0);
                Console.WriteLine("Вычитание массивов");
                for (i = 0; i < a1.Length; i++)
                {
                    a1[i] -= b[i];
                    Console.Write(a1[i] + " ");
                }
                Console.WriteLine();
            }
            else 
                Console.WriteLine("Массивы не возможно поэлементарно сложить и вычесть, так как они разной длины");
        }
        public void MultiMas(double[] m)
        {
            int i = 0;
            double n = 0;
            do
            {
                try
                {
                    Console.Write("Введите число, на которое нужно умножить и поделить массив: ");
                    n = Convert.ToDouble(Console.ReadLine());
                    i = 1;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }while (i == 0);
            Console.WriteLine("Умножение массива");
            double[] a2 = new double[m.Length];
            for(i = 0; i < a2.Length; i++)
            {
                a2[i] = m[i] * n;
                Console.Write(a2[i] + " ");
            }
            Console.WriteLine();
            if (n == 0)
                Console.WriteLine("Невозможно поделить элементы массива на данное число, так как оно равно нулю");
            else 
            {
                Console.WriteLine("Деление массива");
                for (i = 0; i < a2.Length; i++)
                {
                    a2[i] = m[i] / n;
                    Console.Write(a2[i] + " ");
                    Console.WriteLine();
                }
            }
        }
        public void ConclMas(double[] m)
        {
            int i = 0;
            do
            {
                try
                {
                    Console.Write("Введите индекс элемента массива: ");
                    i = Convert.ToInt32(Console.ReadLine());
                    if (i < 0)
                    {
                        throw new FormatException("Индекс элемента массива не может быть отрицательным");
                    }
                    else if(i >= m.Length) 
                    {
                        throw new FormatException("Вы ввели индекс, который превышает максимальный индекс");
                    }
                }
                catch (FormatException ice)
                {
                    Console.WriteLine(ice.Message);
                }
            } while (i < 0 || i >= m.Length);
            Console.WriteLine(m[i]);
            for(i = 0; i < m.Length; i++) 
            {
                Console.Write(m[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
