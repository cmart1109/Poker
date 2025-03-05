using System.Diagnostics.Contracts;

public class Risky : Rival
{   

    private int _balance;
    Random random = new Random();
    public Risky(string name, int level, int balance) : base(name, level, balance)
    {
        Console.WriteLine("Te ha tocado jugar con un jugador Riesgoso");  
        _balance = balance; 
    }

    public override bool GetChancetoBet()
    {
        int x = random.Next(1,100);
        if (x <= 95){
            return true;
         } else {
            return false; 
         }
    }

    public override int GetRivalStartingBet()
    {
        return random.Next(_balance - 5, _balance);
    }

    public override bool CalculateHandOrder(int order){
    if (order <= 9){
        return true;
    } else {
        return false;
    }
    
   }
}