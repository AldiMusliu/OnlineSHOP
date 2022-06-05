using ShitjaProdukteve.MenaxhimiLlogarive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.Produktet
{
    class ProduktiBlere
    {
        public int IdBleresit { get; set; }
        public string Bleresi => MenaxhimiLlogarise.listaUsereve.FirstOrDefault(x => x.Id == IdBleresit).UserName;
        public int IdProduktit { get; set; }
        public string Prodhuesi { get; set; }
        public string Modeli { get; set; }
        public decimal Cmimi { get; set; }
        public int SasiaBlere { get; set; }
        public decimal CmimiTotal { get; set; }
        public DateTime DataBlerjes { get; set; }
    }
}
