using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.Search;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]/{eventId}")]
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
        [ProducesResponseType(typeof(ResponseRegisteredAttendeeEventJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromRoute]Guid eventId ,[FromBody]RequestRegisterAttendessJson request)
        {
            var useCase = new RegisterAttendeesUseCase();

            var response = useCase.Execute(eventId, request);

            return Created(string.Empty, response);
        }

      
    }
}
