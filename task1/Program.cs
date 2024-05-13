using ConsoleApp9.Serializers;
using ProtoBuf;
using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace ConsoleApp9
{
    [Serializable]
    [ProtoContract]
    [ProtoInclude(1, typeof(ComputerScience))]
    [ProtoInclude(2, typeof(Mathematics))]
    public abstract class Marks
    {
        protected string surname;
        protected int mark;
        protected int skips;
        [ProtoMember(3)]
        public string Name
        {
            get { return surname; }
            set { surname = value ?? string.Empty; }
        } // свойство только для чтения, которое возвращает значение поля
        [ProtoMember(4)]
        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        } // свойство только для чтения, которое возвращает значение поля
        [ProtoMember(5)]
        public int Skips
        {
            get { return skips; }
            set { skips = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public abstract void Print();
        public Marks() { }
        public Marks(string surname, int mark, int skips)
        {
            this.surname = surname;
            this.mark = mark;
            this.skips = skips;
        }
    }
    [ProtoContract]
    public class ComputerScience : Marks
    {
        public ComputerScience(string surname, int mark, int skips) : base(surname, mark, skips) { }
        public ComputerScience() : base() { }
        public override void Print() //переопределяю
        {
            Console.WriteLine($"Информатика: {surname} - Оценка: {mark}, Пропуски: {skips}");
        }
    }
    [ProtoContract]
    public class Mathematics : Marks
    {
        public Mathematics() : base() { }
        public Mathematics(string surname, int mark, int skips) : base(surname, mark, skips) { }
        public override void Print() //переопределяю
        {
            Console.WriteLine($"Математика: {surname} - Оценка: {mark}, Пропуски: {skips}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ComputerScience[] computerScienceStudents = new ComputerScience[5]; // создаем массив непроинициализированных переменных типа computerScienceStudents
            computerScienceStudents[0] = new ComputerScience("Alex", 5, 5);
            computerScienceStudents[1] = new ComputerScience("Kate", 3, 6);
            computerScienceStudents[2] = new ComputerScience("Maria", 4, 0);
            computerScienceStudents[3] = new ComputerScience("Andrey", 2, 10);
            computerScienceStudents[4] = new ComputerScience("Katerina", 5, 3);

            Mathematics[] mathematicsStudent = new Mathematics[2]; // создаем массив непроинициализированных переменных типа mathematicsStudent
            mathematicsStudent[0] = new Mathematics("Alexandex", 3, 5);
            mathematicsStudent[1] = new Mathematics("Kim", 2, 6);

            Sort(computerScienceStudents); // сортируем одних
            Sort(mathematicsStudent); // сортируем других

            Console.WriteLine("Sorted:");

            foreach (ComputerScience informatic in computerScienceStudents) // выводим одних
            {
                informatic.Print();
            }
            foreach (Mathematics mathematic in mathematicsStudent) // выводим других
            {
                mathematic.Print();
            }

            Console.WriteLine("Merged:");

            // создаем общий массив для всех наследников используя родительский тип
            Marks[] teachers = new Marks[computerScienceStudents.Length + mathematicsStudent.Length];

            // соединяем
            for (int i = 0; i < computerScienceStudents.Length; i++)
            {
                teachers[i] = computerScienceStudents[i];
            }
            for (int i = 0; i < mathematicsStudent.Length; i++)
            {
                teachers[i + computerScienceStudents.Length] = mathematicsStudent[i];
            }

            Sort(teachers); // если соединять упорядоченно, то и сортировать не придется

            foreach (Marks teacher in teachers) // выводим всех
            {
                teacher.Print();
            }

            ISer[] serializers = new ISer[3]
            {
                new JsonSer(),
                new XMLSer(),
                new BinSer()
            };

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folder = "Marks";
            path = Path.Combine(path, folder);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string[] files = new string[3]
            {
                "marks.json",
                "marks.xml",
                "marks.bin"
            };

            for (int i = 0; i < serializers.Length; i++)
            {
                serializers[i].Write(computerScienceStudents, Path.Combine(path, files[i]));
            }

            for (int i = 0; i < serializers.Length; i++)
            {
                computerScienceStudents = serializers[i].Read<ComputerScience[]>(Path.Combine(path, files[i]));
                foreach (ComputerScience informatic in computerScienceStudents) 
                {
                    informatic.Print();
                }
            }

            Console.ReadKey();
        }
        public static void Sort(Marks[] students) 
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i; j < students.Length; j++)
                {
                    if (students[i].Name.CompareTo(students[j].Name) > 0)
                    {
                        Marks temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
    }
}
