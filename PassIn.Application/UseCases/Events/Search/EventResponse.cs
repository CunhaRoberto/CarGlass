using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events.Search
{
    internal class EventResponse : List<ResponseJson>
    {
        public List<ResponseJson> Events { get; set; }
        public int Total { get; set; }
    }
}