using Domain.Entities.SensorEventAggregate;
using NUnit.Framework;

namespace Tests.UnitTests.Domain.SensorEventAgregateTestes
{
    public class SensorEventTest
    {
        private Timestamp _timestamp;

        private Tag _tag;

        private SensorData _data;

        /// <summary>
        /// Initializes SensorEvent test objects
        /// </summary>
        /// 
        [SetUp]
        public void Setup()
        {
            _tag = new Tag("Brasil.Sudeste.Sensor01");

            _timestamp = new Timestamp("1598860800");

            _data = new SensorData("f12CHF");
        }

        /// <summary>
        /// Assert that SensorEvent is valid for a non-empty 'valor'
        /// </summary>
        /// 
        [Test]
        public void EventStatusProcessed()
        {
            var sensor = new SensorEvent(_timestamp, _tag, _data);

            Assert.True(sensor.Valid);
        }

        /// <summary>
        /// Assert that SensorEvent is invalid for a empty 'valor'
        /// </summary>
        /// 
        [Test]
        public void EventStatusError()
        {
            var sensor = new SensorEvent(_timestamp, _tag, new SensorData(""));

            Assert.AreEqual("Error", sensor.Status);
        }
    }
}