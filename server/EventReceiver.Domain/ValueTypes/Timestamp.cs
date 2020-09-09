using Flunt.Notifications;
using Flunt.Validations;

namespace EventReceiver.Domain.ValueTypes
{
    public class Timestamp : Notifiable
    {
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
            {
                AddNotification(nameof(timestamp), "Timestamp should not be empty.");
            }
            
            if (Valid && !IsTimeStampValidFormat(timestamp))
                AddNotification(nameof(Timestamp), "Error in input format.");
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