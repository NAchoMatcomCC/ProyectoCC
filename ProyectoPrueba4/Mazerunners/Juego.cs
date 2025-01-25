namespace Mazerunners;

using System.Drawing;
using System.Security.Cryptography.Pkcs;

public class Juego
{
    private Laberinto laberinto;
    private List<Jugador> jugadores; // Lista para almacenar múltiples jugadores
    //private CPU ia;
    private int[] numeros_de_personajes;
    public bool juego_terminado;

    public string ganador;

    private int alto;

    private int ancho;

    private Bitmap img;

    
    public Juego(Laberinto laberinto, List<Jugador> jugadores,int numero_de_jugadores, int[] n)
    {
        this.laberinto = laberinto;
        this.jugadores = jugadores;
        juego_terminado=false;
        alto=64;
        ancho=64;
        

        // Posición inicial del jugador
        
        /*for (int i = 0; i < numero_de_jugadores; i++)
        {
            Personaje personaje = new Personaje(n[i]);
            jugadores.Add(new Jugador(laberinto, i + 1, personaje)); // Posición inicial del jugador
            posicioninix = jugadores[i].PosX;
            posicioniniy = jugadores[i].PosY;
        }*/
        //ia = new CPU(laberinto); // La IA se inicializa con el laberinto

    }

    /*public void Iniciar()
    {



        while (true)
        {
            for (int i = 0; i < jugadores.Count; i++)
            {
                for (int j = 0; j < jugadores[i].Personaje.velocidad; j++)
                {
                    if (jugadores[i].Vida == 0)
                    {
                        if (jugadores[i].cant_esferas_dragon > 0 && !jugadores[i].fue_asesinado)
                        {

                            jugadores[i].cant_esferas_dragon -= 1;
                            esferas_por_recoger += 1;
                            laberinto.Poner1EsferasDelDragon();

                        }
                        jugadores[i].PosX = posicioninix;
                        jugadores[i].PosY = posicioniniy;
                        jugadores[i].Vida = 10;

                    }

                    MostrarEstado();
                    Console.WriteLine("Ingrese su movimiento (w/a/s/d) para el jugador en la posición ({0}, {1}): ", jugadores[i].PosX, jugadores[i].PosY);
                    string movimiento = Console.ReadLine();
                    if (movimiento == "q") return; // Salir del juego

                    Mover(jugadores[i], movimiento, i); //El n'umero del jugador es



                    jugadores[i].ActualizarEstado();

                    // Comprobar si el jugador ha llegado a una celda de trampa o si hay algún otro objetivo
                    if (laberinto.GetCelda(jugadores[i].PosX, jugadores[i].PosY).Valor == 7)
                    {
                        if (esferas_por_recoger == 0 && jugadores[i].cant_esferas_dragon >= 4)
                        {
                            Console.WriteLine("¡El jugador ha llegado a la salida! Fin del juego.");
                            return; // Terminar el juego
                        }
                        else
                        {
                            jugadores[i].PosX = posicioninix;
                            jugadores[i].PosY = posicioniniy;
                        }
                    }

                    jugadores[i].fue_asesinado = false;


                }

                for (int k = 0; k < jugadores.Count; k++)
                {
                    // Actualizar turnos sin atacar y tiempo de enfriamiento
                    jugadores[k].turnos_sin_atacar = Math.Max(0, jugadores[k].turnos_sin_atacar - 1);
                    jugadores[k].Personaje.tiempo_de_enfriamiento = Math.Max(0, jugadores[k].Personaje.tiempo_de_enfriamiento - 1);
                }


                //ia.Mover();

            }
        }

        // Aquí la IA se mueve después del jugador


        // Comprobar si el jugador ha llegado a una celda de trampa o si hay algún otro objetivo


        // Aquí podrías agregar lógica para comprobar si la IA ha alcanzado al jugador
        // o cualquier otra condición de finalización del juego.
    }*/

    


