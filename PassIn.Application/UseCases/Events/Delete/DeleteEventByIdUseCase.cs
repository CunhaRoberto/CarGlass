﻿using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Delete
{
    public class DeleteEventByIdUseCase
    {
        private readonly PassInDbContext _dbContext;
        public DeleteEventByIdUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredEventJson Execute(Guid id)
        {
            var entity = _dbContext.Events.Find(id);

            if (entity is null)
            {
                throw new NotFoundException("Event with the specified id does not exist.");
            }
                       

            _dbContext.Events.Remove(entity);
            _dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id,
            };
        }
    }
}

