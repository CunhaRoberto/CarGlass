using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Register
{
    public class RegisterEventsUseCase
    {
        public ResponseRegisteredEventJson Execute(RequestEventJson request)
        {
            Validate(request);

            var dbContext = new PassInDbContext();

            var entity = new Infrastructure.Entities.Event 
            {
              Title = request.Title,
              Details = request.Details,
              Maximum_Attendees = request.MaximumAttendees,
              Slug = request.Title.ToLower().Replace(" ", "-"),
              
              

            };

            dbContext.Events.Add(entity);  
            dbContext.SaveChanges();

            return new ResponseRegisteredEventJson 
            { 
                Id = entity.Id,
               
            };

        }

        private void Validate(RequestEventJson request) 
        {
           if(request.MaximumAttendees < 1)
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
