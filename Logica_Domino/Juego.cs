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
            jugadoresList = new List<IJugador>();
            tablero = new List<Ficha>();
            configuracion = new Configuracion();
            sentido = 1;
            pasesMesa = 0;
        }
        int pasesMesa;
        int sentido;
        List<Ficha> fichaList;
        List<IJugador> jugadoresList;
        List<Ficha> tablero;
        Configuracion configuracion;
        public int PasesMesa => pasesMesa;
        public int Sentido => sentido;
        //Sentido = 1 es normal, Sentido = -1 es inverso
        public List<Ficha> FichasList => fichaList;
        public List<IJugador> JugadoresList => jugadoresList;
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
            IData data = configuracion.TipoDeData switch
            {
                TipoDeData.Clasica => new DataClasica(),
                TipoDeData.Par => new DaraPar(),
                _ => new DataClasica(),
            };


            data.FichaMax = configuracion.MaximoFicha;
            data.CrearData();
            fichaList = data.FichaList;
            Repartir(jugadoresList, fichaList, configuracion.CantidadARepartir);
        }
        public Ficha JuegaUnJugador(int jugToca)
        {
            IJugador jugador = jugadoresList[jugToca];
            Ficha fichaAPoner = new Ficha();
            fichaAPoner = jugador.Jugar(LadosDisponibles(tablero).Item1, LadosDisponibles(tablero).Item2);
            if (fichaAPoner == null)
            {
                pasesMesa++;
                return null;
            }
            else
            {
                pasesMesa = 0;
                if (jugador.JugarPor == 0)
                {
                    if (tablero.Count > 0 && fichaAPoner.Minimo == tablero[0].Minimo)
                    {
                       // Ficha poner = new Ficha();
                       // poner.Maximo = fichaAPoner.Minimo;
                       // poner.Minimo = fichaAPoner.Maximo;
                       // fichaAPoner = poner;
                        fichaAPoner.Virada = true;
                    }
                    tablero.Insert(0, fichaAPoner);
                    
                }
                if (jugador.JugarPor == 1)
                {
                    if (tablero.Count > 0 && fichaAPoner.Maximo == tablero[tablero.Count - 1].Maximo)
                    {
                       // Ficha poner = new Ficha();
                       // poner.Maximo = fichaAPoner.Minimo;
                       // poner.Minimo = fichaAPoner.Maximo;
                       // fichaAPoner = poner;
                        fichaAPoner.Virada = true;
                    }
                    tablero.Add(fichaAPoner);
                }
            }
            return fichaAPoner;
        }
        public int JugadorAJugar(int anterior)
        {
            if (sentido == 1)
            {
                return (anterior + sentido) % jugadoresList.Count();
            }
            else
            {
                if (anterior == 0)
                {
                    return jugadoresList.Count() - 1;
                }
                return anterior - sentido;
            }
        }

        public void ComenzarJuego()
        {
            /* 
             bool termino = false;*/
            #region While(True)
            while (true)
            {
                foreach (var jugador in jugadoresList)
                {

                    Ficha fichaAPoner = new Ficha();
                    fichaAPoner = jugador.Jugar(LadosDisponibles(tablero).Item1, LadosDisponibles(tablero).Item2);
                    if (fichaAPoner == null)
                    {
                        pasesMesa++;
                    }
                    /* if (fichaAPoner != null)
                     {
                         pasesMesa = 0;
                         if (jugador.JugarPor == 0)
                         {
                             if (tablero.Count > 0 && fichaAPoner.Minimo == tablero[0].Minimo)
                             {
                                 Ficha poner = new Ficha();
                                 poner.Maximo = fichaAPoner.Minimo;
                                 poner.Minimo = fichaAPoner.Maximo;
                                 fichaAPoner = poner;
                                 fichaAPoner.Virada = true;
                             }
                             tablero.Insert(0, fichaAPoner);

                         }
                         if (jugador.JugarPor == 1)
                         {
                             if (tablero.Count > 0 && fichaAPoner.Maximo == tablero[tablero.Count - 1].Maximo)
                             {
                                 Ficha poner = new Ficha();
                                 poner.Maximo = fichaAPoner.Minimo;
                                 poner.Minimo = fichaAPoner.Maximo;
                                 fichaAPoner = poner;
                                 fichaAPoner.Virada = true;
                             }
                             tablero.Add(fichaAPoner);

                         }
                     }*/
                    /*            if (FormaDeAcabarClasica(jugadoresList, jugador, pasesMesa))
                                {
                                    termino = true;
                                    break;
                                }
                            }

                            if (termino)
                            {
                                break;
                            }*/
                }
            }
            #endregion
        }
        #region FormasDeAcabar
        public bool FormaDeAcabarClasica(List<IJugador> listJug, IJugador jugador, int pasesMesa)
        {
            if (pasesMesa >= listJug.Count || jugador.Fichas.Count == 0)
            {
                return true;
            }
            return false;
        }
        public bool FormaDeAcabarPaseConsecutivo(List<IJugador> listJug, IJugador jugador, int pasesMesa, int pasesJug)
        {
            if (pasesMesa >= listJug.Count || jugador.Fichas.Count == 0 || jugador.PasesConsecutivos >= pasesJug)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region PuntuacionesFinales

        public int PuntuacionFinalClasica(List<IJugador> listJug)
        {
            int gano = -1;
            int ganoDVerdad = 0;
            int menor = int.MaxValue;
            foreach (var jug in listJug)
            {
                gano++;
                int a = 0;
                foreach (var ficha in jug.Fichas)
                {
                    a += ficha.Maximo = ficha.Minimo;
                }
                if (a < menor)
                {
                    ganoDVerdad = gano;
                    menor = a;
                }
            }
            return ganoDVerdad;
        }
        public int PuntuacionFinalDoblesDobles(List<IJugador> listJug)
        {
            int gano = -1;
            int ganoDVerdad = 0;
            int menor = int.MaxValue;
            foreach (var jug in listJug)
            {
                gano++;
                int a = 0;
                foreach (var ficha in jug.Fichas)
                {
                    if (ficha.Minimo == ficha.Maximo)
                    {
                        a += 2 * ficha.Minimo + 2 * ficha.Minimo;
                    }
                    else
                    {
                        a += ficha.Maximo + ficha.Minimo;
                    }
                }
                if (a < menor)
                {
                    ganoDVerdad = gano;
                    menor = a;
                }
            }
            return ganoDVerdad;
        }
        #endregion

        #region OrdenDeLaJugada
        public void OrdenDeLaJugadaClasica()
        {
            // XD
        }
        public void OrdenDeLaJugadaInversaAlPasar(List<IJugador> listJug, Ficha nullidad, IJugador jugador, int n)
        {
            if (nullidad == null && jugador.PasesConsecutivos >= n)
            {
                sentido = -1;
            }
        }

        #endregion

        public void DetenerJuego(bool pausado)
        {
            while (pausado)
            {
                Thread.Sleep(10);
            }
        }
        public void ReanudarJuego(bool pausado)
        {
            pausado = false;
        }
        public void GuardarJuego()
        {

        }
        public void SalirDelJuego()
        {

        }




    }
}
