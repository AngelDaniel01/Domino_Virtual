using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public enum TipoDeData
    {
        Clasica,
        Par
    }

    public enum CantidadDeJugadores
    {
        DosJugadores,
        TresJugadores,
        Cuatrojugadores
    }
    public enum MaximoFicha
    {
        Max6,
        Max9,
        LibreMenorDe9

    }
    
    public enum PuntuacionesFinales
    {
        Clasica,
        DoblesDobles

    }
    public enum FormaDeAcabar
    {
        Clasica,
        PaseConsecutivo
    }
    public enum OrdenDeLaJugada
    {
        Clasica,
        InversaAlPasar
    }
    public enum TipoDeFicha
    {
        Clasica,
        Color,
        Emoji
    }

    public class Configuracion
    {
        public Configuracion()
        {
            CantidadARepartir = 10;
            MaximoFicha = 9;
            PuntuacionesFinales = PuntuacionesFinales.Clasica;
            FormaDeAcabar = FormaDeAcabar.Clasica;
            OrdenDeLaJugada = OrdenDeLaJugada.Clasica;
            Jugadores = new IJugador[2];
            TipoDeData = TipoDeData.Clasica;
            for (int i = 0; i < Jugadores.Length; i++)
            {
                Jugadores[i] = new JugRandom();
            }
            TipoDeFicha = TipoDeFicha.Clasica;
        }





        public int MaximoFicha;
        public int CantidadARepartir;
        public TipoDeData TipoDeData { get; set; }
        public PuntuacionesFinales PuntuacionesFinales { get; set; }
        public FormaDeAcabar FormaDeAcabar { get; set; }
        public OrdenDeLaJugada OrdenDeLaJugada { get; set; }
        public IJugador[] Jugadores { get; set; }
        public TipoDeFicha TipoDeFicha { get; set; }
    }



}
