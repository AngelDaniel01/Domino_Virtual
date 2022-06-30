using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugRandom : IJugador
    {
        public JugRandom()
        {
            fichas = new List<Ficha>();
        }
       // public JugRandom(List<Ficha> fichas)
       // {
       //     this.fichas = fichas;
       // }

        List<Ficha> fichas;
        public bool QuedanFichas => fichas.Count > 0;
        public List<Ficha> Fichas => fichas;

        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            Random random = new Random();
            int rand = 0;
            int reviadas = 0;
            bool[] mask = new bool[fichas.Count]; 
            while (reviadas < fichas.Count)
            {
                rand = random.Next(0, fichas.Count);
                if (!mask[rand])
                {
                    mask[rand] = true;
                    reviadas++;

                    if (FichaIzq == -1)
                    {
                        PasesConsecutivos = 0;
                        Ficha ficha2 = fichas[rand];
                        fichas.Remove(fichas[rand]);
                        return ficha2;
                    }
                    if (
                        fichas[rand].Minimo == FichaIzq ||
                        fichas[rand].Maximo == FichaIzq
                        )
                    {
                        PasesConsecutivos = 0;
                        JugarPor = 0;
                        Ficha ficha2 = fichas[rand];
                        Fichas.Remove(fichas[rand]);
                        return ficha2;
                    }
                    if (
                        fichas[rand].Minimo == FichaDer ||
                        fichas[rand].Maximo == FichaDer
                        )
                    {
                        PasesConsecutivos = 0;
                        JugarPor = 1;
                        Ficha ficha2 = fichas[rand];
                        Fichas.Remove(fichas[rand]);
                        return ficha2;
                    }
                }
            }
            PasesConsecutivos++;
            return null;



        }
    }
}
