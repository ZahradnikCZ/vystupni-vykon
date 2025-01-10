// Jaky výkon signálu Pout bude na výstupu zesilovače se zesílením 23 dB
// Jestliže je vstupní výkon Pin = 10 mW?
// Pout = Pin * 10^(G/10)
// Pout = 10 * 10^(23/10) = 10 * 10^2.3 = 10 * 199.526 = 1995.26 mW
// Pout = 1.99526 W

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Výpočet výstupního výkonu zesilovače nebo filtru");
        Console.WriteLine("------------------------------------------------");

        //Zadání vstupního výkonu od uživatele
        Console.Write("Zadejte vstupní výkon Pin [mW]: ");
        double Pin = double.Parse(Console.ReadLine().Replace(".", ","));

        //Zadání zisku zesilovače nebo ztrát filtru od uživatele
        Console.Write("Zadejte zisk zesilovače nebo útlum filtru (G) [dB]: ");
        double ziskutlum = double.Parse(Console.ReadLine().Replace(".", ","));

        // Pout = Pin * 10^(G/10)
        // Zesilení nebo utlum v dB převádíme na poměr výkonů
        double Pomer = Math.Pow(10, ziskutlum / 10);
        // Výpočet výstupního výkonu
        double Pout = Pin * Pomer;

        string jednotka = "mW";
        if (Pout > 1000000)
        {
            Pout /= 1000000000;
            jednotka = "kW";
        }
        else if (Pout > 1000)
        {
            Pout /= 1000000;
            jednotka = "W";
        }
        else if (Pout < 1)
        {
            Pout *= 1000;
            jednotka = "uW";
        }

        //Výstup pro uživatele
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"Zisk nebo útlum = {Pomer:F3} ");
        Console.WriteLine($"Výstupní výkon Pout = {Pout:F3} {jednotka}");
        End();
    }
    static void End()
    {
        Console.WriteLine("\nChcete opakovat výpočet? y/n");
        string again = Console.ReadLine();
        if (again == "y")
        {
            Console.Clear();
            Main();
        }
        else if (again == "n")
        {
            Console.WriteLine("Konec programu");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("Chybná volba");
            Console.Clear();
            End();
        }
    }
}
