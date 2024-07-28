public class Validator
{
   public static bool isInt(string input)
   {
        int temp;
        return int.TryParse(input, out temp);
   } 
}