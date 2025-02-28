public class Rival {
    private bool RivalSecondBet;
    Random random = new Random();

    public bool GetChancetoBet(){
         int x = random.Next(1,100);
         if (x <= 50){
            return true;
         } else {
            return false; 
         }
         
    }
    
}