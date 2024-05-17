namespace PassIn.Communication.Responses;
public class ResponseEventJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;    
    public int MaximumAttendees { get; set; }
    public int AttendeesAmount { get; set; }
    public DateTime? Created_At { get; set; }    
    public DateTime? Updated_At { get; set; }       
}


public class ResponseDelEventJson   
{
    public string Message { get; set; } = string.Empty;
    public Guid Id { get; set; }



}