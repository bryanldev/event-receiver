using System.Text.RegularExpressions;
using Flunt.Validations;

namespace Domain.Entities.SensorEventAggregate
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

        public Tag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                AddNotification(nameof(Tag), "Tag should not be empty.");
                return;
            }

            var splitTag = SplitTag(tag);

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
            }
        }

        private string[] SplitTag(string tag) => Regex.Split(tag, "\\.");

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