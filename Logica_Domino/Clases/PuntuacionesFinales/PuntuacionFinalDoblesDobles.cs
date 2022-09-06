using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class PuntuacionFinal_DoblesDobles : IPuntuacionFinal
    {
        public Tuple<int, int> Implementacion(List<IJugador> lista)
        {
            int gano = 0;
            int menor = int.MaxValue;
            int b = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                b = CuentaPuntos(lista[i]);
                if (lista[i].Fichas.Count == 0)
                {
                    return new Tuple<int, int>(i, b);
                }
                else if (b < menor)
                {
                    gano = i;
                    menor = b;
                }
            }
            return new Tuple<int, int>(gano, menor);
        }

        public int CuentaPuntos(IJugador jugador)
        {
            int a = 0;
            foreach (var ficha in jugador.Fichas)
            {
                if (ficha.Maximo == ficha.Minimo)
                {
                    a += 2 * (ficha.Maximo + ficha.Minimo);
                }
                else
                {
                    a += (ficha.Maximo + ficha.Minimo);
                }
            }
            return a;
        }
    }
}
