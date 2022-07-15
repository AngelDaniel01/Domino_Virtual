using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public interface IFormaDeAcabar
    {
        public bool Implementacion(Juego juego, IJugador jugadorActual);
    }
}
