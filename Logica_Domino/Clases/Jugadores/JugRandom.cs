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
            Fichas = new List<Ficha>();
        }
        public bool QuedanFichas => Fichas.Count > 0;

        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }
        public string Nombre { get; set; }
        public List<Ficha> Fichas { get; set; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            Random random = new Random();
            int rand = 0;
            int reviadas = 0;
            bool[] mask = new bool[Fichas.Count];
            while (reviadas < Fichas.Count)
            {
                rand = random.Next(0, Fichas.Count);
                if (!mask[rand])
                {
                    mask[rand] = true;
                    reviadas++;

                    if (FichaIzq == -1)
                    {
                        PasesConsecutivos = 0;
                        Ficha ficha2 = Fichas[rand];
                        Fichas.Remove(Fichas[rand]);
                        return ficha2;
                    }
                    if (
                        Fichas[rand].Minimo == FichaIzq ||
                        Fichas[rand].Maximo == FichaIzq
                        )
                    {
                        PasesConsecutivos = 0;
                        JugarPor = 0;
                        Ficha ficha2 = Fichas[rand];
                        Fichas.Remove(Fichas[rand]);
                        return ficha2;
                    }
                    if (
                        Fichas[rand].Minimo == FichaDer ||
                        Fichas[rand].Maximo == FichaDer
                        )
                    {
                        PasesConsecutivos = 0;
                        JugarPor = 1;
                        Ficha ficha2 = Fichas[rand];
                        Fichas.Remove(Fichas[rand]);
                        return ficha2;
                    }
                }
            }
            PasesConsecutivos++;
            return null;



        }
    }
}