    public void Mover(Keys movimiento, int n)
    {

        if (jugadores[n].PuedeMoverse() && 
            (movimiento==Keys.W || movimiento==Keys.S || movimiento==Keys.A 
                || movimiento==Keys.D || (movimiento==Keys.P && jugadores[n].turnos_sin_atacar == 0 ) 
                || (movimiento==Keys.O && jugadores[n].Personaje.tiempo_de_enfriamiento == 0)))
        {
            jugadores[n].jugador_accion=true;
            int nuevoX = jugadores[n].PosX;
            int nuevoY = jugadores[n].PosY;

            for(int i=0; i<jugadores[n].jugador_velocidad; i++)
            {
                

            switch (movimiento)
            {
                case Keys.W: // Arriba
                    nuevoY--;
                    jugadores[n].direccion=Jugador.direcionmovimiento.HaciaArriba;
                   break;
                case Keys.S: // Abajo
                    nuevoY++;
                    jugadores[n].direccion=Jugador.direcionmovimiento.HaciaAbajo;
                    break;
                case Keys.A: // Izquierda
                    nuevoX--;
                    jugadores[n].direccion=Jugador.direcionmovimiento.Izquierda;
                    break;
                case Keys.D: // Derecha
                    nuevoX++;
                    jugadores[n].direccion=Jugador.direcionmovimiento.Derecha;
                    break;
                case Keys.O: // Poder especial
                    if (n == 0 && jugadores[n].Personaje.tiempo_de_enfriamiento == 0) 
                    {
                        jugadores[n].direccion=Jugador.direcionmovimiento.Poder;
                        jugadores[n].Personaje.Poder(jugadores[0], jugadores[1]);
                    }
                    else if (n == 1 && jugadores[n].Personaje.tiempo_de_enfriamiento == 0)
                    {
                        jugadores[n].direccion=Jugador.direcionmovimiento.Poder;
                        jugadores[n].Personaje.Poder(jugadores[1], jugadores[0]);
                    }
                    break;
                case Keys.P: // Ataque

                    /*
                    if(jugadores[(n+1)%2].direccion==Jugador.dirrecionmovimiento.HaciaAbajo) jugadores[n].direccion=Jugador.dirrecionmovimiento.AtacarHaciaAbajo;
                    else if(jugadores[(n+1)%2].direccion==Jugador.dirrecionmovimiento.HaciaArriba) jugadores[n].direccion=Jugador.dirrecionmovimiento.AtacarHaciaArriba;
                    else if(jugadores[(n+1)%2].direccion==Jugador.dirrecionmovimiento.Derecha) jugadores[n].direccion=Jugador.dirrecionmovimiento.AtacarDerecha;
                    else if(jugadores[(n+1)%2].direccion==Jugador.dirrecionmovimiento.Izquierda) jugadores[n].direccion=Jugador.dirrecionmovimiento.AtacarIzquierda;
                    */


                    
                    if (n == 0 && jugadores[n].turnos_sin_atacar == 0)
                    {
                        
                        //jugadores[0].direccion=jugadores[0].direccion+4;
                        jugadores[0].Atacar(jugadores[1]);

                    }
                    else if (n == 1 && jugadores[n].turnos_sin_atacar == 0)
                    {
                        //jugadores[1].direccion=jugadores[1].direccion+4;
                        jugadores[1].Atacar(jugadores[0]);
                    }
                    break;
                default:
                    Console.WriteLine("Comando no válido.");
                        return;
            }


            
            // Verificar si el movimiento es válido
            if (laberinto.GetCelda(nuevoX, nuevoY).Valor != 1 && (nuevoX!=jugadores[(n+1)%2].PosX || nuevoY!=jugadores[(n+1)%2].PosY)) // Si la celda no es un muro
            {
                // Comprobar si hay una trampa en la nueva posición
                if (laberinto.GetCelda(nuevoX, nuevoY).EsTrampa)
                {
                    jugadores[n].PosX = nuevoX;
                    jugadores[n].PosY = nuevoY;
                    int tipoTrampa = laberinto.GetCelda(nuevoX, nuevoY).Valor;

                    ManejarTrampa(jugadores[n], tipoTrampa);

                    // Convertir la celda de trampa a normal
                    laberinto.GetCelda(nuevoX, nuevoY).Valor = 0; // Cambiar a celda normal
                    laberinto.GetCelda(nuevoX, nuevoY).EsTrampa = false; // Ya no es trampa

                    break;
                }
                else if (laberinto.GetCelda(nuevoX, nuevoY).EsEsferaDelDragon)
                {

                    jugadores[n].PosX = nuevoX;
                    jugadores[n].PosY = nuevoY;
                    jugadores[n].cant_esferas_dragon+=1;
                    laberinto.GetCelda(nuevoX, nuevoY).EsEsferaDelDragon = false;
                    laberinto.esferas_por_recoger -= 1;

                    break;
                }
                else if (laberinto.GetCelda(nuevoX, nuevoY).Valor == 7)
                    {
                        if (laberinto.esferas_por_recoger == 0 && jugadores[n].cant_esferas_dragon >= 4)
                        {
                            jugadores[n].PosX=nuevoX;
                            jugadores[n].PosY=nuevoY;
                            juego_terminado=true;
                            ganador=jugadores[n].Personaje.Nombre_del_Personaje;
                        }
                        else
                        {
                            jugadores[n].PosX = jugadores[n].x;
                            jugadores[n].PosY = jugadores[n].y;
                        }

                        break;
                    }
                else
                {
                    jugadores[n].PosX = nuevoX;
                    jugadores[n].PosY = nuevoY;
                }

                
            }
            else break;

            
            

             
        }

        //jugadores[n].jugador_accion=false;

        

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
                default:
                    Console.WriteLine("Trampa desconocida.");
                    break;
        }
    }

