using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class FormaDeAcabar_Clasica : IFormaDeAcabar
    {
        public bool Implementacion(Juego juego, IJugador jugadorActual)
        {
            if (juego.PasesMesa >= juego.Jugadores.Count || jugadorActual.Fichas.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
