using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class FormaDeAcabar_2_Pases_Consecutivos : IFormaDeAcabar
    {
        public bool Implementacion(Juego juego, IJugador jugadorActual)
        {
            if (juego.PasesMesa >= juego.Jugadores.Count || jugadorActual.Fichas.Count == 0 || jugadorActual.PasesConsecutivos >= 2)
            {
                return true;
            }
            return false;
        }
    }
}
