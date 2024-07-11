using Marten;

namespace RideAlong.Features.Todos;

[Tag("todos")]
[Route("/todos", "GET")]
public class QueryTodos: IReturn<List<Todo>>
{
    public Guid? Id { get; set; }
    public List<Guid>? Ids { get; set; }
    public string? TextContains { get; set; }
}

public class QueryTodoHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public QueryTodoHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public List<Todo> Get(QueryTodos query)
    { 
        return _documentSession.Query<Todo>().ToList();
    }
    
}
