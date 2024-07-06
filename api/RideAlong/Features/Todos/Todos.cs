using Marten.Pagination;
using ServiceStack.Model;

namespace RideAlong.Features.Todos;

[Tag("todos")]
[Route("/todos", "GET")]
public class QueryTodos: IReturn<List<Todo>>
{
    public Guid? Id { get; set; }
    public List<Guid>? Ids { get; set; }
    public string? TextContains { get; set; }
}

[Tag("todos")]
[Route("/todos", "POST")]
public class CreateTodo : IPost, IReturn<Todo>
{
    [ValidateNotEmpty]
    public string Text { get; set; }
    public string Code { get; set; }
}

[Tag("todos")]
[Route("/todos/{Id}", "PUT")]
public class UpdateTodo : IPut, IReturn<Todo>
{
    public Guid Id { get; set; }
    [ValidateNotEmpty]
    public string Text { get; set; }
    public bool IsFinished { get; set; }
}

[Tag("todos")]
[Route("/todos/{Id}", "DELETE")]
public class DeleteTodo : IDelete, IReturnVoid
{
    public Guid Id { get; set; }
}

[Tag("todos")]
[Route("/todos", "DELETE")]
public class DeleteTodos : IDelete, IReturnVoid
{
    public List<Guid> Ids { get; set; }
}

public class Todo
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsFinished { get; set; }
}
