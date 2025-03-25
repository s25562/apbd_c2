namespace ConsoleApp1.Containers;

public class C :Kontener
{
    private string _rodzajProduktu;
    private double _temperatura;
    
    public C(double masaLadunku, double wysokosc, double glebokosc, int numer, string rodzajProduktu, string typ = "C")
        : base(masaLadunku, wysokosc, glebokosc, numer, typ)
    {
        _rodzajProduktu = rodzajProduktu;
        UstawTemperature(_rodzajProduktu);
        
    }
    
    private void UstawTemperature(string rodzajProduktu)
    {
        switch (rodzajProduktu)
        {
            case "Banany":
                _temperatura = 13.3;
                break;
            case "Czekolada":
                _temperatura = 18;
                break;
            case "Ryby":
                _temperatura = 2;
                break;
            case "Mięso":
                _temperatura = -15;
                break;
            case "Lody":
                _temperatura = -18;
                break;
            case "Mrożona pizza":
                _temperatura = -30;
                break;
            case "Sery":
                _temperatura = 7.2;
                break;
            case "Kiełbaski":
                _temperatura = 5;
                break;
            case "Masło":
                _temperatura = 20.5;
                break;
            case "Jajka":
                _temperatura = 19;
                break;
            default:
                _temperatura = 0;
                break;
        }
    }
    
}

