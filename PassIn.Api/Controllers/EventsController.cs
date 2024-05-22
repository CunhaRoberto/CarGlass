using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Delete;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;


namespace PassIn.Api.Controllers
{

    [Route("api/calculation")]
    [ApiController]
    public class CalculationController : ControllerBase 
    {
        
        [HttpGet]
        [Route("{number}")]
        [ProducesResponseType(typeof(ResponseJson), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)] 
        public IActionResult GetEventById([FromRoute] int number)
        {
            var useCase = new GetDividersUseCase();
            var response = useCase.Execute(number);
            return Ok(response);
        }

        

       
        
    }
}