    private void TrampaQuitaVida(Jugador jugador)
    {
        jugador.ReducirVida(2);
        Console.WriteLine("¡Has caído en una trampa que te quita 2 de vida! Tu vida actual es: " + jugador.Vida);
    }

    private void TrampaImpedirMovimiento(Jugador jugador)
    {
        jugador.NoMoversePorTurnos(4); // Establecer el contador de turnos
        Console.WriteLine("¡Has caído en una trampa que te impide moverte por 2 turnos!");
    }


    private void EnviarATrampa(Jugador jugador)
    {
        List<(int, int)> trampas = new List<(int, int)>();

        // Buscar trampas de tipo 2 o 3
        for (int i = 1; i < laberinto.Dimensiones - 1; i++)
        {
            for (int j = 1; j < laberinto.Dimensiones - 2; j++)
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
            jugador.PosX = jugador.x; // Usar la posición inicial almacenada
            jugador.PosY = jugador.y; // Usar la posición inicial almacenada
            Console.WriteLine("Has sido enviado a la posici'on inicial");
        }
    }





    /*private void MostrarEstado()
    {
        Console.Clear();

        foreach (var jugador in jugadores)
        {
            Console.WriteLine($"Vida del Jugador en ({jugador.PosX}, {jugador.PosY}): {jugador.Vida}");
            Console.WriteLine($"No puede moverse en {jugador.NoMoversePorTurnos1}");
        }

        for (int i = 0; i < laberinto.Dimensiones; i++)
        {
            for (int j = 0; j < laberinto.Dimensiones; j++)
            {
                bool jugadorEncontrado = false;
                foreach (var jugador in jugadores)
                {  
                    
                    if (i == jugador.PosX && j == jugador.PosY)
                    {
                        if (jugadores[0].PosX == i && jugadores[0].PosY == j)
                        { 
                            Console.Write("P "); // Mostrar al jugador
                        }
                        else{
                            Console.Write("Q ");
                        }
                        jugadorEncontrado = true;
                        break;
                    }
                }
                if (!jugadorEncontrado){ 
                //else if (i == ia.ObtenerPosicion().Item1 && j == ia.ObtenerPosicion().Item2)
                //{
                //    Console.Write("R "); // Mostrar la IA
                //}
                    if (laberinto.GetCelda(i, j).Valor == 1)
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
            }
            Console.WriteLine();
        }
    }*/

