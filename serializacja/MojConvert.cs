using kolekcje;
using System;
using System.Collections.Generic;
using System.Linq;

namespace serializacja
{
    public static class MojConvert
    {
        public static string SerializujObjekt(object obj)
        {
            string str = "";
            if (obj.GetType().Name == "Gra")
            {
                Gra g = new Gra();
                g = (Gra)obj;
                str += "Gra:\n";
                str += g._tytul;
                str += "\n";
                str += g._wydawca;
                str += "\n";
                str += g._rokWydania;
                str += "\n";
                str += g._cena;
                str += "\n";
                str += g._liczbaSztuk;
                str += "\n";
            }
            if (obj.GetType().Name == "Gracz")
            {
                Gracz g = new Gracz();
                g = (Gracz)obj;
                str += "Gracz:\n";
                str += g._imie;
                str += "\n";
                str += g._nazwisko;
                str += "\n";
            }
            if (obj.GetType().Name == "Zakup")
            {
                Zakup g = new Zakup();
                g = (Zakup)obj;
                str += SerializujObjekt(g._gracz);
                str += SerializujObjekt(g._gra);
            }

            if (obj.GetType().Name == "Kolekcja")
            {
                Kolekcja kolekcja = new Kolekcja();
                kolekcja = (Kolekcja)obj;
                str += "$GRACZE:\n";
                str += SerializujObjekt(kolekcja._gracze);
                str += "$GRY:\n";
                str += SerializujObjekt(kolekcja._grylist);
                str += "$ZAKUPY:\n";
                str += SerializujObjekt(kolekcja._zakupy.ToList());
            }
            if (obj.GetType().Name == "List`1")
            {
                if (obj.GetType().GetGenericArguments()[0].Name == "Gracz")
                {
                    List<Gracz> gracze = new List<Gracz>();
                    gracze = (List<Gracz>)obj;
                    foreach (var gracz in gracze)
                    {
                        str += SerializujObjekt(gracz);
                    }
                }
                if (obj.GetType().GetGenericArguments()[0].Name == "Gra")
                {
                    List<Gra> gry = new List<Gra>();
                    gry = (List<Gra>)obj;
                    foreach (var gra in gry)
                    {
                        str += SerializujObjekt(gra);
                    }
                }

                if (obj.GetType().GetGenericArguments()[0].Name == "Zakup")
                {
                    List<Zakup> zakupy = new List<Zakup>();
                    zakupy = (List<Zakup>)obj;
                    foreach (var z in zakupy)
                    {
                        str += SerializujObjekt(z);
                    }
                }
            }
            return str;
        }

        public static object DeserializujObjekt(string txt, Type t)
        {
            object o = null;
            if (t == typeof(Gra))
            {
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                Gra g = new Gra(lines[1], lines[2], Convert.ToInt32(lines[3]), Convert.ToInt32(lines[4]), Convert.ToInt32(lines[5]));
                return g;
            }
            if (t == typeof(Gracz))
            {
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                Gracz g = new Gracz(lines[1], lines[2]);
                return g;
            }
            if (t == typeof(Zakup))
            {
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                Zakup z = new Zakup(new Gracz(lines[1], lines[2]), new Gra(lines[1 + 3], lines[2 + 3], Convert.ToInt32(lines[3 + 3]), Convert.ToInt32(lines[4 + 3]), Convert.ToInt32(lines[5 + 3])));
                return z;
            }
            if (t == typeof(Kolekcja))
            {
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);

                string str1 = String.Join("\n", lines.SkipWhile(l => l.CompareTo("$GRACZE:") != 0).Skip(1).TakeWhile(l => l.CompareTo("$GRY:") != 0));

                string str2 = String.Join("\n", lines.SkipWhile(l => l.CompareTo("$GRY:") != 0).Skip(1).TakeWhile(l => l.CompareTo("$ZAKUPY:") != 0));

                string str3 = String.Join("\n", lines.SkipWhile(l => l.CompareTo("$ZAKUPY:") != 0).Skip(1));

                var gracze = (List<Gracz>)DeserializujObjekt(str1, typeof(List<Gracz>));

                var gry = (List<Gra>)DeserializujObjekt(str2, typeof(List<Gra>));

                var zakupy = (List<Zakup>)DeserializujObjekt(str3, typeof(List<Zakup>));

                Kolekcja k = new Kolekcja(gracze,gry,zakupy);

                return k;
            }
            if (t == typeof(List<Gracz>))
            {
                List<Gracz> gracze = new List<Gracz>();
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                for (int i = 0; i < lines.Length / 3; i++)
                    gracze.Add(new Gracz(lines[1 + 3 * i], lines[2 + 3 * i]));

                return gracze;
            }
            if (t == typeof(List<Gra>))
            {
                List<Gra> gry = new List<Gra>();
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                for (int i = 0; i < lines.Length / 6; i++)
                    gry.Add(new Gra(lines[1 + 6 * i], lines[2 + 6 * i], Convert.ToInt32(lines[3 + 6 * i]), Convert.ToInt32(lines[4 + 6 * i]), Convert.ToInt32(lines[5 + 6 * i])));

                return gry;
            }
            if (t == typeof(List<Zakup>))
            {
                List<Zakup> zakupy = new List<Zakup>();
                string[] stringSeparators = new string[] { "\n" };
                string[] lines = txt.Split(stringSeparators, StringSplitOptions.None);
                for (int i = 0; i < lines.Length / 9; i++)
                    zakupy.Add(new Zakup(new Gracz(lines[1 + 9 * i], lines[2 + 9 * i]), new Gra(lines[4 + 9 * i], lines[5 + 9 * i], Convert.ToInt32(lines[6 + 9 * i]), Convert.ToInt32(lines[7 + 9 * i]), Convert.ToInt32(lines[8 + 9 * i]))));

                return zakupy;
            }
            return o;
        }
    }
}
