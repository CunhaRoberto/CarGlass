﻿namespace PassIn.Infrastructure.Entities
{
    public class EventUpdate    
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int Maximum_Attendees { get; set; }
        public DateTime Updated_At { get; set; }    

    }
}
