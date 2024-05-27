using CarGlass.Application.UseCases.Funtion;
using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Search
{
    public class GetDividersIsPrimeNumbernUseCase
    {
        public List<ResponseDividerIsPrimeNumberJson> Execute(int number)
        {

            Validate.ValidateNumber(number);

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
    }
}
