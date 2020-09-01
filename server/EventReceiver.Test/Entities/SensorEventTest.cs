using EventReceiver.Domain.Entities;
using EventReceiver.Domain.ValueTypes;
using NUnit.Framework;

namespace EventReceiver.Domain.Entities.Tests
{
    [TestFixture()]
    public class SensorEventTest
    {
        private Timestamp timestamp;

        private Tag tag;

        private Valor valor;

        /// <summary>
        /// Initializes SensorEvent test objects
        /// </summary>
        /// 
        [SetUp()]
        public void Setup()
        {
            tag = new Tag("Brasil.Sudeste.Sensor01");

            timestamp = new Timestamp("1598860800");

            valor = new Valor("f12CHF");
        }

        /// <summary>
        /// Assert that SensorEvent is valid for a non-empty 'valor'
        /// </summary>
        /// 
        [Test()]
        public void EventStatusProcessed()
        {
            var S = new SensorEvent(timestamp, tag, valor);

            Assert.AreEqual(true, S.Valid);
        }

        /// <summary>
        /// Assert that SensorEvent is invalid for a empty 'valor'
        /// </summary>
        /// 
        [Test()]
        public void EventStatusError()
        {
            var S = new SensorEvent(timestamp, tag, new Valor(""));

            Assert.AreEqual(true, S.Invalid);
        }
    }
}