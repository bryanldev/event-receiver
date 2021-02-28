namespace API.Models
{
    public class SensorEventRequestModel
    {
        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Data { get; set; }
    }
}