using static Characters;
using System.Security.Cryptography.X509Certificates;
using static MazeGeneration;
using static Casilla;
using System.Security.Cryptography;
using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;



public class Program
{

    public static bool habilidad1 = false;
    public static bool habilidad2 = false;
    public static int conticonti = 3;


    public static List<Characters> characters = new List<Characters>
         {

             new Characters("Wyll",20, 20, 20, 4,"Favor del Patrón","Disminuye a la mitad el movimiento del adversario durante 4 turnos"),

             new Characters("Laezel",20, 20, 20,3,"Maldición de Vlaakith","Aturde al oponente en cualquier posicion que este se encuentre durante 1 turno"),

             new Characters("Shadowheart",24, 24, 24, 1,"Bendición de Selune","Duplica su movimiento durante un turno"),

             new Characters("Gale",16,16,16, 6,"Elegido de Mystra","Atraviesa una unica pared durante el turno donde activo su habilidad"),

             new Characters("Astarion",24, 24, 24, 3,"Tramposo","Deja en su posicion una trampa aleatoria que se encuentra en el laberinto"),

             new Characters("Karlach",24, 24, 24, 2,"Agarrate fuerte","Durante su turno ninguna trampa tiene efecto sobre ella"),

         };
    static Random rana = new Random();
    public static void CasillaCaer(Characters personaje, Characters rival, string casicasi, string[,] milab, int persid)
    {
        if (casicasi == "🟫")
        {
            personaje.AffectedMovement -= Casilla.trampas["🟫"].AlteraMovimiento;
        }
        if (casicasi == "🔮")
        {
            if (persid == 1)
            {
                Movement.posicionPersonaje1 = (1, 1);
            }
            else
            {
                Movement.posicionPersonaje2 = (31, 31);
            }
        }
        if (casicasi == "🔌")
        {
            personaje.AffectedMovement = 0;
        }
        if (casicasi == "⭕️")
        {
            bool parar = false;
            while (!parar)
            {
                int posicionx = rana.Next(0, milab.GetLength(0));
                int posiciony = rana.Next(0, milab.GetLength(1));
                if (milab[posicionx, posiciony] == "⬛️" && persid == 1)
                {
                    Movement.posicionPersonaje1 = (posicionx, posiciony);
                    parar = true;
                }
                else if (milab[posicionx, posiciony] == "⬛️" && persid == 2)
                {
                    Movement.posicionPersonaje2 = (posicionx, posiciony);
                    parar = true;
                }
            }
        }
        if (casicasi == "🧟")
        {
            rival.AffectedMovement += Casilla.trampas["🧟"].AlteraMovimiento;

        }
        if (casicasi == "🧙")
        {
            personaje.AffectedMovement *= Casilla.npc["🧙"].Item1.AlteraMovimiento;
        }
        if (casicasi == "👩")
        {
            personaje.AffectedMovement *= Casilla.npc["👩"].Item1.AlteraMovimiento;
            personaje.PowerCooldown = Casilla.npc["👩"].Item1.AlteraHabilidad;

        }
        if (casicasi == "🔪")
        {

            personaje.AffectedMovement /= Casilla.npc["🔪"].Item1.AlteraMovimiento;
        }
        if (casicasi == "💡")
        {
            personaje.AffectedMovement *= Casilla.npc["💡"].Item1.AlteraMovimiento;
            rival.AffectedMovement = 0;

        }




    }





