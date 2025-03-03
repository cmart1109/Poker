using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;

public class GameManager
{
    public List<Card> _deck = new List<Card>(); 
    private string decision;
    private bool  _rivalout;
    private bool _playerout;
    private bool _playerFirst;
    private string _betDecision;
    private string _inicialdecision;
    private bool checkbet;
    
    public void Start(){

        
        GamblingSystem gambling = new GamblingSystem();
        gambling.GetInicialBalance();

        Console.WriteLine("Bienvenidos a Poker, donde su suerte se ve reflejada!");
        while (true)
        {
        CheckBalance(gambling);
        Console.WriteLine("Una Partida esta por comenzar.");
        Console.WriteLine("Te unes?");
        _inicialdecision = Console.ReadLine();
        if (_inicialdecision == "si"){

        // Aqui genero el rival -------------------------------------------------------
        Rival rival1 = new Rival("Carlos", 2, 15);
        // --------------------------------------------------------------------------------------------
        
        // Este comando genera las 52 Cartas 
        checkbet = false;
        GenerateDeck();
        YourHand player = new YourHand();
        RivalHand rival = new RivalHand();

        // Aqui se determina el orden y se hace la Apuesta Inicial
        gambling.StartingBet();
        gambling.Bet();
        // Aqui se verifica si uno de los dos lados cancela la Apuesta
        checkbet = gambling.checkBet();
        if (checkbet){
            Console.WriteLine("La Partida se termina por rechazo de Apuesta");
            gambling.ReturnMoneyFromReject();
            continue;
        }
        Thread.Sleep(1000);
        // Aqui se generan los dos mazos
        player.GenerateHand(_deck);
        rival.GenerateHand(_deck);

        Console.WriteLine("Estas son tus primeras cartas");
        player.PrintHand();
        player.CheckHand();
        Thread.Sleep(1000);
        Console.WriteLine();
    
        // A partir de aqui comienza la segunda Apuesta 
        NewBet(gambling, rival1);
        checkbet = gambling.checkBet();
        if (checkbet){
            Console.WriteLine("La Partida se termina por rechazo de Apuesta");
            gambling.ReturnMoneyFromReject();
            continue;
        }

        // Aqui es cuando cada jugador toma una carta más!
        Console.WriteLine("Cada jugador toma una carta más");
        Thread.Sleep(2000);
        player.GetCard(_deck);
        rival.GetCard(_deck);


         Console.WriteLine("Estas son tus cartas");
        player.PrintHand();
        player.CheckHand();
        Thread.Sleep(1000);
        Console.WriteLine();

        Console.WriteLine("Este es el Mazo de tu Rival");
        rival.PrintHand();
        rival.CheckHand();
        Thread.Sleep(1000);
        Console.WriteLine();


        
        int playerOrder = player.GetOrder();
        int rivalOrder = rival.GetOrder();

    // Aqui esta el algoritmo para verificar que jugador Gana, o si hay un empate
        if (playerOrder < rivalOrder)
        {
            Console.WriteLine("Ganaste!");
            Thread.Sleep(1000);
            gambling.SetPlayerVictory();
        }
        else if (playerOrder > rivalOrder)
        {
            Console.WriteLine("Perdiste :(");
            Thread.Sleep(1000);
            gambling.SetRivalVictory();
        }
        else if (playerOrder == rivalOrder) {
            Console.WriteLine("Ambos tienen la misma Mano");
            Thread.Sleep(1000);
            Console.WriteLine();
            int playerMaxNumber = player.GetMaxNumber();
            int rivalMaxNumber = rival.GetMaxNumber();
            if (playerMaxNumber > rivalMaxNumber )
            {
                Console.WriteLine("Ganas por tener el valor mas Alto!");
                Thread.Sleep(1000);
                gambling.SetPlayerVictory();
            }
            else if (playerMaxNumber < rivalMaxNumber)
            {
                Console.WriteLine("Pierdes porque tu rival tiene el Valor mas Alto!");
                Thread.Sleep(1000);
                gambling.SetRivalVictory();
            }
            else {
                Console.WriteLine("Empate definitivo");
                gambling.SetTie();
            }
        }
        }
        Console.WriteLine("Quieres volver a jugar?");
        decision = Console.ReadLine();
        if (decision != "si"){
            Environment.Exit(0);
        }
        else {
            Console.WriteLine("Preparate para la siguiente ronda");
        }
    }
}
    

    public void NewBet(GamblingSystem gambling, Rival rival1){
                _playerFirst = gambling.IsPlayerFirst();
        if (_playerFirst){
            
            Console.WriteLine("Como tú hiciste la primera Apuesta, tu rival decide si hacer la segunda apuesta primero");
            Thread.Sleep(1000);
            gambling.ChangeOrder();
            bool rivalDecision = rival1.GetChancetoBet();
            if (rivalDecision){
                Console.WriteLine("Tu rival ha decidido hacer una segunda apuesta!");
                Thread.Sleep(1000);
                Console.WriteLine();
                gambling.RivalSecondBet(); // Aqui el rival coloca la segunda apuesta y te pregunta si la quieres incrementar
                checkbet = gambling.checkBet();
                if (checkbet){
                Console.WriteLine("Tu rival ha decidido desistir de esta apuesta");
                gambling.ReturnMoneyFromReject();
                return;
                } 
            } else {

                Console.WriteLine("Tu rival ha decidido no hacer una segunda apuesta");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine("Deseas incrementar la apuesta?");
                _betDecision = Console.ReadLine();
                if (_betDecision == "si"){
                gambling.ChangeOrder();
                gambling.Bet();
                checkbet = gambling.checkBet();
                if (checkbet){
                Console.WriteLine("La Partida se termina por rechazo de Apuesta");
                gambling.ReturnMoneyFromReject();
                return;
                } 
                
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
    }

   public void GenerateDeck()
   {
    Deck deck = new Deck();
    _deck = deck.GenerateCards();
   }

    public void CheckBalance(GamblingSystem gambling){

        _rivalout = gambling.IsRivalOut();
        _playerout = gambling.IsPlayerOut();
        if (_rivalout == true)
        {
            Console.WriteLine("Tu rival se ha quedado sin dinero!");
            Console.WriteLine("Gracias por Jugar al Poker :)");
            Environment.Exit(0);
        }
        else if (_playerout == true)
        {
            Console.WriteLine("Te has quedado sin dinero!");
            Console.WriteLine("Gracias por Jugar al Poker :)");
            Environment.Exit(0);
        }
    }
}