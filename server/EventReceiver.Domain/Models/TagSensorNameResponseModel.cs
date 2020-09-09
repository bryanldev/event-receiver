namespace EventReceiver.Domain.Models
{
    public class TagSensorNameResponseModel
    {
        public TagSensorNameResponseModel(string country, string region, string sensorName, int total)
        {
            Country = country;
            Region = region;
            SensorName = sensorName;
            Total = total;
        }

        public string Country { get; set; }
        public string Region { get; set; }
        public string SensorName { get; set; }
        public int Total { get; set; }
    }
}