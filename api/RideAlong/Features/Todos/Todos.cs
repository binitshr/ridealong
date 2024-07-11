using Marten.Pagination;
using ServiceStack.Model;

namespace RideAlong.Features.Todos;

public class Todo
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsFinished { get; set; }
}
