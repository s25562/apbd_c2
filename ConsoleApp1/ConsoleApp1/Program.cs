// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int number = 0;
string input = "Text" + " jakiś inny tekst " + number;
string input2 = $"Text: {number}";

var zmienna = "Hello, World!";

//Nullable
{
    int? nullableInt = null;
    nullableInt = 10;
    Object? o = null;
}

//Kolekcje
{
    var list = new List<int>();
    list.Add(10);
    
    var dict = new Dictionary<string, int>();
    dict.Add("1", 1);
    
}

//Obsługa błędów
{
    try
    {
        throw new Exception();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}