using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugPrimerEncuentro: IJugador
    {
        public JugPrimerEncuentro()
        {
            fichas = new List<Ficha>();
        }
        List<Ficha> fichas;
        public JugPrimerEncuentro(List<Ficha> fichas)
        {
            this.fichas = fichas;
        }
        public bool QuedanFichas => fichas.Count > 0;

        public List<Ficha> Fichas => fichas;

        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }


        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            if (FichaIzq == -1)
            {
                PasesConsecutivos = 0;
                Ficha ficha2 = fichas[0];
                fichas.Remove(fichas[0]);
                return ficha2;
            }

            foreach (var ficha in fichas)
            {
                if (
                    ficha.Minimo == FichaIzq ||
                    ficha.Maximo == FichaIzq
                    )
                {
                    PasesConsecutivos = 0;
                    JugarPor = 0;
                    Ficha ficha2 = ficha;
                    fichas.Remove(ficha);
                    return ficha2;
                }
                if(
                    ficha.Minimo == FichaDer ||
                    ficha.Maximo == FichaDer 
                    )
                {
                    PasesConsecutivos = 0;
                    JugarPor = 1;
                    Ficha ficha2 = ficha;
                    fichas.Remove(ficha);
                    return ficha2;
                }
            }
            PasesConsecutivos++;
            return null;
        }
    }
}
