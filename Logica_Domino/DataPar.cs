using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class DaraPar : IData
    {
        public DaraPar()
        {
            FichaList = new List<Ficha>();
        }
        public List<Ficha> FichaList { get; set; }
        public int FichaMax { get; set; }

        public void CrearData()
        {
            for (int i = 0; i <= FichaMax; i = +2)
            {
                for (int j = i; j <= FichaMax; j = +2)
                {
                    Ficha fichaNew = new Ficha();
                    fichaNew.Minimo = i;
                    fichaNew.Maximo = j;
                    if (i == j)
                    {
                        fichaNew.EsDoble = true;
                    }
                    fichaNew.Foto = i + "-" + j;

                    FichaList.Add(fichaNew);
                }
            }
        }

    }
}
