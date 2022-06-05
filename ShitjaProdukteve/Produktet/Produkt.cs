using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.Produktet
{
    class Produkt
    { 
        public int Id { get; set; }
        public int Sasia { get; set; }
        public decimal Cmimi { get; set; }
        public bool NeStok { get { return Sasia > 0; } }
    }
}
