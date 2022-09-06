using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public enum EnumMaximoFicha
    {
        Max9,
        Max6,
        Entre6y9
    }

    public class Configuracion
    {
        public Configuracion()
        {
            Jugadores = new List<IJugador>();
            EstablecerValoresPredeterminados();
        }



        public int CantidadARepartir;
        public IData Data { get; set; }
        public EnumMaximoFicha EnumMaximoFicha { get; set; }
        public int MaximoFichas { get; set; }
        public IPuntuacionFinal PuntuacionesFinales { get; set; }
        public IFormaDeAcabar FormaDeAcabar { get; set; }
        public IOrdenJugada OrdenDeLaJugada { get; set; }
        public ITipoDeFicha TipoDeFicha { get; set; }
        public List<IJugador> Jugadores { get; set; }



        public Dictionary<string, string> Predeterminados;

        public void EstablecerValoresPredeterminados()
        {
            CantidadARepartir = 10;
            MaximoFichas = 9;
            Data = new Data_Clasica();
            PuntuacionesFinales = new PuntuacionFinal_Clasica();
            FormaDeAcabar = new FormaDeAcabar_Clasica();
            OrdenDeLaJugada = new OrdenJugada_Clasica();
             for (int i = 0; i < 4 ; i++)
             {
                Jugadores.Add(new JugRandom());
             }
            TipoDeFicha = new TipoDeFicha_Clasica();

            Predeterminados = new Dictionary<string, string>();

            Predeterminados.Add("MaximoFicha", Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Max9));
            Predeterminados.Add("PuntuacionesFinales", typeof(PuntuacionFinal_Clasica).Name);
            Predeterminados.Add("FormaDeAcabar", typeof(FormaDeAcabar_Clasica).Name);
            Predeterminados.Add("OrdenDeLaJugada", typeof(OrdenJugada_Clasica).Name);
            Predeterminados.Add("TipoDeFicha", typeof(TipoDeFicha_Clasica).Name);
            Predeterminados.Add("Data", typeof(Data_Clasica).Name);

        }

    }
}
