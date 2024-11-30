namespace Mazerunners;
public class Jugador
{
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Jugador(int inicioX, int inicioY)
    {
        PosX = inicioX;
        PosY = inicioY;
    }

    public void Mover(string direccion, Laberinto laberinto)
    {
        int nuevoX = PosX;
        int nuevoY = PosY;

        switch (direccion.ToLower())
        {
            case "w": // Arriba
                nuevoX--;
                break;
            case "s": // Abajo
                nuevoX++;
                break;
            case "a": // Izquierda
                nuevoY--;
                break;
            case "d": // Derecha
                nuevoY++;
                break;
            default:
                Console.WriteLine("Comando no válido.");
                return;
        }

        // Verificar si el movimiento es válido
        if (laberinto.GetCelda(nuevoX, nuevoY).Valor  !=1) // Si la celda no es un muro
        {
            PosX = nuevoX;
            PosY = nuevoY;
        }
        else
        {
            Console.WriteLine("Movimiento no válido. Hay un muro.");
        }
    }
}