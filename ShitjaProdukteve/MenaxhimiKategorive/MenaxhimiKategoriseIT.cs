using ShitjaProdukteve.Produktet;
using System.Collections.Generic;
using System;
using System.Linq;
using ShitjaProdukteve.Veglat;

namespace ShitjaProdukteve.MenaxhimiKategorive
{
    class MenaxhimiKategoriseIT
    {

        private int totalColors = Enum.GetNames(typeof(ConsoleColor)).Length;
        private ConsoleColor ngjyra;
        private Random rnd = new Random();

        public static List<Smartphone> smartphones = new List<Smartphone>() {
            new Smartphone
            {
                Id=1,
                Prodhuesi="Apple",
                Modeli="Iphone 13ProMax",
                Cmimi=999.90m,
                Sasia=10,
                Procesori="A15 Bionic",
                RAM = 8,
                Ngjyra="Zeze",
                KamPerparmeMpx = "12",
                KamPrapmeMpx = "12+12+12",
                Storage="1TB",
            },
            new Smartphone
            {
                Id=2,
                Prodhuesi="Samsung",
                Modeli="Galaxy S21Ultra",
                Cmimi=979.90m,
                Sasia=20,
                Procesori="Exynos 2100",
                RAM = 16,
                Ngjyra="Silver",
                KamPerparmeMpx = "40",
                KamPrapmeMpx = "108+10+10+12",
                Storage="512GB",
            }
        };
        public static List<Laptop> laptops = new List<Laptop>() {
            new Laptop {
                Id=1,
                Prodhuesi="HP",
                Modeli="Omen 16-b0014nr",
                Cmimi=1489.99m,
                Sasia=15,
                Procesori="i7 Gen11",
                RAM = 16,
                Ngjyra="Zeze",
                KartaGrafike="RTX 3060",
                LlojiDiskut="SSD",
                HDMI=true,
                LlojiMemories="DDR4",
                Storage="512GB"

            }
        };

        IKategoriaIT kategoriaIT;

        public MenaxhimiKategoriseIT()
        {
            kategoriaIT = new MockKategoriaIT();
        }
        public void PrintSmartphone()
        {
            Tekst.Printo($"Gjithsej produkte smartphone: {smartphones.Count}", ConsoleColor.DarkCyan);

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine($"{"Id",-4}|{"Prodhuesi",-10}|{"Modeli",-20}|{"Cmimi",-8}|" +
                $"{"Sasia",-5}|{"Ngjyra",-10}|{"Stok",-4}|{"Procesori",-17}|{"RAM",-4}|{"Storage",-7}|{"Kamerat (Mpx)",-15}|");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            foreach (var sm in smartphones)
            {
                ngjyra = (ConsoleColor)rnd.Next(1, totalColors);

                Tekst.Printo($"{sm.Id,-4}|{sm.Prodhuesi,-10}|{sm.Modeli,-20}|{sm.Cmimi,-8}|" +
                    $"{sm.Sasia,-5}|{sm.Ngjyra,-10}|{(sm.NeStok ? "Po" : "Jo"),-4}|{sm.Procesori,-17}|" +
                    $"{sm.RAM + "GB",-4}|{sm.Storage,-7}|{sm.KamPerparmeMpx + "/" + sm.KamPrapmeMpx,-15}|", ngjyra);
            }
            Console.WriteLine();
        }
        public void PrintLaptop()
        {
            Tekst.Printo($"Gjithsej produkte Laptop: {laptops.Count}", ConsoleColor.DarkCyan);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine($"{"Id",-4}|{"Prodhuesi",-10}|{"Modeli",-18}|{"Cmimi",-8}|" +
                $"{"Sasia",-5}|{"Ngjyra",-10}|{"Stok",-4}|{"RAM",-4}|{"Storage",-7}|" +
                $"{"HDMI",-4}|{"Grafika",-8}|{"Procesori",-10}|{"Memoria",-7}|{"Disku",-5}|");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            foreach (var lt in laptops)
            {
                ngjyra = (ConsoleColor)rnd.Next(1, totalColors);
                Tekst.Printo($"{lt.Id,-4}|{lt.Prodhuesi,-10}|{lt.Modeli,-18}|{lt.Cmimi,-8}|" +
                    $"{lt.Sasia,-5}|{lt.Ngjyra,-10}|{(lt.NeStok ? "Po" : "Jo"),-4}|" +
                    $"{lt.RAM + "GB",-4}|{lt.Storage,-7}|{(lt.HDMI ? "Po" : "Jo"),-4}|" +
                    $"{lt.KartaGrafike,-8}|{lt.Procesori,-10}|{lt.LlojiMemories,-7}|{lt.LlojiDiskut,-5}|", ngjyra);
            }
            Console.WriteLine();
        }

