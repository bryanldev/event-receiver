namespace EventReceiver.Domain.Models
{
    public class SensorEventModel
    {
        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}