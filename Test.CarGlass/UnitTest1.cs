using PassIn.Application.UseCases.Events.Search;
using PassIn.Exceptions;

namespace Test.CarGlass
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(45,  "", new int[] { 1, 3, 5, 9, 15, 45 })]
        [InlineData(-1, "The number is invalid", new int[] { })]
        [InlineData(0, "The zero is invalid", new int[] { })]
        [InlineData(10000, "limit number is 10000", new int[] { })]

        public void VerificaNumeroEntradaBemComoDivisores(int number, string msg, int[] resultado)         
        {
            var useCase = new GetDividersUseCase();           

            try
            {
                var response = GetDividersUseCase.Execute(number);
                Assert.Equal(resultado,response.DividersList);
            }
            catch (ErrorOrValidationExcepition e)
            {
                Assert.Contains(e.Message, msg);               

            }

            
        }


    }
}