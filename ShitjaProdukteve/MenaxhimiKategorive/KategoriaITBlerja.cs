using ShitjaProdukteve.Produktet;
using ShitjaProdukteve.Veglat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiKategorive
{
    class KategoriaITBlerja
    {
        public static List<ProduktiBlere> smartphoneTeBlera=new List<ProduktiBlere>();
        public static List<ProduktiBlere> laptopTeBlera = new List<ProduktiBlere>();
        private IKategoriaIT kategoriaIT;

        public KategoriaITBlerja()
        {
            kategoriaIT = new MockKategoriaIT();
        }
        public void BlejSmartphone()
        {
            Tekst.PrintoWrite("Id e smartphonit qe deshironi ta bleni -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            Tekst.PrintoWrite("Sasia -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int sasiaBlere);
            var result = kategoriaIT.BlejSmartphone(id, sasiaBlere);

            Console.Clear();
            if (result.Sukses)
            {
                Tekst.Printo("Blerja u krye me sukses.", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in result.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }
        public void BlejLaptop()
        {
            Tekst.PrintoWrite("Id e laptopit qe deshironi ta bleni -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            Tekst.PrintoWrite("Sasia -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int sasiaBlere);
            var result = kategoriaIT.BlejLaptop(id, sasiaBlere);

            Console.Clear();

            if (result.Sukses)
            {
                Tekst.Printo("Blerja u krye me sukses.", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in result.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }
        public void PrintBlerjet()
        {
            Console.Clear();
            var smphones = smartphoneTeBlera.Where(x => x.IdBleresit == Aplikacioni.useriAktual.Id).ToList();
            var laptops = laptopTeBlera.Where(x => x.IdBleresit == Aplikacioni.useriAktual.Id).ToList();

            Tekst.Printo($"Gjithsej blerje laptop: {laptops.Count}", ConsoleColor.DarkCyan);

            if (laptops.Count > 0)
            {
                //Tabela.Krijo(laptops, 12);
                Tabela.Krijo(laptops, 12,"Id Bleresit", "Bleresi", "Id Produktit" , "Prodhuesi", "Modeli",
                    "Sasia Blere", "Cmimi",  "Cmimi Total", "Data Blerjes");

                var cmimiTotalLaptop = laptops.Sum(l => l.CmimiTotal);
                Tekst.Printo($"\nCmimi total i laptopeve te blere: {cmimiTotalLaptop}\n", ConsoleColor.Green);
            }
            Console.WriteLine();
            Tekst.Printo($"Gjithsej blerje smartphone: {smphones.Count}", ConsoleColor.DarkCyan);
            
            if (smphones.Count > 0)
            {
                //Tabela.Krijo(smphones, 12);

                Tabela.Krijo(smphones, 12, "Id Bleresit", "Bleresi", "Id Produktit", "Prodhuesi", "Modeli",
                    "Sasia Blere", "Cmimi", "Cmimi Total", "Data Blerjes");

                var cmimiTotalSmartphone = smphones.Sum(s => s.CmimiTotal);
                Tekst.Printo($"\nCmimi total i smartphoneve te blere: {cmimiTotalSmartphone}\n", ConsoleColor.Green);
            }
            Console.WriteLine();
        }

    }
}

/*
Console.WriteLine($"{"Bleresi",-15}|{"Id",-4}|{"Prodhuesi",-10}|{"Modeli",-20}|{"Cmimi",-7}|" +
    $"{"Sasia e blerjeve",-16}|{"Cmimi total",-11}|");
foreach (var lt in laptops)
{
    Console.WriteLine($"{lt.Bleresi,-15}|{lt.Id,-4}|{lt.Prodhuesi,-10}|{lt.Modeli,-20}|{lt.Cmimi,-7}|" +
        $"{lt.SasiaBlere,-16}|{lt.CmimiTotal,-11}|");
}*/

/*Console.WriteLine($"{"Bleresi",-15}|{"Id",-4}|{"Prodhuesi",-10}|{"Modeli",-20}|{"Cmimi",-7}|" +
                $"{"Sasia e blerjeve",-16}|{"Cmimi total",-11}|");

foreach (var sm in smphones)
{
    Console.WriteLine($"{sm.Bleresi,-15}|{sm.Id,-4}|{sm.Prodhuesi,-10}|{sm.Modeli,-20}|{sm.Cmimi,-7}|" +
        $"{sm.SasiaBlere,-16}|{sm.CmimiTotal,-11}|");
}*/
