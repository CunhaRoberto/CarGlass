using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetDividersUseCase
    {
        public List<ResponseDividerJson> Execute(int number)
        {
            Validate(number);

            var responseDividers = new List<ResponseDividerJson>();

            List<int> dividers = Enumerable.Range(1, number)
                .Where(x => number % x == 0)
                .ToList();

            responseDividers.Add(new ResponseDividerJson
            {
                TotalDividers = dividers.Count,
                DividersList = dividers,
            });
            return responseDividers;
        }

        private static void Validate(int number)
        {
            if (number < 1)
            {
                throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberExcepition);
            }


        }
    }
}
