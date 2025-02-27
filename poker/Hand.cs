
public class Hand
{
    private List<Card> cards = new List<Card>();
    private string kindOfHand = "";
    public Dictionary<string, int> GetCardsCount()
    {
        return cards.GroupBy(c => c._number)
        .ToDictionary(global => global.Key, global=> global.Count());
    }



    public bool HasPair()
    {
        return GetCardsCount().Values.Contains(2);
    }
    public bool HasThreeOfaKind()
    {
        return GetCardsCount().Values.Contains(2);
    }
}