using ShitjaProdukteve.Llogaria;
using ShitjaProdukteve.Veglat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiLlogarive
{
    public class MenaxhimiLlogarise
    {
        ILlogaria llogarite = new MockLlogaria();

        public static List<User> listaUsereve = new List<User>() {
            new User { Id = 1, Emri = "Aldi", Mbiemri = "Musliu", UserName = "aldi", Password = "aldimusliu", Roli = Rolet.Admin },
            new User { Id = 2, Emri = "Shaban", Mbiemri = "Kastrati",  UserName = "shaban", Password = "bannkastrati", Roli = Rolet.Menaxher },
            new User { Id = 3, Emri = "Person", Mbiemri = "Personi", UserName = "xPersoni", Password = "12345678", Roli = Rolet.Klient },
        };
        public void PrintUserat()
        {
            Tabela.Krijo(listaUsereve,15);

           /* Console.WriteLine($"|{"Id",-5}|{"Username",-15}|{"Emri",-15}|{"Mbiemri",-15}|{"Roli",-10}|");
            foreach (var user in listaUsereve)
            {
                Console.WriteLine($"|{user.Id,5}|{user.UserName,-15}|{user.Emri,-15}|{user.Mbiemri,-15}|{user.Roli,-10}|");
            }*/

        }

        public void EditoRolin()
        {
            Tekst.PrintoWrite("Emri i userit per editim te rolit -> ", ConsoleColor.Yellow);

            var userName = Console.ReadLine();

            Tekst.Printo("1 - Admin\n" +
                "2 - Menaxher\n" +
                "3 - Klient",
                 ConsoleColor.Cyan);

            Tekst.PrintoWrite("Roli -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int roli);

            var rezultati = llogarite.EditoRolin(userName, (Rolet)roli);

            Console.Clear();

            if (rezultati.Sukses)
            {
                Tekst.Printo("Userit ju ndryshua roli me sukses.", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in rezultati.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }
        public void NdryshoPasswordin()
        {
            Tekst.PrintoWrite("Passwordi i vjeter -> ", ConsoleColor.Yellow);
            var passwordiVjeter = Console.ReadLine();

            Tekst.PrintoWrite("Passwordi i ri -> ", ConsoleColor.Yellow);
            var passwordiRi = Console.ReadLine();

            var rezultati = llogarite.NdryshoPasswordin(passwordiVjeter, passwordiRi);

            Console.Clear();

            if (rezultati.Sukses)
            {
                Tekst.Printo("Passwordi u ndryshua me sukses.", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in rezultati.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }

        public void NdryshoUser()
        {
            var useriAktual = Aplikacioni.useriAktual;
            Tekst.PrintoWrite($"Username [{useriAktual.UserName}] -> ", ConsoleColor.Yellow);
            var userName = Console.ReadLine();

            Tekst.PrintoWrite($"Emri [{useriAktual.Emri}] -> ", ConsoleColor.Yellow);
            var emri = Console.ReadLine();

            Tekst.PrintoWrite($"Mbiemri [{useriAktual.Mbiemri}] -> ", ConsoleColor.Yellow);
            var mbiemri = Console.ReadLine();

            Tekst.PrintoWrite("Shkruani passwordin per konfirmim -> ", ConsoleColor.Yellow);
            var password = Console.ReadLine();

            var user = new User()
            {
                Emri = emri,
                Mbiemri = mbiemri,
                Password = password,
                UserName = userName,
            };

            var rezultati = llogarite.Ndrysho(user);
            Console.Clear();
            if (rezultati.Sukses)
            {
                Tekst.Printo($"Te dhenat u ndryshuan me sukses!", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in rezultati.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }

        public void FshijUser()
        {
            Tekst.PrintoWrite("Id e userit per fshirje -> ", ConsoleColor.Yellow);
            _ = int.TryParse(Console.ReadLine(), out int id);

            var rezultati = llogarite.Fshij(id);

            Console.Clear();

            if (rezultati.Sukses)
            {
                Tekst.Printo($"Useri u fshi me sukses!", ConsoleColor.Green);
            }
            else
            {
                foreach (var error in rezultati.ListaErrorave)
                {
                    Tekst.Printo(error, ConsoleColor.Red);
                }
            }
        }
    }
}
