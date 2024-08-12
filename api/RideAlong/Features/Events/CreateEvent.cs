using Marten;

namespace RideAlong.Features.Events;

[Tag("events")]
[Route("/events", "POST")]
public class CreateEvent : IPost, IReturn<Event>
{
    [ValidateNotEmpty]
    public string Name { get; set; }
    public string Organizer { get; set; }
}

public class CreateEventHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public CreateEventHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task<Event> Post(CreateEvent request)
    {
        var newEvent = new Event { Id = Guid.NewGuid(), Name = request.Name, Organizer = request.Organizer, IsPublished = false, PublishedOn = null};
        _documentSession.Store(newEvent);
        await _documentSession.SaveChangesAsync();

        return newEvent;
    }
}