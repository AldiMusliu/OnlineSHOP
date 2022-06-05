using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.Veglat
{
    class Tabela
    {
        /// <summary>
        /// Printon tabelen per cfaredo liste. Mund ti caktohet gjatesia e rreshtave,
        /// ngjyra e kornizave te headerit dhe e te dhenave
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="gjatesia"></param>
        /// <param name="ngjyraHeader"></param>
        /// <param name="ngjyraData"></param>
        public static void Krijo<T>(List<T> lista, int gjatesia, ConsoleColor ngjyraHeader = ConsoleColor.White, ConsoleColor ngjyraData = ConsoleColor.White)
        {
            var propertite = typeof(T).GetProperties().ToList();

            Console.WriteLine();
            Tekst.Printo(Vija('-', gjatesia * propertite.Count + propertite.Count), ngjyraHeader);

            foreach (var properti in propertite)
            {
                var emriPropertise = properti.Name;
                if (emriPropertise.Length >= gjatesia)
                {
                    emriPropertise = emriPropertise.Substring(0, gjatesia - 1) + ".";
                }
                Console.Write($"{emriPropertise.PadRight(gjatesia)}");
                Tekst.PrintoWrite("|", ngjyraHeader);
            }
            Console.WriteLine();
            Tekst.Printo(Vija('-', gjatesia * propertite.Count + propertite.Count), ngjyraHeader);

            foreach (var item in lista)
            {
                foreach (var properti in propertite)
                {
                    var vlera = item.GetType().GetProperty(properti.Name).GetValue(item).ToString();
                    if (vlera.Length >= gjatesia)
                    {
                        vlera = vlera.Substring(0, gjatesia - 1) + ".";
                    }
                    Console.Write($"{vlera.PadRight(gjatesia)}");
                    Tekst.PrintoWrite("|", ngjyraData);
                }
                Console.WriteLine();
                Tekst.Printo(Vija('-', gjatesia * propertite.Count + propertite.Count), ngjyraData);
            }


        }
        /// <summary>
        /// Printon tabelen per cfaredo liste. Mund ti caktohet gjatesia e rreshtave,
        /// dhe emrat e propertive per ti shfaqur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="gjatesia"></param>
        /// <param name="ngjyraHeader"></param>
        /// <param name="ngjyraData"></param>
        public static void Krijo<T>(List<T> lista, int gjatesia, params string[] emratPropertive)
        {
            Console.WriteLine(Vija('-', gjatesia * emratPropertive.Length + emratPropertive.Length));

            foreach (var emer in emratPropertive)
            {
                var emriPropertise = emer;
                if (emriPropertise.Length >= gjatesia)
                {
                    emriPropertise = emriPropertise.Substring(0, gjatesia - 1) + ".";
                }
                Console.Write($"{emriPropertise.PadRight(gjatesia)}|");
            }
            Console.WriteLine();
            Console.WriteLine(Vija('-', gjatesia * emratPropertive.Length + emratPropertive.Length));

            foreach (var item in lista)
            {
                foreach (var emer in emratPropertive)
                {
                    var vlera = item.GetType().GetProperty(emer.Replace(" ","")).GetValue(item).ToString();
                    if (vlera.Length >= gjatesia)
                    {
                        vlera = vlera.Substring(0, gjatesia - 1) + ".";
                    }
                    Console.Write($"{vlera.PadRight(gjatesia)}|");
                }
                Console.WriteLine();
                Console.WriteLine(Vija('-', gjatesia * emratPropertive.Length + emratPropertive.Length));
            }
        }

        static private string Vija(char karakteri, int gjatesia)
        {
            string vija = "";
            for (int i = 0; i < gjatesia; i++)
            {
                vija += karakteri;
            }
            return vija;
        }

    }
}
