using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugPrimerEncuentro : IJugador
    {
        public JugPrimerEncuentro()
        {
            Fichas = new List<Ficha>();
        }
        public JugPrimerEncuentro(List<Ficha> fichas)
        {
            this.Fichas = fichas;
        }
        public bool QuedanFichas => Fichas.Count > 0;
        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }
        public string Nombre { get; set; }
        public List<Ficha> Fichas { get; set; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            if (FichaIzq == -1)
            {
                PasesConsecutivos = 0;
                Ficha ficha2 = Fichas[0];
                Fichas.Remove(Fichas[0]);
                return ficha2;
            }

            foreach (var ficha in Fichas)
            {
                if (
                    ficha.Minimo == FichaIzq ||
                    ficha.Maximo == FichaIzq
                    )
                {
                    PasesConsecutivos = 0;
                    JugarPor = 0;
                    Ficha ficha2 = ficha;
                    Fichas.Remove(ficha);
                    return ficha2;
                }
                if (
                    ficha.Minimo == FichaDer ||
                    ficha.Maximo == FichaDer
                    )
                {
                    PasesConsecutivos = 0;
                    JugarPor = 1;
                    Ficha ficha2 = ficha;
                    Fichas.Remove(ficha);
                    return ficha2;
                }
            }
            PasesConsecutivos++;
            return null;
        }
    }
}
