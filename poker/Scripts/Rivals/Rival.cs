public class Rival {

   private string _name = "";
   private int _level;
   private int _balance;
    Random random = new Random();

   public Rival(string name, int level, int balance){
      _name = name;
      _level = level;
      _balance = balance;
   }
    public bool GetChancetoBet(){
         int x = random.Next(1,100);
         if (x <= 50){
            return true;
         } else {
            return false; 
         }
         
    }
   public int CalculateHandOrder(int order){
      return 0;
   }
    public string GetRivalName(){
      return _name;
    }

    public int GetRIvalBalance(){
      return _balance;
    }

    
}