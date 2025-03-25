using ConsoleApp1.Containers;
using ConsoleApp1.Vehicle;

namespace ConsoleApp1;

public class System
{
    //Variables
    private bool _running;
    private List<Kontener> _kontenery;
    private List<Vehicle.Pojazd> _statki;
    private int _licznik;
    private int _licznikStatki;

    //Constructors
    public System()
    {
        _statki = new List<Vehicle.Pojazd>();
        _kontenery = new List<Kontener>();
        _licznik = 0;
        _licznikStatki = 0;
        _running = true;
    }
    
    //Methods
    public void Start()
    {
        Console.WriteLine("System started, press ENTER to start");
        Update();
        
    }
    
    private void Update()
    {
        
        while (_running)
        {
            var input = Console.ReadKey().Key;
            GetKeys(input);
            Render();

        }
        Console.WriteLine("System stopped");
    }

    private void GetKeys(ConsoleKey input)
    {
        
        switch (input)
        {
            case ConsoleKey.Enter:
                _running = true;
                break;
            
            case ConsoleKey.Q:
                _running = !_running;
                break;
            
            case ConsoleKey.A:
                DodajStatek();
                break;
            
            case ConsoleKey.S:
                KontenerDoKontenerowca();
                break;
            
            case ConsoleKey.C:
                PokazKonteneryKontenerowca();
                break;
            
            case ConsoleKey.D:
                DodajKontener();
                break;
            
            case ConsoleKey.E:
                OproznijKontener();
                break;
            
            case ConsoleKey.F:
                ZaladujKontener();
                break;
            
            case ConsoleKey.W:
                OproznijKontenerowiec();
                break;
            
            case ConsoleKey.Z:
                ZaladujListeKontenerowNaStatek();
                break;
            
            case ConsoleKey.V:
                UsunKontenerZKontenerowca();
                break;
            
            case ConsoleKey.X:
                ZastapKontenerInnym();
                break;
            
            case ConsoleKey.R:
                PodmienKontenerNaStatkach();
                break;
            
            case ConsoleKey.P:
                PokazKontener();
                break;
            
        }
    }

    public void PokazKontener()
    {
        Console.WriteLine("Podaj numer seryjny kontenera");
        var input = Console.ReadLine();
        for (int i = 0; i < _kontenery.Count; i++)
            if(_kontenery[i].PokazNumerSeryjny() == input)
                _kontenery[i].PokazKontener();
    }

    public void PodmienKontenerNaStatkach()
    {
        Console.WriteLine("Podaj id statku z którego chcesz zamienic kontenery");
        var input = Console.ReadLine();
        var id = int.Parse(input);
        
        Console.WriteLine("Podaj id drugiego statku z którego chcesz zamienic kontenery");
        input = Console.ReadLine();
        var id2 = int.Parse(input);

        for (int i = 0; i < _statki.Count; i++)
        {
            for (int j = 0; j < _statki.Count; j++)
            {
                if (_statki[i].GetId() == id && _statki[j].GetId() == id2)
                {
                    Console.WriteLine("Podaj numer seryjne kontenerów na obu satkach które chcesz zamienić");
                    var sn = Console.ReadLine();
                    
                    var sn2 = Console.ReadLine();
                    ZamienKontenery(_statki[i], sn, _statki[j], sn2);
                }
            }
        }
    }

    private void ZamienKontenery(Pojazd statek, string sn, Pojazd statek2, string sn2)
    {
        var tmp = statek.ZwrocKontener(sn);
        statek.usunKontener(sn);
        statek.dodajKontener(statek2.ZwrocKontener(sn2));
        statek2.usunKontener(sn2);
        statek2.dodajKontener(tmp);
    }

