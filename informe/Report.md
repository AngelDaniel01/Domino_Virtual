# Report
## Etapas del informe:
- ¿Que es?
- ¿Que tiene detras?
- ¿Como se ve?

## ``¿Que es?``
- Este proyecto es una simulacion del conocido juego ``Domino``, donde en todo momento se puede apreciar las jugadas que hacen los jugadores, paso a paso, el cual se puede pausar y ser analizado en cualquier momento. Es ``totalmente personalizable`` con respecto a varios aspectos mas adelante explicados.

## ``¿Como se ve?``
- Tiene varios Formularios, en esta seccion mostrare algunas ``fotos`` de como se ven los formularios de forma predeterminada:
    - Formulario de ``Inicio``:
        ![](Inicio.png)
    - Formulario de los ``Ajustes``:
        ![](Ajustes.png)
    - Formulario de ``Ajustes de jugadores``:
        ![](AjustesDeJugadores.png)
    - Formulario de ``Añadir un jugador``:                
        ![](AnadirUnJugador.png)
    - Formulario del ``Tablero``:
        ![](Tablero.png)
    - Formulario del ``Tablero en curso``:
        ![](TableroAMedias.png)
    - Formulario del ``Tablero finalizado``:
        ![](TableroTerminado.png)


## ``¿Que tiene detras?``
### Esta es la seccion mas interesante, ``empezemos!!!!``
#### Tenemos las siguientes ``interfaces``:
```cs
public interface IJugador
    {
        public Ficha Jugar(int FichaIzq, int FichaDer);
        public string Nombre { get; set; }
        public List<Ficha> Fichas { get; set; }
        public bool QuedanFichas { get; }
        public int PasesConsecutivos { get; set; }
        public int JugarPor { get; set; }
    }
```
- Todos los jugadores tendran que implementar su forma de ``Jugar``, devolviendo la ficha que va a jugar o null si no lleva.
- Tiene la propiedad ``Nombre``, que sera el nombre del jugador.
- Una lista de fichas ``Fichas``, que son las fichas actuales del jugador.
- Un bool ``QuedanFichas``, es true mientras Fichas.Count() > 0.
- Int ``PasesConsecutivos``, el cual se suma cada vez que devuelve null un jugador, se reinicia cuando un jugador devuelve una ficha.
- Int ``JugarPor``, el cual toma 2 valores, 0 para la izquierda y 1 para la derecha.
```cs
public interface IData
    {
        public void CrearData();
        public List<Ficha> FichaList { get; set; }
        public int FichaMax { get; set; }
    }
``` 
- Todas las Datas tendran que implementar su forma de ``CrearData()``.
- Lista de fichas ``FichaList``, contiene las fichas de la Data entera una vez creada.
- Una propiedad que determina hasta que ``numero`` se creara Data.
```cs
public interface ITipoDeFicha
    {
        public string Direccion { get;}
    }
```
- Una propiedad en la cual se le dice la ``Direccion`` de la carpeta donde se encuentran las imagenes que quiere crear, dandole los respectivos valores a las imagenes, ya que cada ficha tiene la forma que se desee, pero debe tener valor cada una de ella.
```cs
public interface IFormaDeAcabar
    {
        public bool Implementacion(Juego juego, IJugador jugadorActual);
    }
```
- El metodo ``Implementacion``, el cual devuelve true cuando considere que haya ganado.
```cs
    public interface IOrdenJugada
    {
        public void Implementacion(Juego juego, IJugador jugadorActual, Ficha ficha);
    }
```
- El metodo ``Implementacion``, el cual le cambia el valor la variable global, ``sentido``, dependiendo de la forma que quiera, el cual es quien dirige la forma en que va el juego. 
```cs
public interface IPuntuacionFinal
    {
        public Tuple<int,int> Implementacion(List<IJugador> lista);
    }
```
- Tiene un metodo ``Implementacion``,  el cual tiene la forma de contar los puntos y dar un ganador, devolviendo una Tupla con ``(Ganador,(Puntos con los que gano))`` respectivamente.
#### Las diferentes ``clases`` que ``heredan`` de las ``interfaces``:
- IJugador:
    - JugBotaGorda, jugador que juega a la clasica estrategia de botar la ficha con mas puntos.
    - JugMedioPensador, jugador que tiene una pequeña estrategia inteligente, juega la ficha disponible que mas de ese valor tiene.
    - JugPrimerEncuentro, jugador el cual juega la primera ficha de izquierda a derecha que encuentre que sea disponible.
    - JugRandom, jugador que escoge una ficha aleatoria y si esta disponible para jugarla pues juega esa, sino busca otra aleatoriamente
