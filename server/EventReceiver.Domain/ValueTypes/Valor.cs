using Flunt.Notifications;

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
        }

        public Valor(string value)
        {
            Value = value;

            if (IsStringEmpty(value))
            {
                Error = true;
                AddNotification("Valor", "Empty field");
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
