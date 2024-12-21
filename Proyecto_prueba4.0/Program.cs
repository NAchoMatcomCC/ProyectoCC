namespace Mazerunners;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        int[] n=[4,5];
        Personaje personaje=new Personaje(2);
        Juego juego = new Juego(2,n);
        juego.Iniciar();
    }
}