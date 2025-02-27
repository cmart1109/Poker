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
        RivalHand rival = new RivalHand();

        // Aqui se generan los dos mazos
        player.GenerateHand(_deck);
        rival.GenerateHand(_deck);
        Console.WriteLine("Estas son tus dos primeras cartas");
        player.PrintHand();
        player.CheckHand();
        Console.ReadLine();

        player.GetCard(_deck);
        Console.WriteLine("Estas son tus tres cartas");
        player.PrintHand();
        player.CheckHand();
        Console.ReadLine();

        Console.WriteLine("Este es el Mazo de tu Rival");
        rival.PrintHand();
        rival.CheckHand();
        Console.ReadLine();
        
        int playerOrder = player.GetOrder();
        int rivalOrder = rival.GetOrder();


        if (playerOrder < rivalOrder)
        {
            Console.WriteLine("Ganaste!");
        }
        else if (playerOrder > rivalOrder)
        {
            Console.WriteLine("Perdiste :(");
        }
        else {
            Console.WriteLine("Error, aun no se han programado los empates");
        }

    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }


}