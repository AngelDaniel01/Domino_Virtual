using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino_Virtual
{
    public partial class AjusteDeJugadores : Form
    {

        List<IJugador> listaDeJugadores;
        public AjusteDeJugadores(List<IJugador> ListaDeJugadores)
        {
            InitializeComponent();
            listaDeJugadores = ListaDeJugadores;
            RefreshGridView();

        }

        public class NombreTipoJugador
        {
            public string NombreDeJugador { get; set; }
            public string TipoDeJugador { get; set; }

        }
        public void RefreshGridView()
        {
            List<NombreTipoJugador> nombreTipoJugadors = new List<NombreTipoJugador>();
            for (int i = 0; i < listaDeJugadores.Count; i++)
            {
                NombreTipoJugador nombreTipoJugador = new NombreTipoJugador();
                nombreTipoJugador.NombreDeJugador = String.IsNullOrEmpty(listaDeJugadores[i].Nombre) ? "jugador " + (i + 1) : listaDeJugadores[i].Nombre;
                nombreTipoJugador.TipoDeJugador = listaDeJugadores[i].GetType().Name;
                nombreTipoJugadors.Add(nombreTipoJugador);
            }
            dataGridView1.DataSource = nombreTipoJugadors;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (listaDeJugadores.Count <= 2)
            {
                MessageBox.Show("No se puede eliminar mas jugadores", "Error");
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Primero seleccione el jugador que quiere eliminar", "Error");
                }
                else
                {
                    int posAEliminar = dataGridView1.SelectedRows[0].Index;
                    listaDeJugadores.Remove(listaDeJugadores[posAEliminar]);

                }
            }
            RefreshGridView();

        }

        private void editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 4)
            {
                MessageBox.Show("No puede agregar mas jugadores", "Error");
            }
            else
            {
                AgregarJugador agregarJugador = new AgregarJugador(listaDeJugadores);
                agregarJugador.ShowDialog();
                RefreshGridView();
            }


        }

        private void Arriba_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Primero seleccione el jugador que quiere subir", "Error");
            }
            else
            {
                int posAEditar = dataGridView1.SelectedRows[0].Index;
                if (listaDeJugadores[posAEditar] == listaDeJugadores[0])
                {
                    MessageBox.Show("El jugador seleccionado ya es el primero", "Error");
                }
                else
                {
                    IJugador cambio = listaDeJugadores[posAEditar];
                    listaDeJugadores[posAEditar] = listaDeJugadores[posAEditar - 1];
                    listaDeJugadores[posAEditar - 1] = cambio;
                }
            }
            RefreshGridView();
        }

        private void Abajo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Primero seleccione el jugador que quiere subir", "Error");
            }
            else
            {
                int posAEditar = dataGridView1.SelectedRows[0].Index;
                if (posAEditar == listaDeJugadores.Count - 1)
                {
                    MessageBox.Show("El jugador seleccionado ya es el ultimo", "Error");
                }
                else
                {
                    IJugador cambio = listaDeJugadores[posAEditar];
                    listaDeJugadores[posAEditar] = listaDeJugadores[posAEditar + 1];
                    listaDeJugadores[posAEditar + 1] = cambio;
                }
            }
            RefreshGridView();
        }

        private void button3_Editarr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int pos = dataGridView1.SelectedRows[0].Index;
                AgregarJugador agregarJugador = new AgregarJugador(listaDeJugadores, pos);
                agregarJugador.ShowDialog();
                RefreshGridView();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el jugador a editar", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjusteDeJugadores_Load(object sender, EventArgs e)
        {

        }
    }
}
