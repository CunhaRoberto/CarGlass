using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetAttendeesByEventIdUseCase   
    {
        public List<ResponseEventJson> Execute(Guid eventId)
        {
            using (var dbContext = new PassInDbContext())
            {
                var entities = dbContext.Events.ToList();


                if (!entities.Any())
                {
                    throw new NotFoundException("No events found.");
                }
                var total = entities.Count();
                var responseEvents = entities.Select(entity => new ResponseEventJson
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Details = entity.Details,
                    Slug = entity.Slug,
                    MaximumAttendees = entity.Maximum_Attendees,
                    Created_At = entity.Created_At,
                    Updated_At = entity.Updated_At, 
                }).ToList();

                return responseEvents; 
            }
        }
    }
}
