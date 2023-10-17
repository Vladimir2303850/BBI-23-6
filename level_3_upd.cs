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
        double lastNumber = 0;
        int sign = 1;
        for (int i = 1; ; i++)
        {
            double x = a;
            while (x <= b)
            {
                sum += sign * Math.Cos(i * x) / (i * i);
                y = (x * x - Math.PI * Math.PI / 2) / 4;
                Console.WriteLine($"{sum} {y}");
                lastNumber = sign * Math.Cos(i * x) / (i * i);

                x += h;
            }
            if (Math.Abs(lastNumber) < 0.0001)
            {
                break;
            }
            sign *= -1;
        }
    }
}
