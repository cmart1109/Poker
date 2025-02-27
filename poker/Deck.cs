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
             for (int i = 1; i <= 13; i++)
             {
                 string number;
                 switch (i)
                 {
                    case 1: number = "A"; break;
                    case 11: number = "J"; break;
                    case 12: number = "Q"; break;
                    case 13: number = "K"; break;
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