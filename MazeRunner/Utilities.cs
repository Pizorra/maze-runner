using System.ComponentModel;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

public class Casilla
{
    public string Nombre { get; private set; }
    public int AlteraMovimiento { get; private set; }
    public int AlteraPosicion { get; private set; }
    public int AlteraTurno { get; private set; }
    public string Descripcion { get; private set; }
    public int AlteraHabilidad { get; private set; }


    public Casilla(string nombre, int alteramovimiento, int alteraposicion, int alteraturno, string descripcion, int alterahabilidad)
    {
        Nombre = nombre;
        AlteraMovimiento = alteramovimiento;
        AlteraPosicion = alteraposicion;
        AlteraTurno = alteraturno;
        Descripcion = descripcion;
        AlteraHabilidad = alterahabilidad;

    }

    public static Dictionary<string, Casilla> trampas = new Dictionary<string, Casilla>
    {

      {"🪬",new Casilla("La Mano de Vecna",0,0,0,"El objetivo final,el tesoro objetivo de esta carrera",0)},
      {"🟫",new Casilla("Barro movedizo",2,0,0,"Disminuye a la mitad el movimiento del jugador",0)},
      {"🔮",new Casilla("una Trampa magica",0,4,0,"Devuelve al jugador a las 4 casillas anteriores",0)},
      {"🔌",new Casilla("un Manifestacion de la Guiteras",0,0,1,"Aturde al jugador durante un turno",0)},
      {"⭕️",new Casilla("un Agujero de gusano",0,0,0,"Deja al jugador en una posicion aleatoria del mapa",0)},
      {"🧟",new Casilla("Un Canibal enterrado",2,0,0,"El oponente escucha tu grito al ser mordido por un canibal enterrado y apresura su paso,duplicando su movimiento",0)},

    };

    public static Dictionary<string, (Casilla, string)> npc = new Dictionary<string, (Casilla, string)>
    {
      {"🧙", (new Casilla("Rollo",0,0,2,"Rollo se manda la tertulia numero 5,pierdes dos turnos",0), "🧙:")},
      {"👩", (new Casilla("Tu Mama",3,0,0,"Restaura tu habilidad para ser usada y triplica tu movimiento",0), "👩:")},
      {"🥷🏾", (new Casilla("Pedrito Heroe de la Confronta",2,0,1,"El heroe antiguo roba tu motorina y te golpea en las piernas,dejandote con la mitad de tu movimiento y con un turno menos",0), "🥷🏾:")},
      {"💡", (new Casilla("Una Idea Brillante",2,0,2,"Gritas muy alto ciertas obscenidades duplicando tu velocidad de movimiento y aturdiendo al contrario durante dos turnos",0), "")}

    };


    public static void MostrarInfoNpc(string emojo)
    {
        Console.WriteLine($"Te has topado con {npc[emojo].Item1.Nombre}");
        Console.WriteLine(npc[emojo].Item1.Descripcion);
        Console.WriteLine(npc[emojo].Item2);
    }
    public static void MostrarInfoCasilla(string emojo)
    {
        Console.WriteLine($"Has caido en {trampas[emojo].Nombre}!");
        Console.WriteLine(trampas[emojo].Descripcion);
    }





}










