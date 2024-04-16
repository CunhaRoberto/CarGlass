using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Update
{
    public class UpdateEventByIdUseCase
    {
        public ResponseRegisteredEventJson Execute(Guid eventId, RequestUpdateEventJson request)
        {
            Validate(request);

            var dbContext = new PassInDbContext();
            var entity = dbContext.Events.Find(eventId);

            {
                if (!string.IsNullOrWhiteSpace(request.Title))               
                {
                    entity.Title = request.Title;                    
                };               
                entity.Details = request.Details;
                entity.Maximum_Attendees = request.MaximumAttendees;
            }
           

           // dbContext.Events.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id,

            };

        }

        private void Validate(RequestUpdateEventJson request)
        {
            if (request.MaximumAttendees < 1)
            {
                throw new ErrorOrValidationExcepition("The MaximumAttendees is invalid.");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new ErrorOrValidationExcepition("The Title is invalid.");
            }

            if (string.IsNullOrWhiteSpace(request.Details))
            {
                throw new ErrorOrValidationExcepition("The Details is invalid.");
            }

        }
    }
}
