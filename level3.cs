using System;

class Program
{
    static void Main()
    {
        double a = Math.PI / 5;
        double b = Math.PI;
        double h = Math.PI / 25;
        double sum = 0;
        double y = 0;
        double last_number = 0;
        for (int i = 1; i < 10000; i++)
        {
            for (double x = a; x <= b; x += h)
            {
                sum += Math.Pow(-1, i) * Math.Cos(i * x) / Math.Pow(i, 2);
                y = (Math.Pow(x, 2) - Math.Pow(Math.PI, 2) / 2) / 4;
                Console.WriteLine($"{sum} {y}");
                last_number = Math.Pow(-1, i) * Math.Cos(i * x) / Math.Pow(i, 2);

            }
            if (Math.Abs(last_number) < 0.0001)
            {
                break;
            }
        }
    }
}