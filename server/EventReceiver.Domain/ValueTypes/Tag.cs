using Flunt.Notifications;
using System.Text.RegularExpressions;

namespace EventReceiver.Domain.ValueTypes
{
    public class Tag : Notifiable
    {
        public string Country { get; private set; }
        public string Region { get; private set; }
        public string Name { get; private set; }


        public Tag(string country, string region, string name)
        {
            Country = country;
            Region = region;
            Name = name;
        }

        public Tag(string tag)
        {
            string[] splitTag;
            splitTag = Regex.Split(tag, "\\.");
            if (splitTag.Length == 3)
            {
                Country = splitTag[0];
                Region = splitTag[1];
                Name = splitTag[2];
            }
            else
                AddNotification("Tag", "Unexpected tag format.");
        }

        public override string ToString()
        {

            return $"{Country}.{Region}.{Name}";

        }
    }
}
