using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;


namespace Mazerunners
{
    public partial class Form1 : Form
    {
        private Juego juego;

        private Graphics g;
        private Keys movimiento;
        private int turno_del_jugador;
        private List<Jugador> jugadores;

        private Laberinto laberinto;

        private Bitmap img;
        //private Image backgroundImage;


        private bool laberintoDibujado;
        public Form1(int[] n)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(0, 0);

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            laberinto = new Laberinto();
            jugadores = new List<Jugador>();

            //backgroundImage = Image.FromFile("img/escenario.png");




            for (int i = 0; i < 2; i++)
            {
                Personaje personaje = new Personaje(n[i]);
                jugadores.Add(new Jugador(laberinto, i + 1, personaje)); // Posición inicial del jugador

            }

            juego = new Juego(laberinto, jugadores, 2, n);
            //jugador = new Bitmap("Jugador.png");
            g = this.CreateGraphics();

            turno_del_jugador = 0;

            laberintoDibujado = false;
            label5.Text = "Jugador1: "+jugadores[0].Personaje.Nombre_del_Personaje;
            label6.Text = "Jugador2: "+jugadores[1].Personaje.Nombre_del_Personaje;
        }


//Encargado de llamar a los m'etodos para graficar de la clase jugador
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (!laberintoDibujado)
            {
                juego.GraficarPermanente(g);
                laberintoDibujado = true;
            }


            if (g != null && this.Visible)
            {
                // Crear un buffer con fondo transparente
                BufferedGraphicsContext bfc = BufferedGraphicsManager.Current;
                BufferedGraphics bf = bfc.Allocate(g, this.ClientRectangle);
                bf.Graphics.Clear(Color.White);
                //bf.Graphics.DrawImage(backgroundImage, this.ClientRectangle);
                // Copiar la parte fija del laberinto sobre el buffer
                bf.Graphics.CopyFromScreen(this.PointToScreen(Point.Empty), Point.Empty, this.ClientRectangle.Size);

                // Dibujar la parte dinámica del laberinto sobre el buffer
                juego.Graficar(bf.Graphics);

                Font font = new Font("Arial", 24);
                Brush brush = Brushes.Red;
                string texto = "Texto de ejemplo";
                //bf.Graphics.DrawString(texto, font, brush, 10, 10);

                // Renderizar el buffer
                bf.Render(g);
            }
            //jugadores[0].jugador_accion=false;
            //jugadores[1].jugador_accion=false;

        }
//Cuando un usuario pulsa una tecla llama al m'etodo mover de la clase jugador
//Comprueba si se cumpli'o la condici'on de victoria para detener el juego
//Cambia de turno
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {



            // Capturar la tecla presionada
            movimiento = e.KeyCode;

            if (jugadores[turno_del_jugador % 2].PuedeMoverse() == false) turno_del_jugador++;

            


            // Llamar al método Mover con la tecla presionada
            juego.Mover(movimiento, turno_del_jugador % 2);


            turno_del_jugador++;

            if (juego.juego_terminado)
            {
                MessageBox.Show($"El juego ha terminado, ha ganado: {juego.ganador}");

                this.Close();
            }

            for (int i = 0; i < jugadores.Count; i++)
            {
                jugadores[i].ActualizarEstado(i);
            }

            if(laberinto.esferas_por_recoger==0 && laberinto.salidax==0) laberinto.GenerarSalida(jugadores[0].PosX, jugadores[0].PosY, jugadores[1].PosX, jugadores[1].PosY);
            if(laberinto.esferas_por_recoger>0 && laberinto.salidax!=0)
            {
                laberinto.GetCelda(laberinto.salidax, laberinto.saliday).Valor=0;
                laberinto.GetCelda(laberinto.salidax, laberinto.saliday).EsPosicionClave=false;
                laberinto.salidax=0;
                laberinto.saliday=0;

                
            } 

        }
//Actualiza la informaci'on de las etiquetas label
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //jugadores[turno_del_jugador % 2].jugador_accion = false;
            jugadores[0].jugador_accion = false;
            jugadores[1].jugador_accion = false;

            if (jugadores[0].Vida <= 3) label1.BackColor = Color.Red;
            else if (jugadores[0].Vida <= 6) label1.BackColor = Color.Yellow;
            else label1.BackColor = Color.Lime;

            if (jugadores[1].Vida <= 3) label7.BackColor = Color.Red;
            else if (jugadores[1].Vida <= 6) label7.BackColor = Color.Yellow;
            else label7.BackColor = Color.Lime;

            string vida = "Vida Jugador 1: " + jugadores[0].Vida.ToString();
            label1.Text = vida;

            string vida2 = "Vida Jugador 2: " + jugadores[1].Vida.ToString();
            label7.Text = vida2;

            label2.Text = "Turnos sin moverse: " + jugadores[0].NoMoversePorTurnos1.ToString();
            label8.Text = "Turnos sin moverse: " + jugadores[1].NoMoversePorTurnos1.ToString();

            label3.Text = "Turnos sin atacar: " + jugadores[0].turnos_sin_atacar.ToString();
            label9.Text = "Turnos sin atacar: " + jugadores[1].turnos_sin_atacar.ToString();

            label4.Text = "Turnos sin usar habilidad: " + jugadores[0].Personaje.tiempo_de_enfriamiento.ToString();
            label10.Text = "Turnos sin usar habilidad: " + jugadores[1].Personaje.tiempo_de_enfriamiento.ToString();

            label11.Text = "Esferas del dragón recogidas: " + jugadores[0].cant_esferas_dragon.ToString();
            label12.Text = "Esferas del dragón recogidas: " + jugadores[1].cant_esferas_dragon.ToString();

            label13.Text = jugadores[turno_del_jugador%2].PuedeMoverse()? "Turno del jugador"+((turno_del_jugador)%2+1).ToString()+": " + jugadores[(turno_del_jugador ) % 2].Personaje.Nombre_del_Personaje : "Turno del jugador"+((turno_del_jugador+1)%2+1).ToString()+": " + jugadores[(turno_del_jugador+1) % 2].Personaje.Nombre_del_Personaje;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //juego.GraficarPermanente(g);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }

}

