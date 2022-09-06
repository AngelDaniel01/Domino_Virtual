namespace Domino_Virtual
{
    public partial class TableroForm : Form
    {
        public const int ALTO = 80;
        public const int ANCHO = 160;
        public const int ALTO_PEQ = 130;
        public const int ANCHO_PEQ = 65;
        int X;
        int Y;
        bool pausado = false;
        bool salir = false;
        bool acabo = false;
        Size sizePeq = new Size();
        Size size = new Size(ANCHO, ALTO);
        Size deLado = new Size(ALTO, ANCHO);
        Posicion posicionIzq;
        Posicion posicionDer;
        Tuple<int, int> Disponibles = new Tuple<int, int>(-1, -1);
        Juego juego;
        string proyectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        int jugadorAJugar;
        public TableroForm(Juego juego)
        {

            InitializeComponent();

            jugadorAJugar = juego.Jugadores.Count - 1;
            X = panel1.Size.Width / 2;
            Y = panel1.Size.Height / 2;
            sizePeq.Width = ANCHO_PEQ;
            sizePeq.Height = ALTO_PEQ;
            this.juego = juego;
            this.juego.CargarJuego();
            posicionIzq = new Posicion(X + ANCHO, Y);
            posicionIzq.JuegaParaLaIzquierda = true;
            posicionDer = new Posicion(X, Y);

            for (int i = 0; i < juego.Jugadores.Count; i++)
            {
                string nombre = string.IsNullOrEmpty(juego.Jugadores[i].Nombre) ? "Jugador " + i : juego.Jugadores[i].Nombre;
                switch (i)
                {
                    case 0:
                        groupBox1.Text = nombre;
                        break;
                    case 1:
                        groupBox2.Text = nombre;
                        groupBox2.Visible = true;
                        break;
                    case 2:
                        groupBox3.Text = nombre;
                        groupBox3.Visible = true;

                        break;
                    case 3:
                        groupBox4.Text = nombre;
                        groupBox4.Visible = true;

                        break;
                    default:
                        break;
                }
            }

        }
        #region Dibujar_Fichas_DE_Jugadores

        private void RefrescarFichasJugador(int posicion)
        {
            if (posicion < juego.Jugadores.Count)
            {
                Graphics graphics;
                switch (posicion)
                {

                    case 0:
                        graphics = panelJugador1.CreateGraphics();
                        break;
                    case 1:
                        graphics = panelJugador2.CreateGraphics();
                        break;
                    case 2:
                        graphics = panelJugador3.CreateGraphics();
                        break;
                    case 3:
                        graphics = panelJugador.CreateGraphics();
                        break;
                    default:
                        graphics = panelJugador1.CreateGraphics();
                        break;
                }
                graphics.Clear(BackColor);

                IJugador jugador = juego.Jugadores[posicion];
                int count = 0;
                foreach (var fich in jugador.Fichas)
                {
                    Image image = Image.FromFile(proyectPath + juego.Configuracion.TipoDeFicha.Direccion + fich.Foto + ".png");
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    graphics.DrawImage(ResizeImage(image, sizePeq), ANCHO_PEQ * count, 0);
                    count++;
                }
            }
        }
        #endregion

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
            pausado = false;
        }

        private void Pausar_Click(object sender, EventArgs e)
        {
            pausado = true;
        }

        private void TableroForm_Load(object sender, EventArgs e)
        {
        }
        public void ComenzarJuego()
        {
            bool termino = false;
            while (!termino && !salir)
            {

                if (!pausado)
                {
                    jugadorAJugar = juego.JugadorAJugar(jugadorAJugar);
                    Ficha fichaAJugar = juego.JuegaUnJugador(jugadorAJugar);
                    if (fichaAJugar != null)
                    {
                        Image image = Image.FromFile(proyectPath + juego.Configuracion.TipoDeFicha.Direccion + fichaAJugar.Foto + ".png");
                        Graphics ficha = panel1.CreateGraphics();
                        if (juego.Jugadores[jugadorAJugar].JugarPor == 0)
                        {
                            ActualizarPosicionIzq(fichaAJugar);
                        }
                        else
                        {
                            ActualizarPosicionDer(fichaAJugar);
                        }


                        GirarFicha(fichaAJugar, image, juego.Jugadores[jugadorAJugar]);

                        if (juego.Jugadores[jugadorAJugar].JugarPor == 0)
                        {
                            if (posicionIzq.EsVertical)
                            {
                                ficha.DrawImage(ResizeImage(image, deLado), posicionIzq.X, posicionIzq.Y);

                            }
                            else
                            {
                                ficha.DrawImage(ResizeImage(image, size), posicionIzq.X, posicionIzq.Y);
                            }
                        }
                        else
                        {
                            if (posicionDer.EsVertical)
                            {
                                ficha.DrawImage(ResizeImage(image, deLado), posicionDer.X, posicionDer.Y);

                            }
                            else
                            {
                                ficha.DrawImage(ResizeImage(image, size), posicionDer.X, posicionDer.Y);
                            }

                        }

                        RefrescarFichasJugador(jugadorAJugar);
                        Thread.Sleep(800);
                    }

                    juego.Configuracion.OrdenDeLaJugada.Implementacion(juego, juego.Jugadores[jugadorAJugar], fichaAJugar);
                }
                if (juego.Configuracion.FormaDeAcabar.Implementacion(juego, juego.Jugadores[jugadorAJugar]))
                {
                    termino = true;
                }
            }
            Tuple<int, int> indJug = juego.Configuracion.PuntuacionesFinales.Implementacion(juego.Jugadores);
            string nombreJug = string.IsNullOrEmpty(juego.Jugadores[indJug.Item1].Nombre) ? "jugador " + indJug.Item1 : juego.Jugadores[indJug.Item1].Nombre;
            string mensaje = "Ha gandado " + nombreJug + " con " + indJug.Item2 + " puntos" + "\n Quiere volver a jugar?";
            string title = "Felicidades";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mensaje, title, buttons);
            if (result == DialogResult.Yes)
            {
                Empezar.Invoke(CambiarATrueEmpezar);
                juego.CargarJuego();
            }
            else
            {
                acabo = true;
            }


        }
        public void CambiarATrueEmpezar()
        {
            panel1.Refresh();
            panelJugador1.BackColor = BackColor;
            panelJugador2.BackColor = BackColor;
            panelJugador3.BackColor = BackColor;
            panelJugador.BackColor = BackColor;
            juego.Sentido = 1;
            juego.PasesMesa = 0;
            jugadorAJugar = juego.Jugadores.Count - 1;
            X = panel1.Size.Width / 2;
            Y = panel1.Size.Height / 2;
            pausado = false;
            salir = false;
            acabo = false;
            Disponibles = new Tuple<int, int>(-1, -1);
            posicionIzq = new Posicion(X + ANCHO, Y);
            posicionIzq.JuegaParaLaIzquierda = true;
            posicionDer = new Posicion(X, Y);
            posicionDer.JuegaParaLaIzquierda = false;

            for (int i = 0; i < juego.Jugadores.Count; i++)
            {
                string nombre = string.IsNullOrEmpty(juego.Jugadores[i].Nombre) ? "Jugador " + i : juego.Jugadores[i].Nombre;
                switch (i)
                {
                    case 0:
                        groupBox1.Text = nombre;
                        break;
                    case 1:
                        groupBox2.Text = nombre;
                        groupBox2.Visible = true;
                        break;
                    case 2:
                        groupBox3.Text = nombre;
                        groupBox3.Visible = true;

                        break;
                    case 3:
                        groupBox4.Text = nombre;
                        groupBox4.Visible = true;

                        break;
                    default:
                        break;
                }
            }


            Empezar.Enabled = true;
        }

        private async void Empezar_Click_1(object sender, EventArgs e)
        {
            Empezar.Enabled = false;
            await Task.Run(() => ComenzarJuego());
            if (acabo)
            {
                this.Close();
            }
        }

        private void Boton_Salir_Click(object sender, EventArgs e)
        {
            salir = true;

        }

        public void GirarFicha(Ficha ficha, Image imagen, IJugador jugador)
        {
            if (ficha.Virada)
            {
                imagen.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            if (ficha.EsDoble)
            {
                if (jugador.JugarPor == 0)
                {
                    if (posicionIzq.EsVertical)
                    {
                        imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    }
                }
                else
                {
                    if (posicionDer.EsVertical)
                    {
                        imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                }

            }
            else
            {
                if (jugador.JugarPor == 0)
                {
                    if (posicionIzq.EsVertical)
                    {
                        imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    else
                    {
                        if (!posicionIzq.JuegaParaLaIzquierda)
                        {
                            imagen.RotateFlip(RotateFlipType.Rotate180FlipNone);

                        }
                    }
                }
                else
                {
                    if (posicionDer.EsVertical)
                    {
                        imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    else
                    {
                        if (posicionDer.JuegaParaLaIzquierda)
                        {
                            imagen.RotateFlip(RotateFlipType.Rotate180FlipNone);


                        }
                    }
                }
            }



        }
        private void ActualizarPosicionIzq(Ficha fichaAPoner)
        {
            posicionIzq.AnteriorEsExtremo = posicionIzq.EsExtremo;
            posicionIzq.AnteriorEsVertical = posicionIzq.EsVertical;

            posicionIzq.EsExtremo = false;
            posicionIzq.EsVertical = false;

            if (posicionIzq.JuegaParaLaIzquierda)
            {
                if (posicionIzq.X - ANCHO < 0) //no cabe, hay que doblar
                {
                    posicionIzq.Y -= ANCHO;
                    posicionIzq.JuegaParaLaIzquierda = !posicionIzq.JuegaParaLaIzquierda;
                    posicionIzq.EsExtremo = posicionIzq.EsVertical = true;
                    if (posicionIzq.YAnterior > -1)
                    {
                        posicionIzq.YAnterior = -1;
                    }
                }
                else
                {
                    ActualizarYFichaVertical(posicionIzq);
                    if (fichaAPoner.EsDoble)
                    {
                        if (posicionIzq.AnteriorEsExtremo)
                        {
                            posicionIzq.X -= ANCHO;
                        }
                        else
                        {
                            posicionIzq.X -= ALTO;

                            posicionIzq.YAnterior = posicionIzq.Y;
                            posicionIzq.Y -= ALTO / 2;

                            posicionIzq.EsVertical = true;
                        }

                    }
                    else
                        posicionIzq.X -= ANCHO;
                }
            }
            else
            {
                if (posicionIzq.X + (ANCHO * 2) > panel1.Size.Width) //no cabe, hay que doblar
                {
                    if (!posicionIzq.AnteriorEsVertical)
                        posicionIzq.X += ALTO;
                    posicionIzq.Y -= ANCHO;
                    posicionIzq.EsVertical = posicionIzq.EsExtremo = posicionIzq.JuegaParaLaIzquierda = true;
                    if (posicionIzq.YAnterior > -1)
                    {
                        posicionIzq.YAnterior = -1;
                    }

                }
                else
                {
                    ActualizarYFichaVertical(posicionIzq);
                    if (fichaAPoner.EsDoble)
                    {
                        if (posicionIzq.AnteriorEsExtremo)
                        {
                            posicionIzq.X += ALTO;
                        }
                        else
                        {
                            posicionIzq.X += ANCHO;

                            posicionIzq.YAnterior = posicionIzq.Y;
                            posicionIzq.Y -= ALTO / 2;

                            posicionIzq.EsVertical = true;
                        }
                    }
                    else
                    {
                        if (posicionIzq.AnteriorEsVertical)
                            posicionIzq.X += ALTO;
                        else
                            posicionIzq.X += ANCHO;
                    }
                }
            }
        }
        private void ActualizarPosicionDer(Ficha fichaAPoner)
        {
            posicionDer.AnteriorEsExtremo = posicionDer.EsExtremo;
            posicionDer.AnteriorEsVertical = posicionDer.EsVertical;

            posicionDer.EsExtremo = false;
            posicionDer.EsVertical = false;

            if (posicionDer.JuegaParaLaIzquierda)
            {
                if (posicionDer.X - ANCHO < 0) //no cabe, hay que doblar
                {
                    if (posicionDer.AnteriorEsVertical)
                        posicionDer.Y += ANCHO;
                    else
                        posicionDer.Y += ALTO;
                    posicionDer.JuegaParaLaIzquierda = !posicionDer.JuegaParaLaIzquierda;
                    posicionDer.EsExtremo = posicionDer.EsVertical = true;
                    if (posicionDer.YAnterior > -1)
                    {
                        posicionDer.YAnterior = -1;
                    }
                }
                else
                {
                    ActualizarYFichaVertical(posicionDer);
                    if (fichaAPoner.EsDoble)
                    {
                        if (posicionDer.AnteriorEsExtremo)
                        {
                            posicionDer.X -= ANCHO;
                            posicionDer.Y += ALTO;
                        }
                        else
                        {
                            posicionDer.X -= ALTO;

                            posicionDer.YAnterior = posicionDer.Y;
                            posicionDer.Y -= ALTO / 2;

                            posicionDer.EsVertical = true;
                        }
                    }
                    else
                    {
                        if (posicionDer.AnteriorEsExtremo)
                            posicionDer.Y += ALTO;
                        posicionDer.X -= ANCHO;
                    }
                }
            }
            else
            {
                if (posicionDer.X + (ANCHO * 2) > panel1.Size.Width) //no cabe, hay que doblar
                {
                    if (!posicionDer.AnteriorEsVertical)
                    {
                        posicionDer.X += ALTO;
                        posicionDer.Y += ALTO;
                    }
                    else
                        posicionDer.Y += ANCHO;
                    posicionDer.EsVertical = posicionDer.EsExtremo = posicionDer.JuegaParaLaIzquierda = true;
                    if (posicionDer.YAnterior > -1)
                    {
                        posicionDer.YAnterior = -1;
                    }

                }
                else
                {
                    if (fichaAPoner.EsDoble)
                    {
                        if (posicionDer.AnteriorEsExtremo)
                        {
                            posicionDer.X += ALTO;
                            posicionDer.Y += ALTO;
                        }
                        else
                        {
                            posicionDer.X += ANCHO;

                            posicionDer.YAnterior = posicionDer.Y;
                            posicionDer.Y -= ALTO / 2;

                            posicionDer.EsVertical = true;
                        }
                    }
                    else
                    {
                        if (posicionDer.AnteriorEsVertical)
                        {
                            ActualizarYFichaVertical(posicionDer);
                            posicionDer.X += ALTO;
                        }
                        else
                            posicionDer.X += ANCHO;

                        if (posicionDer.AnteriorEsExtremo)
                            posicionDer.Y += ALTO;
                    }
                }
            }
        }
        private void ActualizarYFichaVertical(Posicion posicion)
        {
            if (posicion.YAnterior != -1)
            {
                posicion.Y = posicion.YAnterior;
                posicion.YAnterior = -1;
            }
        }
        private class Posicion
        {
            public Posicion(int x, int y)
            {
                X = x;
                Y = y;
                YAnterior = -1;
            }
            public int X { get; set; }
            public int Y { get; set; }
            public bool AnteriorEsExtremo { get; set; }
            public bool AnteriorEsVertical { get; set; }
            public bool EsExtremo { get; set; }
            public bool EsVertical { get; set; }
            public int YAnterior { get; set; }
            public bool JuegaParaLaIzquierda { get; set; }

        }
        private void panelJugador1_Paint(object sender, PaintEventArgs e)
        {
            RefrescarFichasJugador(0);
        }
        private void panelJugador2_Paint(object sender, PaintEventArgs e)
        {
            RefrescarFichasJugador(1);
        }
        private void panelJugador3_Paint(object sender, PaintEventArgs e)
        {
            RefrescarFichasJugador(2);
        }
        private void panelJugador_Paint(object sender, PaintEventArgs e)
        {
            RefrescarFichasJugador(3);
        }
    }
}