﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Virtual
{
    public class JugMedioPensador : IJugador
    {
        public JugMedioPensador()
        {
            Fichas = new List<Ficha>();
        }

        public bool QuedanFichas => Fichas.Count > 0;

        public int JugarPor { get; set; }
        public int PasesConsecutivos { get; set; }
        public string Nombre { get; set; }
        public List<Ficha> Fichas { get; set ; }

        public Ficha Jugar(int FichaIzq, int FichaDer)
        {
            List<Ficha> organizadaIzq = new List<Ficha>();
            List<Ficha> organizadaDer = new List<Ficha>();


            if (FichaIzq == -1)
            {
                int[] valores = new int[10];
                foreach (var ficha in Fichas)
                {
                    for (int i = 0; i < valores.Length; i++)
                    {
                        if (ficha.Maximo == i || ficha.Minimo == i) valores[i]++;
                    }
                }
                int aux = -1;
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] == valores.Max())
                    {
                        aux = i;
                    }
                }
                foreach (var ficha in Fichas)
                {
                    if (ficha.Maximo == aux || ficha.Minimo == aux)
                    {
                        Ficha ficha2 = ficha;
                        Fichas.Remove(ficha);
                        return ficha2;
                    }
                }
            }


            foreach (var ficha in Fichas)
            {
                if (ficha.Minimo == FichaIzq || ficha.Maximo == FichaIzq)
                {
                    organizadaIzq.Add(ficha);
                }
                if (ficha.Minimo == FichaDer || ficha.Maximo == FichaDer)
                {
                    organizadaDer.Add(ficha);
                }

            }
            //devuelvo la primera de la que mas tengo

            if (organizadaIzq.Count > organizadaDer.Count)
            {
                PasesConsecutivos = 0;
                JugarPor = 0;
                Ficha ficha2 = new Ficha();
                ficha2 = organizadaIzq[0];
                Fichas.Remove(organizadaIzq[0]);
                return ficha2;
            }
            if (organizadaDer.Count == 0)
            {
                PasesConsecutivos++;
                return null;
            }
            else
            {
                PasesConsecutivos = 0;
                Ficha ficha2 = new Ficha();
                ficha2 = organizadaDer[0];
                Fichas.Remove(organizadaDer[0]);
                JugarPor = 1;
                return ficha2;
            }
        }
    }
}
