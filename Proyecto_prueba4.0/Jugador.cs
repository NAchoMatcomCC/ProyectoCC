namespace Mazerunners;
public class Jugador
{
    private Laberinto laberinto;
    private Random rand = new Random();
    public int PosX;
    public int PosY;
    public int x, y;
    public int Vida { get; set; } = 10; // Vida inicial del jugadorpublic int Vida { get; private set; } = 10; // Vida inicial del jugador
    //public int NoMoversePorTurnos { get; set; } // Contador de turnos sin poder moverse
    public int NoMoversePorTurnos1;
    public Jugador(Laberinto laberinto){

        this.laberinto=laberinto;
        ObtenerPosicionInicialJ1();
        PosX=x;
        PosY=y;
        NoMoversePorTurnos1=0;
    }

    private void ObtenerPosicionInicialJ1()
    {
        do
        {
            x = rand.Next(1, laberinto.Dimensiones - 1);
            y = rand.Next(1, laberinto.Dimensiones - 1);
        } while (laberinto.GetCelda(x, y).Valor != 5); // Asegurarse de que no sea un muro

        
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
        NoMoversePorTurnos1 = turnos;
        Console.WriteLine($"¡No puedes moverte por {turnos} turnos!");
    }

    public bool PuedeMoverse()
    {
        // Verificar si el jugador puede moverse
        return NoMoversePorTurnos1 == 0;
    }
    
}