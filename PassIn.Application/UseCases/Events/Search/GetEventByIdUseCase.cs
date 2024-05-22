using Microsoft.Extensions.Logging;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PassIn.Application.UseCases.Events.Search
{
    public class GetDividersUseCase 
    {
        public List<int> Execute(int number)
        {
            List<int> Dividers = Enumerable.Range(1, number)
                                 .Where(x => number % x == 0)
                                 .ToList();
            return Dividers;      
        }
    }
}
