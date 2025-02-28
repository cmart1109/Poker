using System.ComponentModel.Design.Serialization;

public class GameManager
{
    public List<Card> _deck = new List<Card>(); 
    private string decision;
    private bool  _rivalout;
    private bool _playerout;
    private bool _playerFirst;
    private string _betDecision;

    private bool _keepgambling;
    public GameManager()
    {

    }
    public void Start(){
        Rival rival1 = new Rival();
        GamblingSystem gambling = new GamblingSystem();
        Console.WriteLine("Bienvenidos a Poker, donde su suerte se ve reflejada!");
        gambling.GetInicialBalance();
        do {
        _rivalout = gambling.IsRivalOut();
        _playerout = gambling.IsPlayerOut();
        if (_rivalout == true)
        {
            Console.WriteLine("Tu rival se ha quedado sin dinero!");
            Console.WriteLine("Gracias por Jugar al Poker :)");
            break;
        }
        else if (_playerout == true)
        {
            Console.WriteLine("Te has quedado sin dinero!");
            Console.WriteLine("Gracias por Jugar al Poker :)");
            break;
        }
         else {

        GenerateDeck();
        YourHand player = new YourHand();
        RivalHand rival = new RivalHand();

        gambling.StartingBet();
        gambling.Bet();
        bool checkbet = gambling.checkBet();
        if (checkbet){
            Console.WriteLine("La Partida se termina por rechazo de Apuesta");
            break;
        } else {

        // Aqui se generan los dos mazos
        player.GenerateHand(_deck);
        rival.GenerateHand(_deck);
        Console.WriteLine("Estas son tus primeras cartas");
        player.PrintHand();
        player.CheckHand();
        Console.ReadLine();
        _playerFirst = gambling.IsPlayerFirst();
        if (_playerFirst){
            Console.WriteLine("Como tú hiciste la primera Apuesta, tu rival decide si hacer la segunda apuesta primero");
            gambling.ChangeOrder();
            bool rivalDecision = rival1.GetChancetoBet();
            if (rivalDecision){
                Console.WriteLine("Tu rival ha decidido hacer una segunda apuesta!");
                gambling.RivalSecondBet();
            } else {
                Console.WriteLine("Tu rival ha decidido no hacer una segunda apuesta");
                Console.WriteLine("Deseas incrementar la apuesta?");
                _betDecision = Console.ReadLine();
                if (_betDecision == "si"){
                gambling.ChangeOrder();
                gambling.Bet();
            } else {

            }
            }
        }
        else {
            Console.WriteLine("Como tu rival comenzo, tu haces la segunda apuesta primero");
            Console.WriteLine("Deseas incrementar la apuesta?");
            _betDecision = Console.ReadLine();
            if (_betDecision == "si"){
                gambling.ChangeOrder();
                gambling.Bet();
            } else {

            }
        }

        Console.WriteLine("Cada jugador toma una carta más");
        Thread.Sleep(2000);
        player.GetCard(_deck);
        rival.GetCard(_deck);


         Console.WriteLine("Estas son tus primeras cartas");
        player.PrintHand();
        player.CheckHand();
        Thread.Sleep(2000);

        Console.WriteLine("Este es el Mazo de tu Rival");
        rival.PrintHand();
        rival.CheckHand();
        Console.ReadLine(); 
        Thread.Sleep(2000);
        
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
        }
        } while (decision == "si");

    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }


}