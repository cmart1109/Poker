using System.Runtime.CompilerServices;

public class Deck
{
    public List<Card> _cards = new List<Card>();
    private string[] _suits = {"Picas","Corazones","Diamantes","Treboles"};
    
    public List<Card> GenerateCards()
    {
            _cards.Clear();
            foreach (var suit in _suits)
            {
             for (int i = 2; i <= 14; i++)
             {
                 string number;
                 switch (i)
                 {
                    default: number = i.ToString(); break;
                 }
                 _cards.Add(new Card(suit, number));
             }
             }
             return _cards;

    }
    public void PrintDeck()
    {
        foreach (Card cards in _cards)
        {
            cards.PrintCard();
        }
    }
}