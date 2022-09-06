using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class Juego
    {
        public Juego()
        {
            fichaList = new List<Ficha>();
            tablero = new List<Ficha>();
            configuracion = new Configuracion();
            jugadoresList = configuracion.Jugadores;
            Sentido = 1;
            PasesMesa = 0;
        }

        List<Ficha> fichaList;
        List<IJugador> jugadoresList;
        List<Ficha> tablero;
        Configuracion configuracion;
        public int PasesMesa { get; set; }
        public int Sentido { get; set; }
        //Sentido = 1 es normal, Sentido = -1 es inverso
        public List<Ficha> FichasList => fichaList;
        public List<IJugador> Jugadores => jugadoresList;
        public List<Ficha> TableroList => tablero;
        public Configuracion Configuracion => configuracion;

        public Tuple<int, int> LadosDisponibles(List<Ficha> tablero)
        {
            int izq = 0;
            int der = 0;
            if (tablero == null || tablero.Count == 0)
            {
                return new Tuple<int, int>(-1, -1);
            }
            if (tablero.Count == 1)
            {
                izq = tablero[0].Minimo;
                der = tablero[0].Maximo;
                return new Tuple<int, int>(izq, der);
            }
            if (tablero[0].Maximo == tablero[1].Maximo || tablero[0].Maximo == tablero[1].Minimo)
            {
                izq = tablero[0].Minimo;
            }
            if (tablero[0].Minimo == tablero[1].Maximo || tablero[0].Minimo == tablero[1].Minimo)
            {
                izq = tablero[0].Maximo;
            }
            if (tablero[tablero.Count - 1].Minimo == tablero[tablero.Count - 2].Maximo || tablero[tablero.Count - 1].Minimo == tablero[tablero.Count - 2].Minimo)
            {
                der = tablero[tablero.Count - 1].Maximo;
            }
            if (tablero[tablero.Count - 1].Maximo == tablero[tablero.Count - 2].Maximo || tablero[tablero.Count - 1].Maximo == tablero[tablero.Count - 2].Minimo)
            {
                der = tablero[tablero.Count - 1].Minimo;
            }
            return new Tuple<int, int>(izq, der);
        }


        public void Repartir(List<IJugador> jugadores, List<Ficha> listaFichas, int cantDFichasXJug)
        {
            Random random = new Random();
            Ficha fichaAAnadir = new Ficha();
            foreach (var jugador in jugadores)
            {
                for (int i = 0; i < cantDFichasXJug; i++)
                {
                    fichaAAnadir = listaFichas[random.Next(0, listaFichas.Count)];
                    jugador.Fichas.Add(fichaAAnadir);
                    listaFichas.Remove(fichaAAnadir);
                }
            }
        }
        public void CargarJuego()
        {
            IData data = configuracion.Data;
            data.FichaMax = configuracion.MaximoFichas;
            data.FichaList = new List<Ficha>();
            tablero = new List<Ficha>();
            data.CrearData();
            fichaList = data.FichaList;
            foreach (var jug in jugadoresList)
            {
                jug.Fichas = new List<Ficha>();
            }
            Repartir(jugadoresList, fichaList, configuracion.CantidadARepartir);
        }
        public Ficha JuegaUnJugador(int jugToca)
        {
            IJugador jugador = jugadoresList[jugToca];
            Ficha fichaAPoner = new Ficha();
            var ladosDisponibles = LadosDisponibles(tablero);
            fichaAPoner = jugador.Jugar(ladosDisponibles.Item1, ladosDisponibles.Item2);
            if (fichaAPoner == null)
            {
                PasesMesa++;
                return null;
            }
            else
            {
                PasesMesa = 0;
                if (jugador.JugarPor == 0)
                {
                    if (tablero.Count > 0 && fichaAPoner.Minimo == ladosDisponibles.Item1)
                    {
                        fichaAPoner.Virada = true;
                    }
                    tablero.Insert(0, fichaAPoner);

                }
                if (jugador.JugarPor == 1)
                {
                    if (tablero.Count > 0 && fichaAPoner.Maximo == ladosDisponibles.Item2)
                    {
                        fichaAPoner.Virada = true;
                    }
                    tablero.Add(fichaAPoner);
                }
            }
            return fichaAPoner;
        }
        public int JugadorAJugar(int anterior)
        {
            if (Sentido == 1)
            {
                return (anterior + Sentido) % jugadoresList.Count();
            }
            else
            {
                if (anterior == 0)
                {
                    return jugadoresList.Count() - 1;
                }
                return anterior - Sentido;
            }
        }











    }
}
