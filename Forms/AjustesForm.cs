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
    public partial class AjustesForm : Form
    {
        Configuracion configuracion;
        List<IJugador> jugadores;
        public AjustesForm(Configuracion configuracion)
        {
            InitializeComponent();

            this.configuracion = configuracion;
            this.jugadores = configuracion.Jugadores;
            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {

            foreach (var item in Enum.GetNames(typeof(EnumMaximoFicha)))
            {
                cBoxLimiteFichas.Items.Add(item);
                if (configuracion.EnumMaximoFicha.ToString() == item)
                    cBoxLimiteFichas.SelectedItem = item;
            }
            numericUpDown1.Value = configuracion.MaximoFichas;

            var instancesPunt = from t in Assembly.GetExecutingAssembly().GetTypes()
                                where t.GetInterfaces().Contains(typeof(IPuntuacionFinal))
                                && t.GetConstructor(Type.EmptyTypes) != null
                                select Activator.CreateInstance(t) as IPuntuacionFinal;
            foreach (var instance in instancesPunt)
            {
                string nombre = instance.GetType().Name;
                string nombreArreglado = NombreArreglado(nombre);
                cBoxPuntuacionFinal.Items.Add(nombreArreglado);
                if (configuracion.PuntuacionesFinales.GetType().Name == nombre)
                    cBoxPuntuacionFinal.SelectedItem = nombreArreglado;
            }


            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IFormaDeAcabar))
                            && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IFormaDeAcabar;
            foreach (var instance in instances)
            {
                string nombre = instance.GetType().Name;
                string nombreArreglado = NombreArreglado(nombre);
                cBoxFinalizarJuego.Items.Add(nombreArreglado);
                if (configuracion.FormaDeAcabar.GetType().Name == nombre)
                    cBoxFinalizarJuego.SelectedItem = nombreArreglado;
            }

            var instancesOrdenJugada = from t in Assembly.GetExecutingAssembly().GetTypes()
                                       where t.GetInterfaces().Contains(typeof(IOrdenJugada))
                                       && t.GetConstructor(Type.EmptyTypes) != null
                                       select Activator.CreateInstance(t) as IOrdenJugada;
            foreach (var instance in instancesOrdenJugada)
            {
                string nombre = instance.GetType().Name;
                string nombreArreglado = NombreArreglado(nombre);
                cBoxOrdenJugada.Items.Add(nombreArreglado);
                if (configuracion.OrdenDeLaJugada.GetType().Name == nombre)
                    cBoxOrdenJugada.SelectedItem = nombreArreglado;
            }

            var instancesTipoDeFicha = from t in Assembly.GetExecutingAssembly().GetTypes()
                                       where t.GetInterfaces().Contains(typeof(ITipoDeFicha))
                                       && t.GetConstructor(Type.EmptyTypes) != null
                                       select Activator.CreateInstance(t) as ITipoDeFicha;
            foreach (var instance in instancesTipoDeFicha)
            {
                string nombre = instance.GetType().Name;
                string nombreArreglado = NombreArreglado(nombre);
                cBoxTipoFicha.Items.Add(nombreArreglado);
                if (configuracion.TipoDeFicha.GetType().Name == nombre)
                    cBoxTipoFicha.SelectedItem = nombreArreglado;
            }

            var instancesData = from t in Assembly.GetExecutingAssembly().GetTypes()
                                where t.GetInterfaces().Contains(typeof(IData))
                                && t.GetConstructor(Type.EmptyTypes) != null
                                select Activator.CreateInstance(t) as IData;
            foreach (var instance in instancesData)
            {
                string nombre = instance.GetType().Name;
                string nombreArreglado = NombreArreglado(nombre);
                comboBox1.Items.Add(nombreArreglado);
                if (configuracion.Data.GetType().Name == nombre)
                    comboBox1.SelectedItem = nombreArreglado;
            }
        }

        private void AjustesForm_Load(object sender, EventArgs e)
        {

        }

        private void valoresPredeterminadosBtn_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = NombreArreglado(configuracion.Predeterminados["Data"]);
            cBoxPuntuacionFinal.SelectedItem = NombreArreglado(configuracion.Predeterminados["PuntuacionesFinales"]);
            cBoxFinalizarJuego.SelectedItem = NombreArreglado(configuracion.Predeterminados["FormaDeAcabar"]);
            cBoxOrdenJugada.SelectedItem = NombreArreglado(configuracion.Predeterminados["OrdenDeLaJugada"]);
            cBoxTipoFicha.SelectedItem = NombreArreglado(configuracion.Predeterminados["TipoDeFicha"]);
            cBoxLimiteFichas.SelectedItem = configuracion.Predeterminados["MaximoFicha"];
            
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            string miNamespace = "Domino_Virtual.";
            configuracion.EnumMaximoFicha = Enum.Parse<EnumMaximoFicha>((string)cBoxLimiteFichas.SelectedItem);
            configuracion.PuntuacionesFinales = (IPuntuacionFinal)Activator.CreateInstance(Type.GetType(miNamespace + NombreDeClase((string)cBoxPuntuacionFinal.SelectedItem, typeof(IPuntuacionFinal).Name)));
            configuracion.FormaDeAcabar = (IFormaDeAcabar)Activator.CreateInstance(Type.GetType(miNamespace + NombreDeClase((string)cBoxFinalizarJuego.SelectedItem, typeof(IFormaDeAcabar).Name))); 
            configuracion.OrdenDeLaJugada = (IOrdenJugada)Activator.CreateInstance(Type.GetType(miNamespace + NombreDeClase((string)cBoxOrdenJugada.SelectedItem, typeof(IOrdenJugada).Name))); 
            configuracion.TipoDeFicha = (ITipoDeFicha)Activator.CreateInstance(Type.GetType(miNamespace + NombreDeClase((string)cBoxTipoFicha.SelectedItem, typeof(ITipoDeFicha).Name))); 
            configuracion.Data = (IData)Activator.CreateInstance(Type.GetType(miNamespace + NombreDeClase((string)comboBox1.SelectedItem, typeof(IData).Name)));
            configuracion.CantidadARepartir = (int)numericUpDownLimiteXJug.Value;
            switch (configuracion.EnumMaximoFicha)
            {
                case EnumMaximoFicha.Max9:
                    configuracion.MaximoFichas = 9;
                    break;
                case EnumMaximoFicha.Max6:
                    configuracion.MaximoFichas = 6;
                    break;
                case EnumMaximoFicha.Entre6y9:
                    configuracion.MaximoFichas = (int)numericUpDown1.Value;
                    break;
                default:
                    break;
            }
            Close();
        }


        private void ajusteJugadoresBtn_Click(object sender, EventArgs e)
        {
            var form = new AjusteDeJugadores(jugadores);
            form.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CantidadArepartirXJug((int)numericUpDown1.Value);
        }

        public void CantidadArepartirXJug(int limiteDeFichas)
        {
            if ((string)comboBox1.SelectedItem == "Par ")
            {
                limiteDeFichas = (int)Math.Floor((double)CantidadFichasPar(limiteDeFichas) / jugadores.Count);
                numericUpDownLimiteXJug.Maximum = limiteDeFichas;
                numericUpDownLimiteXJug.Value = limiteDeFichas;
            }
            else
            {
                numericUpDownLimiteXJug.Maximum = limiteDeFichas + 1;
                numericUpDownLimiteXJug.Value = limiteDeFichas + 1;
            }
            numericUpDownLimiteXJug.Minimum = 2;
        }

        private int CantidadFichasPar(int limiteDeFichas)
        {
            int total = 0;
            for (int i = 0; i < limiteDeFichas; i += 2)
            {
                for (int j = i; j < limiteDeFichas; j += 2)
                {
                    total++;
                }
            }
            return total;




        }

        private void cBoxLimiteFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string eleccion = (string)cBoxLimiteFichas.SelectedItem;
            if (eleccion == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Entre6y9))
            {
                numericUpDown1.Visible = true;
                CantidadArepartirXJug((int)numericUpDown1.Value);
            }
            if (eleccion == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Max6))
            {
                numericUpDown1.Visible = false;
                CantidadArepartirXJug(6);
            }
            if (eleccion == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Max9))
            {
                numericUpDown1.Visible = false;
                CantidadArepartirXJug(9);
            }
        }

        private void numericUpDownLimiteXJug_ValueChanged(object sender, EventArgs e)
        {
        }

        private string NombreArreglado(string nombreClase)
        {
            string[] vs = nombreClase.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            string nuevoNombre = "";
            if (vs.Length > 1)
                for (int i = 1; i < vs.Length; i++)
                {
                    nuevoNombre += vs[i] + " ";
                }
            return nuevoNombre;
        }

        private string NombreDeClase(string nombreCorto, string nombreInterfaz)
        {
            string nuevoNombre = nombreInterfaz.Substring(1) + "_";
            nuevoNombre += nombreCorto.Substring(0, nombreCorto.Length - 1).Replace(" ", "_");

            return nuevoNombre;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccionPar = "Par ";
            if ((string)comboBox1.SelectedItem == seleccionPar)
            {
                CantidadArepartirXJug((int)numericUpDownLimiteXJug.Value - 1);
            }
            else
            {
                if (cBoxLimiteFichas.SelectedItem == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Max9))
                {
                    CantidadArepartirXJug(9);
                }
                if (cBoxLimiteFichas.SelectedItem == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Max6))
                {
                    CantidadArepartirXJug(6);
                }
                if (cBoxLimiteFichas.SelectedItem == Enum.GetName(typeof(EnumMaximoFicha), EnumMaximoFicha.Entre6y9))
                {
                    CantidadArepartirXJug((int)numericUpDown1.Value);
                }
            }
        }
    }
}

