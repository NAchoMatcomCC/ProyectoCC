namespace Mazerunners;

public class Laberinto
{
    private int dimensiones;
    private Celda[,] laberinto;

    public int esferas_por_recoger;

    private Random rand;

    public int salidax;
    public int saliday;

    public Laberinto()
    {
        
        dimensiones = 15;
        laberinto = new Celda[dimensiones, dimensiones];
        esferas_por_recoger = 7;
        rand = new Random();

        salidax=0;
        saliday=0;

        GenerarLaberinto();
        

        
    }

    public int Dimensiones 
    {
        get { return dimensiones; }
    }


//Crea la matriz de Celdas llena de muros
    private void GenerarLaberinto()
    {
        // Inicializar el laberinto con muros
        for (int i = 0; i < dimensiones; i++)
        {   for (int j = 0; j < dimensiones; j++)
            {
                laberinto[i,j]=new Celda();
                laberinto[i, j].Valor = 1;
                laberinto[i,j].Esaccesible=false;
            }
        }

        
        GenerarLaberinto(1,1);

        
        GenerarTrampas();
        SeleccionarCeldas();
        for (int i = 0; i < 7; i++)
        {
            Poner1EsferasDelDragon();  
        }
        //PonerEsferasDelDragon();
    }

//M'etodo para la generaci'on del laberinto usando un algoritmo de backtracking
    private void GenerarLaberinto(int x, int y)
    {
        // Direcciones posibles: derecha, abajo, izquierda, arriba
        int[] direcciones = { 0, 1, 2, 3 }; // 0: derecha, 1: abajo, 2: izquierda, 3: arriba
        Mezclar(direcciones);

        for (int i = 0; i < direcciones.Length; i++)
        {
            int nx = x, ny = y;

            switch (direcciones[i])
            {
                case 0: nx += 2; break; // Derecha
                case 1: ny += 2; break; // Abajo
                case 2: nx -= 2; break; // Izquierda
                case 3: ny -= 2; break; // Arriba
            }

            if (PosionValida(nx, ny) && laberinto[nx, ny].Valor == 1 && laberinto[(nx + x) / 2, (ny + y) / 2].Valor == 1)
            {
                // Marcar como camino
                laberinto[(nx + x) / 2, (ny + y) / 2].Valor = 0; // Crear un camino entre la celda actual y la nueva
                laberinto[(nx + x) / 2, (ny + y) / 2].Esaccesible=true;
                laberinto[nx, ny].Valor = 0; // Marcar la nueva celda como camino
                laberinto[nx, ny].Esaccesible=true;
                GenerarLaberinto(nx, ny); // Recursión
            }
        }
    }
//Cambia el orden de las direcciones en cada llamada recursiva
    private void Mezclar(int[] direcciones)
    {
        for (int i = direcciones.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temporal = direcciones[i];
            direcciones[i] = direcciones[j];
            direcciones[j] = temporal;
        }
    }
//Determina si la posici'on que se est'a dentro de las dimensiones del laberinto
    private bool PosionValida(int x, int y)
    {
        return x > 0 && x < dimensiones-1 && y > 0 && y < dimensiones-1;
    }
//M'etodo para seleccionar una celda del laberinto
    public Celda GetCelda(int x, int y)
    {
        return laberinto[x, y];
    }
//Genera las trampas
    private void GenerarTrampas()
    {
       //Random rand = new Random();
       int totalCeldasVacias = 0;

       // Contar celdas vacías
       for (int i = 1; i < dimensiones - 1; i++)
       {
           for (int j = 1; j < dimensiones - 1; j++)
           {
                if (laberinto[i, j].Valor == 0) // Verificar si la celda está vacía
                {
                    totalCeldasVacias++;
                }
            }
       }

       // Calcular cuántas trampas se generarán (30% de las celdas vacías)
       int trampasAAgregar = (int)(totalCeldasVacias * 0.2);
    
       for (int i = 0; i < trampasAAgregar; i++)
        {
            int x, y;
            bool trampaColocada = false;

            while (!trampaColocada)
            {
                x = rand.Next(1, dimensiones - 1); // Elegir una posición aleatoria para la trampa
                y = rand.Next(1, dimensiones - 1);

                // Verificar si la celda está vacía y no tiene trampas adyacentes
                if (laberinto[x, y].Valor == 0 && !HayTrampaAdyacente(x, y))
                {
                    // Asignar un tipo de trampa aleatorio (2, 3 o 4)
                    int tipoTrampa = rand.Next(2, 5); // Genera un número aleatorio entre 2 y 4
                    laberinto[x, y].Valor = tipoTrampa; // Asigna el valor de la trampa
                    laberinto[x, y].EsTrampa = true; // Marca la celda como trampa
                    trampaColocada = true; // Marca que se ha colocado la trampa
                }
            }
        }
    }

// Método para verificar si hay trampas adyacentes
    private bool HayTrampaAdyacente(int x, int y)
    {
    // Verificar las celdas adyacentes (arriba, abajo, izquierda, derecha)
        return laberinto[x - 1, y].EsTrampa || // Arriba
            laberinto[x + 1, y].EsTrampa || // Abajo
            laberinto[x, y - 1].EsTrampa || // Izquierda
            laberinto[x, y + 1].EsTrampa;   // Derecha
    }
//Selecciona las posiciones de inicio de los dos jugadores
    private void SeleccionarCeldas()
    {
        Random rand = new Random();
        (int, int) celdaInicio1 = (-1, -1);
        (int, int) celdaInicio2 = (-1, -1);
        //(int, int) celdaSalida = (-1, -1);

        // Intentar seleccionar la primera celda de inicio
        while (celdaInicio1 == (-1, -1))
        {
            int x = rand.Next(1, dimensiones - 1);
            int y = rand.Next(1, dimensiones - 1);

                if (laberinto[x, y].Valor == 0) // Verificar si la celda está vacía
                {
                    celdaInicio1 = (x, y);
                    laberinto[x, y].Valor = 5; // Asigna valor 5 a la primera celda de inicio
                    laberinto[x, y].EsPosicionClave=true;
                }
        }

        // Intentar seleccionar la segunda celda de inicio, asegurándose de que no sea adyacente a la primera
        while (celdaInicio2 == (-1, -1))
        {
            int x = rand.Next(1, dimensiones - 1);
            int y = rand.Next(1, dimensiones - 1);

            if (laberinto[x, y].Valor == 0 && !SonAdyacentes(celdaInicio1, (x, y)))
            {
                celdaInicio2 = (x, y);
                laberinto[x, y].Valor = 6; // Asignar valor 6 a la segunda celda de inicio
                laberinto[x, y].EsPosicionClave=true;
            }
        }

        
    }
//Genera la salida cuando se recogen todas las esferas del drag'on
    public void GenerarSalida(int posxjugador1, int posyjugador1, int posxjugador2, int posyjugador2)
    {
        (int, int) celdaSalida = (-1, -1);

         while (celdaSalida == (-1, -1))
        {
            int x = rand.Next(1, dimensiones - 1);
            int y = rand.Next(1, dimensiones - 1);

            if (laberinto[x, y].Valor == 0 && (x!=posxjugador1 || y!=posyjugador1) && (x!=posxjugador2 || y!=posyjugador2))
            {
                celdaSalida = (x, y);
                laberinto[x, y].Valor = 7; // Asignar valor 7 a la celda de salida
                laberinto[x, y].EsPosicionClave=true;

                salidax=x;
                saliday=y;
            }
        }

        
    }

//M'etodo para poner las esferas del drag'on en el laberinto
    public void Poner1EsferasDelDragon(){


        Random rand = new Random();

        bool esferacolocada;
        

        
        int x, y;
        esferacolocada=false;
        
        while (!esferacolocada)
        {
            x = rand.Next(1, dimensiones - 1);
            y = rand.Next(1, dimensiones - 1);

            if (laberinto[x, y].Valor == 0 && !laberinto[x, y].EsEsferaDelDragon) // Verificar si la celda está vacía
            {
                laberinto[x,y].EsEsferaDelDragon=true;
                esferacolocada=true;
            }
        }
        




    }

// Método para verificar si dos celdas son adyacentes
    private bool SonAdyacentes((int, int) celda1, (int, int) celda2)
    {
        return (Math.Abs(celda1.Item1 - celda2.Item1) == 1 && celda1.Item2 == celda2.Item2) ||
            (celda1.Item1 == celda2.Item1 && Math.Abs(celda1.Item2 - celda2.Item2) == 1);
    }


    
}