namespace ConsoleApp1.Containers;

public class Kontener
{
    //Zmienne
    public double _masaLadunku{get;set;}
    private double _wysokosc;
    public double _wagaWlasna{get;set;}
    private double _glebokosc;
    private string _numerSeryjny;
    public double _maksymalnaPojemnosc{get;set;}

    //Konstruktory
    public Kontener(double masaLadunku, double wysokosc, double glebokosc, int numer, string typ = "Zwykły")
    {
        _masaLadunku = masaLadunku;
        _wysokosc = wysokosc;
        _glebokosc = glebokosc;
        UstalWageWlasna();
        UstalMaksymalnaPojemnosc();
        UstalMaseLadunku();
        UstalNumerSeryjny(numer, typ);
    }
    

    
    //Metody
    private void UstalNumerSeryjny(int numer, string typ)
    {
        _numerSeryjny = "KON-";
        _numerSeryjny += typ + "-";
        _numerSeryjny += numer.ToString();
    }
 
    
    protected virtual void UstalWageWlasna(double wagaWlasna = 3000)
    {
        _wagaWlasna = wagaWlasna;
    }
    
    protected virtual void UstalMaksymalnaPojemnosc(double maksymalnaPojemnosc = 300000)
    {
        _maksymalnaPojemnosc = maksymalnaPojemnosc;
    }
    
    protected virtual void UstalMaseLadunku(double masaLadunku = 10000)
    {
        _masaLadunku = masaLadunku;
    }
    

    public void PokazKontener()
    {
        Console.WriteLine("Numer seryjny: " + _numerSeryjny + " Masa ładunku: " + _masaLadunku + 
                          "kg Wysokość: " + _wysokosc + "cm Głębokość: " + _glebokosc  + 
                          "cm MaksymalnaPojemność: " + _maksymalnaPojemnosc + "kg WagaWłasna: " + _wagaWlasna);
    }

    public string PokazNumerSeryjny()
    {
        return _numerSeryjny;
    }
    


    public virtual void OproznijKontener()
    {
        _masaLadunku = 0;
    }
    
    public virtual void ZaladujKontener(double masaLadunku)
    {
        if (masaLadunku > _maksymalnaPojemnosc) throw new OverflowException("Przekroczono pojemność kontenera");
        else _masaLadunku = masaLadunku;
    }
}