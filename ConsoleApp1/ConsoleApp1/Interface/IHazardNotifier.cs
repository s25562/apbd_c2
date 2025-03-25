using System.Diagnostics;

namespace ConsoleApp1.Interface;

public class IHazardNotifier
{
    public static void Notify(string ladunek, string seryjny)
    {
        switch (ladunek)
        {
            case "Paliwo":
                Console.WriteLine("Materiały niebezpieczne - Paliwo !!! W kontenerze: " + seryjny);
                break;
            default:
                Console.WriteLine("Zwykły materiał");
                break;
        }
    }
}