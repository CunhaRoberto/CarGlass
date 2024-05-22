using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetEventAllUseCase
    {
        private readonly PassInDbContext _dbContext;
        public GetEventAllUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public List<ResponseEventJson> Execute()
        {
            var entities = _dbContext.Events.ToList();

            if (!entities.Any())
            {
                throw new NotFoundException("No events found.");
            }

            var responseEvents = new List<ResponseEventJson>();

            foreach (var evento in entities)
            {
                

                responseEvents.Add(new ResponseEventJson
                {
                    Id = evento.Id,
                    Title = evento.Title,
                    Details = evento.Details,
                    Slug = evento.Slug,
                    MaximumAttendees = evento.Maximum_Attendees,                    
                    Created_At = evento.Created_At,
                    Updated_At = evento.Updated_At,
                });
            }

            return responseEvents;
        }
    }

}

