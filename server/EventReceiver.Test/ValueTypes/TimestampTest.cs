using NUnit.Framework;
using System.Linq;

namespace EventReceiver.Domain.ValueTypes.Tests
{
    [TestFixture()]
    public class TimestampTest
    {
        [Test()]
        public void TimestampIsValid()
        {
            // Arrange
            var timestamp = new Timestamp("1598860800");

            // Assert
            Assert.True(timestamp.Valid);
        }

        [Test()]
        public void EmptyArgumentTimestampTest()
        {
            // Arrange
            var timestamp = new Timestamp("");

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Error in input format.", timestamp.Notifications.Single().Message);
        }

        [Test()]
        public void NullArgumentTimestampTest()
        {
            // Arrange
            var timestamp = new Timestamp(null);

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Error in input format.", timestamp.Notifications.Single().Message);
        }

        [Test()]
        public void NonNumericArgumentsTest()
        {
            // Arrange
            var timestamp = new Timestamp("AFH4587!?");

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Error in input format.", timestamp.Notifications.Single().Message);
        }

        [Test()]
        public void ToStringTest()
        {
            // Arrange
            var timestamp = new Timestamp("638956800");

            // Assert
            Assert.That(timestamp.ToString, Is.EqualTo("01/04/1990 08:00:00"));
        }
    }
}