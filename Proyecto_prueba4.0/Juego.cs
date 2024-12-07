namespace Mazerunners;
public class Juego
{
    private Laberinto laberinto;
    private Jugador jugador;
    private CPU ia;

    private int posicioninix;
    private int posicioniniy;
    public Juego()
    {
        laberinto = new Laberinto();
        jugador = new Jugador(laberinto); // Posición inicial del jugador
        ia = new CPU(laberinto); // La IA se inicializa con el laberinto
        posicioninix=jugador.PosX;
        posicioniniy=jugador.PosY;
    }

    public void Iniciar()
    {
        while (true)
        {
            if (jugador.Vida==0){
                jugador.PosX=posicioninix;
                jugador.PosY=posicioniniy;
                jugador.Vida=10;
            }
            MostrarEstado();
            Console.WriteLine("Ingrese su movimiento (w/a/s/d): ");
            string movimiento = Console.ReadLine();
            if(movimiento =="q") break;
            Mover(movimiento);

            jugador.ActualizarEstado();

           

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

    public void Mover(string movimiento)
    {
        if (!jugador.PuedeMoverse())
        {
            Console.WriteLine("No puedes moverte en este turno.");
            return; // No permitir el movimiento
        }

        int nuevoX = jugador.PosX;
        int nuevoY = jugador.PosY;

        switch (movimiento.ToLower())
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
            // Comprobar si hay una trampa en la nueva posición
            if (laberinto.GetCelda(nuevoX, nuevoY).EsTrampa)
            {
                jugador.PosX = nuevoX;
                jugador.PosY = nuevoY;
                int tipoTrampa = laberinto.GetCelda(nuevoX, nuevoY).Valor;

               ManejarTrampa(jugador, tipoTrampa);

                // Convertir la celda de trampa a normal
                laberinto.GetCelda(nuevoX, nuevoY).Valor = 0; // Cambiar a celda normal
                laberinto.GetCelda(nuevoX, nuevoY).EsTrampa = false; // Ya no es trampa
            }
            else
            {
                jugador.PosX = nuevoX;
                jugador.PosY = nuevoY;
            }
        }
        else
        {
            Console.WriteLine("Movimiento no válido. Hay un muro.");
        }
    }

    private void ManejarTrampa(Jugador jugador, int tipoTrampa)
    {
        switch (tipoTrampa)
        {
            case 2: // Trampa que quita 2 de vida
                TrampaQuitaVida(jugador);
                break;
            case 3: // Trampa que impide moverse por 2 turnos
                TrampaImpedirMovimiento(jugador);
                break;
            case 4: // Trampa que envía al jugador a otra trampa
                EnviarATrampa(jugador);
                break;
            /*default:
                Console.WriteLine("Trampa desconocida.");
                break;*/
        }
    }

    private void TrampaQuitaVida(Jugador jugador)
    {
        jugador.ReducirVida(2);
        Console.WriteLine("¡Has caído en una trampa que te quita 2 de vida! Tu vida actual es: " + jugador.Vida);
    }

    private void TrampaImpedirMovimiento(Jugador jugador)
    {
        jugador.NoMoversePorTurnos(2); // Establecer el contador de turnos
        Console.WriteLine("¡Has caído en una trampa que te impide moverte por 2 turnos!");
    }


    private void EnviarATrampa(Jugador jugador)
    {
        List<(int, int)> trampas = new List<(int, int)>();

        // Buscar trampas de tipo 2 o 3
        for (int i = 1; i < laberinto.Dimensiones - 1; i++)
        {
            for (int j = 1; j < laberinto.Dimensiones - 1; j++)
            {
                if (laberinto.GetCelda(i, j).EsTrampa && (laberinto.GetCelda(i, j).Valor == 2 || laberinto.GetCelda(i, j).Valor == 3))
                {
                    trampas.Add((i, j));
                }
            }
        }

        // Si hay trampas disponibles, enviar al jugador a una de ellas
        if (trampas.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(trampas.Count);
            (int nuevaX, int nuevaY) = trampas[index];

            // Mover al jugador a la nueva trampa
            jugador.PosX = nuevaX;
            jugador.PosY = nuevaY;

            // Informar al jugador
            Console.WriteLine($"¡Has sido enviado a una trampa en la posición ({nuevaX}, {nuevaY})!");
            
            int tipoTrampa = laberinto.GetCelda(nuevaX, nuevaY).Valor;
            ManejarTrampa(jugador, tipoTrampa);
            laberinto.GetCelda(nuevaX, nuevaY).Valor = 0; // Cambiar a celda normal
            laberinto.GetCelda(nuevaX, nuevaY).EsTrampa = false; // Ya no es trampa
        }
        else
        {
           jugador.PosX = posicioninix; // Usar la posición inicial almacenada
           jugador.PosY = posicioniniy; // Usar la posición inicial almacenada
           Console.WriteLine("Has sido enviado a la posici'on inicial");
        }
    }





    private void MostrarEstado()
    {
        Console.Clear();

        Console.WriteLine($"Vida del Jugador:{jugador.Vida}");
        Console.WriteLine($"No puede moverser en {jugador.NoMoversePorTurnos1}");

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
                else if(laberinto.GetCelda(i,j).EsEsferaDelDragon)
                {
                    Console.Write("🟠");
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