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
        if (_playerFirst)
        {
            
            Console.WriteLine("Tu vas primero, ingresa tu apuesta inicial:");
    do   {
            while (!int.TryParse(Console.ReadLine(), out _playerBet))
            {
                Console.WriteLine("Entrada Invalida. Por favor, ingresa un número válido");
                Console.Write("Ingresa un número: ");
                if(_playerBet > _playerBalance)
                {
                    Console.WriteLine("La apuesta que deseas ingresar supera tu Balance!");
                }
                
            }

            Console.WriteLine($"Número Ingresado: {_playerBet}");
            } while (0==0);
            
        }
    }

    public void RivalStartingBet(){

    }
    
}