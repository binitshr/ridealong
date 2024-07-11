using Marten;

namespace RideAlong.Features.Todos;

[Tag("todos")]
[Route("/todos", "DELETE")]
public class DeleteTodos : IDelete, IReturnVoid
{
    public List<Guid> Ids { get; set; }
}

public class DeleteTodosHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public DeleteTodosHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public async Task Delete(DeleteTodos request)
    {
        foreach (var todo in request.Ids)
        {
            _documentSession.Delete<Todo>(todo);
        }
        await _documentSession.SaveChangesAsync();

    }
}