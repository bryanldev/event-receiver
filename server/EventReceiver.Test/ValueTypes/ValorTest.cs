using System.Linq;
using EventReceiver.Domain.ValueTypes;
using NUnit.Framework;

namespace EventReceiver.Test.ValueTypes
{
    [TestFixture]
    public class ValorTest
    {
        [Test]
        public void EmptyValorReturnErrorStatus()
        {
            // Arrange
            var valor = new Valor("");

            // Assert
            Assert.True(valor.Valid);
            Assert.AreEqual("Error", valor.IsProcessed());
        }

        [Test]
        public void NullValorReturnError()
        {
            // Arrange
            var valor = new Valor(null);

            // Assert
            Assert.True(valor.Invalid);
            Assert.AreEqual("Valor should not be null.", valor.Notifications.Single().Message);
        }


        [Test]
        public void ToStringTest()
        {
            // Arrange
            var valor1 = new Valor("wk340");
            var valor2 = new Valor("14340");
            var emptyValor = new Valor("");

            // Assert
            Assert.That(valor1.IsProcessed(), Is.EqualTo("Processed"));
            Assert.That(valor2.IsProcessed(), Is.EqualTo("Processed"));
            Assert.That(emptyValor.IsProcessed(), Is.EqualTo("Error"));
        }
    }
}