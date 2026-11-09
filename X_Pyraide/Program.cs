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
                Console.WriteLine();      // zeilenumbruch nach jeder Stufe
            }
            for (int a = stufen - 1; a >= 1; a--) // sorgt dafür, dass die Pyramide auch wieder nach unten geht
            {
                for (int b = 1; b <= stufen - a; b++) // sorgt dafür, dass die abstände zwischen den stufen auch wieder nach unten gehen
                {
                    Console.Write(" ");
                }
                for (int c = 1; c <= (2 * a - 1); c++) // sorgt dafür, dass die X's in den stufen auch wieder nach unten gehen
                {
                    Console.Write("X");
                }
                Console.WriteLine();   // zeilenumbruch nach jeder Stufe
            }
        }   
    }
}

