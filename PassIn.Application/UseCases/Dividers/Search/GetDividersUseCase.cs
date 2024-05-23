using PassIn.Communication.Responses;
using PassIn.Exceptions;
using System.Numerics;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetDividersUseCase
    {
        public ResponseDividerJson Execute(int number)
        {
            var responseDividers = new ResponseDividerJson();

           

                Validate(number);

                List<int> dividers = Enumerable.Range(1, number)
                    .Where(x => number % x == 0)
                    .ToList();


                responseDividers.TotalDividers = dividers.Count;
                responseDividers.DividersList = dividers;

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

        }
        
    }
}
