using System;

namespace ConsoleApp1
{
    internal class level1_num1
    {
        static void Main(string[] args)
        {
            //1 
            int r = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                a[i, 0] = Convert.ToInt32(Console.ReadLine());
                a[i, 1] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                int x = a[i, 0], y = a[i, 1];
                if (Math.Abs(x * x + y * y - r * r) <= Math.Pow(10, -3))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            //2
            double sum = 0;
            for (double i = 1; i <= 10; i += 1)
                    {
                        sum = sum + (1 / i); 
                    }
            Console.WriteLine(sum);

            //3
            double sum = 0;
            for (double i = 1; i <= 113; i += 2)
            {
                sum += (i + 1) / (i + 2);
            }
            Console.WriteLine(sum);

            //4
            double sum = 0;
            int x = 10;
            for (int i = 0; i <= 8; i += 1)
            {
                sum += Math.Cos((i + 1) * x) / Math.Pow(x, 0);
            }
            Console.WriteLine(sum);

            //5
            int p = 1;
            int sum = 0;
            for (int h = 0; h <= 9; h++)
            {
                int ph = p + h;
                sum = (int)(sum + Math.Pow(ph, 2));
            }
            Console.WriteLine(sum);

            //6
            double number = 0;
            for (double i = -4; i <= 4; i += 0.5)
            {
                number = (Math.Pow(0.5 * i, 2) - 7 * i);
                Console.WriteLine($"{number} {i}");
            }

            //7
            int proizv = 1;
            for (int i = 1; i <= 6; i++)
            {
                proizv = proizv * i;
            }
            Console.WriteLine(proizv);

            //8
            int sum = 0;
            int fact1 = 1;
            for (int i = 1; i <= 6; i++)
            {
                fact1 = fact1 * i;
                sum += fact1;
            }
            Console.WriteLine(sum);

            //9
            int Factorial(int n)
            {
                if (n == 1) return 1;

                return n * Factorial(n - 1);
            }

            int sum = 0;
            int number = 0;

            for (int i = 1; i <= 6; i++)
            {
                number = (int)(Math.Pow(-1, i) * Math.Pow(5, i) / Factorial(i));
                sum += number;
            }
            Console.WriteLine(number);

            //10
            int number = 1;
            for (int i = 1; i <= 7; i++)
            {
                number *= 3;
            }
            Console.WriteLine(number);


            //11
            int j = 6;
            for (int i = 1; i < j; i++)
            {
                Console.Write(i + " ");
            }
            Console.Write($"{j},");
            Console.WriteLine();
            int b = 5;
            for (int i = 0; i < b; i++)
            {
                Console.Write(b + " ");
            }
            Console.Write($"{b}.");
            Console.WriteLine();

            //12
            double sum = 0;
            int x = 2;
            for (int i = 0; i <= 10; i++)
            {
                sum += 1 / Math.Pow(x, i);
            }
            Console.WriteLine(sum);

            //13
            Console.WriteLine("x     y");
            double y13 = 0;
            for (double x13 = -1.5; x13 < 1.6; x13 += 0.1)
            {
                if (x13 <= -1) y13 = 1;
                else if (x13 > -1 && x13 <= 1)
                {
                    if (x13 == 0) y13 = 0;
                    else y13

            //14
            int s = 1;
            int p = 1;
            int t = 0;
            Console.WriteLine(1);
            Console.WriteLine(1);
            for (int i = 1; i <= 6; i++)
            {
                t = s + p;
                s = p;
                p = t;
                Console.WriteLine(з);
            }

            //15
            int n = 5;

            int numerator1 = 1;
            int denominator1 = 1;

            int numerator2 = 2;
            int denominator2 = 1;

            int numerator = 0;
            int denominator = 0;

            for (int i = 3; i <= n; i++)
            {
                numerator = numerator1 + numerator2;
                denominator = denominator1 + denominator2;
                numerator1 = numerator2;
                denominator1 = denominator2;
                numerator2 = numerator;
                denominator2 = denominator;
            }
            Console.WriteLine("5-й член последовательности: " + (double)numerator / denominator);
            Console.ReadKey();
                }
            }
        }
    }
}
