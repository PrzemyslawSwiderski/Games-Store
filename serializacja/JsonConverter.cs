using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace serializacja
{
    public class JsonConverter : IConverter
    {
        public void Serializuj<T>(T g, string n)
        {
            try
            {
                string json = JsonConvert.SerializeObject(g);
                File.WriteAllText(string.Format(@"{0}\SerializacjaTests\serialejson\{1}.txt", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), n), json);
            }
            catch (IOException)
            {
            }
        }
        public T DeSerializuj<T>(string plik)
        {
            T obj = default(T);
            using (StreamReader file = File.OpenText(string.Format(@"{0}\SerializacjaTests\serialejson\{1}.txt", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), plik)))
            {
                JsonSerializer serializer = new JsonSerializer();
                obj = (T)serializer.Deserialize(file, typeof(T));
            }
            return obj;
        }
    }
}
