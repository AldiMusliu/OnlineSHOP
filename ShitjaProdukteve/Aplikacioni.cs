using ShitjaProdukteve.Llogaria;
using ShitjaProdukteve.MenaxhimiKategorive;
using ShitjaProdukteve.MenaxhimiLlogarive;
using ShitjaProdukteve.Veglat;
using System;
using System.Collections.Generic;

namespace ShitjaProdukteve
{
    class Aplikacioni
    {
        public static User useriAktual;
        private ILlogaria llogarite;
        private MenaxhimiKategoriseIT menaxhimiIT;
        private MenaxhimiLlogarise menaxhimiLlogarive;
        private KategoriaITBlerja blerjaIT;
        public Aplikacioni()
        {
            useriAktual = new User();
            menaxhimiIT = new MenaxhimiKategoriseIT();
            menaxhimiLlogarive = new MenaxhimiLlogarise();
            blerjaIT = new KategoriaITBlerja();
            llogarite = new MockLlogaria();
        }
        public void Miresevini()
        {

            Tekst.Printo(@"
                              __  __ _                          _       _ 
    Punuar nga:              |  \/  (_)_ __ ___  ___  _____   _(_)_ __ (_)
                             | |\/| | | '__/ _ \/ __|/ _ \ \ / / | '_ \| |
    Aldi Musliu              | |  | | | | |  __/\__ \  __/\ V /| | | | | |
    Shaban Kastrati          |_|__|_|_|_|  \___||___/\___| \_/ |_|_| |_|_|
   
                                              
                    ", ConsoleColor.Blue);
        }
        public void Fillimi()
        {
            Tekst.Printo(
                "1 - Mbyll programin\n" +
                "2 - Kyqu\n" +
                "3 - Regjistrohu\n" +
                "4 - Lista e produkteve\n\n",
                ConsoleColor.Cyan);
            Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int zgjedhja);
            switch (zgjedhja)
            {
                case 1:
                    return;
                case 2:
                    Login();
                    break;
                case 3:
                    Register();
                    break;
                case 4:
                    Console.Clear();
                    menaxhimiIT.PrintSmartphone();
                    menaxhimiIT.PrintLaptop();
                    Fillimi();
                    break;
                default:
                    Console.Clear();
                    Miresevini();
                    Fillimi();
                    break;
            }
        }
        void Login()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Username -> ");
            var userName = Console.ReadLine();

            Console.Write("Password -> ");
            var password = Console.ReadLine();
            Console.ResetColor();

            var rezultati = llogarite.Login(userName, password);
            Console.Clear();
            if (rezultati)
            {
                Tekst.Printo($"{useriAktual.UserName} jeni kyqur si {useriAktual.Roli} me sukses", ConsoleColor.Green);

                Console.WriteLine();
                ZgjedhKategorine();
            }
            else
            {
                Tekst.Printo($"Te dhenat gabim\n", ConsoleColor.Red);
                Tekst.Printo(
                    "1 - Kthehu.\n" +
                    "X - Shtyp ndonje buton tjeter per te provuar perseri."
                    , ConsoleColor.Yellow);

                Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
                _ = int.TryParse(Console.ReadLine(), out int zgjedhja);

                Console.Clear();
                if (zgjedhja == 1)
                {
                    Miresevini();
                    Fillimi();
                }
                else
                {
                    Login();
                }
            }

        }
        void Register()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Username -> ");
            var userName = Console.ReadLine();
            Console.Write("Emri -> ");
            var emri = Console.ReadLine();
            Console.Write("Mbiemri -> ");
            var mbiemri = Console.ReadLine();
            Console.Write("Password -> ");
            var password = Console.ReadLine();
            Console.Write("Konfirmo Passwordin -> ");
            var confirmPassword = Console.ReadLine();
            Console.ResetColor();

            var user = new User()
            {
                Emri = emri,
                Mbiemri = mbiemri,
                Password = password,
                UserName = userName,
            };

            var result = llogarite.Regjistro(user);

            if (password != confirmPassword)
                result.ListaErrorave.Add("Passwordi duhet te jete i njejte me confirm password!");

            Console.Clear();

