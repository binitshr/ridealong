using Marten.Pagination;
using ServiceStack.Model;

namespace RideAlong.Features.Events;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Organizer { get; set; }
    public DateTimeOffset CreatedOn
    {
        get;
        set;
    }
    
    public DateTimeOffset PublishedOn { get; set; }
}
