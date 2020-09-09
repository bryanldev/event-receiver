using System.Text.RegularExpressions;
using Flunt.Validations;

namespace EventReceiver.Domain.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Country { get; private set; }
        public string Region { get; private set; }
        public string SensorName { get; private set; }

        #region ForeingKey

        public int SensorEventId { get; set; }
        public virtual SensorEvent SensorEvent { get; set; }

        #endregion

        protected Tag()
        {
        }

        public Tag(string country, string region, string name)
        {
            Country = country;
            Region = region;
            SensorName = name;
        }

        public Tag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                AddNotification(nameof(Tag), "Tag should not be empty.");
                return;
            }

            var splitTag = Regex.Split(tag, "\\.");

            if (splitTag.Length != 3)
            {
                AddNotification(nameof(Tag), "Unexpected tag format.");
                return;
            }

            if (Valid)
            {
                Country = splitTag[0];
                Region = splitTag[1];
                SensorName = splitTag[2];
                Validate();
            }
        }

        private void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNull(Country, "Tag.Country", "Country should not be null")
                .IsNotNull(Region, "Tag.Region", "Region should not be null")
                .IsNotNull(SensorName, "Tag.SensorName", "SensorName should not be null")
            );
        }

        public override string ToString()
        {
            return $"{Country}.{Region}.{SensorName}";
        }
    }
}