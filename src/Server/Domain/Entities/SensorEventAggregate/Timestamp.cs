using Flunt.Notifications;

namespace Domain.Entities.SensorEventAggregate
{
    public class Timestamp : Notifiable
    {
        /// <summary>
        /// When the event occurred on UNIX Timestamp
        /// </summary>
        public string Time { get; }

        public Timestamp(string unixTimeStamp)
        {
            Validate(unixTimeStamp);

            if (Valid)
                Time = unixTimeStamp;
        }

        private void Validate(string timestamp)
        {
            if (string.IsNullOrWhiteSpace(timestamp))
                AddNotification(nameof(timestamp), "Timestamp should not be empty.");

            if (Valid && !IsTimeStampValidFormat(timestamp))
                AddNotification(nameof(timestamp), "Error in input format.");
        }

        private bool IsTimeStampValidFormat(string timestamp)
        {
            return decimal.TryParse(timestamp, out _);
        }

        public override string ToString()
        {
            return $"{Time}";
        }
    }
}