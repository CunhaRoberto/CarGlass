using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/calculation")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        /// <summary>
        /// Verifica lista de divisores e lista de divisores primos.
        /// </summary>
        
        [HttpGet]
        [Route("{number}")]
        [ProducesResponseType(typeof(ResponseDividerJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetDividers([FromRoute] int number)
        {
            var useCase = new GetDividersUseCase();
            var response = useCase.Execute(number);
            return Ok(response);
        }

        /// <summary>
        ///Search list of registered events.
        /// </summary>
        /// <returns> Returns a list of the registered events.</returns>

        [HttpGet]
        [Route("dividers/iscousin/{number}")]
        [ProducesResponseType(typeof(ResponseDividerIsCousinJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetDividersIsCousin([FromRoute] int number)    
        {
            var useCase = new GetDividersIsCousinUseCase();
            var response = useCase.Execute(number);
            return Ok(response);
        }
    }
}
