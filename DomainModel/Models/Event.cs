namespace DomainModel.Models;

public class Event
{
    public int EventId { get; set; }
    public int EventType { get; set; }
    public string? LongDesc { get; set; }
    public string? ShortDesc { get; set; }
    public DateTime EventDate { get; set; }
    public int AccId { get; set; }

    public Event(int eventType, string longDesc, string shortDesc, DateTime dt, int accId)
    {
        EventType = eventType;
        LongDesc = longDesc;
        ShortDesc = shortDesc;
        EventDate = dt;
        AccId = accId;
    }
    public Event() { }

}
