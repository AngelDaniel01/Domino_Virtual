using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class OrdenJugada_Clasica : IOrdenJugada
    {
        public void Implementacion(Juego juego, IJugador jugadorActual, Ficha ficha)
        {
            juego.Sentido = 1;
        }
    }
}
