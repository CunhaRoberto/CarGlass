using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Attendees.Delete
{
    public class DeleteAttendeesByIdUseCase   
    {
        private readonly PassInDbContext _dbContext;
        public DeleteAttendeesByIdUseCase()  
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredEventJson Execute(Guid id)
        {
            var entity = _dbContext.Attendees.Find(id);

            if (entity is null)
            {
                throw new NotFoundException("Attendees with the specified id does not exist.");
            }

            _dbContext.Attendees.Remove(entity);
            _dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id,
            };
        }
    }
}
