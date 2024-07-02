namespace RideAlong.Features;

[Tag("events")]
[Route("/events/create", "POST")]
public class CreateEvent
{
    public string Name { get; set; }
    public string Code { get; set; }
}

public class CreateEventHandler : Service
{
    public Guid Post(CreateEvent request)
    {
        // create an event in the database

        if (!request.Code.IsEmpty())
        {
            //
        }
        
        // publish EventCreated()
        var evt = new Event();
        // save to db
        return Guid.NewGuid();
    } 
}

public class EventCreated{}