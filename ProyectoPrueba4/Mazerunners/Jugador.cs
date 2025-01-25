namespace Mazerunners;
using System.Drawing;
using System.Security.Cryptography.Pkcs;
public class Jugador
{
    private Laberinto laberinto;
    private Random rand = new Random();
    public int PosX;
    public int PosY;
    public int x, y;
    public int Vida;// Vida inicial del jugadorpublic int Vida { get; private set; } = 10; // Vida inicial del jugador
    private int ancho;
    private int alto;

    private Bitmap jugadorimg;
    public bool jugador_accion;

    public int jugador_velocidad;
    public int jugador_fuerza_ataque;

    
    public Personaje Personaje { get; private set; }
    public int turnos_sin_atacar;
    public int cant_esferas_dragon;
    public direcionmovimiento direccion;

    private int contador;

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
        ancho = 64;
        alto = 64;
        direccion= direcionmovimiento.HaciaAbajo;
        jugador_accion=false;
        jugadorimg=new Bitmap(DireccionImagen());
        jugador_velocidad=1;
        jugador_fuerza_ataque=1;
        
        
        NoMoversePorTurnos1=0;
    }

    public enum direcionmovimiento{


        HaciaAbajo,
        HaciaArriba,
        Derecha,
        Izquierda,
        AtacarHaciaAbajo,
        AtacarHaciaArriba,
        AtacarDerecha,
        AtacarIzquierda,
        Poder,


    }

    private string DireccionImagen()
    {
        if (Personaje.Nombre_del_Personaje == "Goku") return "img/goku.png";
        else if (Personaje.Nombre_del_Personaje == "Freezer") return "img/freezer.png";
        else if (Personaje.Nombre_del_Personaje == "Vegeta") return "img/vegeta.png";
        else if (Personaje.Nombre_del_Personaje == "Krilin") return "img/krillin.png";
        else if (Personaje.Nombre_del_Personaje == "Jiren") return "img/majin_boo.png";
        else if (Personaje.Nombre_del_Personaje == "Gohan") return "img/gohan.png";
        else if (Personaje.Nombre_del_Personaje == "Androide 18") return "img/androide.png";
        else if (Personaje.Nombre_del_Personaje == "Piccolo") return "img/piccolo.png";
        else if (Personaje.Nombre_del_Personaje == "Trunks") return "img/trunks.png";
        else if (Personaje.Nombre_del_Personaje == "Cell") return "img/cell.png";
        else return "Personaje desconocido";
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
            Personaje.Habilidad_Ataque(this, jugador2, 2*jugador_fuerza_ataque);
            turnos_sin_atacar=5;
        } 

    }

     public bool Posicion_cercana(Jugador otroJugador)
    {

        if(PosX - otroJugador.PosX==1 && PosY == otroJugador.PosY)
        {
            direccion=direcionmovimiento.AtacarIzquierda;

            return true;
        }
        else if(otroJugador.PosX - PosX == 1 && PosY == otroJugador.PosY)
        {
            direccion=direcionmovimiento.AtacarDerecha;

            return true;
        }
        else if(PosY - otroJugador.PosY == 1 && PosX == otroJugador.PosX)
        {
            direccion=direcionmovimiento.AtacarHaciaArriba;

            return true;
        }
        else if(otroJugador.PosY - PosY == 1 && PosX == otroJugador.PosX)
        {
            direccion=direcionmovimiento.AtacarHaciaAbajo;//parece que hay un error lógico porque ataca abajo en lugar de a la derecha lo mismo ocurre con los demás
            
            return true;
        }

        // Verificar si el otro jugador está en una posición adyacente
        //return (Math.Abs(PosX - otroJugador.PosX) == 1 && PosY == otroJugador.PosY) || // Arriba o Abajo
        //       (Math.Abs(PosY - otroJugador.PosY) == 1 && PosX == otroJugador.PosX); // Izquierda o Derecha

        return false;
    }
    public void ReducirVida(int cantidad)
    {
        Vida -= cantidad;
        if (Vida < 0) Vida = 0; // Asegurarse de que la vida no sea negativa
    }

    public void ActualizarEstado(int n)
    {
        if (Vida == 0)
        {
            if (cant_esferas_dragon > 0)
            {
                cant_esferas_dragon -= 1;

                if(!fue_asesinado)
                {
                    laberinto.esferas_por_recoger += 1;
                    laberinto.Poner1EsferasDelDragon();
                }
            }

            ObtenerPosicionInicialJ1(n+1);

            PosX = x;
            PosY = y;
            Vida = 10;

            fue_asesinado=false;

        }  
        // Este método se puede llamar al final de cada turno para decrementar el contador
        if (NoMoversePorTurnos1 > 0)
        {
            NoMoversePorTurnos1--;
        }

        if(turnos_sin_atacar>0) turnos_sin_atacar--;
        if(Personaje.tiempo_de_enfriamiento>0) Personaje.tiempo_de_enfriamiento--;
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

    public void Mostrar(Graphics g)
    {
        if (jugador_accion)
        { 
            Rectangle corte=new Rectangle(contador*64, (int)direccion*64, alto, ancho);
            g.DrawImage(jugadorimg, PosX * alto, PosY * ancho, corte, GraphicsUnit.Pixel);
            contador++;
            if(contador==3) contador=0;
        }
        else
        {


            
            Rectangle corte=new Rectangle(0, (int)direccion*64, alto, ancho);
            g.DrawImage(jugadorimg, PosX * alto, PosY * ancho, corte, GraphicsUnit.Pixel);

        }

        

    }

    public void Mover()
    {

    }

    
    
}