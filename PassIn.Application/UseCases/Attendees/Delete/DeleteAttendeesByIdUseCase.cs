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
        public ResponseRegisteredEventJson Execute(string id)
        {
            var entity = _dbContext.Attendees.Find(id) ?? throw new NotFoundException(ExceptionMsg.NotFoundAttendees);
            _dbContext.Attendees.Remove(entity);
            _dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id.ToString(),
            };
        }
    }
}
