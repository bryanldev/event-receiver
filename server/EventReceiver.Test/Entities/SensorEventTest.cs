using EventReceiver.Domain.Entities;
using EventReceiver.Domain.ValueTypes;
using NUnit.Framework;

namespace EventReceiver.Test.Entities
{
    [TestFixture]
    public class SensorEventTest
    {
        private Timestamp _timestamp;

        private Tag _tag;

        private Valor _valor;

        /// <summary>
        /// Initializes SensorEvent test objects
        /// </summary>
        /// 
        [SetUp]
        public void Setup()
        {
            _tag = new Tag("Brasil.Sudeste.Sensor01");

            _timestamp = new Timestamp("1598860800");

            _valor = new Valor("f12CHF");
        }

        /// <summary>
        /// Assert that SensorEvent is valid for a non-empty 'valor'
        /// </summary>
        /// 
        [Test]
        public void EventStatusProcessed()
        {
            var sensor = new SensorEvent(_timestamp, _tag, _valor);

            Assert.True(sensor.Valid);
        }

        /// <summary>
        /// Assert that SensorEvent is invalid for a empty 'valor'
        /// </summary>
        /// 
        [Test]
        public void EventStatusError()
        {
            var sensor = new SensorEvent(_timestamp, _tag, new Valor(""));

            Assert.AreEqual("Error", sensor.Status);
        }
    }
}