using EventReceiver.Domain.ValueTypes;

namespace EventReceiver.Domain.Entities
{
    public class Event : BaseEntity<int>
    {
        protected Event() { }
        public Event(Timestamp Timestamp, Tag Tag, Valor Valor)
        {

            AddNotifications(Timestamp, Tag, Valor);

            if (Valid)
            {
                this.Timestamp = Timestamp;
                this.Tag = Tag;
                this.Valor = Valor;
            }

        }

        public Tag Tag { get; }
        public Timestamp Timestamp { get; }
        public Valor Valor { get; }

        public override string ToString()
        {
            return $"{Tag}";
        }
    }
}
