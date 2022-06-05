using ShitjaProdukteve.Produktet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiKategorive
{
    class MockKategoriaIT : IKategoriaIT
    {
        public Validimi BlejLaptop(int idProduktit, int sasia)
        {
            var laptop = MenaxhimiKategoriseIT.laptops.SingleOrDefault(s => s.Id == idProduktit);
            var validimi = new Validimi();
            if (laptop != null)
            {
                if (laptop.Sasia >= sasia && laptop.Sasia != 0)
                {
                    laptop.Sasia -= sasia;

                    var laptopModel = new ProduktiBlere()
                    {
                        IdBleresit = Aplikacioni.useriAktual.Id,
                        DataBlerjes = DateTime.Now,
                        Cmimi = laptop.Cmimi,
                        CmimiTotal = laptop.Cmimi * sasia,
                        IdProduktit = laptop.Id,
                        Prodhuesi = laptop.Prodhuesi,
                        SasiaBlere = sasia,
                        Modeli = laptop.Modeli
                    };
                    KategoriaITBlerja.laptopTeBlera.Add(laptopModel);
                }
                else
                {
                    validimi.ListaErrorave.Add("Nuk ka sasi te mjaftueshme.");
                }
            }
            else
            {
                validimi.ListaErrorave.Add("Produkti nuk ekziston.");

            }
            return validimi;

        }

        public Validimi BlejSmartphone(int idProduktit, int sasia)
        {
            var smartphone = MenaxhimiKategoriseIT.smartphones.SingleOrDefault(s => s.Id == idProduktit);
            var validimi = new Validimi();
            if (smartphone != null)
            {
                if (smartphone.Sasia >= sasia && smartphone.Sasia != 0)
                {
                    smartphone.Sasia -= sasia;

                    var smartphoneModel = new ProduktiBlere()
                    {
                        IdBleresit = Aplikacioni.useriAktual.Id,
                        DataBlerjes = DateTime.Now,
                        Cmimi = smartphone.Cmimi,
                        CmimiTotal = smartphone.Cmimi * sasia,
                        IdProduktit = smartphone.Id,
                        Prodhuesi = smartphone.Prodhuesi,
                        SasiaBlere = sasia,
                        Modeli = smartphone.Modeli
                    };
                    KategoriaITBlerja.smartphoneTeBlera.Add(smartphoneModel);
                }
                else
                {
                    validimi.ListaErrorave.Add("Nuk ka sasi te mjaftueshme.");
                }
            }
            else
            {
                validimi.ListaErrorave.Add("Produkti nuk ekziston.");
            }
            return validimi;
        }

        public void EditoLaptop(Laptop laptopNdryshuar)
        {
            var laptop = MenaxhimiKategoriseIT.laptops.SingleOrDefault(sm => sm.Id == laptopNdryshuar.Id);

            if (laptop != null)
            {
                laptop.Modeli = laptopNdryshuar.Modeli;
                laptop.Prodhuesi = laptopNdryshuar.Prodhuesi;
                laptop.RAM = laptopNdryshuar.RAM;
                laptop.Sasia = laptopNdryshuar.Sasia;
                laptop.Storage = laptopNdryshuar.Storage;
                laptop.Ngjyra = laptopNdryshuar.Ngjyra;
                laptop.Procesori = laptopNdryshuar.Procesori;
                laptop.KartaGrafike = laptopNdryshuar.KartaGrafike;
                laptop.LlojiDiskut = laptopNdryshuar.LlojiDiskut;
                laptop.LlojiMemories = laptopNdryshuar.LlojiMemories;
                laptop.HDMI = laptopNdryshuar.HDMI;
                laptop.Cmimi = laptopNdryshuar.Cmimi;
            }
        }


        public void EditoSmartphone(Smartphone smartphoneNdryshuar)
        {
            var smartphone = MenaxhimiKategoriseIT.smartphones.SingleOrDefault(sm => sm.Id == smartphoneNdryshuar.Id);

            if (smartphone != null)
            {
                smartphone.Modeli = smartphoneNdryshuar.Modeli;
                smartphone.Prodhuesi = smartphoneNdryshuar.Prodhuesi;
                smartphone.RAM = smartphoneNdryshuar.RAM;
                smartphone.Sasia = smartphoneNdryshuar.Sasia;
                smartphone.Storage = smartphoneNdryshuar.Storage;
                smartphone.Ngjyra = smartphoneNdryshuar.Ngjyra;
                smartphone.Procesori = smartphoneNdryshuar.Procesori;
                smartphone.KamPrapmeMpx = smartphoneNdryshuar.KamPrapmeMpx;
                smartphone.KamPerparmeMpx = smartphoneNdryshuar.KamPerparmeMpx;
                smartphone.Cmimi = smartphoneNdryshuar.Cmimi;
            }
        }

        public bool FshijLaptop(int id)
        {
            var laptop = MenaxhimiKategoriseIT.laptops.SingleOrDefault(sm => sm.Id == id);
            if (laptop != null)
            {
                bool result = MenaxhimiKategoriseIT.laptops.Remove(laptop);
                return result;
            }
            return false;
        }

        public bool FshijSmartphone(int id)
        {
            var smartphone = MenaxhimiKategoriseIT.smartphones.SingleOrDefault(sm => sm.Id == id);
            if (smartphone != null)
            {
                bool result = MenaxhimiKategoriseIT.smartphones.Remove(smartphone);
                return result;
            }
            return false;
        }

        public void ShtoLaptop(Laptop laptop)
        {
            var id = 1;
            if (MenaxhimiKategoriseIT.laptops.Count > 0)
            {
                id = MenaxhimiKategoriseIT.laptops.Max(sm => sm.Id) + 1;
            }
            laptop.Id = id;
            MenaxhimiKategoriseIT.laptops.Add(laptop);
        }

        public void ShtoSmartphone(Smartphone smartphone)
        {
            var id = 1;
            if (MenaxhimiKategoriseIT.smartphones.Count > 0)
            {
                id = MenaxhimiKategoriseIT.smartphones.Max(sm => sm.Id) + 1;
            }
            smartphone.Id = id;
            MenaxhimiKategoriseIT.smartphones.Add(smartphone);
        }
    }
}
