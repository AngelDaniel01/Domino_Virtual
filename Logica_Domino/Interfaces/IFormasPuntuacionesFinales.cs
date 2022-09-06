using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public interface IPuntuacionFinal
    {
        public Tuple<int,int> Implementacion(List<IJugador> lista);
    }
}