    public static void Main(string[] args)
    {
        string bienv = @"                                                                                                                                                                          
,-----.  ,--.                                      ,--.   ,--.                       ,-----.          ,--.   ,--.                          ,------.                       
|  |) /_ `--' ,---. ,--,--,,--.  ,--.,---. ,--,--, `--' ,-|  | ,---.      ,--,--.    |  |) /_  ,--,--.|  | ,-|  |,--.,--.,--.--. ,---.     |  .--. ' ,--,--. ,---. ,---.  
|  .-.  \,--.| .-. :|      \\  `'  /| .-. :|      \,--.' .-. || .-. |    ' ,-.  |    |  .-.  \' ,-.  ||  |' .-. ||  ||  ||  .--'(  .-'     |  '--'.'' ,-.  || .--'| .-. : 
|  '--' /|  |\   --.|  ||  | \    / \   --.|  ||  ||  |\ `-' |' '-' '    \ '-'  |    |  '--' /\ '-'  ||  |\ `-' |'  ''  '|  |   .-'  `)    |  |\  \ \ '-'  |\ `--.\   --. 
`------' `--' `----'`--''--'  `--'   `----'`--''--'`--' `---'  `---'      `--`--'    `------'  `--`--'`--' `---'  `----' `--'   `----'     `--' '--' `--`--' `---' `----' 
                                                                                                                                                                          ";

        Console.WriteLine(bienv);
        Console.WriteLine("Es tu primera vez jugando?");
        Console.WriteLine("Q-SI    E-NO");
        var opcion = Console.ReadKey().Key;


        while (opcion != ConsoleKey.Q && opcion != ConsoleKey.E)
        {

            Console.Clear();
            Console.WriteLine("Tanque ponme una de las teclas que te dije,esto no se va a partir");
            Console.WriteLine("Es tu primera vez jugando?");
            Console.WriteLine("Q-SI    E-NO");
            opcion = Console.ReadKey().Key;

        }



        if (opcion == ConsoleKey.Q)
        {
            Console.Clear();
            Console.WriteLine("Deseas recibir un tutorial sobre la funcionalidad y el objetivo del juego?");
            Console.WriteLine("Q-SI    E-NO");
            var opcion2 = Console.ReadKey().Key;

            while (opcion2 != ConsoleKey.Q && opcion2 != ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("Querido jugador,es Q o E lo que tienes que presionar,hay que leer mas mi camarada");
                Console.WriteLine("Deseas recibir un tutorial sobre la funcionalidad y el objetivo del juego?");
                Console.WriteLine("Q-SI    E-NO");
                opcion2 = Console.ReadKey().Key;
            }



            if (opcion2 == ConsoleKey.Q)
            {
                Console.Clear();
                Console.WriteLine("Casillas NPC o casillas trampas y Win Condition:");
                Console.WriteLine();
                Console.WriteLine("🪬:La Mano de Vecna,una extremidad de un dios antiguo que se dice que profiere poderes inimaginables a aquel que la posea,es la Win Condition");
                Console.WriteLine("🟫:Barro Movedizo,una casilla trampa que disminuira el movimiento de tu personaje en 8");
                Console.WriteLine("🔮:Trampa Magica,una trampa hecha para disuadir a los saqueadores de tumbas,te devolvera a tu casilla incial");
                Console.WriteLine("🔌:Manifestacion de la Guiteras,una infiltracion de un mundo paralelo con grandes cantidades de energia,aturdira al jugador durante un turno");
                Console.WriteLine("⭕️:Agujero de Gusano,un ente travieso que debido a su inmenso poder ya no busca alimento,mas bien molestar a los saqueadores de tumbas dejandolos en posiciones aleatorias del laberinto");
                Console.WriteLine("🧟:Canibal enterrado,trabajadores asalariados de la tumba,a cambio de poder mordisquear a aventureros se esconden en los suelos de la tumba esperando su oportunidad,aumentan en 8 la velocidad de movimiento del jugador contrario");
                Console.WriteLine();
                Console.WriteLine("🧙:Rollo,un mago extremadamente poderoso y extremadamente senil,te siguio hasta la tumba pidiendo comida y la proxima vez que te vea te contara una de sus batallitas,te aturde durante un turno");
                Console.WriteLine("👩:Tu Mama,tu querida mami que se entero que andabas enfermito y fue al laberinto a cuidarte jovenzuelo,triplica tu movimiento y reinicia el cooldown de tu habilidad");
                Console.WriteLine("🔪:Pedrito Heroe de la Confronta,un heroe procedente de El Aplanado,con cierta historia criminal,reducira tu velocidad a la mitad durante dos turnos");
                Console.WriteLine("💡:Idea Brillante,durante tu busqueda del tesoro has tenido mucho tiempo para pensar en la oscuridad de la tumba,decides gritar con mucho impetu y usar todas tus fuerzas para llegar al tesoro,aturdes al adversario y duplicas tu velocidad durante dos turnos");
                Console.WriteLine();
                Console.WriteLine("A continuacion veremos los personajes disponibles y sus habilidades");
                Console.WriteLine("Toque una tecla cuando este listo para continuar");
                Console.ReadKey();

            }
            if (opcion2 == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("Ah pero tu te cree tiguere eh?,esta bien");
                Console.WriteLine("Toca una tecla para continuar");
                Console.ReadKey();
            }




        }
        if (opcion == ConsoleKey.E)
        {
            Console.Clear();
            Console.WriteLine("Entonces vamos parriba del lio");
            Console.WriteLine("Toque una tecla para continuar");
            Console.ReadKey();
        }




        Console.Clear();

        Console.WriteLine("Jugador 1, elige tu personaje:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{characters[i].Name} - Movimiento:{characters[i].Movement} - Enfriamiento de habilidad:{characters[i].PowerCooldown} turno(s) - Habilidad especial: {characters[i].Power}");
            Console.WriteLine(characters[i].PowerDescription);
        }

        int eleccion = 0;
        while (eleccion < 1 || eleccion > characters.Count)
        {
            Console.WriteLine("Ingresa el numero del personaje que deseas elegir: ");
            eleccion = int.Parse(Console.ReadLine()!);
        }

        Characters selectedCharacter = characters[eleccion - 1];
        Console.WriteLine($"Jugador 1, has elegido a {selectedCharacter.Name}");
        int coolicooli1 = 0;

        Console.WriteLine("Jugador 2, elige tu personaje:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{characters[i].Name} - Movimiento:{characters[i].Movement} - Enfriamiento de habilidad:{characters[i].PowerCooldown} turno(s) - Habilidad especial: {characters[i].Power}");
            Console.WriteLine(characters[i].PowerDescription);
        }

        int eleccion2 = 0;
        while (eleccion2 < 1 || eleccion2 > characters.Count)
        {
            Console.WriteLine("Ingresa el numero del personaje que deseas elegir: ");
            eleccion2 = int.Parse(Console.ReadLine()!);
            if (eleccion2 == eleccion)
            {
                while (eleccion2 == eleccion)
                {

                    Console.WriteLine("No pueden tener el mismo personaje");
                    eleccion2 = int.Parse(Console.ReadLine()!);
                }
            }
        }
        Characters selectedCharacter2 = characters[eleccion2 - 1];
        Console.WriteLine($"Jugador 2, has elegido a {selectedCharacter2.Name}");
        int coolicooli2 = 0;
        Console.WriteLine("El jugador 1 es la ficha azul ubicada en la esquina superior izquierda,el jugador 2 la ficha roja en la esquina inferior derecha");
        Console.WriteLine("Pulse una tecla para comenzar la partida");
        Console.ReadKey();








        MazeGeneration laberinto = new MazeGeneration(31, 31);
        bool[,] mamita = new bool[33, 33];




        int movimientosRestantes1 = selectedCharacter.Movement;
        int movimientosRestantes2 = selectedCharacter2.Movement;
        bool mamannema1 = false;
        bool mamannema2 = false;
        string turn1 = @"                                                                                                                             
,--------.                                     ,--.                ,--.                          ,--.                   ,--. 
'--.  .--',--.,--.,--.--.,--,--,  ,---.      ,-|  | ,---.          |  |,--.,--. ,---.  ,--,--. ,-|  | ,---. ,--.--.    /   | 
   |  |   |  ||  ||  .--'|      \| .-. |    ' .-. || .-. :    ,--. |  ||  ||  || .-. |' ,-.  |' .-. || .-. ||  .--'    `|  | 
   |  |   '  ''  '|  |   |  ||  |' '-' '    \ `-' |\   --.    |  '-'  /'  ''  '' '-' '\ '-'  |\ `-' |' '-' '|  |        |  | 
   `--'    `----' `--'   `--''--' `---'      `---'  `----'     `-----'  `----' .`-  /  `--`--' `---'  `---' `--'        `--' 
                                                                               `---'                                         ";
        string turn2 = @"                                                                                                                               
,--------.                                     ,--.                ,--.                          ,--.                   ,---.  
'--.  .--',--.,--.,--.--.,--,--,  ,---.      ,-|  | ,---.          |  |,--.,--. ,---.  ,--,--. ,-|  | ,---. ,--.--.    '.-.  \ 
   |  |   |  ||  ||  .--'|      \| .-. |    ' .-. || .-. :    ,--. |  ||  ||  || .-. |' ,-.  |' .-. || .-. ||  .--'     .-' .' 
   |  |   '  ''  '|  |   |  ||  |' '-' '    \ `-' |\   --.    |  '-'  /'  ''  '' '-' '\ '-'  |\ `-' |' '-' '|  |       /   '-. 
   `--'    `----' `--'   `--''--' `---'      `---'  `----'     `-----'  `----' .`-  /  `--`--' `---'  `---' `--'       '-----' 
                                                                               `---'                                           ";