    private void ZastapKontenerInnym()
    {
        Console.WriteLine("Podaj id statku z którego chcesz zamienic kontenery");
        var input = Console.ReadLine();
        var id = int.Parse(input);
        for (var i = 0; i < _statki.Count; i++)
        {
            if (_statki[i].GetId() == id)
            {
                Console.WriteLine("Podaj numer seryjny kontenera ktory chcesz podmienic");
                var snSystem = Console.ReadLine();
                Console.WriteLine("Podaj numer seryjny kontenera ktory chcesz podmienic na statku");
                var snStatek = Console.ReadLine();
                for (var j = 0; j < _kontenery.Count; j++)
                {
                    
                    if (_kontenery[j].PokazNumerSeryjny() == snSystem)
                    {
                        _statki[i].ZamienKontenery(snSystem, _kontenery[j]);
                    }
                }
            }
        }
    }

    private void UsunKontenerZKontenerowca()
    {
        Console.WriteLine("Podaj id statku z którego chcesz usunac kontener");
        var input = Console.ReadLine();
        var id = int.Parse(input);

        for (var i = 0; i < _statki.Count; i++)
        {
            if (_statki[i].GetId() == id)
            {
                Console.WriteLine("Podaj sn kontenera, ktory chcesz usunac");
                input = Console.ReadLine();
                _statki[i].usunKontener(input);
            }
        }
    }

    private void ZaladujListeKontenerowNaStatek()
    {
        Console.WriteLine("Podaj id statku którego chcesz oproznic kontenery");
        var input = Console.ReadLine();
        var id = int.Parse(input);
        for (var i = 0; i < _statki.Count; i++)
        {
            if (id == _statki[i].GetId())
            {
                for(int j = 0; j < _statki.Count; j++) 
                    _statki[i].dodajKontener(_kontenery[j]);
            }
        }
    }

    private void OproznijKontenerowiec()
    {
        Console.WriteLine("Podaj id statku którego chcesz oproznic kontenery");
        var input = Console.ReadLine();
        var id = int.Parse(input);
        for (var i = 0; i < _statki.Count; i++)
        {
            if (id == _statki[i].GetId())
            {
                _statki[i].WyladujKontenerowiec();
            }
        }
    }

    private void PokazKonteneryKontenerowca()
    {
        Console.WriteLine("Podaj id statku którego chcesz pokazac kontenery");
        var input = Console.ReadLine();
        var id = int.Parse(input);
        for (var i = 0; i < _statki.Count; i++)
        {
            if (id == _statki[i].GetId())
            {
                _statki[i].PokazWszystkieKontenery();
            }
        }
    }

    private void KontenerDoKontenerowca()
    {
        Console.WriteLine("podaj id statku do ktorego chcesz przypisac kontener");
        var input = Console.ReadLine();
        var id = int.Parse(input);

        for (var i = 0; i < _statki.Count; i++)
        {
            if (id == _statki[i].GetId())
            {
                Console.WriteLine("podaj numer seryjny kontenera jaki chcesz przypisać");
                input = Console.ReadLine();
                for(var j = 0; j < _kontenery.Count; j++)
                    if (input == _kontenery[j].PokazNumerSeryjny())
                    {
                        _statki[i].dodajKontener(_kontenery[j]); 
                    }
                    else
                    {
                        Console.WriteLine("Nie ma takiego kontenera");
                    }
            }
            else
            {
                Console.WriteLine("Nie ma takiego statku");
            }
        }
    }

    private void DodajStatek()
    {
        Console.WriteLine("Podaj parametry statku: ");
        Console.WriteLine("Podaj maksymalna predkosc: ");
        var input = Console.ReadLine();
        var predkosc = double.Parse(input);
        
        Console.WriteLine("Podaj maksymalna ilosc kontenerow: ");
        input = Console.ReadLine();
        var maksKontenerow = int.Parse(input);
        
        Console.WriteLine("Podaj maksymalne obciazenie: ");
        input = Console.ReadLine();
        var maksObciazenie = double.Parse(input);
        _statki.Add(new Vehicle.Statek(++_licznikStatki, predkosc, maksKontenerow, maksObciazenie));
    }
    