        public void ShtoSmartphone()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Prodhuesi: ");
            var prodhuesi = Console.ReadLine();
            Console.Write("Modeli: ");
            var modeli = Console.ReadLine();
            Console.Write("Cmimi: ");
            _ = decimal.TryParse(Console.ReadLine(), out decimal cmimi);
            Console.Write("Sasia: ");
            _ = int.TryParse(Console.ReadLine(), out int sasia);
            Console.Write("Ngjyra: ");
            var ngjyra = Console.ReadLine();
            Console.Write("Procesori: ");
            var procesori = Console.ReadLine();
            Console.Write("Kamera e perparme: ");
            var kameraPerparme = Console.ReadLine();
            Console.Write("Kamera e prapme: ");
            var kameraPrapme = Console.ReadLine();
            Console.Write("RAM: ");
            _ = int.TryParse(Console.ReadLine(), out int ram);
            Console.Write("Storage: ");
            var memoriaBrendshme = Console.ReadLine();
            Console.ResetColor();
            var smartphone = new Smartphone()
            {
                Prodhuesi = prodhuesi,
                Modeli = modeli,
                Sasia = sasia,
                KamPerparmeMpx = kameraPerparme,
                KamPrapmeMpx = kameraPrapme,
                Procesori = procesori,
                Storage = memoriaBrendshme,
                RAM = ram,
                Cmimi = cmimi,
                Ngjyra = ngjyra
            };
            kategoriaIT.ShtoSmartphone(smartphone);

