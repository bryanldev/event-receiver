using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities.SensorEventAggregate
{
    public class SensorData : Notifiable
    {
        /// <summary>
        /// Data collected from a given sensor
        /// </summary>
        public string Value { get; private set; }

        public SensorData(string value)
        {
            this.Value = value;
            Validate();
        }

        private void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNull(Value, "SensorData.Value", "SensorData should not be null.")
            );
        }

        public string IsProcessed()
        {
            return Value.Equals("") ? "Error" : "Processed";
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}