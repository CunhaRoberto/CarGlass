using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System.Net.Mail;

namespace PassIn.Application.UseCases.Events.Register
{
    public class RegisterEventsUseCase
    {
        private readonly PassInDbContext _dbContext;

        public RegisterEventsUseCase() 
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredEventJson Execute(RequestEventJson request)
        {
            Validate(request);


            var entity = new Infrastructure.Entities.Event 
            {
              Title = request.Title,
              Details = request.Details,
              Maximum_Attendees = request.MaximumAttendees,
              Slug = request.Title.ToLower().Replace(" ", "-"),
              Created_At = DateTime.UtcNow,
              

            };

            _dbContext.Events.Add(entity);

            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new ErrorOrValidationExcepition("Unable to connect to the database!.");
            }

           
           

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
