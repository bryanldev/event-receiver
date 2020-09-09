using System.Linq;
using EventReceiver.Domain.Entities;
using NUnit.Framework;

namespace EventReceiver.Test.ValueTypes
{
    [TestFixture]
    public class TagTest
    {
        /// <summary>
        /// Assert that Tag is valid for this string format
        /// </summary>
        /// 
        [Test]
        public void TagIsValid()
        {
            // Arrange
            var tag = new Tag("Brasil.Sudeste.Sensor01");

            // Assert
            Assert.True(tag.Valid);
        }

        [Test]
        public void TagIsInvalid1()
        {
            // Arrange
            var tag = new Tag("Brasil.Sudeste.Sensor01.Radix");

            // Assert
            Assert.True(tag.Invalid);
            Assert.AreEqual("Unexpected tag format.", tag.Notifications.Single().Message);
        }


        [Test]
        public void TagIsInvalid2()
        {
            // Arrange
            var tag = new Tag("Brasil.Sudeste");

            // Assert
            Assert.True(tag.Invalid);
            Assert.AreEqual("Unexpected tag format.", tag.Notifications.Single().Message);
        }

        [Test]
        public void TagIsInvalid3()
        {
            // Arrange
            var tag = new Tag("Brasil");

            // Assert
            Assert.True(tag.Invalid);
            Assert.AreEqual("Unexpected tag format.", tag.Notifications.Single().Message);
        }

        [Test]
        public void EmptyArgumentTagTest()
        {
            // Arrange
            var tag = new Tag("");

            // Assert
            Assert.True(tag.Invalid);
            Assert.AreEqual("Tag should not be empty.", tag.Notifications.Single().Message);
        }

        [Test]
        public void NullArgumentTagTest()
        {
            // Arrange
            var tag = new Tag(null);

            // Assert
            Assert.True(tag.Invalid);
            Assert.AreEqual("Tag should not be empty.", tag.Notifications.Single().Message);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var tag = new Tag("Brasil.Norte.Sensor02");

            // Assert
            Assert.That(tag.ToString, Is.EqualTo("Brasil.Norte.Sensor02"));
        }
    }
}