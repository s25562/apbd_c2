using ConsoleApp1.Containers;

namespace ConsoleApp1.Vehicle;

public abstract class Pojazd
{
    private List<Kontener> _kontenery;
    private double _maksPredkosc;
    private int _maksKontenerow;
    private int _aktualnieKontenerow;
    private double _maksObciazenie;
    private double _aktualneObciazenie;
    private int _id;

    public Pojazd(int id, double maksPredkosc, int maksKontenerow, double maksObciazenie)
    {
        _id = id;
        _kontenery = new List<Kontener>();
        _aktualnieKontenerow = 0;
        _maksPredkosc = maksPredkosc;
        _maksKontenerow = maksKontenerow;
        _maksObciazenie = maksObciazenie;
    }


    public Kontener ZwrocKontener(string sn)
    {
        for(int i=0; i<_kontenery.Count; i++)
            if(_kontenery[i].PokazNumerSeryjny() == sn)
                return _kontenery[i];
        return null;
    }

    public void PokazPojazd()
    {
        Console.WriteLine($"ID: {_id}, Kontenerow: {_kontenery.Count}, MaksPredkosc: {_maksPredkosc}, MaksKontenerow: {_maksKontenerow}");
    }
 

    public void WyladujKontenerowiec()
    {
        _kontenery.Clear();
    }
    public int GetId()
    {
        return _id;
    }

    public void PokazWszystkieKontenery()
    {
        for (int i = 0; i < _kontenery.Count; i++)
            Console.WriteLine((_kontenery[i].PokazNumerSeryjny()));
    }

    public void dodajKontener(Kontener kontener)
    {
        if (kontener._masaLadunku + _aktualneObciazenie < _maksObciazenie
            && _aktualnieKontenerow + 1 < _maksKontenerow)
        {
            _aktualneObciazenie += kontener._masaLadunku;
            _aktualnieKontenerow++;
            _kontenery.Add(kontener);
        }
        else
        {
            Console.WriteLine("Brak miejsca na statku");
        }
    }

    public void ZamienKontenery(string sn, Kontener kontener)
    {
        for (int i = 0; i < _kontenery.Count; i++)
        {
            if (_kontenery[i].PokazNumerSeryjny() == sn)
            {
                _kontenery[i] = kontener;
            }
            else
            {
                Console.WriteLine("Brak takiego numeru seryjnego");
            }
        }
    }
    
    public void usunKontener(string sn)
    {
        for (int i = 0; i < _kontenery.Count; i++)
        {
            if (sn == _kontenery[i].PokazNumerSeryjny())
            {
                _kontenery.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("Nie ma takiego kontenera");
            }
        }
    }
}