using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace serializacja
{
    public class TxtConverter : IConverter
    {
        public void Serializuj<T>(T g, string n)
        {
            try
            {
                string str = MojConvert.SerializujObjekt(g);
                File.WriteAllText(string.Format(@"{0}\SerializacjaTests\serialetxt\{1}.txt", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), n), str);
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

                string str = File.ReadAllText(string.Format(@"{0}\SerializacjaTests\serialetxt\{1}.txt", Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName), plik));
                obj = (T)MojConvert.DeserializujObjekt(str, typeof(T));
            }
            catch (IOException)
            {
            }
            return obj;
        }
    }
}
