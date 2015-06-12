using kolekcje;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace serializacja
{
    public class XmlConverter : IConverter
    {
        public void Serializuj<T>(T obj, string nazwa)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter textWriter = new StreamWriter(string.Format(@"{0}\SerializacjaTests\serialexml\{1}.xml", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), nazwa));

                serializer.Serialize(textWriter, obj);
                textWriter.Close();
            }
            catch (Exception)
            {
            }
        }
        public T DeSerializuj<T>(string nazwa)
        {
            T obj = default(T);
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StreamReader(string.Format(@"{0}\SerializacjaTests\serialexml\{1}.xml", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), nazwa));

                obj = (T)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku.");
            }

            return obj;
        }

    }
}
