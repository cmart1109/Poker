public class GameManager
{
    List<Card> _deck = new List<Card>(); 
    public void Start(){
        GenerateDeck();


    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }
}