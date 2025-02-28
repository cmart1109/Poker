
public class Hand
{
    private List<Card> _hand = new List<Card>();
    public Hand()
    {
        
    }
    
    public virtual List<Card> GenerateHand(List<Card> deck){
    return _hand;
    }
    
    public Card GetRandomCard(List<Card> deck) {

        Random random = new Random();
        int index = random.Next(deck.Count);
        Card card = deck[index];
        deck.Remove(deck[index]);
        return card;
    }
    public virtual void PrintHand()
    {
        foreach (var hand in _hand)
        {
            hand.PrintCard();
        }
    }

    public virtual void GetCard(List<Card >deck)
    {
        Card newCard = GetRandomCard(deck);
        _hand.Add(newCard);
    }

    public virtual int GetOrder() {
        return 0;
    }

    public virtual int GetMaxNumber()
    {
        return 0;
    }




    }





// -------------------------------------------------------------------------------------------