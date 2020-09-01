using EventReceiver.Domain.ValueTypes;

namespace EventReceiver.Domain.Entities
{
    public class SensorEvent : BaseEntity<int>
    {
        protected SensorEvent() { }
        public SensorEvent(Timestamp Timestamp, Tag Tag, Valor Valor)
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
