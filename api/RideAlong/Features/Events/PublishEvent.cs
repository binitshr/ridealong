using Marten;

namespace RideAlong.Features.Events;

[Tag("events")]
[Route("/events/{Id}/publish", "POST")]
public class PublishEvent
{
    public Guid Id { get; set; }
}

public class PublishEventHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public PublishEventHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task<Event> Post(PublishEvent request)
    {
        var evt = request.ConvertTo<Event>();
        evt.IsPublished = true;
        _documentSession.Store(evt);
        await _documentSession.SaveChangesAsync();

        return evt;
    }
}


public class EventPublished
{
    public Guid Id { get; set; }

}