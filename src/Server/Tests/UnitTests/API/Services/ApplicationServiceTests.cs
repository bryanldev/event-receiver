using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Profiles;
using API.Services;
using AutoMapper;
using Domain.Entities.SensorEventAggregate;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;

namespace Tests.UnitTests.API.Controllers
{
    public class ApplicationServiceTests
    {
        private Mock<ISensorEventRepository> _mock;
        private Mapper _mapper;

        [SetUp]
        public void Setup()
        {
            // AutoMapper
            var profile = new SensorEventProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);

            // Data
            var data = new List<SensorEvent>() {
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.nordeste.sensor02"),new SensorData("p84h499")),
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.norte.sensor02"),new SensorData("")),
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.sul.sensor02"),new SensorData("pk55419"))
            }.AsQueryable().BuildMock();

            _mock = new();
            _mock.Setup(m => m.GetAll()).Returns(data.Object);
        }


        [Test]
        public async Task Can_Get_All_SensorEvents()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _mapper);

            // Act
            var result = await service.GetAllEvents();
            var processed = result.Where(x => x.Status == "Processed");
            var error = result.Where(x => x.Status == "Error");

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, processed.Count());
            Assert.AreEqual(1, error.Count());
        }

        [Test]
        public async Task Can_Save_New_Event()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _mapper);
            var target = new SensorEventRequestModel {
                Data = "",
                Tag = "brasil.norte.sensor02",
                Timestamp = "1631002021301"
            };

            // Act
            var result = await service.SaveEvent(target);
            var allEvents = await service.GetAllEvents();

            // Assert
            Assert.AreEqual(target, result);
        }

    }
}