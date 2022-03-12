using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SuniyIntelekt
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Console Suniy Intellekt

            SortedList<double, int> qiymat = new SortedList<double, int>();
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m=");
            int m = int.Parse(Console.ReadLine());
            int[,] S = new int[n, m];
            int[] SS = new int[m];
            int[] Sinf = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    S[i, j] = rand.Next() % 10;
                    Console.Write(S[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------");
            for (int i = 0; i < m; i++)
            {
                SS[i] = rand.Next() % 10;
                Console.WriteLine($"Kiritilgan qiymatlar : {SS[i]}");
            }
            Console.WriteLine("-------------------\n" +
                "Sinflarni kiriting :");
            for (int i = 0; i < n; i++)
            {
                Sinf[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("-------------------");
            double[] masofa = new double[n];
            double s = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    s += Math.Pow(SS[j] - S[i, j], 2);
                }
                masofa[i] = Math.Sqrt(s);
                s = 0;
                Console.WriteLine($"Berilgan obyektga nisbatan masofalar : {masofa[i]}");
            }
            Console.WriteLine("-------------------");

            for (int i = 0; i < n; i++)
            {
                qiymat.TryAdd(masofa[i], Sinf[i]);
            }
            foreach (var item in qiymat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------");
            mbox:
            Console.Write("K=");
            int k = int.Parse(Console.ReadLine());
            if (k % 2 != 0 && k <= n)
            {
                int indeks = 0, bir = 0, ikki = 0;
                foreach (var item in qiymat)
                {
                    if (indeks < k)
                    {
                        Console.WriteLine(item);
                        if (item.Value == 1)
                        {
                            bir++;
                        }
                        else
                        {
                            ikki++;
                        }
                        indeks++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (bir > ikki)
                {
                    Console.WriteLine($"Berilgan obyektim 1-sinfga tegishli !!!");
                }
                else
                {
                    Console.WriteLine($"Berilgan obyektim 2-sinfga tegishli !!!");
                }
            }
            else if (k % 2 == 0)
            {
                Console.WriteLine("Kiritgan k miz juft bulishi mumkin emas !!!");
            }
            else
            {
                Console.WriteLine($"Kiritgan  sonimiz {k}>{n} katta . Bu esa S obyektimizda xatolikka olib keladi . Iltimos qaytadan kiriting !!!");
            }
            goto mbox;

            #endregion
        }
    }
}
