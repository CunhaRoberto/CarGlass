using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System.Net.Mail;

namespace PassIn.Application.UseCases.Events.Register
{
    public class RegisterAttendeesUseCase   
    {
        private readonly PassInDbContext _dbContext;

        public RegisterAttendeesUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredAttendeeEventJson Execute(Guid eventId,RequestRegisterAttendessJson request)
        {           

            Validate(eventId, request);

            var entity = new Infrastructure.Entities.Attendee
            {
               Name= request.Name.Trim(),
               Email= request.Email.Trim(),
               Event_Id= eventId,
               Created_At = DateTime.UtcNow
            };

            _dbContext.Attendees.Add(entity);    
            _dbContext.SaveChanges();

            return new ResponseRegisteredAttendeeEventJson
            {
                Id = entity.Id,
            };

        }

        private void Validate(Guid eventId, RequestRegisterAttendessJson request)           

        {
            var eventExist = _dbContext.Events.Any(ev => ev.Id == eventId);

            request.Email= request.Email.Trim();

            if (!eventExist)
            {
                throw new NotFoundException("Event with the specified id does not exist.");
            }
          
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ErrorOrValidationExcepition("The Name is invalid.");
            }

            if (string.IsNullOrWhiteSpace(request.Email) || !IsValidEmail(request.Email) )
            {
                throw new ErrorOrValidationExcepition("The Details is invalid.");
            }

            var attendeeRegistred = _dbContext.Attendees.Any(at => at.Email.Equals(request.Email) && at.Event_Id == eventId);
            if (attendeeRegistred)
            {
                throw new RecordAlreadyExistsException("Attendees already registered for the event.");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var enderecoEmail = new MailAddress(email);
                return enderecoEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
