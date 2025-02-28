using System.Dynamic;
using System.Reflection.Metadata;

public class GamblingSystem 
{
    Random random = new Random();
    private int _playerBalance;
    private int _rivalBalance;
    private int _bet;
    private bool _playerFirst;
    private int _playerBet;
    private int _rivalBet;

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
        if (_playerFirst)
        {
            
    do   {
            Console.WriteLine("Tu pones la apuesta Inicial!");
            Console.WriteLine("ingresa tu apuesta inicial:");
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
                    _playerBalance -= _playerBet;
                    _bet += _playerBet * 2;
                    Console.WriteLine($"Ahora tu balance es de {_playerBalance}$");
                // -------------------------------------------------------------------------------------
                    _rivalBalance -= _playerBet;
                    Console.WriteLine("Tu rival ha aceptado la apuesta!");
                // -------------------------------------------------------------------------------------
                    Console.WriteLine($"Hay {_bet}$ en Juego!");
                    break;
            }
            } while (_playerBet > _playerBalance);
            
        }
        else {
            Console.WriteLine("Tu rival va primero!");
            RivalStartingBet();
            Console.WriteLine($"Tu rival ha hecho una apuesta inicial de {_rivalBet}$");
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
            else if (decision == "no") {
                Console.WriteLine("No se apuesta");
            }

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
    
}