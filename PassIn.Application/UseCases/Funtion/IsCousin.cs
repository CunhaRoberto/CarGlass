using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarGlass.Application.UseCases.Funtion
{
    public class PrimeNumbersVerifier 
    {
        public static bool IsPrimeNumber(int number)      
        {
            if (number <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

      

    }
}
