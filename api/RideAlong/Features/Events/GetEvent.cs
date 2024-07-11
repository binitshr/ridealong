using Marten;

namespace RideAlong.Features.Events;

[Tag("events")]
[Route("/events", "GET")]
public class QueryEvents: IReturn<List<Event>>
{
    public Guid? Id { get; set; }
    public List<Guid>? Ids { get; set; }
    public string Name { get; set; }
}

public class QueryEventsHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public QueryEventsHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    public List<Event> Get(QueryEvents query)
    { 
        return _documentSession.Query<Event>().ToList();
    }

    
}