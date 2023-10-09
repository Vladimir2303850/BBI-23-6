using System;

namespace ConsoleApp1
{
    internal class level1_num1
    {
        static void Main(string[] args)
        {
            //1
            int sum = 0;

            for (int i = 2; i <= 35; i += 3)
            {
                sum += i;
            }
            Console.WriteLine(sum);

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
            double x = 1.5;
            double sum = 0.0;
            double xPower = 1.0;

            // Вычисление суммы
            for (int i = 1; i <= 9; i++)
            {
                double term = Math.Cos(i * x) / xPower;
                sum += term;
                xPower *= x;
            }

            Console.WriteLine(sum);

            //5
            int p = 2;
            int h = 3;
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int term = (p + i * h) * (p + i * h);
                sum += term;
            }

            Console.WriteLine("Сумма равна: " + sum);

            //6
            double x = -4;
            double step = 0.5;
            double end = 4;
            double y;

            Console.WriteLine(" x \t\t y(x)");
            Console.WriteLine("-----------------------");

            while (x <= end)
            {
                y = 0.5 * x * x - 7 * x;
                Console.WriteLine(x + "\t\t" + y);

                x += step;
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
            double sum = 0.0;
            int step = 1;
            int factorial = 1;

            for (int i = 1; i <= 6; i++)
            {
                double term = ((i % 2 == 0) ? 1 : -1) * step / factorial;
                sum += term;

                step *= 5;
                factorial *= i + 1;
            }

            Console.WriteLine(sum);

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
            double x = 2.5;
            double sum = 0.0;
            double x_step = 1.0;

            for (int i = 0; i <= 10; i++)
            {
                sum += 1 / x_step
                x_step *= x;
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
