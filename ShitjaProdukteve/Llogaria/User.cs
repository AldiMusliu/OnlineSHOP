using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.Llogaria
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public Rolet Roli { get; set; }
        public string Password { get; set; }
    }
}
