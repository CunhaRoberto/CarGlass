using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events.Register
{
    internal class ResponseRegisteredAttendesJson : ResponseRegisteredAttendeeEventJson
    {
        public Guid Id { get; set; }
    }
}