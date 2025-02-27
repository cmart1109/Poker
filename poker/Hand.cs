
public class Hand
{
    private List<Card> _hand = new List<Card>();
    public Dictionary<string, int> GetCardsCount()
    {
        return _hand.GroupBy(c => c._number)
        .ToDictionary(global => global.Key, global=> global.Count());
    }

    public Hand()
    {
        
    }
    
    public List<Card> GenerateHand(List<Card> deck){
        for (int i = 1; i <= 3; i++)
        {
            _hand.Add(GetRandomCard(deck));
        }
    return _hand;
    }
    
    public Card GetRandomCard(List<Card> deck) {

        Random random = new Random();
        int index = random.Next(deck.Count);
        Card card = deck[index];
        return card;
    }}







// -------------------------------------------------------------------------------------------