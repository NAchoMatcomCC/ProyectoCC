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

        private bool laberintoDibujado;
        public Form1()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(0, 0);

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            laberinto = new Laberinto();
            jugadores = new List<Jugador>();



            int[] n = { 1, 7 };
            for (int i = 0; i < 2; i++)
            {
                Personaje personaje = new Personaje(n[i]);
                jugadores.Add(new Jugador(laberinto, i + 1, personaje)); // Posición inicial del jugador

            }

            juego = new Juego(laberinto, jugadores, 2, n);
            //jugador = new Bitmap("Jugador.png");
            g = this.CreateGraphics();

            turno_del_jugador = 0;

            laberintoDibujado=false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (!laberintoDibujado)
            {
                juego.GraficarPermanente(g);
                laberintoDibujado = true;
            }

            // Crear un buffer con fondo transparente
            BufferedGraphicsContext bfc = BufferedGraphicsManager.Current;
            BufferedGraphics bf = bfc.Allocate(g, this.ClientRectangle);
            bf.Graphics.Clear(Color.White);

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
            //jugadores[0].jugador_accion=false;
            //jugadores[1].jugador_accion=false;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //jugadores[turno_del_jugador % 2].jugador_accion = false;
            jugadores[0].jugador_accion = false;
            jugadores[1].jugador_accion = false;
        }

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

