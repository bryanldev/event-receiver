using Flunt.Notifications;
using Flunt.Validations;

namespace EventReceiver.Domain.ValueTypes
{
    public class Valor : Notifiable
    {
        public string Value { get; private set; }
        
        public Valor(string value)
        {
            Value = value;
            Validate();
        }

        private void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNull(Value, "Valor.Value", "Valor should not be null.")
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