namespace Mazerunners;

public class Personaje
{

    PersonajeElegir personaje;
    public int tiempo_de_enfriamiento;
    public int velocidad;
    public int fuerza_de_ataque;
    public int vida;
    

    enum PersonajeElegir{

        Goku,
        Freezer,
        Vegeta,
        Krilin,
        Jiren,
        Gohan,
        Androide18,
        Piccolo,
        Trunks,
        Cell,
        
    }
    


    public Personaje(int n){

        personaje=ElegirPersonaje(n);
        tiempo_de_enfriamiento=0;
        fuerza_de_ataque=1;
        velocidad=1;
        vida=10;

    }


    public void Poder(Jugador jugador1, Jugador jugador2)
    {
        switch (personaje)
        {
            case PersonajeElegir.Goku:
                Habilidad_Ataque(jugador2, 4);
                tiempo_de_enfriamiento=20;
                break;

            case PersonajeElegir.Freezer:
                Paralizar(jugador2,2);
                if(jugador2.Vida>2) Habilidad_Ataque(jugador2,2);
                tiempo_de_enfriamiento=22;
                break;

            case PersonajeElegir.Vegeta:
                Habilidad_Ataque(jugador2, 3);
                Paralizar(jugador2,1);
                tiempo_de_enfriamiento=18;
                break;

            case PersonajeElegir.Krilin:
                Paralizar(jugador2,3);
                tiempo_de_enfriamiento=16;
                break;

            case PersonajeElegir.Jiren:
                PoderAbsoluto(jugador1);
                fuerza_de_ataque+=1;
                tiempo_de_enfriamiento=100;
                break;

            case PersonajeElegir.Gohan:
                Habilidad_Ataque(jugador2, 4);
                tiempo_de_enfriamiento=20;
                break;

            case PersonajeElegir.Androide18:
                Habilidad_Ataque(jugador1,2);
                Habilidad_Ataque(jugador2,5);
                tiempo_de_enfriamiento=18;
                break;

            case PersonajeElegir.Piccolo:
                Regeneracion(jugador1, 3);
                tiempo_de_enfriamiento=16;
                break;

            case PersonajeElegir.Trunks:
                Habilidad_Ataque(jugador2,2);
                velocidad+=1;
                tiempo_de_enfriamiento=50;;
                break;

            case PersonajeElegir.Cell:
                Habilidad_Ataque(jugador2,2);
                Regeneracion(jugador1, 2);
                tiempo_de_enfriamiento=22;
                break;

            default:
                break;
        }
    }

   

    private void Paralizar(Jugador jugador, int cant_turnos)
    {
        // El jugador no puede moverse en su próximo turno
        jugador.NoMoversePorTurnos(cant_turnos);
        Console.WriteLine("¡Freezer ha paralizado al otro jugador!");
    }
    
    private void PoderAbsoluto(Jugador jugador)
    {
        jugador.Vida=30;
        Console.WriteLine("¡Jiren ha activado Poder Absoluto! Reduciendo el daño recibido en el siguiente turno.");
    }

    private void Habilidad_Ataque(Jugador jugador2, int n)
    {
        if (jugador2.Vida > n) jugador2.ReducirVida(n);
        else jugador2.Vida = 0;
        Console.WriteLine("¡Ha lanzado Kamehameha y le ha quitado 4 de vida al otro jugador!");
    }

    private void Regeneracion(Jugador jugador, int n)
    {
        jugador.Vida += 3; // Restaura 3 puntos de vida
        if (jugador.Vida>10) jugador.Vida=10;
        Console.WriteLine("¡Piccolo ha usado Regeneración y ha restaurado 3 de vida!");
    }

    PersonajeElegir ElegirPersonaje(int n){

        if (n==1){
            return PersonajeElegir.Goku;
        }
        else if (n==2){
            return PersonajeElegir.Freezer;
        }
        else if (n==3){
            return PersonajeElegir.Vegeta;
        }
        else if (n==4){
            return PersonajeElegir.Krilin;
        }
        else if (n==5){
            return PersonajeElegir.Jiren;
        }
        else if (n==6){
            return PersonajeElegir.Gohan;
        }
        else if (n==7){
            return PersonajeElegir.Androide18;
        }
        else if (n==8){
            return PersonajeElegir.Piccolo;
        }
        else if (n==9){
            return PersonajeElegir.Trunks;
        }
        else{
            return PersonajeElegir.Cell;
        }

    }
    
}