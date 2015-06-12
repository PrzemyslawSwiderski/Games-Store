using System;

namespace kolekcje
{
    public static class Rand
    {
        private static readonly Random Rng = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string RandomString(int size)
        {
            var buffer = new char[size];

            for (var i = 0; i < size; i++)
            {
                buffer[i] = Chars[Rng.Next(Chars.Length)];
            }
            return new string(buffer);
        }

        public static int RandomRok()
        {
            return Rng.Next(1990, 2016);
        }
        public static int RandomCena()
        {
            return Rng.Next(30, 200);
        }
        public static int RandomSztuki()
        {
            return Rng.Next(3, 20);
        }
    }
}