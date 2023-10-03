using System;

namespace ConsoleApp1
{
    internal class level2
    {
        static void Main(string[] args)
        {
            //1
            double sum = 0;
            int x = 1;
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                sum += Math.Cos(i * x) / Math.Pow(i, 2);
                if (Math.Abs(Math.Cos(i * x) / Math.Pow(i, 2)) < 0.0001)
                {
                    Console.WriteLine(sum);
                    break;
                }
            }

            //2
            int sum = 1;
            int last_sum = 0;

            for (int i = 1; i <= 10000; i += 3)
            {
                sum *= i;
                if (sum <= 30000)
                {
                    last_sum = sum;
                }
                if (sum > 30000)
                {
                    Console.WriteLine(last_sum);
                    break;
                }
            }

            //3
            int s = 0, n = 0, m;
            const int a = 2, h = 3, p = 41;
            while (s <= p)
            {
                m = a + n * h;
                s = s + m;
                n = n + 1;
            }
            n--;
            Console.WriteLine($"{n:d}");

            //4
            double sum = 0;
            double x = 0.9;
            double last_sum = 0;
            for (int n = 1; n <= 10000; n++)
            {
                sum += Math.Pow(x, n * 2);
                if (Math.Pow(x, n * 2) >= 0.0001)
                {
                    last_sum = sum;
                }

                if (Math.Pow(x, n * 2) < 0.0001)
                {
                    Console.WriteLine(last_sum);
                    break;
                }
            }

            //5
            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());
            int K = 0;
            while (N >= M)
            {
                K += 1;
                N -= M;
            }
            Console.WriteLine(K);
            Console.WriteLine(N);

            //6
            int n = 1;
            int time = 0; 

            while (n != 105) 
            {
            time++; 


            n += n;


            if (n > 105)
                {
            n = 105;
                }
            }

            Console.WriteLine("Время: " + time);
            Console.ReadKey();

            //7.1
            
            double r = 10;
            double sum = 10;
            for (int kolvo = 1; kolvo < 7; kolvo++)
            {
                r = r + r * 0.1;
                sum += r;
            }
            Console.WriteLine(sum);
            
            //7.2
            double r = 10;
            double sum = 10;
            int kolvo = 1;
            for (kolvo = 1; sum < 100;)
            {
                r = r + r * 0.1;
                sum += r;
                kolvo += 1;
            }
            Console.WriteLine(kolvo);
            
            //7.3
            double r = 10;
            double sum = 10;
            int kolvo = 1;
            for (kolvo = 1; r <= 20;)
            {
                r = r + r * 0.1;
                kolvo += 1;
            }
            Console.WriteLine(kolvo);


            //8
            double sum = 10000;
            for (int i = 1; i <= 100; i++)
            {
                sum *= 1.08;
                if (sum >= 20000)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
