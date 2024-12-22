using System;

namespace Mazerunners
{
    public class Menu
    {
        public static void Jugar()
        {
            // Lógica para seleccionar personajes
            Console.WriteLine("Selecciona los personajes:");
            Console.WriteLine("1. Goku");
            Console.WriteLine("2. Freezer");
            Console.WriteLine("3. Vegeta");
            Console.WriteLine("4. Krilin");
            Console.WriteLine("5. Jiren");
            Console.WriteLine("6. Gohan");
            Console.WriteLine("7. Androide18");
            Console.WriteLine("8. Piccolo");
            Console.WriteLine("9. Trunks");
            Console.WriteLine("10. Cell");

            int[] seleccion = new int[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Selecciona el personaje {i + 1} (o presiona cualquier otra tecla para volver al menú principal): ");
        
                // Leer la entrada del usuario
                string entrada = Console.ReadLine();

                // Verificar si la entrada es un número válido
                if (int.TryParse(entrada, out int personajeSeleccionado) && personajeSeleccionado >= 1 && personajeSeleccionado <= 10)
                {
                    seleccion[i] = personajeSeleccionado;
                }
                else
                {
                    Console.WriteLine("Volviendo al menú principal...");
                    return; // Volver al menú principal
                }
            }

            // Crear una instancia de Juego y pasar los personajes seleccionados
            Juego juego = new Juego(2, seleccion);
            juego.Iniciar();
        }

        public static void Instrucciones()
        {
            Console.WriteLine("Instrucciones del juego:");
            Console.WriteLine("1. Cada jugador selecciona un personaje.");
            Console.WriteLine("2. Los jugadores se turnan para moverse y atacar.");
            Console.WriteLine("3. El objetivo es reducir la vida del oponente a 0.");
            Console.WriteLine("4. Usa las teclas 'w', 'a', 's', 'd' para moverte.");
            Console.WriteLine("5. Presiona 'o' para usar habilidades y 'p' para atacar.");
            Console.WriteLine("6. ¡Diviértete!");

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
            Console.ReadKey();
        }

        public static void Salir()
        {
            Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
            Environment.Exit(0); // Salir del juego
        }

        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("1. Jugar");
                Console.WriteLine("2. Instrucciones");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Jugar();
                        break;
                    case "2":
                        Instrucciones();
                        break;
                    case "3":
                        Salir();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }
    }
}