using Microsoft.Extensions.Logging;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.Update
{
    public class UpdateEventByIdUseCase
    {
        private readonly PassInDbContext _dbContext;
        public UpdateEventByIdUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredEventJson Execute(Guid eventId, RequestUpdateEventJson request)
        {
            var retorno = new RequestUpdateEventJson();

            var entity = _dbContext.Events.Find(eventId);
            var attendeesNumber  = _dbContext.Attendees.Count(attendees => attendees.Event_Id == eventId);

           

            Validate(request, attendeesNumber, entity);

            {
                if (!string.IsNullOrWhiteSpace(request.Title))               
                {
                    entity.Title = request.Title;
                    entity.Slug = request.Title.ToLower().Replace(" ", "-");
                };

                if (!string.IsNullOrWhiteSpace(request.Details))
                {
                    entity.Details = request.Details;
                }
                if (request.MaximumAttendees > 0)
                {
                    entity.Maximum_Attendees = request.MaximumAttendees;
                }
                  entity.Updated_At = DateTime.UtcNow;
                
            }
            _dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id,

            };
        }

        private void Validate(RequestUpdateEventJson request, int attendeesNumber, Event entity)
        {
            if (entity is null)
            {
                throw new NotFoundException("An events with id dont exist.");
            }


            

            if(string.IsNullOrWhiteSpace(request.Details) 
                && string.IsNullOrWhiteSpace(request.Title)
                && request.MaximumAttendees == 0
                )
            {
                throw new ErrorOrValidationExcepition("No data was provided to make the change.");
            }

            if (request.MaximumAttendees < 0)
            {
                throw new ErrorOrValidationExcepition("The MaximumAttendees is invalid.");

            }

            if (request.MaximumAttendees < attendeesNumber)
            {
                throw new ConflictException($"There are alredy {attendeesNumber} attendees registered!");
            }


        }
    }
}