    public void GraficarPermanente(Graphics g)
    {
        int contadorimagen3=0;

        for (int i = 0; i < laberinto.Dimensiones; i++)
        {
            for (int j = 0; j < laberinto.Dimensiones; j++)
            {
                if (laberinto.GetCelda(i,j).Valor != 1 && !laberinto.GetCelda(i, j).EsPosicionClave)
                {
                    img=new Bitmap("img/escenario.png");
                    g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                }
                else
                {
                    img=new Bitmap("img/muros.png");
                    Rectangle corte=new Rectangle(contadorimagen3*64, 0, alto, ancho);
                    g.DrawImage(img, i * alto, j * ancho, corte, GraphicsUnit.Pixel);
                    contadorimagen3++;
                    if(contadorimagen3==9) contadorimagen3=0; 
                }
            }
        }

    }
    public void Graficar(Graphics g)
    {
        int contadorimagen=0;
        int contadorimagen2=0;
        //int contadorimagen3=0;
        Font font = new Font("Arial", 24);
        Brush brush = Brushes.Red;
        string texto = "";

        //g.Clear(Color.White);

        /*for (int i = 0; i < jugadores.Count; i++)
        {
            texto += $"Jugador {i + 1}: {jugadores[i].Personaje.Nombre_del_Personaje} - Vida: {jugadores[i].Vida} - No puede moverse por {jugadores[i].NoMoversePorTurnos1} turnos\n";
        }*/

        //g.Clear(Color.White);

        Brush brocha;
        for (int i = 0; i < laberinto.Dimensiones; i++)
        {
            for (int j = 0; j < laberinto.Dimensiones; j++)
            {
                if (laberinto.GetCelda(i,j).Valor != 1)
                {
                    img=new Bitmap("img/escenario.png");
                    g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                }



                /*if (laberinto.GetCelda(i, j).Valor == 1)
                {
                    brocha = Brushes.Gray; // Mostrar muro
                    //g.FillRectangle(brocha, i * 64, j * 64, 64, 64);
                    //g.DrawRectangle(Pens.Black, i * 64, j * 64, 64, 64);

                    img=new Bitmap("img/muros.png");
                    Rectangle corte=new Rectangle(contadorimagen3*64, 0, alto, ancho);
                    g.DrawImage(img, i * alto, j * ancho, corte, GraphicsUnit.Pixel);
                    contadorimagen3++;
                    if(contadorimagen3==9) contadorimagen3=0;
                }*/
                /*if (laberinto.GetCelda(i, j).EsPosicionClave)
                {
                    if (laberinto.GetCelda(i, j).Valor == 5)
                    {
                        brocha = Brushes.Beige; // Celda de inicio1
                    }
                    else if (laberinto.GetCelda(i, j).Valor == 6)
                    {
                        brocha = Brushes.Pink; // Celda de inicio2    
                    }
                    else 
                    {
                        brocha=Brushes.RosyBrown; // Celda de salida
                    }
                }*/
                if (laberinto.GetCelda(i, j).EsPosicionClave)
                {
                    if (laberinto.GetCelda(i, j).Valor == 5)
                    {
                        img=new Bitmap("img/inicio.png");
                        g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                    }
                    else if (laberinto.GetCelda(i, j).Valor == 6)
                    {
                        img=new Bitmap("img/otroinicio.png");
                        g.DrawImage(img, i * alto, j * ancho, alto, ancho);    
                    }
                    else 
                    {
                        img=new Bitmap("img/shenlong.png");
                        g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                    }
                }
                else if (laberinto.GetCelda(i, j).EsTrampa)
                {

                    if (laberinto.GetCelda(i, j).Valor == 2) //Trampas que quitan vida
                    {
                        brocha = Brushes.Red;
                        img=new Bitmap("img/soldadosdefreezer.png");
                        Rectangle corte=new Rectangle(contadorimagen2*64, 0, alto, ancho);
                        g.DrawImage(img, i * alto, j * ancho, corte, GraphicsUnit.Pixel);
                        contadorimagen2++;
                        if (contadorimagen2==18) contadorimagen2=0;
                    }
                    else if (laberinto.GetCelda(i, j).Valor == 3) //Trampas que impiden el movimiento
                    {
                        brocha=Brushes.Purple;
                        img=new Bitmap("img/saibaman.png");
                        g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                    }
                    else  //Trampas que te transportan a otra posici'on
                    {
                        brocha=Brushes.Blue;
                        img=new Bitmap("img/celljr.png");
                        g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                    }
                }
                else if (laberinto.GetCelda(i, j).EsEsferaDelDragon)
                {
                    brocha = Brushes.Orange;
                    img=new Bitmap("img/esferas.png");
                    Rectangle corte=new Rectangle(contadorimagen*64, 0, alto, ancho);
                    g.DrawImage(img, i * alto, j * ancho, corte, GraphicsUnit.Pixel);
                    contadorimagen++;

                    
                }
                /*else
                {
                    brocha=Brushes.White; // Espacio vacío
                    //g.FillRectangle(brocha, i * 64, j * 64, 64, 64);
                    //g.DrawRectangle(Pens.Black, i * 64, j * 64, 64, 64);

                    img=new Bitmap("img/escenario.png");
                    g.DrawImage(img, i * alto, j * ancho, alto, ancho);
                }*/

                //g.FillRectangle(brocha, i * 64, j * 64, 64, 64);
                //g.DrawRectangle(Pens.Black, i * 64, j * 64, 64, 64);

            }

        }
        foreach (var jugador in jugadores)
        {
            //g.FillEllipse(Brushes.Orange, jugador.PosX * 64, jugador.PosY * 64, 64, 64);
            jugador.Mostrar(g);
        }

        // Calcular la posición del texto a la derecha del laberinto
        int laberintoAncho = laberinto.Dimensiones * 64; // Ancho total del laberinto
        int margenDerecho = 20; // Margen entre el laberinto y el texto
        int posicionTextoX = laberintoAncho + margenDerecho; // Posición X del texto
        int posicionTextoY = 20; // Posición Y del texto (margen superior)

        g.DrawString(texto, font, brush, posicionTextoX, posicionTextoY);


    }
}
