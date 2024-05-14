using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetAttendeesByEventIdUseCase
    {
        private readonly PassInDbContext _dbCcontext;
        public GetAttendeesByEventIdUseCase()
        {
            _dbCcontext = new PassInDbContext();
        }
        public List<ResponseAttendeeJson> Execute(Guid eventId)
        {
            var result = _dbCcontext.Attendees.ToList() 
                ?? throw new NotFoundException(ExceptionMsg.NotFoundEvents) ;
         
            var responseEvents = result.Select(entity => new ResponseAttendeeJson
            {
                Id = entity.Id.ToString(),
                Name = entity.Name, 
                Email = entity.Email,   
                CreatedAt = entity.Created_At
                
            }).ToList();

            return responseEvents;
        }
    }
}
