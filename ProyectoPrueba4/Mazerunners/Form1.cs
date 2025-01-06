using System.DirectoryServices;

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
        public Form1()
        {
            InitializeComponent();

            laberinto=new Laberinto();
            jugadores=new List<Jugador>();



            int[] n = { 1, 1 };
            for (int i = 0; i < 2; i++)
            {
                Personaje personaje = new Personaje(n[i]);
                jugadores.Add(new Jugador(laberinto, i + 1, personaje)); // Posición inicial del jugador
            
            }

            juego = new Juego(laberinto, jugadores, 2, n);
            //jugador = new Bitmap("Jugador.png");
            g = this.CreateGraphics();
            turno_del_jugador =0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           

            BufferedGraphicsContext bfc = BufferedGraphicsManager.Current;
            BufferedGraphics bf = bfc.Allocate(g, this.ClientRectangle);

            




            juego.Graficar(bf.Graphics);
            bf.Render(g);
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // Capturar la tecla presionada
            movimiento = e.KeyCode;

            for (int i = 0; i < jugadores.Count; i++)
            {
                jugadores[i].ActualizarEstado(i);
            }

            if(jugadores[turno_del_jugador%2].PuedeMoverse()==false) turno_del_jugador++;

            
            // Llamar al método Mover con la tecla presionada
            juego.Mover(movimiento, turno_del_jugador%2);

            turno_del_jugador++;

             if(juego.juego_terminado)
            {
                MessageBox.Show($"El juego ha terminado, ha ganado: {juego.ganador}");
                
                this.Close();
            }
    
        }
    }
}
