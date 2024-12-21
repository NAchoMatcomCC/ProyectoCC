namespace Mazerunners;
public class Jugador
{
    private Laberinto laberinto;
    private Random rand = new Random();
    public int PosX;
    public int PosY;
    public int x, y;
    public int Vida;  // Vida inicial del jugadorpublic int Vida { get; private set; } = 10; // Vida inicial del jugador
    public Personaje Personaje { get; private set; }
    public int turnos_sin_atacar;
    public int cant_esferas_dragon;

    //public int NoMoversePorTurnos { get; set; } // Contador de turnos sin poder moverse
    public bool fue_asesinado=false;
    public int NoMoversePorTurnos1;
    public Jugador(Laberinto laberinto, int jugadorNumero,Personaje personaje){

        this.laberinto=laberinto;
        this.Personaje=personaje;
        Vida=personaje.vida;
        ObtenerPosicionInicialJ1(jugadorNumero);
        PosX=x;
        PosY=y;
        turnos_sin_atacar=0;
        cant_esferas_dragon=0;
        
        
        NoMoversePorTurnos1=0;
    }

    private void ObtenerPosicionInicialJ1(int jugadorNumero)
    {
        do
        {
            x = rand.Next(1, laberinto.Dimensiones - 1);
            y = rand.Next(1, laberinto.Dimensiones - 1);
        } while (laberinto.GetCelda(x, y).Valor != (jugadorNumero == 1 ? 5 : 6)); // Asegurarse de que no sea un muro

        
    }

     public void Atacar(Jugador jugador2){

        if (Posicion_cercana(jugador2)){
            Personaje.Habilidad_Ataque(this, jugador2, 2*Personaje.fuerza_de_ataque);
            turnos_sin_atacar=5;
        } 

    }

     public bool Posicion_cercana(Jugador otroJugador)
    {
        // Verificar si el otro jugador está en una posición adyacente
        return (Math.Abs(PosX - otroJugador.PosX) == 1 && PosY == otroJugador.PosY) || // Arriba o Abajo
               (Math.Abs(PosY - otroJugador.PosY) == 1 && PosX == otroJugador.PosX); // Izquierda o Derecha
    }
    public void ReducirVida(int cantidad)
    {
        Vida -= cantidad;
        if (Vida < 0) Vida = 0; // Asegurarse de que la vida no sea negativa
    }

    public void ActualizarEstado()
    {
        // Este método se puede llamar al final de cada turno para decrementar el contador
        if (NoMoversePorTurnos1 > 0)
        {
            NoMoversePorTurnos1--;
        }
    }

    public void NoMoversePorTurnos(int turnos)
    {
        // Establecer el contador de turnos sin poder moverse
        NoMoversePorTurnos1 += turnos;
        Console.WriteLine($"¡No puedes moverte por {turnos} turnos!");
    }

    public bool PuedeMoverse()
    {
        // Verificar si el jugador puede moverse
        return NoMoversePorTurnos1 == 0;
    }

    
    
}