- IData:
    - Data_Clasica, el cual crea la forma clasica de las datas, del 1-9.
    - Data_Par, el cual crea la data con solo numeros par, no existe ni el 1, ni el 3...
- ITipoDeFicha:
    - TipoDeFicha_Clasica, son las fichas clasicas, blancas con hoyitos negros.
    - TipoDeFicha_Negra, son las fichas parecidas a las clasicas, pero estas de color negro y hoyitos blancos.
- IFormaDeAcabar:
    - FormaDeAcabar_Clasica, la clasica forma de acabar, que alguien se quede sin fichas o que se quede sin fichas disponibles para jugar los jugadores
    - FormaDeAcabar_2_Pases_Consecutivos, forma en la cual, a parte de acabar como la forma clasica, si un jugador se pasa dos veces consecutivas, acabara el juego.
- IOrdenJugada:
    - OrdenJugada_Clasica, juega el siguiente jugador y cuando llega al ultimo, juega nuevamente el primero,  lo que es la forma clasica de siempre.
    - OrdenJugada_Inversa_Al_Pasarse, juega de forma clasica, pero al pasarse un jugador, se invierte el sentido del juego
- IPuntuacionFinal:
    - PuntuacionFinal_Clasica, suma normal los puntos de cada ficha del jugador, la forma clasica
    - PuntuacionFinal_DoblesDobles, suma los puntos de cada ficha del jugador, pero si se encuentra un doble, vale doble el valor de la ficha.
### Las ``clases`` que implemente:
- Ficha:
    ```cs
    public int Maximo { get; set; }
    ```
    - Propiedad que es el valor maximo de los dos valores de una ficha
    ```cs
    public int Minimo { get; set; }
    ```
    - Propiedad que es el valor minimo de los dos valores de una ficha
    ```cs
    public bool EsDoble { get; set; }
    ```
    - Propiedad que si los dos valores de la ficha son iguales, es true.
    ```cs
    public bool Virada { get; set; }
    ```
    - Propiedad que se le asigna si la ficha va virada, o sea, no se puso del orden (minimo-maximo)
    ```cs
    public string Foto;
    ```
    - Foto que se le asigna a la variable dependiendo de los valores
- Juego:
    ```cs
     public void Repartir(List<IJugador> jugadores, List<Ficha> listaFichas, int cantDFichasXJug)
    ```
    - Reparte las fichas a los jugadores, dado una lista de fichas y cuantas por jugadores
    ```cs
    public void CargarJuego()
    ```
    - Carga el juego dados los valores predeterminados o seleccionados
    ```cs
    public Ficha JuegaUnJugador(int jugToca)
    ```
    - Llama a la propiedad del jugador que juega, y la ficha es agregada a una lista llamada Tablero.


