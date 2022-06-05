using ShitjaProdukteve.Produktet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiKategorive
{
    interface IKategoriaIT
    {
        Validimi BlejSmartphone(int idProduktit, int sasia);
        Validimi BlejLaptop(int idProduktit, int sasia);
        void ShtoSmartphone(Smartphone smartphone);
        void ShtoLaptop(Laptop laptop);
        bool FshijSmartphone(int id);
        bool FshijLaptop(int id);
        void EditoSmartphone(Smartphone smartphoneNdryshuar);
        void EditoLaptop(Laptop laptopNdryshuar);
    }
}
