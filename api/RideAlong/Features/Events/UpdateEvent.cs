using Marten;
using RideAlong.Features.Todos;

namespace RideAlong.Features.Events;

[Tag("events")]
[Route("/events/{Id}", "PUT")]
public class UpdateEvent : IPut, IReturn<Event>
{
    [ValidateNotEmpty] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Organizer { get; set; }
}

public class UpdateEventHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public UpdateEventHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task<Event> Put(UpdateEvent request)
    {
        var updatedEvent = request.ConvertTo<Event>();
        _documentSession.Store(updatedEvent);
        await _documentSession.SaveChangesAsync();

        return updatedEvent;
    }
}

public class EventUpdated
{
    public Guid Id { get; set; }
}