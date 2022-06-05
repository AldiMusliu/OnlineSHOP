using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve
{
    class Validimi
    {
        public Validimi()
        {
            ListaErrorave = new List<string>();
        }
        public List<string> ListaErrorave { get; set; }
        public bool Sukses { get { return ListaErrorave.Count <= 0; }  }
    }
}
