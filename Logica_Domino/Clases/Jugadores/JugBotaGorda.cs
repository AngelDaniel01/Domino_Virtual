using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugBotaGorda : IJugador
    {
        public JugBotaGorda()
        {
            Fichas = new List<Ficha>();
        }
        public JugBotaGorda(List<Ficha> fichas)
        {
        }

        public bool QuedanFichas => Fichas.Count > 0;
        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }
        public string Nombre { get; set; }
        public List<Ficha> Fichas { get; set; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            Ficha fichaFinal = null;
            if (FichaIzq == -1)
            {
                foreach (var ficha in Fichas)
                {
                    for (int i = 9; i < 0; i--)
                    {
                        if (ficha.Maximo == i || ficha.Minimo == i)
                        {
                            PasesConsecutivos = 0;
                            Ficha ficha2 = new Ficha();
                            ficha2 = ficha;
                            Fichas.Remove(ficha);
                            return ficha2;
                        }
                    }
                }
            }

            foreach (var ficha in Fichas)
            {
                if (
                    ficha.Minimo == FichaDer ||
                    ficha.Maximo == FichaDer
                    )
                {
                    if (fichaFinal == null || (ficha.Maximo + ficha.Minimo) > (fichaFinal.Maximo + fichaFinal.Minimo))
                    {
                        JugarPor = 1;
                        fichaFinal = ficha;
                    }

                }
                if (
                    ficha.Minimo == FichaIzq ||
                    ficha.Maximo == FichaIzq
                    )
                {
                    if (fichaFinal == null || (ficha.Maximo + ficha.Minimo) > (fichaFinal.Maximo + fichaFinal.Minimo))
                    {
                        JugarPor = 0;
                        fichaFinal = ficha;
                    }
                }
            }
            if (fichaFinal == null)
            {
                PasesConsecutivos++;
                return null;
            }
            else
            {
                PasesConsecutivos = 0;
                Ficha ficha2 = fichaFinal;
                Fichas.Remove(fichaFinal);
                return ficha2;
            }
        }
    }
}