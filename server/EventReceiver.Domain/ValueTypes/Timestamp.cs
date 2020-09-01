using EventReceiver.Infra.Shared;
using Flunt.Notifications;
using System;

namespace EventReceiver.Domain.ValueTypes
{
    public class Timestamp : Notifiable
    {
        public DateTime Time { get; private set; }

        public Timestamp(string timestamp)
        {
            Validate(timestamp);

            if (Valid)
                Time = Util.TimeStampToDate(timestamp);
        }

        private void Validate(string timestamp)
        {
            if (!IsTimeStampValidFormat(timestamp))
                AddNotification(nameof(Timestamp), "Error in input format.");
        }

        private bool IsTimeStampValidFormat(string timestamp)
        {
            return !string.IsNullOrEmpty(timestamp) && decimal.TryParse(timestamp, out _);
        }

        public override string ToString()
        {
            return $"{Time}";
        }
    }
}
