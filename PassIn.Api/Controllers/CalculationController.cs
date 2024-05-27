using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Search;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CalculationController : ControllerBase
    {


        [HttpGet]
        [Route("dividers/{number}")]
        [ProducesResponseType(typeof(ResponseDividerJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetDividers([FromRoute] int number)
        {
            var useCase = new GetDividersUseCase();
            var response = GetDividersUseCase.Execute(number);
            return Ok(response);
        }


        [HttpGet]
        [Route("dividers/prime-number/{number}")]
        [ProducesResponseType(typeof(ResponseDividerIsPrimeNumberJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetDividersIsPrimeNumber([FromRoute] int number)
        {
            var useCase = new GetDividersIsPrimeNumbernUseCase();
            var response = useCase.Execute(number);
            return Ok(response);
        }
    }
}
