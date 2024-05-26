using CarGlass.Application.UseCases.Funtion;
using CarGlass.Exceptions;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Search
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
            responseDividers.PrimeDividersList = (dividers.Where(PrimeNumbersVerifier.IsPrimeNumber).ToList());

            return responseDividers;

        }

        private static void Validate(int number)
        {

            if (number < 0) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberExcepition);

            if (number == 0) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationZeroExcepition);

            if (number > 10000) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberLimitExcepition);
        }
    }

}
