using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public interface IJugador
    {
        public int PasesConsecutivos { get; set; }
        public Ficha Jugar(int FichaIzq, int FichaDer);
        public bool QuedanFichas { get; }
        public List<Ficha> Fichas { get; }
        public int JugarPor { get; set; }
    }
}
