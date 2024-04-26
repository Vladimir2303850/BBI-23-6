using System;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    protected string text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    
    private string _text;
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        _text = text;
    }
    public string ParseText(string text)
    {
        var letters = new Dictionary<string, int>();
        for (int i = 0; i < _text.Length - 1; i++)
        {
            var letter = _text.Substring(i, 1);
            if (!letters.ContainsKey(letter))
            {
                letters[letter] = 0;
            }
            letters[letter]++;
        }
        var maxKey = letters.Keys.Max();
        return maxKey;
    }
}

class Task2 : Task
{
    private string _text;
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        _text = text;
    }

    public bool CheckBrackets(string text)
    {
        int parenthesesCount = 0; // ()
        int squareBracketsCount = 0; // []
        int curlyBracesCount = 0; // {}

        foreach (char c in text)
        {
            if (c == '(')
                parenthesesCount++;
            else if (c == ')')
                parenthesesCount--;
            else if (c == '[')
                squareBracketsCount++;
            else if (c == ']')
                squareBracketsCount--;
            else if (c == '{')
                curlyBracesCount++;
            else if (c == '}')
                curlyBracesCount--;

            if (parenthesesCount < 0 || squareBracketsCount < 0 || curlyBracesCount < 0)
                return false;
        }

        return parenthesesCount == 0 && squareBracketsCount == 0 && curlyBracesCount == 0;
    }
}

class JsonIO
{
    public static void Write<T>(T obj, string Path)
    {
        using (FileStream filestream1 = new FileStream(Path, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(filestream1, obj);
        }
    }
    public static T Read<T>(string Path)
    {
        using (FileStream filestream2 = new FileStream(Path, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(filestream2); 
        }
        return default(T);
    }
}

class Program
{
    static void Main()
    {
        string text = "[]ddddddffffffffff"; 
        Task1 task1 = new Task1(text);
        Console.WriteLine(task1.ParseText(text));

        Task2 task2 = new Task2(text);
        
        Console.WriteLine(task2.CheckBrackets(text));

        string path = @"C:\Users\m2303850\Desktop"; 
        string folderName = "Solution"; 
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string file_1 = "task_1.json";
        string file_2 = "task_2.json";

        file_1 = Path.Combine(path, file_1);
        file_2 = Path.Combine(path, file_2);

        if (!File.Exists(file_1))
        {
            JsonIO.Write<Task1>((Task1)task1, file_1);
        }
        else
        {
            var task_1 = JsonIO.Read<Task1>(file_1);
        }
        if (!File.Exists(file_2))
        {
            JsonIO.Write<Task2>((Task2)task2, file_2);
        }
        else
        {
            var task_2 = JsonIO.Read<Task2>(file_2);
        }

    }
}