            if (result.Sukses)
            {
                Tekst.Printo($"{useriAktual.UserName} jeni regjistruar dhe kyqur me sukses.\n", ConsoleColor.Green);
                ZgjedhKategorine();
            }
            else
            {
                foreach (var error in result.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }

                Console.WriteLine();
                Tekst.Printo(
                    "1 - Kthehu.\n" +
                    "X - Shtyp ndonje buton tjeter per te provuar perseri."
                    , ConsoleColor.Yellow);

                Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);

                _ = int.TryParse(Console.ReadLine(), out int zgjedhja);

                Console.Clear();
                if (zgjedhja == 1)
                {
                    Miresevini();
                    Fillimi();
                }
                else
                {
                    Register();
                }
            }



        }
        void ZgjedhKategorine()
        {

            Tekst.Printo(
               "█████████████████████████████████\n" +
               "██           Kategorite        ██\n" +
               "█████████████████████████████████\n" +
                "\n1 - Ckyqu\n" +
                "2 - Kategoria IT\n" +
                "3 - Kategoria Software\n" +
                "4 - Ndrysho te dhenat e llogarise\n" +
                "5 - Ndrysho passwordin",
                ConsoleColor.Cyan);
            if (useriAktual.Roli == Rolet.Admin)
            {
                Tekst.Printo("6 - Menaxho userat", ConsoleColor.Cyan);
            }

            Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int zgjedhja);

            switch (zgjedhja)
            {
                case 1:
                    Console.Clear();
                    useriAktual = new User();
                    Miresevini();
                    Fillimi();
                    break;
                case 2:
                    Console.Clear();
                    if (useriAktual.Roli == Rolet.Admin || useriAktual.Roli == Rolet.Menaxher)
                        MenaxhimiITMenu();
                    else
                        MenuBlerja();
                    break;
                case 3:
                    Console.Clear();
                    Tekst.Printo("Kategoria software nuk ekziston per momentin!", ConsoleColor.Red);
                    ZgjedhKategorine();
                    break;
                case 4:
                    Console.Clear();
                    menaxhimiLlogarive.NdryshoUser();
                    ZgjedhKategorine();
                    break;
                case 5:
                    Console.Clear();
                    menaxhimiLlogarive.NdryshoPasswordin();
                    ZgjedhKategorine();
                    break;
                case 6:
                    if (useriAktual.Roli == Rolet.Admin)
                    {
                        Console.Clear();
                        MenaxhoUserat();
                    }
                    else
                    {
                        Tekst.Printo("Nuk keni access!", ConsoleColor.Red);
                        ZgjedhKategorine();
                    }
                    break;
                default:
                    Console.Clear();
                    ZgjedhKategorine();
                    break;
            }

        }
        void MenuBlerja()
        {
            Tekst.Printo(
               "█████████████████████████████████\n" +
               "██          Menu Blerja        ██\n" +
               "█████████████████████████████████\n" +
               "\n1 - Ckyqu\n" +
               "2 - Kthehu.\n" +
               "3 - Blej smartphone.\n" +
               "4 - Blej laptop.\n" +
               "5 - Lista e produkteve te blera.\n" +
               "6 - Lista e smartphoneve.\n" +
               "7 - Lista e laptopeve."
               , ConsoleColor.Cyan);
            Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int zgjedhja);
            switch (zgjedhja)
            {
                case 1:
                    Console.Clear();
                    useriAktual = new User();
                    Miresevini();
                    Fillimi();
                    break;
                case 2:
                    Console.Clear();
                    ZgjedhKategorine();
                    break;
                case 3:
                    Console.Clear();
                    menaxhimiIT.PrintSmartphone();
                    blerjaIT.BlejSmartphone();
                    MenuBlerja();
                    break;
                case 4:
                    Console.Clear();
                    menaxhimiIT.PrintLaptop();
                    blerjaIT.BlejLaptop();
                    MenuBlerja();
                    break;
                case 5:
                    Console.Clear();
                    blerjaIT.PrintBlerjet();
                    MenuBlerja();
                    break;
                case 6:
                    Console.Clear();
                    menaxhimiIT.PrintSmartphone();
                    MenuBlerja();
                    break;
                case 7:
                    Console.Clear();
                    menaxhimiIT.PrintLaptop();
                    MenuBlerja();
                    break;
                default:
                    Console.Clear();
                    MenuBlerja();
                    break;
            }

        }

        void MenaxhoUserat()
        {
            menaxhimiLlogarive.PrintUserat();
            Tekst.Printo(
               "█████████████████████████████████\n" +
               "██     Menaxhimi i userave     ██\n" +
               "█████████████████████████████████\n"+
               "\n1 - Kthehu\n" +
               "2 - Fshij user\n" +
               "3 - Ndrysho rolin",
               ConsoleColor.Cyan);
            Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int zgjedhja);

            switch (zgjedhja)
            {
                case 1:
                    Console.Clear();
                    ZgjedhKategorine();
                    break;
                case 2:
                    Console.Clear();
                    menaxhimiLlogarive.PrintUserat();
                    menaxhimiLlogarive.FshijUser();
                    MenaxhoUserat();
                    break;
                case 3:
                    Console.Clear();
                    menaxhimiLlogarive.PrintUserat();
                    menaxhimiLlogarive.EditoRolin();
                    MenaxhoUserat();
                    break;
                default:
                    Console.Clear();
                    MenaxhoUserat();
                    break;
            }

        }

        void MenaxhimiITMenu()
        {
            Tekst.Printo(
               "█████████████████████████████████\n" +
               "██  Menaxhimi i kategorise IT  ██\n" +
               "█████████████████████████████████\n" +
                "\n1 - Ckyqu\n" +
                "2 - Kthehu.\n" +
                "3 - Menu Blerja.\n" +
                "4 - Shto smartphone te ri.\n" +
                "5 - Fshij smartphone.\n" +
                "6 - Edito smartphone.\n" +
                "7 - Lista e smartphoneve.\n" +
                "8 - Shto laptop te ri.\n" +
                "9 - Fshij laptop.\n" +
                "10 - Edito laptop.\n" +
                "11 - Lista e laptopeve."
                , ConsoleColor.Cyan);
            Tekst.PrintoWrite("-> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int zgjedhja);
            switch (zgjedhja)
            {
                case 1:
                    Console.Clear();
                    useriAktual = new User();
                    Miresevini();
                    Fillimi();
                    break;
                case 2:
                    Console.Clear();
                    ZgjedhKategorine();
                    break;
                case 3:
                    Console.Clear();
                    MenuBlerja();
                    break;
                case 4:
                    Console.Clear();
                    menaxhimiIT.ShtoSmartphone();
                    MenaxhimiITMenu();
                    break;
                case 5:
                    Console.Clear();
                    if (MenaxhimiKategoriseIT.smartphones.Count > 0)
                    {
                        menaxhimiIT.PrintSmartphone();
                        menaxhimiIT.FshijSmartphone();
                    }
                    else
                    {
                        Tekst.Printo("Nuk ekziston asnje produkt!", ConsoleColor.Red);
                    }
                    MenaxhimiITMenu();
                    break;
                case 6:
                    Console.Clear();
                    if (MenaxhimiKategoriseIT.smartphones.Count > 0)
                    {
                        menaxhimiIT.PrintSmartphone();
                        menaxhimiIT.EditoSmartphone();
                    }
                    else
                    {
                        Tekst.Printo("Nuk ekziston asnje produkt!", ConsoleColor.Red);
                    }
                    MenaxhimiITMenu();
                    break;
                case 7:
                    Console.Clear();
                    menaxhimiIT.PrintSmartphone();
                    MenaxhimiITMenu();
                    break;
                case 8:
                    Console.Clear();
                    menaxhimiIT.ShtoLaptop();
                    MenaxhimiITMenu();
                    break;
                case 9:
                    Console.Clear();
                    if (MenaxhimiKategoriseIT.laptops.Count > 0)
                    {
                        menaxhimiIT.PrintLaptop();
                        menaxhimiIT.FshijLaptop();
                    }
                    else
                    {
                        Tekst.Printo("Nuk ekziston asnje produkt!", ConsoleColor.Red);
                    }
                    MenaxhimiITMenu();
                    break;
                case 10:
                    Console.Clear();
                    if (MenaxhimiKategoriseIT.laptops.Count > 0)
                    {
                        menaxhimiIT.PrintLaptop();
                        menaxhimiIT.EditoLaptop();
                    }
                    else
                    {
                        Tekst.Printo("Nuk ekziston asnje produkt!", ConsoleColor.Red);
                    }
                    MenaxhimiITMenu();
                    break;
                case 11:
                    Console.Clear();
                    menaxhimiIT.PrintLaptop();
                    MenaxhimiITMenu();
                    break;
                default:
                    Console.Clear();
                    MenaxhimiITMenu();
                    break;
            }

        }
    }
}
