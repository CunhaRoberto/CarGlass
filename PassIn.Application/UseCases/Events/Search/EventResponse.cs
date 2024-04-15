using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events.Search
{
    internal class EventResponse : List<ResponseEventJson>
    {
        public List<ResponseEventJson> Events { get; set; }
        public int Total { get; set; }
    }
}