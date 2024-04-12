using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Delete;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Infrastructure.Entities;


namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredEventJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RequestEventJson request)
        {
            var useCase = new RegisterEventsUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)] 
        public IActionResult GetEventById([FromRoute] Guid id)
        {
            var useCase = new GetEventByIdUseCase();
            var response = useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseDelEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
         
        public IActionResult DeleteEventById([FromRoute] Guid id)   
        {
            var useCase = new DeleteEventByIdUseCase();
            var response = useCase.Execute(id);
                       
            return Ok("Successfully removed!");
               
        }
    }
}
