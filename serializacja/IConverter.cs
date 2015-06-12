using kolekcje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serializacja
{
    public interface IConverter
    {
        void Serializuj<T>(T g,string n);
        T DeSerializuj<T>(string plik);
    }
}
