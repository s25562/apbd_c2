using ConsoleApp1.Interface;

namespace ConsoleApp1.Containers;

public class L :Kontener
{
    private string _rodzajLadunku;
    public string ladunek { get; set; }
    public L(double masaLadunku, double wysokosc, double glebokosc, int numer, string typ = "L", string rodzajLadunku = "Zwykły")
        : base(masaLadunku, wysokosc, glebokosc, numer, typ)
    {
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