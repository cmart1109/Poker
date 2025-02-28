public class Card
{
    public string _symbol = "";
    public string _number = "";

    public Card(string symbol, string number)
    {
        _symbol = symbol;
        _number = number; 
    }

    public void PrintCard(){
        if (_number == "14"){
        Console.WriteLine($"A de {_symbol}");
        }
        else if (_number == "13"){
        Console.WriteLine($"K de {_symbol}");
        }
        else if (_number == "12"){
        Console.WriteLine($"Q de {_symbol}");
        }
        else if (_number == "11"){
        Console.WriteLine($"J de {_symbol}");
        }
        else {
        Console.WriteLine($"{_number} de {_symbol}");
        }
    }
}