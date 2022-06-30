using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public interface IData
    {
        public List<Ficha> FichaList { get; set; }
        public void CrearData();
        public int FichaMax { get; set; }
    }
}
