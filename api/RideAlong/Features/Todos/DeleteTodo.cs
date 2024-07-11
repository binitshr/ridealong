using Marten;

namespace RideAlong.Features.Todos;


[Tag("todos")]
[Route("/todos/{Id}", "DELETE")]
public class DeleteTodo : IDelete, IReturnVoid
{
    public Guid Id { get; set; }
}

public class DeleteTodoHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public DeleteTodoHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public async Task Delete (DeleteTodo request)
    {
        _documentSession.Delete<Todo>(request.Id);
        await _documentSession.SaveChangesAsync();
    }

}

public class TodoDeleted{}