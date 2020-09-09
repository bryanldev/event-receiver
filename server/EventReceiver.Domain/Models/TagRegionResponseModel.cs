namespace EventReceiver.Domain.Models
{
    public class TagRegionResponseModel
    {
        public TagRegionResponseModel(string country, string region, int total)
        {
            Country = country;
            Region = region;
            Total = total;
        }

        public string Country { get; set; }
        public string Region { get; set; }
        public int Total { get; set; }
    }
}