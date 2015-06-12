using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serializacja
{
    public class BinConverter : IConverter
    {

        public void Serializuj<T>(T g, string n)
        {
            try
            {
                using (Stream stream = File.Open(string.Format(@"{0}\SerializacjaTests\serialebin\{1}.bin", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), n), FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, g);
                }
            }
            catch (IOException)
            {
            }
        }

        public T DeSerializuj<T>(string plik)
        {

            T obj = default(T);
            try
            {
                using (Stream stream = File.Open(string.Format(@"{0}\SerializacjaTests\serialebin\{1}.bin", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), plik), FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    obj = (T)bin.Deserialize(stream);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku.");
            }
            return obj;
        }
    }
}
