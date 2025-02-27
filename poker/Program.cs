using System;

class Program
{
    static void Main()
    {
        string decision;
        do{
        GameManager game = new GameManager();
        game.Start();
        Console.WriteLine("Quieres Jugar otra vez?");
        decision = Console.ReadLine();
        } while (decision == "Si");
    }
}
