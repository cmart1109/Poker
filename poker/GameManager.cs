public class GameManager
{
    public List<Card> _deck = new List<Card>(); 

    public GameManager()
    {

    }
    public void Start(){
        Console.WriteLine("Bienvenidos a Poker Texas Hold'em, donde su suerte se ve reflejada!");
        GenerateDeck();
        YourHand player = new YourHand();
        player.GenerateHand(_deck);
        player.PrintHand();
        Console.WriteLine("Estas son tus dos primeras cartas");
        player.CheckHand();
        Console.ReadLine();
        player.GetCard(_deck);
        player.PrintHand();
        Console.WriteLine("Este es tu nuevo Mazo");
        player.CheckHand();

    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }


}