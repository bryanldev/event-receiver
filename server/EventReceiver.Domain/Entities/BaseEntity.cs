using Flunt.Notifications;

namespace EventReceiver.Domain.Entities
{
    public abstract class BaseEntity<TKeyType> : Notifiable
    {
        public virtual TKeyType Id { get; }
        protected BaseEntity(TKeyType id = default)
        {
            Id = id;
        }
    }
}
