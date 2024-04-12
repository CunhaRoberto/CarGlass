using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Communication.Responses
{
    public class ResponseDeletedEventJson
    {
        public Guid Id { get; set; }

        public string Message { get; set; } = string.Empty;

        public ResponseDeletedEventJson(string message) 
        {
            Message = message;
        }
    }

}
