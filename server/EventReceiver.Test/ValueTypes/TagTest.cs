using NUnit.Framework;
using EventReceiver.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReceiver.Domain.ValueTypes.Tests
{
    [TestFixture()]
    public class TagTest
    {
        /// <summary>
        /// Assert that Tag is valid for this string format
        /// </summary>
        /// 
        [Test()]
        public void TagIsValid()
        {
            var tag = new Tag("Brasil.Sudeste.Sensor01");
            Assert.AreEqual(true, tag.Valid);
        }

        [Test()]
        public void TagIsInvalid1()
        {
            var tag = new Tag("Brasil.Sudeste.Sensor01.Radix");
            Assert.AreEqual(true, tag.Invalid);
        }


        [Test()]
        public void TagIsInvalid2()
        {
            var tag = new Tag("Brasil.Sudeste");
            Assert.AreEqual(true, tag.Invalid);
        }

        [Test()]
        public void TagIsInvalid3()
        {
            var tag = new Tag("Brasil");
            Assert.AreEqual(true, tag.Invalid);
        }

        [Test()]
        public void EmptyArgumentTagTest()
        {
            var tag = new Tag("");
            Assert.AreEqual(true, tag.Invalid);
        }

        [Test()]
        public void NullArgumentTagTest()
        {
            Assert.That(()=> new Tag(null), Throws.ArgumentNullException);
        }

        [Test()]
        public void ToStringTest()
        {
            var tag = new Tag("Brasil.Norte.Sensor02");
            Assert.That(tag.ToString, Is.EqualTo("Brasil.Norte.Sensor02"));
        }
    }
}