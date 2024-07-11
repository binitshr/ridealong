using Marten;

namespace RideAlong.Features.Todos;

[Tag("todos")]
[Route("/todos/{Id}", "PUT")]
public class UpdateTodo : IPut, IReturn<Todo>
{
    public Guid Id { get; set; }
    [ValidateNotEmpty]
    public string Text { get; set; }
    public bool IsFinished { get; set; }
}

public class UpdateTodoHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public UpdateTodoHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public async Task<Todo> Put(UpdateTodo request)
    {
        var todo = request.ConvertTo<Todo>();
        _documentSession.Store(todo);
        await _documentSession.SaveChangesAsync();
        
        return todo;
    }
    
}

public class TodoUpdated
{
    public Guid Id { get; set; }
}