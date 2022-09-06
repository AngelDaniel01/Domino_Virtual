namespace Domino_Virtual
{
    public partial class LaunchForm : Form
    {
        Juego juego;
        public LaunchForm()
        {
            juego = new Juego();
            InitializeComponent();

        }

        private void ajustesBtn_Click_1(object sender, EventArgs e)
        {
            var ajustes = new AjustesForm(juego.Configuracion);
            ajustes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableroForm tableroForm = new TableroForm(juego);
            tableroForm.Show();
        }

        private void LaunchForm_Load(object sender, EventArgs e)
        {

        }
    }
}