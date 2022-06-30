using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class Ficha
    {
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public bool EsDoble { get; set; }
        public bool Virada { get; set; }
        public bool Vertical { get; set; }
        public string Foto;
    }
}
