using System;

public class MazeGeneration
{
    public Random aleatorio = new Random();
    public Random listloco = new Random();
    public static string[,] laberinto;
    public static List<string> emotrap = new List<string>
    {
        "🟫","🔮","🔌","⭕️","🧟"
    };

    public List<string> emonpc = new List<string>
    {
        "🧙","👩","🔪","💡"
    };

    public List<string> emoverse = new List<string>
    {
        "🟫","🔮","🔌","⭕️","🧟","🧙","👩","🔪","💡"
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
        laberinto[fila/2+1, columna/2]="⬛️";
        laberinto[fila/2-1, columna/2]="⬛️";
        laberinto[fila/2, columna/2+1]="⬛️";
        laberinto[fila/2, columna/2-1]="⬛️";
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