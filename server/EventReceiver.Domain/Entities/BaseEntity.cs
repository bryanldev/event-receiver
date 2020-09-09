using Flunt.Notifications;

namespace EventReceiver.Domain.Entities
{
    public abstract class BaseEntity<T> : Notifiable
    {
        public virtual T Id { get; }

        protected BaseEntity(T id = default)
        {
            Id = id;
        }
    }
}