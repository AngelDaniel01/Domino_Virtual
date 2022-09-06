using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino_Virtual
{
    public partial class AgregarJugador : Form
    {
        IJugador jugador;
        List<IJugador> jugadorList;
        int pos;
        public AgregarJugador(List<IJugador> Jugadores, int posicion = -1)
        {
            InitializeComponent();
            jugadorList = Jugadores;
            pos = posicion;
            if (posicion != -1)
            {
                jugador = Jugadores[posicion];
                textBox1.Text = String.IsNullOrEmpty(jugador.Nombre) ? "jugador " + posicion : jugador.Nombre;
            }

            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IJugador))
                            && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IJugador;

            foreach (var instance in instances)
            {
                comboBox1.Items.Add(instance.GetType().Name);
            }
            if (posicion != -1)
            {
                comboBox1.SelectedItem = jugador.GetType().Name;
            }


        }

        private void AgregarJugador_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string type = comboBox1.SelectedItem.ToString();

            var jugadorTipo = Type.GetType("Domino_Virtual." + type);
            var jug = Activator.CreateInstance(jugadorTipo) as IJugador;


            {
                jug.Nombre = name;
                if (pos == -1)
                {
                    if (jugadorList.Count == 4)
                    {
                        MessageBox.Show("No puede agregar mas de 4 jugadores", "Error");
                    }
                    else
                    {
                        jugadorList.Add(jug);
                    }
                }
                else
                {
                    jugadorList[pos] = jug;
                }
                this.Close();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
