namespace Mazerunners;
public class Celda
{
    public int Valor { get; set; } // 0 = espacio, 1 = muro
    public bool EsTrampa { get; set; }

    public bool EsPosicionClave { get; set; }

    public Celda()
    {
        Valor = 0; // Inicialmente, todas las celdas son espacios vacíos
        EsTrampa = false;
        EsPosicionClave = false;
    }
}