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
            var dbContext = new PassInDbContext();
            var entity = dbContext.Events.Find(eventId);

            if (entity is null){
                throw new NotFoundException("An events with id dont exist.");
            }

            Validate(request);

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
           
            dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id,

            };

        }

        private void Validate(RequestUpdateEventJson request)
        {
            var retorno = new RequestUpdateEventJson();

            if(string.IsNullOrWhiteSpace(request.Details) 
                || string.IsNullOrWhiteSpace(request.Title)
                || request.MaximumAttendees == 0
                )
            {
                throw new ErrorOrValidationExcepition("No data was provided to make the change.");
            }

            if (request.MaximumAttendees < 0)
            {
                throw new ErrorOrValidationExcepition("The MaximumAttendees is invalid.");
            }

        }
    }
}
