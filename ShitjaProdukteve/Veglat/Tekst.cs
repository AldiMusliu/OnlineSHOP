using System;

namespace ShitjaProdukteve.Veglat
{
    class Tekst
    {
        public static void Printo(string vlera, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(vlera);
            Console.ResetColor();
        }
        public static void PrintoWrite(string vlera, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(vlera);
            Console.ResetColor();
        }
    }
}
