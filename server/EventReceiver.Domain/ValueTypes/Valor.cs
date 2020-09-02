using Flunt.Notifications;
using Flunt.Validations;

namespace EventReceiver.Domain.ValueTypes
{
    public class Valor : Notifiable
    {
        public string Value { get; private set; }
        public bool Error { get; private set; }

        public Valor(string value, bool error)
        {
            Value = value;
            Error = error;
            Validate(value);
        }

        public Valor(string value)
        {
            Value = value;
            Validate(value);
        }

        public void Validate(string value)
        {
            if (IsStringEmpty(value))
            {
                Error = true;
                AddNotification(nameof(Valor), "Valor is empty.");
            }
        }

        private bool IsStringEmpty(string value)
        {
            return value.Equals(string.Empty);
        }

        public override string ToString()
        {
            if (!Error)
                return $"{Value}";
            else
                return $"Error";
        }
    }
}
