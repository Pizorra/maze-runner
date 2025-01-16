using static Characters;
using System.Security.Cryptography.X509Certificates;
using static MazeGeneration;
using static Casilla;



public class Program
{




    public static void Main(string[] args)
    {

        List<Characters> characters = new List<Characters>
         {

             new Characters("Wyll",20, 3,"Favor del Patrón"),

             new Characters("Laezel",20,4,"Maldición de Vlaakith"),

             new Characters("Shadowheart",24,1,"Bendición de Selune"),

             new Characters("Gale",16,1,"Elegido de Mystra"),

             new Characters("Astarion",24,3,"Tramposo"),

             new Characters("Karlach",24,2,"Agarrate fuerte"),

         };


        Console.WriteLine("Jugador 1, elige tu personaje:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{characters[i].Name} - Movimiento:{characters[i].Movement} - Enfriamiento de habilidad:{characters[i].PowerCooldown} turno(s) - Habilidad especial: {characters[i].Power}");
        }

        int eleccion = 0;
        while (eleccion < 1 || eleccion > characters.Count)
        {
            Console.WriteLine("Ingresa el numero del personaje que deseas elegir: ");
            eleccion = int.Parse(Console.ReadLine()!);
        }

        Characters selectedCharacter = characters[eleccion - 1];
        Console.WriteLine($"Jugador 1, has elegido a {selectedCharacter.Name}");

        Console.WriteLine("Jugador 2, elige tu personaje:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{characters[i].Name} - Movimiento:{characters[i].Movement} - Enfriamiento de habilidad:{characters[i].PowerCooldown} turno(s) - Habilidad especial: {characters[i].Power}");
        }

        int eleccion2 = 0;
        while (eleccion2 < 1 || eleccion2 > characters.Count && eleccion2 != eleccion)
        {
            Console.WriteLine("Ingresa el numero del personaje que deseas elegir: ");
            eleccion2 = int.Parse(Console.ReadLine()!);
        }
        Characters selectedCharacter2 = characters[eleccion2 - 1];
        Console.WriteLine($"Jugador 2, has elegido a {selectedCharacter2.Name}");








        MazeGeneration laberinto = new MazeGeneration(31, 31);




        int movimientosRestantes1 = selectedCharacter.Movement;
        int movimientosRestantes2 = selectedCharacter2.Movement;
        bool mamannema1 = false;
        bool mamannema2 = false;

        while (!mamannema1 && !mamannema2)
        {
            while (movimientosRestantes1 > 0)
            {
                if (movimientosRestantes1 > 0)
                {

                    movimientosRestantes2 = characters[eleccion2 - 1].Movement;
                    Movement.MostrarMapa();
                    Console.WriteLine($"Turno de {selectedCharacter.Name} (Jugador 1). Movimientos restantes: {movimientosRestantes1}");
                    Console.WriteLine("Jugador 1, muevase en la direccion deseada (WASD):");
                    var key1 = Console.ReadKey(true).Key;
                    switch (key1)

                    {
                        case ConsoleKey.W:
                            if (Movement.moverPersonaje("arriba", 1))
                                movimientosRestantes1--;
                            break;

                        case ConsoleKey.S:
                            if (Movement.moverPersonaje("abajo", 1))
                                movimientosRestantes1--;
                            break;

                        case ConsoleKey.A:
                            if (Movement.moverPersonaje("izquierda", 1))
                                movimientosRestantes1--;
                            break;

                        case ConsoleKey.D:
                            if (Movement.moverPersonaje("derecha", 1))
                                movimientosRestantes1--;
                            break;
                        default:
                            Console.WriteLine("Tecla no valida...Usa WASD");
                            break;
                    }
                    if (MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] != "⬛️" && MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] != "🧱")
                    {
                        if (Casilla.trampas.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]))
                        {
                            Casilla.MostrarInfoCasilla(MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y]);
                            Console.WriteLine("Toque una tecla para terminar la excepcion de la ocurrencia");
                            Console.ReadKey();
                            if (MazeGeneration.laberinto[Movement.posicionPersonaje1.x, Movement.posicionPersonaje1.y] == "🪬")
                            {
                                mamannema1 = true;
                                Console.WriteLine("HAS ENCONTRADO EL MALDITO TESORO, HAS VENCIDO A TU MALDITO OPONENTE DIABLO FELICIDADES");
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

                    }
                }


            }
            while (movimientosRestantes2 > 0)
            {


                if (movimientosRestantes2 > 0)
                {
                    movimientosRestantes1 = characters[eleccion - 1].Movement;
                    Movement.MostrarMapa();
                    Console.WriteLine($"Turno de {selectedCharacter2.Name} (Jugador 2). Movimientos restantes: {movimientosRestantes2}");
                    Console.WriteLine("Jugador 2, muevase en la dirección deseada (WASD):");
                    var key2 = Console.ReadKey(true).Key;

                    if (key2 == ConsoleKey.W)
                    {
                        if (Movement.moverPersonaje("arriba", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.S)
                    {
                        if (Movement.moverPersonaje("abajo", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.A)
                    {
                        if (Movement.moverPersonaje("izquierda", 2))
                            movimientosRestantes2--;
                    }
                    else if (key2 == ConsoleKey.D)
                    {
                        if (Movement.moverPersonaje("derecha", 2))
                            movimientosRestantes2--;
                    }
                    else
                    {
                        Console.WriteLine("Tecla no válida... Usa WASD.");
                    }

                    if (MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] != "⬛️" && MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] != "🧱")
                    {
                        if (Casilla.trampas.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]))
                        {
                            Casilla.MostrarInfoCasilla(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]);
                            Console.WriteLine("Toque una tecla para terminar la excepcion de la ocurrencia");
                            Console.ReadKey();
                            if (MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] == "🪬")
                            {
                                mamannema2 = true;
                                Console.WriteLine("HAS ENCONTRADO EL MALDITO TESORO, HAS VENCIDO A TU MALDITO OPONENTE DIABLO FELICIDADES");
                                break;
                            }
                        }
                        if (Casilla.npc.ContainsKey(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]))
                        {
                            Casilla.MostrarInfoNpc(MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y]);
                            Console.WriteLine("Toque una tecla para terminar la excepcion de la ocurrencia");
                            Console.ReadKey();
                            MazeGeneration.laberinto[Movement.posicionPersonaje2.x, Movement.posicionPersonaje2.y] = "⬛️";

                        }
                    }
                }
            }







        }
    }
}


