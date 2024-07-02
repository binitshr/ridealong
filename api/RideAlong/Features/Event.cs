namespace RideAlong.Features;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid Owner { get; set; }
    public DateTimeOffset CreatedOn
    {
        get;
        set;
    }
    
    public DateTimeOffset PublishedOn { get; set; }
}