namespace Domino_Virtual
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // cambio de prueba
            Juego juego = new Juego();
            JugRandom jugRandom = new JugRandom();
            JugRandom jugRandom2 = new JugRandom();
            //JugRandom jugRandom3 = new JugRandom();
            //JugRandom jugRandom4 = new JugRandom();
            juego.JugadoresList.Add(jugRandom);
            juego.JugadoresList.Add(jugRandom2);
            //juego.JugadoresList.Add(jugRandom3);
            //juego.JugadoresList.Add(jugRandom4);
            ApplicationConfiguration.Initialize();
            Application.Run(new TableroForm(juego));
        }
    }
}