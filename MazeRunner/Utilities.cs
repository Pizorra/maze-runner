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
      {"🟫",new Casilla("Barro movedizo",8,0,0,"Disminuye en 8 el movimiento del jugador",0)},
      {"🔮",new Casilla("una Trampa magica",0,0,0,"Devuelve al jugador a su posicion inicial",0)},
      {"🔌",new Casilla("una Manifestacion de la Guiteras",0,0,1,"Aturde al jugador durante un turno",0)},
      {"⭕️",new Casilla("un Agujero de gusano",0,0,0,"Deja al jugador en una posicion aleatoria del mapa",0)},
      {"🧟",new Casilla("un Canibal enterrado",8,0,0,"El oponente escucha tu grito al ser mordido por un canibal enterrado y apresura su paso,aumentando en 8 su movimiento",0)},

    };

  public static Dictionary<string, (Casilla, string)> npc = new Dictionary<string, (Casilla, string)>
    {
      {"🧙", (new Casilla("Rollo",0,0,2,"Rollo se manda la tertulia numero 5,pierdes un turno",0), "🧙:Consorte atiendeme bien,es momento de enumerarte los logros de nuestra Revolucion")},
      {"👩", (new Casilla("Tu Mama",3,0,0,"Restaura tu habilidad para ser usada y triplica tu movimiento",0), "👩:Tienes catarro por andar descalzo,dejame que te haga un cocimiento de quaisimi y estas en talla mi amor")},
      {"🔪", (new Casilla("Pedrito Heroe de la Confronta",2,0,0,"El heroe antiguo roba tu motorina y te golpea en las piernas,dejandote con la mitad de tu movimiento",0), "🔪:Por estas determinadas razones es que mi colectivo de camaradas se enfrenta a usted,accione usted la palanca aumentadora de velocidad,accione")},
      {"💡", (new Casilla("una Idea Brillante",2,0,2,"Gritas muy alto ciertas obscenidades duplicando tu velocidad de movimiento",0), "")}

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










