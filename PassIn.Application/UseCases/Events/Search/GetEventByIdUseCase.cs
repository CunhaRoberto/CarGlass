using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetEventByIdUseCase
    {
        public ResponseEventJson Execute(Guid id)
        {
            var dbContext = new PassInDbContext();
            var entity = dbContext.Events.Find(id);
            
            if(entity is null)
            {
                throw new NotFoundException("An events with id dont exist.");
            }
            return new ResponseEventJson
            {
                Id = entity.Id,
                Title = entity.Title,
                Details = entity.Details,
                Slug = entity.Slug,
                MaximumAttendees = entity.Maximum_Attendees,
                
            };
        }
    }
}
