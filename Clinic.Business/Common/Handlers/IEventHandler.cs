using Clinic.Data.Contracts;
using MediatR;

namespace Clinic.Business.Contracts;

public interface IEventHandler< in TEvent> : INotificationHandler<TEvent>
    where TEvent : IEvent
{
}
