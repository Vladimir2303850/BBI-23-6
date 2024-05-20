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
    [Serializable]
    public class Group
    {
        protected int math;
        protected int physics;
        protected int chemistry;
        protected int AddtionalClass_1;
        protected int AddtionalClass_2;
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
        [ProtoMember(7)]
        public int Additional_1
        {
            get { return AddtionalClass_1; }
            set { AddtionalClass_1 = value; }
        } // свойство только для чтения, которое возвращает значение поля
        [ProtoMember(8)]
        public int Additional_2
        {
            get { return AddtionalClass_2; }
            set { AddtionalClass_2 = value; }
        } // свойство только для чтения, которое возвращает значение поля
        public Group() { }
        [JsonConstructor]
        public Group(int math, int physics, int chemistry)
        {
            this.math = math;
            this.physics = physics;
            this.chemistry = chemistry;
        }
        public Group(int math, int physics, int chemistry, int additional_1, int additional_2)
        {
            this.math = math;
            this.physics = physics;
            this.chemistry = chemistry;
            this.AddtionalClass_1 = additional_1;
            this.AddtionalClass_2 = additional_2;
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
    [Serializable]
    public class GroupA : Group
    {
        public GroupA() : base() { }
        [JsonConstructor]
        public GroupA(int math, int physics, int chemistry, int english, int history) : base(math, physics, chemistry, english, history)
        {
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + Additional_1 + Additional_2) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Английский: {Additional_1}, История: {Additional_2}");
        }
    }
    [ProtoContract]
    [Serializable]
    public class GroupB : Group
    {
        public GroupB() : base() { }
        [JsonConstructor]
        public GroupB(int math, int physics, int chemistry, int biology, int geography) : base(math, physics, chemistry, biology, geography)
        {
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + Additional_1 + Additional_2) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Биология: {Additional_1}, География: {Additional_2}");
        }
    }
    [ProtoContract]
    [Serializable]
    public class GroupC : Group
    {
        public GroupC() : base() { }
        [JsonConstructor]
        public GroupC(int math, int physics, int chemistry, int literature, int art) : base(math, physics, chemistry, literature, art)
        {
        }

        public override double CalculateAverage()
        {
            return (math + physics + chemistry + Additional_1 + Additional_2) / 5.0;
        }

        public override void Print()
        {
            Console.WriteLine($"Математика: {math}, Физика: {physics}, Химия: {chemistry}, Литература: {Additional_1}, Рисование: {Additional_2}");
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
