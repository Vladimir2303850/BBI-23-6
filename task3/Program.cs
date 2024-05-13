using ConsoleApp11.Serializers;
using ProtoBuf;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp11
{
    [XmlInclude(typeof(Group)), XmlInclude(typeof(GroupA))]
    [XmlInclude(typeof(Group)), XmlInclude(typeof(GroupB))]
    [XmlInclude(typeof(Group)), XmlInclude(typeof(GroupC))]
    [ProtoContract]
    [ProtoInclude(1, typeof(GroupA))]
    [ProtoInclude(2, typeof(GroupB))]
    [ProtoInclude(3, typeof(GroupC))]
    public class Group
    {
        protected int math;
        protected int physics;
        protected int chemistry;
        [ProtoMember(4)]
        public int Math
        {
            get { return math; }
            set { math = value; }
        } // свойство только для чтения, которое возвращает значение поля
        [ProtoMember(5)]
        public int Physics
        {
            get { return physics; }
            set { physics = value; }
        } // свойство только для чтения, которое возвращает значение поля
        [ProtoMember(6)]
        public int Chemistry
        {
            get { return chemistry; }
            set { chemistry = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public Group() { }
        public Group(int math, int physics, int chemistry)
        {
            this.math = math;
            this.physics = physics;
            this.chemistry = chemistry;
        }

        public virtual double CalculateAverage()
        {
            return (math + physics + chemistry) / 3.0;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}");
        }
    }
    [ProtoContract]
    public class GroupA : Group
    {
        protected int english;
        [ProtoMember(7)]
        public int English
        {
            get { return english; }
            set { english = value; }
        } // свойство только для чтения, которое возвращает значение поля
        protected int history;
        [ProtoMember(8)]
        public int History
        {
            get { return history; }
            set { history = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public GroupA() : base() { }
        public GroupA(int math, int physics, int chemistry, int english, int history) : base(math, physics, chemistry)
        {
            this.english = english;
            this.history = history;
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + english + history) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Английский: {english}, История: {history}");
        }
    }
    [ProtoContract]
    public class GroupB : Group
    {
        protected int biology;
        [ProtoMember(9)]
        public int Biology
        {
            get { return biology; }
            set { biology = value; }
        } // свойство только для чтения, которое возвращает значение поля
        protected int geography;
        [ProtoMember(10)]
        public int Geography
        {
            get { return geography; }
            set { geography = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public GroupB() : base() { }
        public GroupB(int math, int physics, int chemistry, int biology, int geography) : base(math, physics, chemistry)
        {
            this.biology = biology;
            this.geography = geography;
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + biology + geography) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Биология: {biology}, География: {geography}");
        }
    }
    [ProtoContract]
    public class GroupC : Group
    {
        protected int literature;
        [ProtoMember(11)]
        public int Literature
        {
            get { return literature; }
            set { literature = value; }
        } // свойство только для чтения, которое возвращает значение поля
        protected int art;
        [ProtoMember(12)]
        public int Art
        {
            get { return art; }
            set { art = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public GroupC() : base() { }
        public GroupC(int math, int physics, int chemistry, int literature, int art) : base(math, physics, chemistry)
        {
            this.literature = literature;
            this.art = art;
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + literature + art) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Литература: {literature}, Рисование: {art}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            GroupA groupA = new GroupA(80, 75, 85, 90, 70);
            GroupB groupB = new GroupB(85, 78, 88, 92, 82);
            GroupC groupC = new GroupC(78, 72, 80, 85, 88);
            Group[] groups = new Group[] { groupA, groupB, groupC };
            Console.WriteLine("Студенты всех групп:");

            foreach (Group group in groups)
            {
                group.Print();
            }

            ISer[] serializers = new ISer[3]
            {
                new JsonSer(),
                new XMLSer(),
                new BinSer()
            };

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folder = "Groups";
            path = Path.Combine(path, folder);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string[] files = new string[3]
            {
                "group.json",
                "group.xml",
                "group.bin"
            };

            for (int i = 0; i < serializers.Length; i++)
            {
                serializers[i].Write(groups, Path.Combine(path, files[i]));
            }

            for (int i = 0; i < serializers.Length; i++)
            {
                groups = serializers[i].Read<Group[]>(Path.Combine(path, files[i]));
                foreach (Group group in groups)
                {
                    group.Print();
                }
            }
            Console.ReadKey();
        }
    }
}
