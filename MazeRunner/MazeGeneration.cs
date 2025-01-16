using System;

public class MazeGeneration
{
    public Random aleatorio = new Random();
    public Random listloco = new Random();
    public static string[,] laberinto;
    public List<string> emotrap = new List<string>
    {
        "🟫","🔮","🔌","⭕️","🧟"
    };

    public List<string> emonpc = new List<string>
    {
        "🧙","👩","🥷🏾","💡"
    };

    public List<string> emoverse = new List<string>
    {
        "🟫","🔮","🔌","⭕️","🧟","🧙","👩","🥷🏾","💡"
    };




    public int fila;
    public int columna;
    public bool[,] visitado;

    public int[] movimiento_fila = { 2, -2, 0, 0 };
    public int[] movimiento_columna = { 0, 0, 2, -2 };

    public MazeGeneration(int fila1, int columna1)
    {
        fila = fila1 + 2;
        columna = columna1 + 2;
        visitado = new bool[fila, columna];
        laberinto = new string[fila, columna];
        IniciLaber();
        GeneradorCamino(1, 1);
        CasillasTirar();
        laberinto[fila/2, columna/2] = "🪬";
        ImprimiLaber();
    }

    public void IniciLaber()
    {
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                if (j % 2 != 0 && i % 2 != 0)
                {
                    laberinto[i, j] = "⬛️";
                }
                else
                {
                    laberinto[i, j] = "🧱";
                }
                visitado[i, j] = false;
            }
        }
    }
    public void CasillasTirar()
    {
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                int emobility = aleatorio.Next(0, 10);
                if (emobility == 1 && laberinto[i, j] == "⬛️")
                {
                    int listlocoloco = listloco.Next(0, emoverse.Count());
                    laberinto[i, j] = emoverse[listlocoloco];
                    if (emonpc.Contains(emoverse[listlocoloco]))
                    {
                        emoverse.Remove(emoverse[listlocoloco]);
                    }
                }
            }
        }
    }

    public void ImprimiLaber()
    {
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                Console.Write(laberinto[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void GeneradorCamino(int f, int c)
    {
        visitado[f, c] = true;


        int[] direcciones = { 0, 1, 2, 3 };
        Alborotador(direcciones, aleatorio);

        for (int i = 0; i < 4; i++)
        {
            int vecinof = f + movimiento_fila[direcciones[i]];
            int vecinoc = c + movimiento_columna[direcciones[i]];

            if (CasillaValida(vecinof, vecinoc) && !visitado[vecinof, vecinoc])
            {

                laberinto[f + movimiento_fila[direcciones[i]] / 2, c + movimiento_columna[direcciones[i]] / 2] = "⬛️";
                GeneradorCamino(vecinof, vecinoc);
            }
        }
    }

    public bool CasillaValida(int posx, int posy)
    {
        return posx >= 1 && posy >= 1 && posx < fila - 1 && posy < columna - 1;
    }

    private void Alborotador(int[] array, Random rng)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}













/*using System.CodeDom.Compiler;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class MazeGeneration
{

    public Random aleatorio = new Random();

    public string[,] laberinto;
    public int fila;
    public int columna;
    public bool[,] visitado;

    public int[] movimiento_fila = { 2, -2, 0, 0 };


    public int[] movimiento_columna = { 0, 0, 2, -2 };

    public MazeGeneration(int fila1, int columna1)
    {
        fila = fila1 + 2;
        columna = columna1 + 2;
        visitado = new bool[fila, columna];
        laberinto = new string[fila, columna];
        IniciLaber();
        GeneradorCamino(1, 1);
        ImprimiLaber();

    }

    public void IniciLaber()
    {
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {


                if (j % 2 != 0 && i % 2 != 0)
                {
                    laberinto[i, j] = "⬛️";
                }
                else
                {
                    laberinto[i, j] = "🧱";
                }


                visitado[i, j] = false;



            }
        }
    }


    public void ImprimiLaber()
    {
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                Console.Write(laberinto[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void GeneradorCamino(int f, int c)
    {

        visitado[f, c] = true;

        bool existe = false;

        for (int i = 0; i < 4; i++)
        {
            int vecinof;
            int vecinoc;

            vecinof = f + movimiento_fila[i];
            vecinoc = c + movimiento_columna[i];
            if (CasillaValida(vecinof, vecinoc) == true && visitado[vecinof, vecinoc] == false)
            {
                existe = true;




            }
        }

        if (existe == true)
        {
            while (true)
            {

                int num = aleatorio.Next() % 4;
                int vecinof;
                int vecinoc;

                vecinof = f + movimiento_fila[num];
                vecinoc = c + movimiento_columna[num];

                if (CasillaValida(vecinof, vecinoc) == true && visitado[vecinof, vecinoc] == false && num == 0)
                {
                    laberinto[f + 1, c] = "⬛️";
                    GeneradorCamino(vecinof, vecinoc);
                    break;

                }
                else if (CasillaValida(vecinof, vecinoc) == true && visitado[vecinof, vecinoc] == false && num == 1)
                {
                    laberinto[f - 1, c] = "⬛️";
                    GeneradorCamino(vecinof, vecinoc);
                    break;

                }
                else if (CasillaValida(vecinof, vecinoc) == true && visitado[vecinof, vecinoc] == false && num == 2)
                {
                    laberinto[f, c + 1] = "⬛️";
                    GeneradorCamino(vecinof, vecinoc);
                    break;

                }
                else if (CasillaValida(vecinof, vecinoc) == true && visitado[vecinof, vecinoc] == false && num == 3)
                {
                    laberinto[f, c - 1] = "⬛️";
                    GeneradorCamino(vecinof, vecinoc);
                    break;

                }



            }
        }
   }

    public bool CasillaValida(int posx, int posy)
    {
        if (posx < 1 || posy < 1 || posx > 21 || posy > 21)
        {
            return false;
        }

        if (laberinto[posx, posy] == "🧱")
        {
            return false;

        }


        return true;

    }
}*/



/*public class MazeGeneration
{

    public static int width = 41;
    public static int height = 41;
    public static char[,] maze;
    static Random rand = new Random();

    public MazeGeneration()
    {
        maze = new char[width, height];
        for(int i=0; i<41; i++){
            for(int j=0; j<41; j++){
                maze[i, j]='0';
            }
        }
        GenerateMaze(0, 0);
        PrintMaze();
    }

    public static void GenerateMaze(int x, int y)
    {
        maze[x, y] = '1';
        var directions = new (int, int)[]
        {

            (0,1),
            (1,0),
            (0,-1),
            (-1,0),



        };


        Shuffle(directions);

        foreach (var (dx, dy) in directions)
        {
            int nx = x + dx;
            int ny = y + dy;
            if (IsInBounds(nx, ny) && maze[nx, ny] == '0')
            {
                //maze[nx , ny] = '1';
                GenerateMaze(nx, ny);
            }
        }
    }

    public static void Shuffle((int, int)[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);

        }
    }

    public static bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public static void PrintMaze()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(maze[x, y] == '1' ? " " : "#");

            }
            Console.WriteLine();
        }
    }







}*/
