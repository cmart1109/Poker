using System.Reflection.Metadata;

public class Gambling 
{
    private int _playerBalance;
    private int _rivalBalance;
    private int _bet;
    private bool _playerFirst;
    private int _playerBet;
    private int _rivalBet;

    public Gambling(){

    }

    public void GetInicialBalance(){
        _playerBalance = 15;
        _rivalBalance = 15;
        _bet = 0;
    }

    public void StartingBet(){
        Random random = new Random();
        _playerFirst = random.Next(2) == 0;
        DisplayPlayerBalance();
        if (_playerFirst)
        {
            
    do   {
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
                    _bet += _playerBet;
                    Console.WriteLine($"Ahora tu balance es de {_playerBalance}$");
                    Console.WriteLine($"Hay {_bet}$ en Juego!");
                    break;
            }
            } while (_playerBet > _playerBalance);
            
        }
        else {
            Console.WriteLine("Tu rival va primero!");
        }
    }

    public void RivalStartingBet(){

    }
    public void DisplayPlayerBalance(){
        Console.WriteLine($"Tienes un Balance de {_playerBalance}$");
    }
}