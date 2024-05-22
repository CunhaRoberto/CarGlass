using Microsoft.Extensions.Logging;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetEventByIdUseCase
    {
        private readonly PassInDbContext _dbContext;    
        public GetEventByIdUseCase()
        {
            _dbContext = new PassInDbContext();           
        }
        public ResponseEventJson Execute(Guid id)
        {
           
            var entity = _dbContext.Events.Find(id);
            var attendeesNumber = "";

            if (entity is null)
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
                AttendeesAmount = 0,
                Created_At =entity.Created_At,
                Updated_At =entity.Updated_At,
                
            };
        }
        

    }
}
