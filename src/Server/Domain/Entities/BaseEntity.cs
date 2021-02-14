using Flunt.Notifications;

namespace Domain.Entities
{
    public abstract class BaseEntity<T> : Notifiable
    {
        public virtual int Id { get; protected set; }
    }
}