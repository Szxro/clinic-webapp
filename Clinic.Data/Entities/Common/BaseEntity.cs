using Clinic.Data.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Data.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    [NotMapped]
    public readonly List<IEvent> events = new();

    public void AddEvent(IEvent @event)
    {
        events.Add(@event);
    }

    public void RemoveEvent(IEvent @event)
    {
        events.Remove(@event);
    }

    public void Clear()
    {
        events.Clear();
    }
}
