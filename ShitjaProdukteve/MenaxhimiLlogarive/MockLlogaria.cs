using ShitjaProdukteve.Llogaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiLlogarive
{
    class MockLlogaria : ILlogaria
    {
        public Validimi EditoRolin(string userName, Rolet roli)
        {
            var validimi = new Validimi();
            var user = MenaxhimiLlogarise.listaUsereve.FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                if (user.Roli != Rolet.Admin)
                {
                    user.Roli = roli;
                }
                else
                {
                    validimi.ListaErrorave.Add($"Useri me emrin {user.UserName} eshte admin dhe nuk mund ti ndryshohet roli!");
                }
            }
            else
            {
                validimi.ListaErrorave.Add($"Useri me emrin {userName} nuk ekziston!");
            }
            return validimi;
        }
        public Validimi Fshij(int id)
        {
            var user = MenaxhimiLlogarise.listaUsereve.FirstOrDefault(u => u.Id == id);
            var validimi = new Validimi();
            if (user != null)
            {
                if (user.Roli != Rolet.Admin)
                {
                    MenaxhimiLlogarise.listaUsereve.Remove(user);
                }
                else
                {
                    validimi.ListaErrorave.Add($"Useri me emrin {user.UserName} eshte admin dhe nuk mund fshihet!");
                }
            }
            else
            {
                validimi.ListaErrorave.Add($"Useri me id: {id} nuk ekziston!");
            }
            return validimi;
        }
        public bool Login(string userName, string password)
        {
            var user = MenaxhimiLlogarise.listaUsereve.SingleOrDefault(u => u.UserName == userName);

            if (user != null)
            {
                if (user.Password == password)
                {
                    Aplikacioni.useriAktual = user;
                    return true;
                }
            }
            return false;
        }

        public Validimi Ndrysho(User user)
        {
            var useriAktual = MenaxhimiLlogarise.listaUsereve.SingleOrDefault(u => u.Id == Aplikacioni.useriAktual.Id);

            var validimi = new Validimi();
            if (useriAktual != null)
            {
                if (user.Password != useriAktual.Password)
                {
                    validimi.ListaErrorave.Add("Passwordi gabim!");
                }
                var ekziston = MenaxhimiLlogarise.listaUsereve.Exists(x => x.UserName == user.UserName);
                if (ekziston)
                {
                    validimi.ListaErrorave.Add("Useri me kete emer ekziston!");
                }
                if (user.Password.Length < 8)
                {
                    validimi.ListaErrorave.Add("Passwordi duhet te jete >= 8 karaktere!");
                }
                if (string.IsNullOrEmpty(user.Emri))
                {
                    validimi.ListaErrorave.Add("Kerkohet emri!");
                }
                if (string.IsNullOrEmpty(user.Emri))
                {
                    validimi.ListaErrorave.Add("Kerkohet mbiemri!");
                }
                if (user.UserName.Length < 6)
                {
                    validimi.ListaErrorave.Add("Username duhet te jete >= 6 karaktere!");
                }
                if (validimi.Sukses)
                {
                    useriAktual.Mbiemri = user.Mbiemri;
                    useriAktual.Emri = user.Emri;
                    useriAktual.UserName = user.UserName;
                }
            }
            return validimi;
        }

        public Validimi NdryshoPasswordin(string passwordiVjeter, string passwordiRi)
        {
            var user = MenaxhimiLlogarise.listaUsereve.SingleOrDefault(u => u.Id == Aplikacioni.useriAktual.Id);

            var validimi = new Validimi();
            if (user != null)
            {
                if (passwordiVjeter != user.Password)
                {
                    validimi.ListaErrorave.Add("Passwordi vjeter gabim!");
                }
                if (passwordiRi.Length < 8)
                {
                    validimi.ListaErrorave.Add("Passwordi duhet te jete >= 8!");
                }
                if (validimi.Sukses)
                {
                    user.Password = passwordiRi;
                }
            }
            return validimi;
        }

        public Validimi Regjistro(User newUser)
        {

            newUser.Id = MenaxhimiLlogarise.listaUsereve.Max(u => u.Id) + 1;
            newUser.Roli = Rolet.Klient;

            var validimi = new Validimi();

            var ekziston = MenaxhimiLlogarise.listaUsereve.Exists(x => x.UserName == newUser.UserName);
            if (ekziston)
            {
                validimi.ListaErrorave.Add("Useri me kete emer ekziston!");
            }
            if (newUser.Password.Length < 8)
            {
                validimi.ListaErrorave.Add("Passwordi duhet te jete >= 8 karaktere!");
            }
            if (string.IsNullOrEmpty(newUser.Emri))
            {
                validimi.ListaErrorave.Add("Kerkohet emri!");
            }
            if (string.IsNullOrEmpty(newUser.Emri))
            {
                validimi.ListaErrorave.Add("Kerkohet mbiemri!");
            }
            if (newUser.UserName.Length < 6)
            {
                validimi.ListaErrorave.Add("Username duhet te jete >= 6 karaktere!");
            }
            if (validimi.Sukses)
            {
                MenaxhimiLlogarise.listaUsereve.Add(newUser);
                Aplikacioni.useriAktual = newUser;
            }
            return validimi;
        }
    }
}
