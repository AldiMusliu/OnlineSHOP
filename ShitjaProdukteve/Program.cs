using ShitjaProdukteve.Veglat;
using System;

namespace ShitjaProdukteve
{
    class Program
    {
        static void Main(string[] args)
        {
            var aplikacioni = new Aplikacioni();

            aplikacioni.Miresevini();
            aplikacioni.Fillimi();

            Tekst.Printo("\nJu faleminderit!", ConsoleColor.Green);
            Console.WriteLine("Shtyp ndonje buton per ta mbyllur programin.");
            Console.ReadKey();
        }
    }
}
