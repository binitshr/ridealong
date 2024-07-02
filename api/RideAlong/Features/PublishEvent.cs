namespace RideAlong.Features;

[Tag("events")]
[Route("/events/publish", "POST")]
public class PublishEvent
{
    public Guid Id { get; set; }
}

public class PublishEventHandler : Service
{
    public Guid Post(PublishEvent request)
    {
        // load from the database
        var evt = new Event();
        
        
        evt.PublishedOn = DateTimeOffset.UtcNow;
        // save to database
        // Publish an event in the database
        return request.Id;
    } 
}


public class EventPublished{}