- Configuracion:
    ```cs
        public int CantidadARepartir;
    ```
    ```cs
        public IData Data { get; set; }
    ```
    ```cs
        public EnumMaximoFicha EnumMaximoFicha { get; set; }
    ```
    ```cs
        public int MaximoFichas { get; set; }
    ```
    ```cs
        public IPuntuacionFinal PuntuacionesFinales { get; set; }
    ```
    ```cs
        public IFormaDeAcabar FormaDeAcabar { get; set; }
    ```
    ```cs
        public IOrdenJugada OrdenDeLaJugada { get; set; }
    ```
    ```cs
        public ITipoDeFicha TipoDeFicha { get; set; }
    ```
    ```cs
        public List<IJugador> Jugadores { get; set; }
    ```
    - Estos son los aspectos a personalizar que se guardan en configuracion, ya sean los predeterminados o los elegidos por el usuario.
    ### Tenemos el codigo del Formulario Inicio:
    - Basicamnete este tiene dos botones, ``Jugar`` y ``Ajustes``, el primero te dirige hacia el formulario ``Tablero``, y el otro para el formulario ``Ajustes``
    ### Tenemos el codigo del Formulario Ajustes:
    - En resumen, este adapta los valores selecionados por el usuario, desde los ComboBox, los NumericUpDown y todo, para guardarlos en una configuracion, que sera proximamente la que se use a la hora de ejecutar el juego
    - Como codigos curiosos a explicar estan:
    ```cs
    var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof(Interfaz))
                    && t.GetConstructor(Parametros del constructor) != null
                    select Activator.CreateInstance(t) as Interfaz;

    ```
    - Este crea instancias de todas las clases que heredan de dicha interfaz, esto me ayuda bastante, ya que lo unico que debe hacer un nuevo programador si quiere añadir una variedad mas a alguna implementacion es crear una clase, heredar de la interfaz correspondiente, el nombre de la clase debe ser el nombre de la interfaz seguido de un guion bajo, y el nombre que usted desee, para asi junto con el metodo que le mostrare a continuacion, tomo automaticamente los nombres de la clase y los añado a los comboBox, y todo asi esta hecho de forma tal para que tenga que editar la menor cantidad de codigo para añadir implementaciones.
    ```cs
    private string NombreArreglado(string nombreClase)        
    ```
    - Este metodo arregla el nombre dado el nombre de la clase, devuelve solo lo que tienes despues del guion bajo antes comentado, asi, todo sale de una manera mas optima y muy facil.
    - Tambien tiene dos botones con gran importancia, primero un boton llamado ``Volver a los Valores``, el cual da el valor de predeterminado a todos los aspectos visibles en ese formulario, y el boton ``Ajuste de jugadores``, que te dirige al formulario Ajuste de jugadores que a continuacion se explicara.
    ### Tenemos el codigo del Formulario Ajustes de juagdores:
    - Basicamente, este contiene un DataGridView, que contiene los nombre y forma de jugar de los jugadores que participaran en el juego
    - Tiene las opciones de eliminar un jugador, que minimo podras jugar con dos jugadores, de lo contrario saldra un messageBox diciendo que no puede eliminar mas jugadores
    - Opcion de editar, que te dirige al formulario ``Añadir un jugador``, pudes cambiar el nombre y la forma de jugar del jugador seleccionado
    - Agregar un jugador, el cual tambien te dirige hacia ``Añadir un jugador`` , donde introduciras el nombre del jugador y la forma de jugar del mismo. Si intentas añadir mas de 4 jugadores saldra un MessageBox que dira que no se permiten agregar mas jugadores. 
    - Dos botones que se muestran como dos flechas, hacia arriba y hacia abajo, estos mueven el orden de los jugadores para que elijas el orden en el que se jugara.
    ### Tenemos el codigo del Formulario Añadir un jugador:
    - Este formulario como explique anteriormente, se le añaden los nombres y la forma de jugar de cada jugador.
    ### Tenemos el codigo del Formulario Tablero:
- Como elementos a destacar tenemos los siguientes botones:
    - ``Pausa``, el cual al pulsarse en cualquier momento del juego pausa el hilo de la jugada, dado que cambia el valor a un variable global que determina si el juego debe estar en curso o no.
    - ``Reanudar``, el cual como el anterior, cambia el valor de la variable global y hace que continue el juego
    - ``Salir``, el cual tambien cambia el valor a una variable global que hace que el juego acabe inmediatamente, dando el ganador en ese momento.
    - ``Empezar``, este boton le da paso a que comience el juego en un hilo diferente.
- El metodo ``ComenzarJuego``, imprime las fichas que juega el jugador en el Panel, verifica si ha terminado el juego y cuando termina muestra un MessageBox con el ganador y los puntos con los que gano, este tiene dos opciones para volver a jugar o no, si desea volver a jugar se limpia el Panel y se vuelven a repartir las fichas de los jugadores.
```cs
  public void ComenzarJuego()
  ```
- Los metodos siguientes son todos con el objetivo de que la forma, la posicion, y la manera logica de las fichas a la hora de imprimir sean la mejor posible, estos metodos fueron los que mas dolores de cabeza me causaron  y unos de los que mas horas se le dedico en la elaboracion de este proyecto.
```cs
public void GirarFicha(Ficha ficha, Image imagen, IJugador jugador)
private void ActualizarPosicionIzq(Ficha fichaAPoner)
private void ActualizarPosicionDer(Ficha fichaAPoner)
private void ActualizarYFichaVertical(Posicion posicion)
```