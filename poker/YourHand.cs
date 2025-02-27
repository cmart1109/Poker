
public class YourHand : Hand
{
    private List<Card> _hand = new List<Card>();
    public Dictionary<string, int> GetCardsCount()
    {
        return _hand.GroupBy(c => c._number)
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
        if (GetCardsCount().Values.Contains(2) == true)
        {
            Console.WriteLine("Tienes un par!");
        }
        else if (GetCardsCount().Values.Contains(3) == true)
        {
            Console.WriteLine("Tienes un Trio!");
        }
        else if (GetCardsCount().Values.Contains(4) == true)
        {
            Console.WriteLine("Tienes un Poker!");
        }
        else 
        {
            Console.WriteLine("Tienes un Carta mas alta!");
        }
    }
}