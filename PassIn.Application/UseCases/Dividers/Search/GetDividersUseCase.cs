using CarGlass.Exceptions;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetDividersUseCase
    {
        public static ResponseDividerJson Execute(int number)
        {
            var responseDividers = new ResponseDividerJson();



            Validate(number);

            List<int> dividers = Enumerable.Range(1, number)
                .Where(x => number % x == 0)
                .ToList();


            responseDividers.TotalDividers = dividers.Count;
            responseDividers.DividersList = dividers;
            responseDividers.CousinList = (dividers.Where(IsPrime).ToList());
            
            return responseDividers;

        }

        private static void Validate(int number)
        {

            if (number < 0)
            {
                throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberExcepition);
            }

            if (number == 0)
            {
                throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationZeroExcepition);
            }

            if (number > 10000)
            { 
                throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberLimitExcepition); }
        }



        static bool IsPrime(int number)
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
