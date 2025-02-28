public class GameManager
{
    public List<Card> _deck = new List<Card>(); 
    private string decision;
    private bool  _rivalout;

    public GameManager()
    {

    }
    public void Start(){
        GamblingSystem gambling = new GamblingSystem();
        Console.WriteLine("Bienvenidos a Poker, donde su suerte se ve reflejada!");
        gambling.GetInicialBalance();
        do {
        _rivalout = gambling.IsRivalOut();
        if (_rivalout == true)
        {
            Console.WriteLine("Tu rival se ha quedado sin dinero!");
            Console.WriteLine("Gracias por Jugar al Poker :)");
            break;
        } else {

        GenerateDeck();
        YourHand player = new YourHand();
        RivalHand rival = new RivalHand();

        gambling.StartingBet();
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
            gambling.SetPlayerVictory();
        }
        else if (playerOrder > rivalOrder)
        {
            Console.WriteLine("Perdiste :(");
            gambling.SetRivalVictory();
        }
        else if (playerOrder == rivalOrder) {
            Console.WriteLine("Ambos tienen la misma Mano");
            Console.WriteLine();
            int playerMaxNumber = player.GetMaxNumber();
            int rivalMaxNumber = rival.GetMaxNumber();
            if (playerMaxNumber > rivalMaxNumber )
            {
                Console.WriteLine("Ganas por tener el valor mas Alto!");
                gambling.SetPlayerVictory();
            }
            else if (playerMaxNumber < rivalMaxNumber)
            {
                Console.WriteLine("Pierdes porque tu rival tiene el Valor mas Alto!");
                gambling.SetRivalVictory();
            }
            else {
                Console.WriteLine("Empate definitivo");
                gambling.SetTie();
            }
        }
        Console.WriteLine("Quieres volver a jugar?");
        decision = Console.ReadLine();
        }
        } while (decision == "si");

    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }


}