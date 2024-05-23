using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Search;
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
