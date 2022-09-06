using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class OrdenJugada_Inversa_Al_Pasarse : IOrdenJugada
    {
        public void Implementacion(Juego juego, IJugador jugadorActual, Ficha ficha)
        {
            if (ficha == null && jugadorActual.PasesConsecutivos >= 2)
            {
                if (juego.Sentido == 1)
                {
                    juego.Sentido = -1;
                }
                else
                {
                    juego.Sentido = 1;
                }
            }
        }
    }
}