        string victory = @"                                                                                            
,--.  ,--.  ,---.   ,---.      ,--.   ,--.,------.,--.  ,--. ,-----.,--.,------.   ,-----.  
|  '--'  | /  O  \ '   .-'      \  `.'  / |  .---'|  ,'.|  |'  .--./|  ||  .-.  \ '  .-.  ' 
|  .--.  ||  .-.  |`.  `-.       \     /  |  `--, |  |' '  ||  |    |  ||  |  \  :|  | |  | 
|  |  |  ||  | |  |.-'    |       \   /   |  `---.|  | `   |'  '--'\|  ||  '--'  /'  '-'  ' 
`--'  `--'`--' `--'`-----'         `-'    `------'`--'  `--' `-----'`--'`-------'  `-----'  
                                                                                            ";


        while (!mamannema1 && !mamannema2)
        {

            movimientosRestantes2 = characters[eleccion2 - 1].Movement;
            while (movimientosRestantes1 > 0)
            {
                if (movimientosRestantes1 > 0)
                {

                    Movement.MostrarMapa();
                    Console.WriteLine(turn1);
                    Console.WriteLine($"Turno de {selectedCharacter.Name} (Jugador 1). Movimientos restantes: {movimientosRestantes1}");
                    Console.WriteLine("Jugador 1, muevase en la direccion deseada (WASD):");
                    Console.WriteLine("Presione Q para usar la habilidad especial predeterminada del personaje");
                    var key1 = Console.ReadKey(true).Key;

                    if (key1 == ConsoleKey.Q && habilidad1 == false && coolicooli1 == 0)
                    {

                        habilidad1 = true;
                        coolicooli1 = selectedCharacter.PowerCooldown;

                        Characters.Poderes(selectedCharacter.Name);
                        if (selectedCharacter.Name == "Astarion")
                        {
                            MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] = MazeGeneration.emotrap[Characters.trampitrampi];
                            Characters.notthis = true;
                        }
                        if (Characters.dupliquiti == true && selectedCharacter.Name == "Shadowheart")
                        {
                            selectedCharacter.AffectedMovement *= 2;
                            dupliquiti = false;
                        }
                        if (Characters.viandazo && selectedCharacter.Name == "Laezel")
                        {
                            movimientosRestantes2 = 0;
                            Characters.viandazo = false;
                        }



                    }

                    if (key1 == ConsoleKey.W)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje1.x) - 1, Movement.posicionPersonaje1.y] == "🧱" && (Characters.pared && selectedCharacter.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje1.x) - 1, Movement.posicionPersonaje1.y] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("arriba", 1))
                            movimientosRestantes1--;
                    }
                    else if (key1 == ConsoleKey.S)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje1.x) + 1, Movement.posicionPersonaje1.y] == "🧱" && (Characters.pared && selectedCharacter.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje1.x) + 1, Movement.posicionPersonaje1.y] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("abajo", 1))
                            movimientosRestantes1--;
                    }
                    else if (key1 == ConsoleKey.A)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje1.x), Movement.posicionPersonaje1.y - 1] == "🧱" && (Characters.pared && selectedCharacter.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje1.x), Movement.posicionPersonaje1.y - 1] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("izquierda", 1))
                            movimientosRestantes1--;
                    }
                    else if (key1 == ConsoleKey.D)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje1.x), Movement.posicionPersonaje1.y + 1] == "🧱" && (Characters.pared && selectedCharacter.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje1.x), Movement.posicionPersonaje1.y + 1] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("derecha", 1))
                            movimientosRestantes1--;
                    }
                    else
                    {
                        Console.WriteLine("Tecla no válida... Usa WASD.");
                    }


                    if (MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] != "⬛️" && !mamita[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] && MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] != "🧱")
                    {
                        if ((!(Characters.agarrate && selectedCharacter.Name == "Karlach")) && (!(Characters.notthis && selectedCharacter.Name == "Astarion")))
                        {

                            mamita[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] = true;
                            if (Casilla.trampas.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]))
                            {
                                Casilla.MostrarInfoCasilla(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]);
                                Console.WriteLine("Toque una tecla para terminar la excepcion de la ocurrencia");
                                Console.ReadKey();
                                if (MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] == "🪬")
                                {
                                    mamannema1 = true;
                                    Console.WriteLine(victory);
                                    break;
                                }

                            }
                            if (Casilla.npc.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]))
                            {
                                Casilla.MostrarInfoNpc(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]);
                                Console.WriteLine("Toque una tecla para terminar la excepcion de la ocurrencia");
                                Console.ReadKey();
                                MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] = "⬛️";
                            }
                            CasillaCaer(selectedCharacter, selectedCharacter2, MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y], MazeGeneration.laberinto, 1);

                        }

                    }
                    Characters.notthis = false;


                }

            }
            if (coolicooli1 == 0)
            {
                habilidad1 = false;
            }
            else
            {
                coolicooli1--;
            }
            if (Characters.lechazo == true && selectedCharacter.Name == "Wyll")
            {
                movimientosRestantes2 /= 2;
                if (conticonti == 0)
                {
                    lechazo = false;
                    conticonti = 3;

                }
                else
                {
                    conticonti--;
                }


            }
            if (Characters.agarrate && selectedCharacter.Name == "Karlach")
            {
                Characters.agarrate = false;
            }
            selectedCharacter.Movement = selectedCharacter.AffectedMovement;
            selectedCharacter.AffectedMovement = selectedCharacter.Originmovement;
            if (mamannema1 == true)
            {
                break;
            }

            movimientosRestantes1 = characters[eleccion - 1].Movement;
            while (movimientosRestantes2 > 0)
            {

                if (movimientosRestantes2 > 0)
                {

                    Movement.MostrarMapa();
                    Console.WriteLine(turn2);
                    Console.WriteLine($"Turno de {selectedCharacter2.Name} (Jugador 2). Movimientos restantes: {movimientosRestantes2}");
                    Console.WriteLine("Jugador 2, muevase en la dirección deseada (WASD):");
                    Console.WriteLine("Presione Q para usar la habilidad especial predeterminada del personaje");
                    var key2 = Console.ReadKey(true).Key;
                    if (key2 == ConsoleKey.Q && habilidad2 == false && coolicooli2 == 0)
                    {
                        habilidad2 = true;
                        coolicooli2 = selectedCharacter2.PowerCooldown;
                        Characters.Poderes(selectedCharacter2.Name);
                        if (selectedCharacter2.Name == "Astarion")
                        {
                            MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] = MazeGeneration.emotrap[Characters.trampitrampi];
                            Characters.notthis = true;
                        }
                        if (Characters.dupliquiti == true && selectedCharacter2.Name == "Shadowheart")
                        {
                            selectedCharacter2.AffectedMovement *= 2;
                            dupliquiti = false;
                        }
                        if (Characters.viandazo && selectedCharacter2.Name == "Laezel")
                        {
                            movimientosRestantes1 = 0;
                            Characters.viandazo = false;
                        }


                    }

                    if (key2 == ConsoleKey.W)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje2.x) - 1, Movement.posicionPersonaje2.y] == "🧱" && (Characters.pared && selectedCharacter2.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje2.x) - 1, Movement.posicionPersonaje2.y] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("arriba", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.S)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje2.x) + 1, Movement.posicionPersonaje2.y] == "🧱" && (Characters.pared && selectedCharacter2.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje2.x) + 1, Movement.posicionPersonaje2.y] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("abajo", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.A)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje2.x), Movement.posicionPersonaje2.y - 1] == "🧱" && (Characters.pared && selectedCharacter2.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje2.x), Movement.posicionPersonaje2.y - 1] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("izquierda", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.D)
                    {
                        if (MazeGeneration.laberinto[(Movement.posicionPersonaje2.x), Movement.posicionPersonaje2.y + 1] == "🧱" && (Characters.pared && selectedCharacter2.Name == "Gale"))
                        {
                            MazeGeneration.laberinto[(Movement.posicionPersonaje2.x), Movement.posicionPersonaje2.y + 1] = "⬛️";
                            Characters.pared = false;
                        }
                        if (Movement.moverPersonaje("derecha", 2))
                            movimientosRestantes2--;
                    }
                    else
                    {
                        Console.WriteLine("Tecla no válida... Usa WASD.");
                    }

                    if (MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] != "⬛️" && !mamita[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] && MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] != "🧱")
                    {
                        if ((!(Characters.agarrate && selectedCharacter2.Name == "Karlach")) && (!(Characters.notthis && selectedCharacter2.Name == "Astarion")))
                        {
                            mamita[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] = true;
                            if (Casilla.trampas.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]))
                            {
                                Casilla.MostrarInfoCasilla(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]);
                                Console.WriteLine("Toque una tecla para proceder");
                                Console.ReadKey();
                                if (MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] == "🪬")
                                {
                                    mamannema2 = true;
                                    Console.WriteLine(victory);
                                    break;
                                }



                            }

                            if (Casilla.npc.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]))
                            {
                                Casilla.MostrarInfoNpc(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]);
                                Console.WriteLine("Toque una tecla para proceder");
                                Console.ReadKey();
                                MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] = "⬛️";
                            }
                            CasillaCaer(selectedCharacter2, selectedCharacter, MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y], MazeGeneration.laberinto, 2);
                        }
                    }
                    Characters.notthis = false;
                }

            }
            if (coolicooli2 == 0)
            {
                habilidad2 = false;
            }
            else
            {
                coolicooli2--;
            }

            if (Characters.lechazo == true && selectedCharacter2.Name == "Wyll")
            {
                movimientosRestantes1 /= 2;
                if (conticonti == 0)
                {
                    lechazo = false;
                    conticonti = 3;

                }
                else
                {
                    conticonti--;
                }


            }
            if (Characters.agarrate && selectedCharacter2.Name == "Karlach")
            {
                Characters.agarrate = false;
            }
            selectedCharacter2.Movement = selectedCharacter2.AffectedMovement;
            selectedCharacter2.AffectedMovement = selectedCharacter2.Originmovement;



        }







    }
}




