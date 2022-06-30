using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugHumano : IJugador
    {
        public JugHumano()
        {
            fichas = new List<Ficha>();
        }
        List<Ficha> fichas;

        public int PasesConsecutivos { get; set; }

        public bool QuedanFichas => fichas.Count > 0;

        public List<Ficha> Fichas => fichas;

        public int JugarPor { get; set; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            Console.WriteLine("Diga que ficha jugar?");
            string escrito = Console.ReadLine();
            escrito.ToLower();
            if (escrito == "p")
            {
                PasesConsecutivos++;
                return null;
            }
            else
            {
                int a = int.Parse(escrito);
                if (FichaIzq == -1)
                {
                    PasesConsecutivos = 0;
                    Ficha ficha2 = fichas[a];
                    Fichas.Remove(fichas[a]);
                    return ficha2;
                }
                if (fichas[a].Minimo == FichaIzq || fichas[a].Maximo == FichaIzq)
                {
                    JugarPor = 0;
                    PasesConsecutivos = 0;
                    Ficha ficha2 = fichas[a];
                    Fichas.Remove(fichas[a]);
                    return ficha2;
                }
                if (fichas[a].Minimo == FichaDer || fichas[a].Maximo == FichaDer)
                {
                    JugarPor = 1;
                    PasesConsecutivos = 0;
                    Ficha ficha2 = fichas[a];
                    Fichas.Remove(fichas[a]);
                    return ficha2;
                }
            }
            return null;
        }
    }
}
