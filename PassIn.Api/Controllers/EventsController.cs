using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Delete;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Application.UseCases.Events.Update;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;


namespace PassIn.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Register an event
        /// </summary>
        /// <remarks>
        /// Example:
        /// {
        /// "title": "Curso de Api C#",
        /// "details": "Aprenda constrir uma Api C# do ZERO.",
        /// "maximumAttendees": 130
        /// }
        /// }
        /// </remarks>
        /// <returns> Returns the ID of the registered event.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredEventJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RequestEventJson request)
        {
            var useCase = new RegisterEventsUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }


        /// <summary>
        /// Search an event by id.
        /// </summary>
        /// <remarks>
        /// Example:
        /// { "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <returns> Returns the data of the registered event.</returns>
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

        /// <summary>
        ///Search list of registered events.
        /// </summary>
        /// <returns> Returns a list of the registered events.</returns>
        [HttpGet]        
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)] 
        public IActionResult GetEventAll()
        {
            var useCase = new GetEventAllUseCase();
            var response = useCase.Execute().ToList();
            return Ok(response);
        }

        /// <summary>
        /// Remove an event by id.
        /// </summary>
        /// <remarks>
        /// Example:
        /// { "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <returns> Returns the data of the registered event.</returns>
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

        /// <summary>
        /// Update an event by id.
        /// </summary>
        /// <remarks>
        /// Example:
        /// { "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <returns> Returns the data of the updated event.</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseDelEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        public IActionResult UpdateEventById([FromQuery ] RequestUpdateEventJson request, [FromRoute] Guid id)
        {
            var useCase = new UpdateEventByIdUseCase();
            var response = useCase.Execute(id, request);

            return Ok("Successfully updated!");

        }
    }
}
