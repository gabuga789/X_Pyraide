// =====================================================================
//  Projekt "Arena" - Stand Ende Modul 5 (Version v5)
//
//  Neu gegenüber v4: ein echter Kampf Runde für Runde (while),
//  Mehrfachangriffe je nach Waffe (for), Zufall und ein Menü (do-while).
//  Der Gegner ist jetzt ein Troll mit 600 Lebenspunkten.
//  Dieses Programm wächst im Laufe des Kurses weiter.
// =====================================================================

namespace Uebungs_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Held ---
            Console.Write("Wie heißt dein Held? ");
            string heldenName = Console.ReadLine();

            Console.Write("Lebenspunkte: ");
            int lebenspunkte = int.Parse(Console.ReadLine());

            Console.Write("Stärke: ");
            int staerke = int.Parse(Console.ReadLine());

            Console.Write("Gold: ");
            int gold = int.Parse(Console.ReadLine());

            Console.Write("Kritische Chance (z. B. 0,15): ");
            double kritischeChance = double.Parse(Console.ReadLine());

            if (kritischeChance < 0 || kritischeChance > 1)
            {
                Console.WriteLine("Die Chance muss zwischen 0 und 1 liegen - sie wird auf 0 gesetzt.");
                kritischeChance = 0;
            }

            bool hatSchild = true;

            // --- Gegner ---
            string gegnerName = "Troll";
            int gegnerLebenspunkte = 600;
            int gegnerRuestung = 8;

            // --- Waffe ---
            Console.Write("Waffe (Schwert/Axt/Bogen/Speer): ");
            string waffenName = Console.ReadLine();
            int waffenBonus;
            int angriffe;

            switch (waffenName)
            {
                case "Schwert":
                case "schwert":
                    waffenBonus = 6;
                    break;
                case "Axt":
                case "axt":
                    waffenBonus = 10;
                    break;
                case "Bogen":
                case "bogen":
                    waffenBonus = 1;
                    istFernkampf = true; // Bogen aktiviert den Fernkampf
                    break;
                case "Dolch":
                case "dolch":
                    waffenBonus = 2;
                    break;
                case "Hellebarde":
                case "hellebarde":
                    waffenBonus = 12;
                    break;
                case "Streitkolben":
                case "streitkolben":
                    waffenBonus = 18;
                    break;
                case "Speer":
                case "speer":
                    waffenBonus = 5;
                    istFernkampf = true;
                    break;
                case "Großschwert":
                case "großschwert":
                    waffenBonus = 15;
                    break;
                default:
                    Console.WriteLine("Unbekannte Waffe - du kämpfst mit bloßen Fäusten.");
                    waffenName = "bloßen Fäusten";
                    waffenBonus = 0;
                    break;
            }

            int grundschaden = 10;

            // --- Schadensberechnung ---
            bool istFernkampf = waffenName == "Bogen" || waffenName == "Speer";

            int ruestungsAbzug = gegnerRuestung;

            if (istFernkampf)
            {
                ruestungsAbzug = gegnerRuestung / 2;
            }

            int schaden = (grundschaden + waffenBonus) * staerke - ruestungsAbzug;

            // --- Vorsprung ---
            int vorsprung = lebenspunkte - gegnerLebenspunkte;

            // --- Ausgabe ---
            Console.WriteLine();
            Console.WriteLine("=== HELDENPROFIL ===");
            Console.WriteLine($"Name:         {heldenName}");
            Console.WriteLine($"Lebenspunkte: {lebenspunkte}");
            Console.WriteLine($"Stärke:       {staerke}");
            Console.WriteLine($"Gold:         {gold}");
            Console.WriteLine($"Krit-Chance:  {kritischeChance}");
            Console.WriteLine($"Schild:       {hatSchild}");

            if (lebenspunkte < 20)
            {
                Console.WriteLine("Kritisch! Nimm einen Heiltrank.");
            }
            else if (lebenspunkte < 60)
            {
                Console.WriteLine("Angeschlagen.");
            }
            else
            {
                Console.WriteLine("Alles im grünen Bereich.");
            }

            Console.WriteLine();
            Console.WriteLine("=== GEGNER ===");
            Console.WriteLine($"Name:         {gegnerName}");
            Console.WriteLine($"Lebenspunkte: {gegnerLebenspunkte}");
            Console.WriteLine($"Rüstung:      {gegnerRuestung}");

            Console.WriteLine();
            Console.WriteLine($"{heldenName} greift mit {waffenName} an und verursacht {schaden} Schaden.");

            if (schaden >= gegnerLebenspunkte)
            {
                Console.WriteLine($"{gegnerName} fällt mit einem Schlag!");
            }
            else
            {
                Console.WriteLine($"{gegnerName} übersteht den ersten Angriff.");
            }

            if (vorsprung > 0)
            {
                Console.WriteLine($"{heldenName} ist um {vorsprung} LP im Vorteil.");
            }
            else if (vorsprung < 0)
            {
                Console.WriteLine($"{gegnerName} ist um {-vorsprung} LP im Vorteil.");
            }
            else
            {
                Console.WriteLine("Gleichstand.");
            }

            // --- Händler ---
            Console.WriteLine();
            Console.WriteLine("=== HÄNDLER ===");
            Console.Write("Testpreis für einen Heiltrank: ");
            int trankPreis = int.Parse(Console.ReadLine());

            if (trankPreis <= 0)
            {
                Console.WriteLine("Der Preis muss größer als 0 sein.");
            }
            else
            {
                int traenke = gold / trankPreis;
                int restGold = gold % trankPreis;
                Console.WriteLine($"Du kannst {traenke} Tränke kaufen, {restGold} Gold bleiben übrig.");
            }

            // --- Kampfbilanz ---
            Console.WriteLine();
            Console.WriteLine("=== KAMPFBILANZ ===");
            Console.Write("Bestrittene Kämpfe: ");
            int kaempfe = int.Parse(Console.ReadLine());

            Console.Write("Davon gewonnen: ");
            int siege = int.Parse(Console.ReadLine());

            if (kaempfe <= 0 || siege < 0 || siege > kaempfe)
            {
                Console.WriteLine("Unsinnige Eingabe - die Bilanz kann nicht berechnet werden.");
            }
            else
            {
                int niederlagen = kaempfe - siege;
                double siegquote = (double)siege / kaempfe;

                Console.WriteLine($"Siege:       {siege}");
                Console.WriteLine($"Niederlagen: {niederlagen}");
                Console.WriteLine($"Siegquote:   {siegquote:F2}");

                char rang;

                if (siegquote >= 0.75)
                {
                    rang = 'A';
                }
                else if (siegquote >= 0.50)
                {
                    rang = 'B';
                }
                else if (siegquote >= 0.25)
                {
                    rang = 'C';
                }
                else
                {
                    rang = 'D';
                }

                Console.WriteLine($"Rang:        {rang}");

                switch (rang)
                {
                    case 'A':
                        Console.WriteLine("Titel:       Legende der Arena");
                        break;
                    case 'B':
                        Console.WriteLine("Titel:       Erfahrener Kämpfer");
                        break;
                    case 'C':
                        Console.WriteLine("Titel:       Solider Anfänger");
                        break;
                    default:
                        Console.WriteLine("Titel:       Noch viel zu lernen");
                        break;
                }

                bool bossFrei = kaempfe >= 5 && siegquote >= 0.5 && lebenspunkte >= 80;

                if (bossFrei)
                {
                    Console.WriteLine("Die Bossarena steht dir offen.");
                }
                else
                {
                    Console.WriteLine("Für den Bosskampf fehlt noch etwas.");
                }
            }

            // --- Zufall ---
            Random zufall = new Random();

            // --- Spielmenü ---
            int wahl;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== WAS WILLST DU TUN? ===");
                Console.WriteLine("1 = Kämpfen");
                Console.WriteLine("2 = Heiltrank kaufen");
                Console.WriteLine("3 = Beenden");
                Console.Write("Deine Wahl: ");
                wahl = int.Parse(Console.ReadLine());

                if (wahl == 1)
                {
                    int gegnerLP = gegnerLebenspunkte;
                    int runde = 1;

                    while (lebenspunkte > 0 && gegnerLP > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"-- Runde {runde} --");

                        for (int i = 1; i <= angriffe; i++)
                        {
                            int rundenSchaden = schaden + zufall.Next(-5, 6);
                            gegnerLP = gegnerLP - rundenSchaden;
                            Console.WriteLine($"{heldenName} trifft für {rundenSchaden}. {gegnerName}: {gegnerLP} LP");
                        }

                        if (gegnerLP > 0)
                        {
                            int gegnerSchaden = zufall.Next(10, 31);
                            lebenspunkte = lebenspunkte - gegnerSchaden;
                            Console.WriteLine($"{gegnerName} trifft für {gegnerSchaden}. {heldenName}: {lebenspunkte} LP");
                        }

                        runde = runde + 1;
                    }

                    Console.WriteLine();

                    if (lebenspunkte > 0)
                    {
                        Console.WriteLine($"{gegnerName} ist besiegt!");
                    }
                    else
                    {
                        Console.WriteLine($"{heldenName} ist besiegt.");
                    }
                }
                else if (wahl == 2)
                {
                    if (trankPreis > 0 && gold >= trankPreis)
                    {
                        gold = gold - trankPreis;
                        lebenspunkte = lebenspunkte + 30;
                        Console.WriteLine($"Getrunken. Lebenspunkte: {lebenspunkte}, Gold: {gold}");
                    }
                    else
                    {
                        Console.WriteLine("Dafür reicht dein Gold nicht.");
                    }
                }
            }
            while (wahl != 3);
        }
    }
}
