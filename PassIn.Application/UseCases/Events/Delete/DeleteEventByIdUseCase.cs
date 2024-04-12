using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Events.Delete
{
    public class DeleteEventByIdUseCase
    {
        public ResponseRegisteredEventJson Execute(Guid id)   
        {
            using (var dbContext = new PassInDbContext())
            {
                var entity = dbContext.Events.Find(id);

                if (entity is null)
                {
                    throw new NotFoundException("Event with the specified id does not exist.");
                }
                
                dbContext.Events.Remove(entity);
                dbContext.SaveChanges();

                return new ResponseRegisteredEventJson
                {
                    Id = entity.Id,

                };

            }
        }

    }
}
