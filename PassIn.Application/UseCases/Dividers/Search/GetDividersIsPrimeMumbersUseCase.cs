using CarGlass.Application.UseCases;
using CarGlass.Application.UseCases.Funtion;
using CarGlass.Exceptions;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Search
{
    public class GetDividersIsPrimeNumbernUseCase
    {
        public List<ResponseDividerIsPrimeNumberJson> Execute(int number)
        {
            
            Validate(number);

            List<int> dividers = Enumerable.Range(1, number)
                .Where(x => number % x == 0)
                .ToList();

            var responseDividers = new List<ResponseDividerIsPrimeNumberJson>();
            foreach (var evento in dividers)
            {
                responseDividers.Add(new ResponseDividerIsPrimeNumberJson
                {
                    Dividers = evento,
                    PrimeNumber = PrimeNumbersVerifier.IsPrimeNumber(evento)
                });
            }


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
