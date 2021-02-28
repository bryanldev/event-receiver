namespace Domain.Entities.SensorEventAggregate
{
    public class SensorEvent : BaseEntity<int>
    {
        public Tag Tag { get; }
        public Timestamp Timestamp { get; }
        public SensorData Data { get; }
        public string Status { get; }

        protected SensorEvent()
        {
        }

        public SensorEvent(Timestamp timestamp, Tag tag, SensorData sensorData)
        {
            AddNotifications(timestamp, tag, sensorData);

            Data = sensorData;
            Status = sensorData.IsProcessed();

            if (Valid)
            {
                Timestamp = timestamp;
                Tag = tag;
            }
        }

        public override string ToString()
        {
            return $"{{" +
                   $"timestamp:{Timestamp}," +
                   $"tag:{Tag}," +
                   $"valor:{Data}" +
                   $"}}";
        }
    }
}