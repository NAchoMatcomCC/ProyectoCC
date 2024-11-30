namespace Mazerunners;
public class Juego
{
    private Laberinto laberinto;
    private Jugador jugador;
    private CPU ia;

    public Juego()
    {
        laberinto = new Laberinto();
        jugador = new Jugador(1,1); // Posición inicial del jugador
        ia = new CPU(laberinto); // La IA se inicializa con el laberinto
    }

    public void Iniciar()
    {
        while (true)
        {
            MostrarEstado();
            Console.WriteLine("Ingrese su movimiento (w/a/s/d): ");
            string movimiento = Console.ReadLine();
            if(movimiento =="q") break;
            jugador.Mover(movimiento, laberinto);

           

            // Aquí la IA se mueve después del jugador
            ia.Mover();

            // Comprobar si el jugador ha llegado a una celda de trampa o si hay algún otro objetivo
            if (laberinto.GetCelda(jugador.PosX, jugador.PosY).Valor==7)
            {
                Console.WriteLine("¡Has llegado a la salida fin del juego !");
                break;
            }

            // Aquí podrías agregar lógica para comprobar si la IA ha alcanzado al jugador
            // o cualquier otra condición de finalización del juego.
        }
    }

    private void MostrarEstado()
    {
        Console.Clear();
        for (int i = 0; i < laberinto.Dimensiones; i++)
        {
            for (int j = 0; j < laberinto.Dimensiones; j++)
            {
                if (i == jugador.PosX && j == jugador.PosY)
                {
                    Console.Write("P "); // Mostrar al jugador
                }
                else if (i == ia.ObtenerPosicion().Item1 && j == ia.ObtenerPosicion().Item2)
                {
                    Console.Write("R "); // Mostrar la IA
                }
                else if (laberinto.GetCelda(i, j).Valor == 1)
                {
                    Console.Write("██"); // Mostrar muro
                }
                 else if (laberinto.GetCelda(i, j).EsPosicionClave)
                {
                    if(laberinto.GetCelda(i, j).Valor==5)  Console.Write("🔵"); // Celda de inicio1
                    else if(laberinto.GetCelda(i, j).Valor==6)  Console.Write("🟢"); // Celda de inicio2    
                    else  Console.Write("🏆"); // Celda de salida        

                }
                else if (laberinto.GetCelda(i, j).EsTrampa){

                    if (laberinto.GetCelda(i, j).Valor==2)Console.Write("⚠️ ");
                    else if (laberinto.GetCelda(i, j).Valor==3)Console.Write("🧨");
                    else Console.Write("🐍");
                }
                else
                {
                    Console.Write("  "); // Espacio vacío
                }
            }
            Console.WriteLine();
        }
    }
}