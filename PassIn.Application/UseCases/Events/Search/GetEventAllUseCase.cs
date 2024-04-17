using System;
using System.Collections.Generic;
using System.Linq;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetEventAllUseCase 
    {
        public List<ResponseEventJson> Execute()
        {
            using (var dbContext = new PassInDbContext())
            {
                var entities = dbContext.Events.ToList();


                if (!entities.Any())
                {
                    throw new NotFoundException("No events found.");
                }
                var total = entities.Count();
                var responseEvents = entities.Select(entity => new ResponseEventJson
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Details = entity.Details,
                    Slug = entity.Slug,
                    MaximumAttendees = entity.Maximum_Attendees
                }).ToList();

                return responseEvents; 
            }
        }
    }
}
