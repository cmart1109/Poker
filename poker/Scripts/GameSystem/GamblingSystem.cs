using System.Dynamic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

public class GamblingSystem 
{
    Random random = new Random();
    private int _playerBalance;
    private int _rivalBalance;
    private int _bet;
    private bool _playerFirst;
    private int _playerBet;
    private int _rivalBet;

    private bool _out;
    public GamblingSystem(){

    }

    public void GetInicialBalance(){
        _playerBalance = 15;
        _rivalBalance = 15;
        _bet = 0;
    }

    public void StartingBet(){
        _playerFirst = random.Next(2) == 0;
        DisplayPlayerBalance();
        DisplayRivalBalance();

    }
    public void Bet(){
        if (_playerFirst)
        {    
            Console.WriteLine("Tu vas primero en esta ronda!");
            Thread.Sleep(1000);  
    do   {
            Console.WriteLine("ingresa tu apuesta:");
            while (!int.TryParse(Console.ReadLine(), out _playerBet))
                {
                Console.WriteLine("Entrada Invalida. Por favor, ingresa un número válido");
                Console.WriteLine("Ingresa un número: ");
                }   
                if(_playerBet > _playerBalance)
                {
                    Console.WriteLine("La apuesta que deseas ingresar supera tu Balance!");
                }
                else {
                    Console.WriteLine($"Número Ingresado: {_playerBet}");
                    Thread.Sleep(1000);
                    _playerBalance -= _playerBet;
                    Console.WriteLine($"Ahora tu balance es de {_playerBalance}$");
                    Thread.Sleep(1000);
                // -------------------------------------------------------------------------------------
                    if (_rivalBalance > _playerBet) {
                        Console.WriteLine("Tu rival ha aceptado la apuesta!");
                        _rivalBalance -= _playerBet;
                        _bet += _playerBet * 2;
                        Thread.Sleep(1000);
                    } else {
                        Console.WriteLine("Tu rival no tiene suficiente para esa apuesta inicial.");
                        Console.WriteLine("La Partida se termina.");
                        Console.WriteLine("Te quedas con lo que esta en el plato de apuestas");
                        _playerBalance += _playerBet;
                        _bet = 0;
                        _out = true;
                    }
                // -------------------------------------------------------------------------------------
                    Console.WriteLine($"Hay {_bet}$ en Juego!");
                    break;
            }
            } while (_playerBet > _playerBalance);
            
        }
        else {
            Console.WriteLine("Tu rival va primero!");
            Thread.Sleep(1000);
            RivalStartingBet();
            Console.WriteLine($"Tu rival ha hecho una apuesta de {_rivalBet}$");
            Thread.Sleep(1000);
            Console.WriteLine("Te unes a la apuesta?: ");
            string decision = Console.ReadLine();
            if (decision == "si")
            {
                if (_playerBalance < _rivalBet){
                    Console.WriteLine("La Apuesta del rival es más alta que tu balance");
                    Console.WriteLine("Quedas fuera de esta ronda! :(");
                    Console.WriteLine("Gracias por jugar al Poker");
                    Environment.Exit(0);
                }
                else {
                    _rivalBalance -= _rivalBet;
                    _playerBalance -= _rivalBet;
                    _bet += _rivalBet * 2;
                    Console.WriteLine($"Ahora tu balance es de {_playerBalance}$");
                    Console.WriteLine($"Hay {_bet}$ en Juego!");

                }
            }   
            else  {
                Console.WriteLine("No se apuesta");
                _rivalBet += _bet;
                Console.WriteLine("La Partida se termina.");
                Console.WriteLine("El rival se queda con lo que esta en el plato de apuestas");
                _out = true;

            }

        }
        _playerBet = 0;
        _rivalBet = 0;
    }
    public void RivalSecondBet(){
            RivalStartingBet();
            Console.WriteLine($"Tu rival ha hecho una apuesta de {_rivalBet}$");
            Console.WriteLine("Te unes a la apuesta?: ");
            string decision = Console.ReadLine();
            if (decision == "si")
            {
                if (_playerBalance < _rivalBet){
                    Console.WriteLine("La Apuesta del rival es más alta que tu balance");
                    Console.WriteLine("Quedas fuera de esta ronda! :(");
                    Console.WriteLine("Gracias por jugar al Poker");
                    Environment.Exit(0);
                }
                else {
                    _rivalBalance -= _rivalBet;
                    _playerBalance -= _rivalBet;
                    _bet += _rivalBet * 2;
                    Console.WriteLine($"Ahora tu balance es de {_playerBalance}$");
                    Console.WriteLine($"Hay {_bet}$ en Juego!");

                }
            }   
            else  {
                Console.WriteLine("No se apuesta");
                _rivalBet += _bet;
                Console.WriteLine("La Partida se termina.");
                Console.WriteLine("El rival se queda con lo que esta en el plato de apuestas");
                _out = true;
            }

        
        _playerBet = 0;
        _rivalBet = 0;
    }


    public void RivalStartingBet(){
        _rivalBet = random.Next(1,_rivalBalance);

    }
    public void DisplayPlayerBalance(){
        Console.WriteLine($"Tienes un Balance de {_playerBalance}$");
    }

    public void DisplayRivalBalance(){
        Console.WriteLine($"Tu rival tiene un Balance de {_rivalBalance}$");
    }


    public void SetPlayerVictory()
    {
        Console.WriteLine($"has ganado el dinero de la apuesta!!!");
        Console.WriteLine($"Has ganado {_bet}$");
        _playerBalance += _bet;
        DisplayPlayerBalance();
        _bet = 0;
        Console.WriteLine("Ahora el plato de apuestas esta vacío");
    }

    public void SetRivalVictory()
    {
        Console.WriteLine($"Has Perdido el dinero de la apuesta");
        Console.WriteLine($"Tu rival ha ganado {_bet}$");
        _rivalBalance += _bet;
        _bet = 0;
        Console.WriteLine("Ahora el plato de apuestas esta vacío");
    }

    public void SetTie(){
        Console.WriteLine("Han empatado, lo que este en el plato de apuestas se mantendra para la siguiente ronda");
    }


    public bool IsRivalOut(){
        if (_rivalBalance == 0){
            return true;
        } else {
            return false;
        }
    }
    public bool IsPlayerOut(){
        if (_playerBalance == 0){
            return true;
        } else {
            return false;
        }
    }
    public bool IsPlayerFirst(){
        if (_playerFirst){
            return true;
        } else {
            return false;
        }
    }

    public void ChangeOrder(){
        if (_playerFirst){
            _playerFirst = false;
        } else {
            _playerFirst = true;
        }
    }
    
    public bool checkBet()
    {
        return _out;
    }

    public void ReturnMoneyFromReject(){
        _playerBalance += _bet / 2;
        _rivalBalance += _bet / 2;
        _bet = 0;

    }
}