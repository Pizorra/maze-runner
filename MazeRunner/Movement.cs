using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using static Program;
class Movement
{
    public static (int x, int y) posicionPersonaje1 = (1, 1);
    public static (int x, int y) posicionPersonaje2 = (31, 31);


    public static void MostrarMapa()
    {
        Console.Clear();
        for (int x = 0; x < MazeGeneration.laberinto.GetLength(0); x++)
        {
            for (int y = 0; y < MazeGeneration.laberinto.GetLength(1); y++)
            {
                if ((x, y) == posicionPersonaje1)
                {
                    Console.Write("👵");
                }
                else if ((x, y) == posicionPersonaje2)
                {
                    Console.Write("👨");
                }
                else
                {
                    Console.Write(MazeGeneration.laberinto[x, y]);
                }

            }
            Console.WriteLine();





        }
    }




    public static bool moverPersonaje(string direccion, int numerodejugador)
    {
        int x, y;
        if (numerodejugador == 1)
        {
            x = posicionPersonaje1.x;
            y = posicionPersonaje1.y;
        }

        else if (numerodejugador == 2)
        {
            x = posicionPersonaje2.x;
            y = posicionPersonaje2.y;
        }
        else
        {
            return false;
        }


        if (direccion == "arriba" && x > 0 && MazeGeneration.laberinto[x - 1, y] != "🧱")
        {
            x--;
        }

        else if (direccion == "abajo" && x < MazeGeneration.laberinto.GetLength(0) - 1 && MazeGeneration.laberinto[x + 1, y] != "🧱")
        {
            x++;
        }

        else if (direccion == "izquierda" && y > 0 && MazeGeneration.laberinto[x, y - 1] != "🧱")
        {
            y--;
        }

        else if (direccion == "derecha" && y < MazeGeneration.laberinto.GetLength(1) - 1 && MazeGeneration.laberinto[x, y + 1] != "🧱")
        {
            y++;
        }
        else
        {
            return false;
        }
        if (numerodejugador == 1)
        {
            posicionPersonaje1 = (x, y);
        }
        else if (numerodejugador == 2)
        {
            posicionPersonaje2 = (x, y);
        }


        return true;









    }






}