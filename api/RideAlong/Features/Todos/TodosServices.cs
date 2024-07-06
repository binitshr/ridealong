using System.Collections;
using Marten;

namespace RideAlong.Features.Todos;

public class TodosServices : Service
{

    private readonly IDocumentSession _documentSession;

    public TodosServices(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    public List<Todo> Get(QueryTodos query)
    { 
       return _documentSession.Query<Todo>().ToList();
    }

    public async Task<Todo> Post(CreateTodo request)
    {
        var newTodo = new Todo { Id = Guid.NewGuid(), Text = request.Text };
        _documentSession.Store(newTodo);

        await _documentSession.SaveChangesAsync();
        
        return newTodo;
    }

    public async Task<Todo> Put(UpdateTodo request)
    {
        var todo = request.ConvertTo<Todo>();
        _documentSession.Store(todo);
        await _documentSession.SaveChangesAsync();
        
        return todo;
    }

    // Handles Deleting the Todo item
    public async Task Delete (DeleteTodo request)
    {
        _documentSession.Delete<Todo>(request.Id);
        await _documentSession.SaveChangesAsync();

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