    private void ZaladujKontener()
    {
        Console.WriteLine("Podaj numer seryjny kontenera do opróżnienia: ");
        var input = Console.ReadLine();
        Console.WriteLine("Podaj mase ładunku: ");
        var input2 = Console.ReadLine();
        var masaLadunku = double.Parse(input2);

        for(int i = 0; i < _kontenery.Count; i++)
            if (input == _kontenery[i].PokazNumerSeryjny())
                _kontenery[i].ZaladujKontener(masaLadunku);
    }

    private void OproznijKontener()
    {
        Console.WriteLine("Podaj numer seryjny kontenera do opróżnienia: ");
        var input = Console.ReadLine();
        for(int i = 0; i < _kontenery.Count; i++)
            if (input == _kontenery[i].PokazNumerSeryjny())
                _kontenery[i].OproznijKontener();
    }

    private void DodajKontener()
    {
        Console.WriteLine("Podaj parametry kontenera: ");
        Console.WriteLine("Podaj mase ładunku: ");
        var input = Console.ReadLine();
        var masaLadunku = double.Parse(input);
        
        Console.WriteLine("Podaj wysokość: ");
        input = Console.ReadLine();
        var wysokosc = double.Parse(input);
        
        Console.WriteLine("Podaj głębokość: ");
        input = Console.ReadLine();
        var glebokosc = double.Parse(input);
        
        Console.WriteLine("Podaj typ do wyboru: L - Liquid, G - Gaz, C - Chłodniczy");
        var typ = Console.ReadLine();

        
        _licznik++;
        switch (input)
        {
            case "L":
                _kontenery.Add(new L(masaLadunku, wysokosc, glebokosc, _licznik, typ));
                break;
            case "G":
                _kontenery.Add(new G(masaLadunku, wysokosc, glebokosc, _licznik, typ));
                break;
            case "C":
                _kontenery.Add(new C(masaLadunku, wysokosc, glebokosc, _licznik, typ));
                break;
            default:
                _kontenery.Add(new Kontener(masaLadunku, wysokosc, glebokosc, _licznik));
                break;
        }
    }

    private void Render()
    {
        Console.WriteLine("==================================================================");
        Console.WriteLine("Lista kontenerowców:" + _statki.Count);
        for(int i=0; i<_statki.Count; i++)
            _statki[i].PokazPojazd();
        Console.WriteLine();
        
        Console.WriteLine("==================================================================");
        Console.WriteLine("Lista kontenerów:" + _kontenery.Count);
        foreach (var kontener in _kontenery) kontener.PokazKontener();
        Console.WriteLine();
        
        Console.WriteLine("==================================================================");
        Console.WriteLine("Dostępne opcje:" );
        
        Console.WriteLine("A. Dodaj kontenerowiec");
        Console.WriteLine("D. Dodaj kontener");
        if (_kontenery.Count > 0 ) Console.WriteLine("F. Załaduj kontener");
        if (_statki.Count > 0) Console.WriteLine("Z. Zaladuj liste kontenerow do kontenerowca ");
        if (_statki.Count > 0)Console.WriteLine("V. Usun kontener z kontenerowca ");
        if (_kontenery.Count > 0 ) Console.WriteLine("E. Opróżnij kontener");
        if (_kontenery.Count > 0 )Console.WriteLine("X. Zastąp kontener innym ");
        if (_kontenery.Count > 0 && _statki.Count > 0) Console.WriteLine("S. Dodaj kontener do kontenerowca ");
        if (_statki.Count > 0)Console.WriteLine("C. Pokaz kontenery kontenerowca ");
        if (_statki.Count > 0)Console.WriteLine("W. Opróżnij kontenerowiec ");
        if (_kontenery.Count > 0 )Console.WriteLine("O. Wypisz informacje o danym kontenerze ");

    }
    
    
    
}