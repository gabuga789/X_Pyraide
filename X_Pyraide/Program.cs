namespace X_Pyraide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stufen = 15; // Anzahl der Stufen der Pyramide
            for (int a = 1; a <= stufen; a++) // erstellt die stufen der Pyramide (wert; bedingung; inkrement bzw. was passieren soll)
            {
                for (int b = 1; b <= stufen - a; b++) // für die abstände zwischen den stufen
                {
                    Console.Write(" ");
                }
                for (int c = 1; c <= (2 * a - 1); c++) // für die X's in den stufen
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
    }
}

