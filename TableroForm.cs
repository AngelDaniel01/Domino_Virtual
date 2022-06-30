namespace Domino_Virtual
{
    public partial class TableroForm : Form
    {
        public const int ALTO = 80;
        public const int ANCHO = 160;
        public const int ALTO_PEQ = 130;
        public const int ANCHO_PEQ = 65;
        public const int X = 595;
        public const int Y = 335;
        public int DirDer = 1;
        public int DirIzq = 0;
        public int YnuevoIzq = -1;
        public int YnuevoDer = -1;
        public Tuple<int, int> PosIzq = new Tuple<int, int>(X + ANCHO, Y);
        public Tuple<int, int> PosDer = new Tuple<int, int>(X, Y);
        bool salir = false;
        bool ultimaEsExtremoIzq = false;
        bool ultimaEsExtremoDer = false;
        Size sizePeq = new Size();
        Size size = new Size(ANCHO, ALTO);
        Size deLado = new Size(ALTO, ANCHO);


        Juego juego;

        public TableroForm(Juego juego)
        {
            sizePeq.Width = ANCHO_PEQ;
            sizePeq.Height = ALTO_PEQ;
            this.juego = juego;
            this.juego.CargarJuego();
            InitializeComponent();

        }
        #region Dibujar_Fichas_DE_Jugadores
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int count = 0;
            foreach (var fich in juego.JugadoresList[0].Fichas)
            {
                Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fich.Foto + ".png");
                Graphics ficha = panelJugador1.CreateGraphics();
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                ficha.DrawImage(ResizeImage(image, sizePeq), ANCHO_PEQ * count, 0);
                count++;
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            int count = 0;
            foreach (var fich in juego.JugadoresList[1].Fichas)
            {
                Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fich.Foto + ".png");
                Graphics ficha = panelJugador2.CreateGraphics();
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                ficha.DrawImage(ResizeImage(image, sizePeq), ANCHO_PEQ * count, 0);
                count++;

            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            int count = 0;
            if (juego.JugadoresList.Count >= 3)
            {
                foreach (var fich in juego.JugadoresList[2].Fichas)
                {
                    Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fich.Foto + ".png");
                    Graphics ficha = panelJugador3.CreateGraphics();
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    ficha.DrawImage(ResizeImage(image, sizePeq), ANCHO_PEQ * count, 0);
                    count++;

                }
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int count = 0;
            if (juego.JugadoresList.Count > 3)
            {
                foreach (var fich in juego.JugadoresList[3].Fichas)
                {
                    Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fich.Foto + ".png");
                    Graphics ficha = panelJugador.CreateGraphics();
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    ficha.DrawImage(ResizeImage(image, sizePeq), ANCHO_PEQ * count, 0);
                    count++;
                }
            }
        }
        #endregion
        public void PintarTablero()
        {
            int count = 0;
            if (juego.TableroList != null && juego.TableroList.Count > 0)
            {
                int i = 0;
                foreach (var fich in juego.TableroList)
                {

                    Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fich.Foto + ".png");
                    Graphics ficha = panel1.CreateGraphics();
                    if (fich.Virada == true)
                    {
                        int a = fich.Minimo;
                        fich.Minimo = fich.Maximo;
                        fich.Maximo = a;
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    if (fich.EsDoble == true)
                    {
                        int a = size.Width;
                        int b = size.Height;
                        Size size2 = new Size(b, a);
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    if (i < 6)
                    {
                        count++;
                        ficha.DrawImage(ResizeImage(image, size), ANCHO * count, 0);
                    }
                    if (i == 6)
                    {
                        int a = size.Width;
                        int b = size.Height;
                        Size size2 = new Size(b, a);
                        count++;
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        ficha.DrawImage(ResizeImage(image, size2), ANCHO * count, 0);
                    }
                    if (i > 6)
                    {
                        count--;
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        ficha.DrawImage(ResizeImage(image, size), ANCHO * count, ALTO * 2);

                    }
                    i++;
                    Thread.Sleep(2000);
                }
            }
        }

        public void PosEsDoble(int dir, int ladoAJugar)
        {
            if (ladoAJugar == 0)
            {
                if (dir == 0)
                {
                    YnuevoIzq = PosIzq.Item2;
                    PosIzq = new Tuple<int, int>(PosIzq.Item1 - ALTO, PosIzq.Item2 - (ALTO / 2));
                }
                else
                {
                    YnuevoIzq = PosIzq.Item2;
                    PosIzq = new Tuple<int, int>(PosIzq.Item1 + ANCHO, PosIzq.Item2 - (ALTO / 2));
                }
            }
            else
            {
                if (dir == 1)
                {
                    YnuevoDer = PosDer.Item2;
                    PosDer = new Tuple<int, int>(PosDer.Item1 + ANCHO, PosDer.Item2 - ALTO / 2);
                }
                else
                {
                    YnuevoDer = PosDer.Item2;
                    PosDer = new Tuple<int, int>(PosDer.Item1 - ALTO, PosDer.Item2 - ALTO / 2);
                }
            }

        }
        public void Posicion(IJugador jug, Ficha fichaMomento)
        {
            if (YnuevoIzq != -1)
            {
                if (jug.JugarPor == 0 && DirIzq == 1)
                {
                    PosIzq = new Tuple<int, int>(PosIzq.Item1 - ALTO, PosIzq.Item2);
                }
                PosIzq = new Tuple<int, int>(PosIzq.Item1, YnuevoIzq);
                YnuevoIzq = -1;
            }

            if (YnuevoDer != -1)
            {
                if (jug.JugarPor == 1 && DirDer == 0)
                {
                    PosDer = new Tuple<int, int>(PosDer.Item1, PosDer.Item2);
                }
                if (jug.JugarPor == 1 && DirDer == 1)
                {
                    PosDer = new Tuple<int, int>(PosDer.Item1 - ALTO, PosDer.Item2);
                }
                PosDer = new Tuple<int, int>(PosDer.Item1, YnuevoDer);
                YnuevoDer = -1;
            }


            if (jug.JugarPor == 0)
            {
                if (DirIzq == 0)
                {
                    if (PosIzq.Item1 - ANCHO > 0)
                    {
                        if (fichaMomento.EsDoble)
                        {
                            PosEsDoble(DirIzq, jug.JugarPor);
                            fichaMomento.Vertical = true;
                        }
                        else
                        {
                            PosIzq = new Tuple<int, int>(PosIzq.Item1 - ANCHO, PosIzq.Item2);
                        }
                    }
                    else
                    {
                        fichaMomento.Vertical = true;
                        //girar 90 grados decirselo a la ficha
                        PosIzq = new Tuple<int, int>(PosIzq.Item1, PosIzq.Item2 - ANCHO);
                        DirIzq = 1;
                        ultimaEsExtremoIzq = true;
                    }
                }
                else
                {
                    if (PosIzq.Item1 + ANCHO * 2 < panel1.Size.Width)
                    {
                        if (ultimaEsExtremoIzq)
                        {
                            ultimaEsExtremoIzq = false;
                            PosIzq = new Tuple<int, int>(PosIzq.Item1 + ALTO, PosIzq.Item2);
                        }
                        else
                        {
                            if (fichaMomento.EsDoble)
                            {
                                PosEsDoble(DirIzq, jug.JugarPor);
                                fichaMomento.Vertical = true;

                            }
                            else
                            {
                                PosIzq = new Tuple<int, int>(PosIzq.Item1 + ANCHO, PosIzq.Item2);
                            }
                        }

                    }
                    else
                    {
                        DirIzq = 0;
                        ultimaEsExtremoIzq = true;
                        PosIzq = new Tuple<int, int>(PosIzq.Item1 + ALTO, PosIzq.Item2 - ANCHO);

                    }


                }
            }
            else
            {
                if (DirDer == 1)
                {
                    if (PosDer.Item1 + ANCHO * 2 < panel1.Size.Width)
                    {
                        if (fichaMomento.EsDoble)
                        {
                            PosEsDoble(DirDer, jug.JugarPor);
                            fichaMomento.Vertical = true;
                        }
                        else
                        {
                            PosDer = new Tuple<int, int>(PosDer.Item1 + ANCHO, PosDer.Item2);
                        }
                    }
                    else
                    {
                        fichaMomento.Vertical = true;
                        //girar 90 grados decirselo a la ficha
                        PosDer = new Tuple<int, int>(PosDer.Item1 + ALTO, PosDer.Item2 + ALTO);
                        DirDer = 0;
                        ultimaEsExtremoDer = true;
                    }
                }
                else
                {
                    if (PosDer.Item1 - ANCHO > 0)
                    {
                        if (ultimaEsExtremoDer)
                        {
                            ultimaEsExtremoDer = false;
                            PosDer = new Tuple<int, int>(PosDer.Item1 - ANCHO, PosDer.Item2 + ALTO);
                        }
                        else
                        {
                            if (fichaMomento.EsDoble)
                            {
                                PosEsDoble(DirDer, jug.JugarPor);
                                fichaMomento.Vertical = true;
                            }
                            else
                            {
                                PosDer = new Tuple<int, int>(PosDer.Item1 - ANCHO, PosDer.Item2);
                            }
                        }
                    }
                    else
                    {
                        DirDer = 1;
                        ultimaEsExtremoDer = true;
                        PosDer = new Tuple<int, int>(PosDer.Item1, PosDer.Item2 + ANCHO);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        public Image ResizeImage(Image a, Size b)
        {
            return (Image)(new Bitmap(a, b));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Pausar_Click(object sender, EventArgs e)
        {

        }

        private void TableroForm_Load(object sender, EventArgs e)
        {

        }

        private void Empezar_Click_1(object sender, EventArgs e)
        {
            int jugadorAJugar = juego.JugadoresList.Count - 1;
            bool termino = false;
            bool pausado = false;
            while (!termino && !salir)
            {

                if (!pausado)
                {
                    jugadorAJugar = juego.JugadorAJugar(jugadorAJugar);
                    Ficha fichaAJugar = juego.JuegaUnJugador(jugadorAJugar);
                    if (fichaAJugar != null)
                    {
                        Image image = Image.FromFile("C:/Users/Angel/Desktop/Proyecto Final a entregar/Domino_Virtual/Fotos_Domino_blancas/domino-white-" + fichaAJugar.Foto + ".png");
                        Graphics ficha = panel1.CreateGraphics();
                        Posicion(juego.JugadoresList[jugadorAJugar], fichaAJugar);

                        if (fichaAJugar.Vertical)
                        {
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }

                        if (fichaAJugar.Virada)
                        {
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }

                        if (juego.JugadoresList[jugadorAJugar].JugarPor == 0)
                        {
                            if (fichaAJugar.Vertical)
                            {
                                ficha.DrawImage(ResizeImage(image, deLado), PosIzq.Item1, PosIzq.Item2);
                            }
                            else
                            {
                                ficha.DrawImage(ResizeImage(image, size), PosIzq.Item1, PosIzq.Item2);
                            }
                        }
                        else
                        {
                            if (fichaAJugar.Vertical)
                            {
                                ficha.DrawImage(ResizeImage(image, deLado), PosDer.Item1, PosDer.Item2);
                            }
                            else
                            {
                                ficha.DrawImage(ResizeImage(image, size), PosDer.Item1, PosDer.Item2);
                            }
                        }
                        //Thread.Sleep(1500);
                    }

                }
                if (juego.FormaDeAcabarClasica(juego.JugadoresList, juego.JugadoresList[jugadorAJugar], juego.PasesMesa))
                {
                    termino = true;
                    /////////////////////decirle a lizfe q es innecesario bool termino xk el break pincha ya
                    break;
                }


            }


        }

        private void Boton_Salir_Click(object sender, EventArgs e)
        {
            salir = true;
        }
    }
}