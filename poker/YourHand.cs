
using System.ComponentModel.Design;

public class YourHand : Hand
{   
    private int _order = 0;
    private List<Card> _hand = new List<Card>();

    private bool CheckStraight(List<int> numbers)
    {
    if (numbers.Count < 5)
        return false;


    if (numbers.Contains(14) && numbers.Contains(2) && numbers.Contains(3) && numbers.Contains(4) && numbers.Contains(5))
        return true;

    
    for (int i = 0; i <= numbers.Count - 5; i++)
    {
        if (numbers[i + 4] - numbers[i] == 4 &&
            numbers[i + 1] == numbers[i] + 1 &&
            numbers[i + 2] == numbers[i] + 2 &&
            numbers[i + 3] == numbers[i] + 3)
        {
            return true;
        }
    }

    return false;
}

    public Dictionary<string, int> GetCardsCount()
    {
        return _hand.GroupBy(c => c._number)
        .ToDictionary(global => global.Key, global=> global.Count());
    }
        public Dictionary<string, int> GetSuitsCount()
    {
        return _hand.GroupBy(c => c._symbol)
        .ToDictionary(global => global.Key, global=> global.Count());
    }
    public YourHand()
    {

    }
    public override List<Card> GenerateHand(List<Card> deck)
    {
        for (int i = 1; i <= 2; i++)
        {
            _hand.Add(GetRandomCard(deck));
            
        }
        return _hand;
    }
    public override void PrintHand()
    {
        foreach (var hand in _hand)
        {
            hand.PrintCard();
        }
    }
    public override void GetCard(List<Card >deck)
    {
        Card newCard = GetRandomCard(deck);
        _hand.Add(newCard);
    }

    public void CheckHand()
    {
        var CardCounts = GetCardsCount().Values.ToList();
        var SuitsCounts = GetSuitsCount().Values.ToList();
        var CardsNumber = GetCardsCount().Keys.Select(int.Parse).OrderBy(x => x).ToList();

        int pairs = CardCounts.Count(x => x == 2);
        bool hasThree = CardCounts.Contains(3);
        bool hasFour = CardCounts.Contains(4);
        bool hasColor = SuitsCounts.Contains(5);
        bool HasStraight = CheckStraight(CardsNumber);


        if (hasFour)
        {
            Console.WriteLine("Tienes un Poker!");
            _order = 3;
            
        }
        else if (hasColor && HasStraight)
        {
            Console.WriteLine("Tienes una Escalera de Color!");
            _order = 2;
        }
        else if (HasStraight)
        {
            Console.WriteLine("Tienes una Escalera!");
            _order = 6;
        }
        else if (hasColor)
        {
            Console.WriteLine("Tienes un Color!");
            _order = 5;
        }
        else if (hasThree && pairs == 1)
        {
            Console.WriteLine("Tienes un FullHouse!");
            _order = 4;
        }
        else if (hasThree)
        {
            Console.WriteLine("Tienes un Trio!");
            _order = 7;
        }
        else if (pairs == 2) {
            Console.WriteLine("Tienes un doble Par!");
            _order = 8;
        }
        else if (pairs == 1)
        {
            Console.WriteLine("Tienes un par!");
            _order = 9;
        }
        else 
        {
            Console.WriteLine("Tienes una carta mas alta!");
            _order = 10;
        }
    }
    public int GetOrder(){
        return _order;
    }
}