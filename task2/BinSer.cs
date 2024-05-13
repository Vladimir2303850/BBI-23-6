using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp10.Serializers;

namespace ConsoleApp10.Serializers
{
    internal class BinSer : ISer
    {
        public void Write<T>(T obj, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Serializer.Serialize<T>(fs, obj);
            }
        }
        public T Read<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return Serializer.Deserialize<T>(fs);
            }
        }

    }
}
