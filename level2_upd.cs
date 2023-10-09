using System;

namespace ConsoleApp1
{
    internal class level2
    {
        static void Main(string[] args)
        {
            //1
            double x = 0.5;
            double epsilon = 0.0001;
            double sum = 1.0;
            double term = 1.0;
            double xSquared = x * x;
            int n = 1;

            while (Math.Abs(term) >= epsilon)
            {
                sum += term;
                n++;
                xSquared *= xSquared;
                term = xSquared;
            }
            Console.WriteLine(sum);

            //2
            int limit = 30000;
            int product = 1;
            int n = 1;


            while (product <= limit)
            {
                product *= n;
                n += 3;
            }
            n -= 3;

            Console.WriteLine(n);


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
            double x = 0.5;
            double epsilon = 0.0001;
            double sum = 1.0;
            double term = 1.0;
            int n = 2;
            double xSquared = x * x;

            while (Math.Abs(term) >= epsilon)
            {
                sum += term;
                term *= xSquared;
                n += 2;
            }
            Console.WriteLine(sum);

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
