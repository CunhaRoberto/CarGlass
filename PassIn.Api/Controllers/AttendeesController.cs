using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        /// <summary>
        /// Register attendees in event
        /// </summary>
        /// <remarks>
        /// Examples 
        /// {
        /// "name": "Roberto Cunha",
        /// "email": "rcunha@live.com"
        /// }, eventId : c2825351-98b7-44bf-a96d-5e5c23d8ad87
        /// </remarks>
        /// 
        /// <returns> </returns>
        [HttpPost]
        [Route("{eventId}")]
        [ProducesResponseType(typeof(ResponseRegisteredAttendeeEventJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]


        public IActionResult Register([FromRoute]Guid eventId ,[FromBody]RequestRegisterAttendessJson request)
        {
            var useCase = new RegisterAttendeesUseCase();

            var response = useCase.Execute(eventId, request);

            return Created(string.Empty, response);
        }


        /// <summary>
        ///Search list of registered events.
        /// </summary>
        /// <returns> Returns a list of the registered events.</returns>
        [HttpGet]
        [Route("{eventId}")]
        [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        // [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)] 
        public IActionResult GetAttendesByEventId([FromRoute] Guid eventId)     
        {
            var useCase = new GetAttendeesByEventIdUseCase();
            var response = useCase.Execute(eventId).ToList();
            return Ok(response);
        }

    }
}
