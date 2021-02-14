using System.Linq;
using Domain.Entities.SensorEventAggregate;
using NUnit.Framework;

namespace Tests.UnitTests.Domain.SensorEventAgregateTestes
{
    public class TimestampTest
    {
        [Test]
        public void TimestampIsValid()
        {
            // Arrange
            var timestamp = new Timestamp("1598860800");

            // Assert
            Assert.True(timestamp.Valid);
        }

        [Test]
        public void EmptyArgumentTimestampTest()
        {
            // Arrange
            var timestamp = new Timestamp("");

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Timestamp should not be empty.", timestamp.Notifications.Single().Message);
        }

        [Test]
        public void NullArgumentTimestampTest()
        {
            // Arrange
            var timestamp = new Timestamp(null);

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Timestamp should not be empty.", timestamp.Notifications.Single().Message);
        }

        [Test]
        public void NonNumericArgumentsTest()
        {
            // Arrange
            var timestamp = new Timestamp("AFH4587!?");

            // Assert
            Assert.True(timestamp.Invalid);
            Assert.AreEqual("Error in input format.", timestamp.Notifications.Single().Message);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var timestamp = new Timestamp("638956800");

            // Assert
            Assert.That(timestamp.ToString, Is.EqualTo("638956800"));
        }
    }
}