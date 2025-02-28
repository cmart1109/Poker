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
        Console.WriteLine("Estas son tus primeras cartas");
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
        else if (playerOrder == rivalOrder) {
            Console.WriteLine("Ambos tienen la misma Mano");
            Console.WriteLine();
            int playerMaxNumber = player.GetMaxNumber();
            int rivalMaxNumber = rival.GetMaxNumber();
            if (playerMaxNumber > rivalMaxNumber )
            {
                Console.WriteLine("Ganas por tener el valor mas Alto!");
            }
            else if (playerMaxNumber < rivalMaxNumber)
            {
                Console.WriteLine("Pierdes porque tu rival tiene el Valor mas Alto!");
            }
            else {
                Console.WriteLine("Empate definitivo");
            }
        }

    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }


}