            Console.Clear();
            Tekst.Printo("Smartphoni u shtua me sukses!", ConsoleColor.Green);
        }
        public void ShtoLaptop()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Prodhuesi: ");
            var prodhuesi = Console.ReadLine();
            Console.Write("Modeli: ");
            var modeli = Console.ReadLine();
            Console.Write("Cmimi: ");
            _ = decimal.TryParse(Console.ReadLine(), out decimal cmimi);
            Console.Write("Sasia: ");
            _ = int.TryParse(Console.ReadLine(), out int sasia);
            Console.Write("Ngjyra: ");
            var ngjyra = Console.ReadLine();
            Console.Write("Procesori: ");
            var procesori = Console.ReadLine();
            Console.Write("Karta Grafike: ");
            var kartaGrafike = Console.ReadLine();
            Console.Write("Lloji i diskut: ");
            var llojiDiskut = Console.ReadLine();
            Console.Write("Lloji i memories: ");
            var llojiMemories = Console.ReadLine();
            Console.Write("HDMI (Po/Jo): ");
            bool hdmi = false;
            if (Console.ReadLine().ToLower() == "po")
                hdmi = true;
            Console.Write("RAM: ");
            _ = int.TryParse(Console.ReadLine(), out int ram);
            Console.Write("Storage: ");
            var memoriaBrendshme = Console.ReadLine();
            Console.ResetColor();
            var laptop = new Laptop()
            {
                Prodhuesi = prodhuesi,
                Modeli = modeli,
                Sasia = sasia,
                Procesori = procesori,
                Storage = memoriaBrendshme,
                RAM = ram,
                Cmimi = cmimi,
                Ngjyra = ngjyra,
                HDMI = hdmi,
                KartaGrafike = kartaGrafike,
                LlojiDiskut = llojiDiskut,
                LlojiMemories = llojiMemories
            };
            kategoriaIT.ShtoLaptop(laptop);
            Console.Clear();
            Tekst.Printo("Laptopi u shtua me sukses!", ConsoleColor.Green);
        }
        public void EditoSmartphone()
        {
            Tekst.PrintoWrite("Id e smartphonit qe deshironi ta editoni -> ", ConsoleColor.Yellow);

            _ = int.TryParse(Console.ReadLine(), out int id);
            var smartphone = smartphones.SingleOrDefault(sm => sm.Id == id);

            if (smartphone != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Prodhuesi [{smartphone.Prodhuesi}] -> ");
                var prodhuesi = Console.ReadLine();

                Console.Write($"Modeli [{smartphone.Modeli}] -> ");
                var modeli = Console.ReadLine();

                Console.Write($"Cmimi [{smartphone.Cmimi}] -> ");
                _ = decimal.TryParse(Console.ReadLine(), out decimal cmimi);

                Console.Write($"Sasia [{smartphone.Sasia}] -> ");
                _ = int.TryParse(Console.ReadLine(), out int sasia);

                Console.Write($"Ngjyra [{smartphone.Ngjyra}] -> ");
                var ngjyra = Console.ReadLine();

                Console.Write($"Procesori [{smartphone.Procesori}] -> ");
                var procesori = Console.ReadLine();

                Console.Write($"Kam. perparme [{smartphone.KamPerparmeMpx}] -> ");
                var kameraPerparme = Console.ReadLine();

                Console.Write($"Kam. prapme [{smartphone.KamPrapmeMpx}] -> ");
                var kameraPrapme = Console.ReadLine();

                Console.Write($"RAM [{smartphone.RAM}] -> ");
                _ = int.TryParse(Console.ReadLine(), out int ram);

                Console.Write($"Storage [{ smartphone.Storage}] -> ");
                var memoriaBrendshme = Console.ReadLine();

                Console.ResetColor();

                var newSmartphone = new Smartphone()
                {
                    Id = id,
                    Modeli = modeli,
                    Sasia = sasia,
                    Storage = memoriaBrendshme,
                    Cmimi = cmimi,
                    Ngjyra = ngjyra,
                    RAM = ram,
                    KamPerparmeMpx = kameraPerparme,
                    KamPrapmeMpx = kameraPrapme,
                    Procesori = procesori,
                    Prodhuesi = prodhuesi
                };
                kategoriaIT.EditoSmartphone(newSmartphone);
                Console.Clear();
                Tekst.Printo("Ky produkt u perditesua me sukses!", ConsoleColor.Green);
            }
            else
            {
                Console.Clear();
                Tekst.Printo("Ky smartphone nuk ekziston!", ConsoleColor.Red);
            }
        }
        public void EditoLaptop()
        {
            Tekst.PrintoWrite("Id e laptopit qe deshironi ta editoni -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            var laptop = laptops.SingleOrDefault(lt => lt.Id == id);

            if (laptop != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Prodhuesi [{laptop.Prodhuesi}] -> ");
                var prodhuesi = Console.ReadLine();

                Console.Write($"Modeli [{laptop.Modeli}] -> ");
                var modeli = Console.ReadLine();

                Console.Write($"Cmimi [{laptop.Cmimi}] -> ");
                _ = decimal.TryParse(Console.ReadLine(), out decimal cmimi);

                Console.Write($"Sasia [{laptop.Sasia}] -> ");
                _ = int.TryParse(Console.ReadLine(), out int sasia);

                Console.Write($"Ngjyra [{laptop.Ngjyra}] -> ");
                var ngjyra = Console.ReadLine();

                Console.Write($"Procesori [{laptop.Procesori}] -> ");
                var procesori = Console.ReadLine();

                Console.Write($"RAM [{laptop.RAM}] -> ");
                _ = int.TryParse(Console.ReadLine(), out int ram);

                Console.Write($"Storage [{ laptop.Storage}] -> ");
                var memoriaBrendshme = Console.ReadLine();

                Console.Write($"Karta grafike [{ laptop.KartaGrafike}] -> ");
                var kartaGrafike = Console.ReadLine();

                Console.Write($"Lloji i diskut [{ laptop.LlojiDiskut}] -> ");
                var llojiDiskut = Console.ReadLine();

                Console.Write($"Storage [{ laptop.Storage}] -> ");
                var llojiMemories = Console.ReadLine();

                Console.Write($"(Po/Jo) HDMI [{(laptop.HDMI ? "Po" : "Jo")}] -> ");
                bool hdmi = false;
                if (Console.ReadLine().ToLower() == "po")
                    hdmi = true;

                Console.ResetColor();

                var newLaptop = new Laptop()
                {
                    Id = id,
                    Sasia = sasia,
                    Storage = memoriaBrendshme,
                    Cmimi = cmimi,
                    KartaGrafike = kartaGrafike,
                    HDMI = hdmi,
                    LlojiMemories = llojiMemories,
                    LlojiDiskut = llojiDiskut,
                    Modeli = modeli,
                    Ngjyra = ngjyra,
                    Procesori = procesori,
                    Prodhuesi = prodhuesi,
                    RAM = ram
                };

                kategoriaIT.EditoLaptop(newLaptop);
                Console.Clear();
                Tekst.Printo("Ky produkt u perditesua me sukses!", ConsoleColor.Green);
            }
            else
            {
                Console.Clear();
                Tekst.Printo("Ky laptop nuk ekziston!", ConsoleColor.Red);
            }
        }

        public void FshijSmartphone()
        {
            Tekst.PrintoWrite("Id e smartphonit qe deshironi ta fshini -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            var result = kategoriaIT.FshijSmartphone(id);

            Console.Clear();
            if (result)
            {
                Tekst.Printo("Fshirja u krye me sukses.", ConsoleColor.Green);
            }
            else
            {
                Tekst.Printo("Ky produkt nuk ekziston ose problem gjate fshirjes.", ConsoleColor.Red);
            }

        }
        public void FshijLaptop()
        {
            Tekst.PrintoWrite("Id e laptopit qe deshironi ta fshini -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            var result = kategoriaIT.FshijLaptop(id);

            Console.Clear();
            if (result)
            {
                Tekst.Printo("Fshirja u krye me sukses.", ConsoleColor.Green);
            }
            else
            {
                Tekst.Printo("Ky produkt nuk ekziston ose problem gjate fshirjes.", ConsoleColor.Red);
            }

        }


    }
}
