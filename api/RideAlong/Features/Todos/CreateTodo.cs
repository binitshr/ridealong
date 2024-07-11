using Marten;

namespace RideAlong.Features.Todos;

[Tag("todos")]
[Route("/todos", "POST")]
public class CreateTodo : IPost, IReturn<Todo>
{
    [ValidateNotEmpty]
    public string Text { get; set; }
    public string Code { get; set; }
}

public class CreateTodoHandler : Service
{
    private readonly IDocumentSession _documentSession;

    public CreateTodoHandler(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    
    public async Task<Todo> Post(CreateTodo request)
    {
        var newTodo = new Todo { Id = Guid.NewGuid(), Text = request.Text };
        _documentSession.Store(newTodo);
        
        await _documentSession.SaveChangesAsync();
        
        return newTodo;
    }
    
}

public class TodoCreated
{
    public Guid Id { get; set; }
}