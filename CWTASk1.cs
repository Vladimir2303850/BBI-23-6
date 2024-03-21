using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

struct GuessGame
{
    private int zagad_number = 0;
    private int guessed = 0;
    private int number_of_tries = 0;
    private int unique = Int32.MaxValue;
    public int Zagad_number { get { return zagad_number; } }
    public int Guessed { get { return guessed; } }
    public int Number_of_tries { get { return number_of_tries; } }
    public int Unique { get { return unique; } }
    public GuessGame(int unique1, int guessed1, int number_of_tries1, int zagad_number1)
    {
        unique = unique1;
        guessed = guessed1;
        number_of_tries = number_of_tries1;
        zagad_number = zagad_number1;
    }
    public void Print(int zagad_number, int number_of_tries, int unique)
    {
        Console.WriteLine($"Число: {zagad_number} Количество попыток: {number_of_tries} Рекорд: {unique}");

    }
    public void Try_method(int uniquee, int zagad_number, int guessedd, int number_of_triess)
    {
        Console.WriteLine("Введите число на попытку");
        int number = Convert.ToInt32(Console.ReadLine());
        number_of_tries += 1;
        if (number == zagad_number)
        {
            guessed = 1;
        }
        else
        {
            if (uniquee > Math.Abs(zagad_number - number))
            {
                unique = Math.Abs(zagad_number - number);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число");
        int zagad_number = Convert.ToInt32(Console.ReadLine());
        GuessGame gg = new GuessGame();
        while (gg.Guessed != 1)
        {
            gg.Try_method(gg.Unique, zagad_number, gg.Guessed, gg.Number_of_tries);
        }
        gg.Print(zagad_number, gg.Number_of_tries, nique);
    }
}