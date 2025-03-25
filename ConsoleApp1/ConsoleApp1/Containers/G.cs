using ConsoleApp1.Interface;

namespace ConsoleApp1.Containers;

public class G :Kontener
{
    private double _cisnienie;
    private string _rodzajLadunku;
    public G(double masaLadunku, double wysokosc, double glebokosc, int numer, string typ = "G")
        : base(masaLadunku, wysokosc, glebokosc, numer, typ)
    {
        Console.WriteLine("Podaj rodzaj ładunku: ");
        var tmp = Console.ReadLine();
        _rodzajLadunku = tmp;
        Console.WriteLine("Podaj cisnienie: ");
        tmp = Console.ReadLine();
        _cisnienie = double.Parse(tmp);
        IHazardNotifier.Notify(_rodzajLadunku, base.PokazNumerSeryjny());
    }
    public override void OproznijKontener()
    {
        _masaLadunku = _maksymalnaPojemnosc * 0.95;
        

    }
    
    public virtual void ZaladujKontener(double masaLadunku)
    {
        if (masaLadunku > _maksymalnaPojemnosc) throw new OverflowException("Przekroczono pojemność kontenera");
        else _masaLadunku = masaLadunku;
    }
}