namespace Mazerunners;
public class CPU
{
    private Laberinto laberinto;
    private (int, int) posicion;
    private Random rand = new Random();

    public CPU(Laberinto laberinto)
    {
        this.laberinto = laberinto;
        posicion = ObtenerPosicionInicial();
    }

    private (int, int) ObtenerPosicionInicial()
    {
        int x, y;
        do
        {
            x = rand.Next(1, laberinto.Dimensiones - 1);
            y = rand.Next(1, laberinto.Dimensiones - 1);
        } while (laberinto.GetCelda(x, y).Valor == 1); // Asegurarse de que no sea un muro

        return (x, y);
    }

    public void Mover()
    {
        List<(int, int)> movimientosPosibles = ObtenerMovimientosPosibles();

        if (movimientosPosibles.Count > 0)
        {
            // Elegir un movimiento aleatorio
            var movimiento = movimientosPosibles[rand.Next(movimientosPosibles.Count)];
            posicion = movimiento;
        }
    }

    private List<(int, int)> ObtenerMovimientosPosibles()
    {
        List<(int, int)> movimientos = new List<(int, int)>();
        int x = posicion.Item1;
        int y = posicion.Item2;

        // Verificar las celdas adyacentes
        if (x > 0 && laberinto.GetCelda(x - 1, y).Valor != 1) // Arriba
            movimientos.Add((x - 1, y));
        if (x < laberinto.Dimensiones - 1 && laberinto.GetCelda(x + 1, y).Valor != 1) // Abajo
            movimientos.Add((x + 1, y));
        if (y > 0 && laberinto.GetCelda(x, y - 1).Valor != 1) // Izquierda
            movimientos.Add((x, y - 1));
        if (y < laberinto.Dimensiones - 1 && laberinto.GetCelda(x, y + 1).Valor != 1) // Derecha
            movimientos.Add((x, y + 1));

        return movimientos;
    }

    public (int, int) ObtenerPosicion()
    {
        return posicion;
    }
}