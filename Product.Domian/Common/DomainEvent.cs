using MediatR;

namespace ProductManagement.Domian.Common;
public abstract class DomainEvent : INotification
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}

