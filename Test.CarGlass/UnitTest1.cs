using CarGlass.Application.UseCases.Funtion;
using PassIn.Application.UseCases.Search;        
using PassIn.Exceptions;

namespace Test.CarGlass
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(12, new int[] { 1, 2, 3, 4, 6, 12 }, new int[] { 2, 3 })]
        [InlineData(45, new int[] { 1, 3, 5, 9, 15, 45 }, new int[] { 3, 5 })]
        //[InlineData(-1, "The number is invalid", new int[] { })]
        //[InlineData(0, "The zero is invalid", new int[] { })]
        //[InlineData(10000, "limit number is 10000", new int[] { })]

        public void CheckListDividersAndListDividersPrimes(int number, int[] expectedDividersList, int[] expectedDivisoresPrimeNumberList)
        {

            var response = GetDividersUseCase.Execute(number);

            Assert.Equal(expectedDividersList, response.DividersList);
            Assert.Equal(expectedDivisoresPrimeNumberList, response.PrimeDividersList);

        }

        [Fact]
        public void VerifieListDividersAndListDividersPrimes()
        {
            // Arrange
            int number = 12;
            var expectedDividersList = new List<int> { 1, 2, 3, 4, 6, 12 };
            var expectedDivisoresPrimeNumberList = new List<int> { 2, 3 };

            // Act
            var result = GetDividersUseCase.Execute(number);

            // Assert
            Assert.Equal(expectedDividersList.Count, result.TotalDividers);
            Assert.Equal(expectedDividersList, result.DividersList);
            Assert.Equal(expectedDivisoresPrimeNumberList, result.PrimeDividersList);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(5, true)]

        public void IsPrime_ReturnsExpectedResult(int number, bool expectedResult)
        {

            bool result = PrimeNumbersVerifier.IsPrimeNumber(number);

            Assert.Equal(expectedResult, result);
        }



       

        [Theory]
        [InlineData(-1, "The number is invalid")]
        [InlineData(0, "The zero is invalid")]
        [InlineData(10001, "limit number is 10000")]

        public void VerificaNumeroEntradaBemComoDivisores(int number, string msg)
        {
            var useCase = new GetDividersIsPrimeNumbernUseCase();

            // Assert
            Assert.Throws<ErrorOrValidationExcepition>(() => useCase.Execute(number))
                  .Message.Equals(msg);
        }
              
       
    }
}
