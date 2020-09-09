namespace EventReceiver.Domain.Models
{
    public class SensorEventResponseModel
    {
        public SensorEventResponseModel(string timestamp, string tag, string value, string status)
        {
            Timestamp = timestamp;
            Tag = tag;
            Value = value;
            Status = status;
        }

        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    }
}