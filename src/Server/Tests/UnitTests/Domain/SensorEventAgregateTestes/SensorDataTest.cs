
using Domain.Entities.SensorEventAggregate;
using NUnit.Framework;
using System.Linq;

namespace Tests.UnitTests.Domain.SensorEventAgregateTestes
{
    public class SensorDataTests
    {
        [Test]
        public void EmptyValorReturnErrorStatus()
        {
            // Arrange
            var valor = new SensorData("");

            // Assert
            Assert.True(valor.Valid);
            Assert.AreEqual("Error", valor.IsProcessed());
        }

        [Test]
        public void NullValorReturnError()
        {
            // Arrange
            var valor = new SensorData(null);

            // Assert
            Assert.True(valor.Invalid);
            Assert.AreEqual("SensorData should not be null.", valor.Notifications.Single().Message);
        }


        [Test]
        public void ToStringTest()
        {
            // Arrange
            var valor1 = new SensorData("wk340");
            var valor2 = new SensorData("14340");
            var emptyValor = new SensorData("");

            // Assert
            Assert.That(valor1.IsProcessed(), Is.EqualTo("Processed"));
            Assert.That(valor2.IsProcessed(), Is.EqualTo("Processed"));
            Assert.That(emptyValor.IsProcessed(), Is.EqualTo("Error"));
        }
    }
}