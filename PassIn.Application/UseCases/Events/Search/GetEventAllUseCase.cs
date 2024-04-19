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

