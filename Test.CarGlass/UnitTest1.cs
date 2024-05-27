using CarGlass.Application.UseCases.Funtion;
using PassIn.Application.UseCases.Search;

namespace Test.CarGlass
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(12, new int[] { 1, 2, 3, 4, 6, 12 }, new int[] { 2, 3 })]
        [InlineData(45, new int[] { 1, 3, 5, 9, 15, 45 }, new int[] { 3, 5 })]


        public void CheckListDividersAndListDividersPrimes(int number, int[] expectedDividersList, int[] expectedDivisoresPrimeNumberList)
        {

            var response = GetDividersUseCase.Execute(number);

            Assert.Equal(expectedDividersList, response.DividersList);
            Assert.Equal(expectedDivisoresPrimeNumberList, response.PrimeDividersList);

        }

        [Fact]
        public void VerifierListDividersAndListDividersPrimes()
        {

            int number = 12;
            var expectedDividersList = new List<int> { 1, 2, 3, 4, 6, 12 };
            var expectedDivisoresPrimeNumberList = new List<int> { 2, 3 };


            var result = GetDividersUseCase.Execute(number);


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


        [Fact]
        public void VerifierListDividersAndListDividersPrimes2()
        {

            int number = 10;
            var expectedDividers = new[]
            {
                new { Dividers = 1, PrimeNumber = false },
                new { Dividers = 2, PrimeNumber = true },
                new { Dividers = 5, PrimeNumber = true },
                new { Dividers = 10, PrimeNumber = false }
            };


            var useCase = new GetDividersIsPrimeNumbernUseCase();
            var result = useCase.Execute(number);

            Assert.NotNull(result);

            Assert.Equal(expectedDividers.Length, result.Count);

            for (int i = 0; i < expectedDividers.Length; i++)
            {
                Assert.Equal(expectedDividers[i].Dividers, result[i].Dividers);
                Assert.Equal(expectedDividers[i].PrimeNumber, result[i].PrimeNumber);
            }

        }

        [Theory]
        [InlineData(-1, "Negative number is invalid")]
        [InlineData(0, "The number zero is invalid")]
        [InlineData(10001, "Limit number is 10000")]

        public void CheckEntryNumber(int number, string expectedMessage)
        {
            var exception = Record.Exception(() => Validate.ValidateNumber(number));

            Assert.Equal(expectedMessage, exception.Message);


        }
    }
}
