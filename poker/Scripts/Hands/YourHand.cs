
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

public class YourHand : Hand
{   
    private int _order = 0;
    private List<Card> _hand = new List<Card>();
    private int _maxNumber;

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
        for (int i = 1; i <= 3; i++)
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
        var CardsValueOrder = GetCardsCount().Keys.Select(int.Parse).OrderByDescending(x => x).ToList();
        

        int pairs = CardCounts.Count(x => x == 2);
        bool hasThree = CardCounts.Contains(3);
        bool hasFour = CardCounts.Contains(4);
        bool hasColor = SuitsCounts.Contains(5);
        bool HasStraight = CheckStraight(CardsNumber);


        if (hasFour)
        {
            _order = 3;
            string number = GetCardsCount().First(x => x.Value == 4).Key;
            _maxNumber = int.Parse(number);
            Console.WriteLine("Tienes un Poker!");
            
        }
        else if (hasColor && HasStraight)
        {
            _order = 2;
            _maxNumber = CardsNumber.Max();
            Console.WriteLine("Tienes una Escalera de Color!");
        }
        else if (HasStraight)
        {
            _maxNumber = CardsNumber.Max();
            _order = 6;
            Console.WriteLine("Tienes una Escalera!");
        }
        else if (hasColor)
        {
            Console.WriteLine("Tienes un Color!");
            _maxNumber = CardsNumber.Max();
            _order = 5;
        }
        else if (hasThree && pairs == 1)
        {
            _order = 4;
            string number = GetCardsCount().First(x => x.Value == 3).Key;
            _maxNumber = int.Parse(number);
            Console.WriteLine("Tienes un FullHouse!");
        }
        else if (hasThree)
        {
            _order = 7;
            string number = GetCardsCount().First(x => x.Value == 3).Key;
            _maxNumber = int.Parse(number);
            Console.WriteLine("Tienes un Trio!");
        }
        else if (pairs == 2) {
            _order = 8;
            string number = GetCardsCount()
                .Where(x => x.Value == 2)
                .Max(x => int.Parse(x.Key))
                .ToString();
            _maxNumber = int.Parse(number);
            Console.WriteLine("Tienes un doble Par!");
        }
        else if (pairs == 1)
        {
            Console.WriteLine("Tienes un par!");
            string number = GetCardsCount().First(x => x.Value == 2).Key;
            _maxNumber = int.Parse(number);
            _order = 9;
        }
        else 
        {
            Console.WriteLine("Tienes una carta mas alta!");
            _maxNumber = CardsNumber.Max();
            _order = 10;
        }
    }
    public override int GetOrder(){
        return _order;
    }
    public override int GetMaxNumber()
    {
        return _maxNumber;
    }
}