namespace API.Models
{
    public class SensorEventResponseModel
    {
        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
    }
}