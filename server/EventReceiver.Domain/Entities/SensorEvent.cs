using EventReceiver.Domain.ValueTypes;

namespace EventReceiver.Domain.Entities
{
    public class SensorEvent : BaseEntity<int>
    {
        protected SensorEvent()
        {
        }

        public SensorEvent(Timestamp timestamp, Tag tag, Valor valor)

        {
            AddNotifications(timestamp, tag, valor);

            Valor = valor;
            Status = valor.IsProcessed();

            if (Valid)
            {
                Timestamp = timestamp;
                Tag = tag;
            }
        }

        public Tag Tag { get; }
        public Timestamp Timestamp { get; }
        public Valor Valor { get; }

        public string Status { get; }

        public override string ToString()
        {
            return $"{{" +
                   $"timestamp:{Timestamp}," +
                   $"tag:{Tag}," +
                   $"valor:{Valor}" +
                   $"}}";
        }
    }
}