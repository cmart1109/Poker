public class Card
{
    protected string _symbol = "";
    public string _number = "";

    public Card(string symbol, string number)
    {
        _symbol = symbol;
        _number = number; 
    }

    public void PrintCard(){
        Console.WriteLine($"{_number} de {_symbol}");
    }
}