using CarGlass.Exceptions;
using PassIn.Exceptions;

namespace CarGlass.Application.UseCases.Funtion
{
    public static class Validate
    {
        public static void ValidateNumber(int number)
        {

            if (number < 0) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberExcepition);

            if (number == 0) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationZeroExcepition);

            if (number > 10000) throw new ErrorOrValidationExcepition(ExceptionMsg.ErrorOrValidationNumberLimitExcepition);
        }
    }
}
