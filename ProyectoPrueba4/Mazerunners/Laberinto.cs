namespace Mazerunners;

public class Laberinto
{
    private float densidad;
    private int dimensiones;
    private Celda[,] laberinto;

    public int esferas_por_recoger;

    public Laberinto(float densidad = 0.5f, int dimensiones = 15)
    {
        this.densidad = densidad;
        this.dimensiones = dimensiones;
        laberinto = new Celda[dimensiones, dimensiones];
        esferas_por_recoger = 7;
        GenerarLaberinto();

        
    }

    public int Dimensiones 
    {
        get { return dimensiones; }
    }

    private void GenerarLaberinto()
    {
        // Inicializar la matriz
        for (int i = 0; i < dimensiones; i++)
        {
            for (int j = 0; j < dimensiones; j++)
            {
                laberinto[i, j] = new Celda();
                if (i == 0 || j == 0 || i == dimensiones - 1 || j == dimensiones - 1)
                {
                    laberinto[i, j].Valor = 1;
                    laberinto[i, j].Esaccesible = false;

                }
                else
                {
                    laberinto[i, j].Valor = 0; 
                }
            }
        }

        // Calcular la cantidad de paredes a agregar
        int FParedes = (int)(densidad * (dimensiones * dimensiones) / 4);

        // Generar el laberinto
        Random rand = new Random();
        for (int i = 0; i < FParedes; i++)
        {
            int x = rand.Next(2, dimensiones - 2) / 2 * 2; // x par
            int y = rand.Next(2, dimensiones - 2) / 2 * 2; // y par
            laberinto[x, y].Valor = 1; // Colocar pared
            laberinto[x, y].Esaccesible = false;

            // Agregar paredes alrededor
            for (int j = 0; j < 4; j++)
            {
                int[] mx = { x, x, x + 2, x - 2 };
                int[] my = { y + 2, y - 2, y, y };
                int r = rand.Next(0, 4); // Elegir una dirección aleatoria
                if (my[r] >= 0 && my[r] < dimensiones && mx[r] >= 0 && mx[r] < dimensiones && laberinto[my[r], mx[r]].Valor == 0)
                {
                    laberinto[my[r], mx[r]].Valor = 1; // Colocar pared
                    laberinto[my[r], mx[r]].Esaccesible = false;
                    // Conectar la pared
                    int midX = (x + mx[r]) / 2;
                    int midY = (y + my[r]) / 2;
                    if (midY >= 0 && midY < dimensiones && midX >= 0 && midX < dimensiones)
                    {
                        laberinto[midY, midX].Valor = 1; // Conectar
                        laberinto[midY, midX].Esaccesible = false;
                    }
                }
            }
        }
        int[,] accesibles=CeldasInaccesibles();
        QuitarCeldasInaccesibles(accesibles);
        GenerarTrampas();
        SeleccionarCeldas();
        PonerEsferasDelDragon();
    }

    public Celda GetCelda(int x, int y)
    {
        return laberinto[x, y];
    }

    private void GenerarTrampas()
    {
       Random rand = new Random();
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

    private void SeleccionarCeldas()
    {
        Random rand = new Random();
        (int, int) celdaInicio1 = (-1, -1);
        (int, int) celdaInicio2 = (-1, -1);
        (int, int) celdaSalida = (-1, -1);

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

        // Intentar seleccionar la celda de salida, asegurándose de que no sea adyacente a las celdas de inicio
        while (celdaSalida == (-1, -1))
        {
            int x = rand.Next(1, dimensiones - 1);
            int y = rand.Next(1, dimensiones - 1);

            if (laberinto[x, y].Valor == 0 && !SonAdyacentes(celdaInicio1, (x, y)) && !SonAdyacentes(celdaInicio2, (y, x)))
            {
                celdaSalida = (x, y);
                laberinto[x, y].Valor = 7; // Asignar valor 7 a la celda de salida
                laberinto[x, y].EsPosicionClave=true;
            }
        }
    }

    private void PonerEsferasDelDragon(){


        Random rand = new Random();

        bool esferacolocada;
        

        for (int i = 1; i <= 7; i++)
        {
            int x, y;
            esferacolocada=false;
        
            while (!esferacolocada)
            {
            x = rand.Next(1, dimensiones - 1);
            y = rand.Next(1, dimensiones - 1);

                if (laberinto[x, y].Valor == 0  && !laberinto[x,y].EsEsferaDelDragon) // Verificar si la celda está vacía
                {
                    laberinto[x,y].EsEsferaDelDragon=true;
                    esferacolocada=true;
                }
            }
        }




    }

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


    private int[,] CeldasInaccesibles(){

        int [,] distancia=new int[laberinto.GetLength(0),laberinto.GetLength(1)];

        distancia[1,1]=1;

        int[] df={-1,1,0,0};
        int[] dc={0,0,1,-1};

        bool huboCambio;

        do{

            huboCambio=false;

            // Para cada posible celda del tablero 
            for (int i= 1;i<laberinto.GetLength(0)-1 ; i++){

                for (int j = 1; j <laberinto.GetLength(1)-1; j++)
                {

                    // Saltarse las celdas no marcadas 
                    if (distancia [i, j] == 0) continue;

                    // Saltarse las celdas inválidas

                    if (!laberinto[i, j].Esaccesible) continue; // Hay obstáculo en la celda

                    // Inspeccionar celdas vecinas a la celda [i, j]

                    for (int d=0; d<df.Length; d++){

                        int vf=i+df[d];

                        int vc=j+dc[d];

                        // Determinar si es un vecino válido y no ha sido marcado 
                        if (PosicionValida (laberinto.GetLength(0)-1,laberinto.GetLength(1)-1, vf, vc) && distancia [vf, vc] == 0 && laberinto [vf, vc].Esaccesible) {  

                            // Actualizar esta celda 
                            distancia [vf, vc]=distancia [i, j] + 1;
                            huboCambio = true;


                            break;

                        }
                    } 
                }
            }
        }while (huboCambio);

    return distancia;
    }

    private void QuitarCeldasInaccesibles(int [,] accesibles){

        for (int i = 0; i < laberinto.GetLength(0); i++)
        {
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
                if(laberinto[i,j].Valor==accesibles[i,j]) laberinto[i,j].Valor=1;
            }
        }
    }


    private bool PosicionValida(int filas, int columnas, int x, int y)
    {
        // Verificar si las coordenadas están dentro de los límites del laberinto
        if (x < 0 || x >= filas || y < 0 || y >= columnas)
        {
            return false; // Fuera de los límites
        }

        // Verificar si la celda es accesible
        return laberinto[x, y].Esaccesible; // Devuelve true si es accesible, false si no lo es
    }
}