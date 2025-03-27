using ConsoleApp1.Interface;

namespace ConsoleApp1.Containers;

public class L :Kontener
{
    private string _rodzajLadunku;
    public L(double masaLadunku, double wysokosc, double glebokosc, int numer, string rodzajLadunku, string typ = "L")
        : base(masaLadunku, wysokosc, glebokosc, numer, typ)
    {
        Console.WriteLine("Podaj rodzaj ladunku");
        _rodzajLadunku = rodzajLadunku;
        IHazardNotifier.Notify(rodzajLadunku, base.PokazNumerSeryjny());
    }
    
    public override void ZaladujKontener(double masaLadunku)
    {
        if (masaLadunku > _maksymalnaPojemnosc) throw new OverflowException("Przekroczono pojemność kontenera");
        if (_rodzajLadunku == "Paliwo")
        { 
            var newMaxLoad = _maksymalnaPojemnosc - (_maksymalnaPojemnosc * 0.50);
            if (masaLadunku > newMaxLoad)
            {
                Console.WriteLine("Uwaga, próba wykonania niebezpiecznej operacji");
                ZaladujKontener(masaLadunku);
            }
        }
        else
        {
            var newMaxLoad = _maksymalnaPojemnosc - (_maksymalnaPojemnosc * 0.90);
            if (masaLadunku > newMaxLoad)
            {
                Console.WriteLine("Uwaga, próba wykonania niebezpiecznej operacji");
                ZaladujKontener(masaLadunku);
            }
        }
        
        _masaLadunku = masaLadunku;
    }
}