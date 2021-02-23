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
        private Mock<ITagRepository> _tagRepositoryMock;
        private Mapper _mapper;

        [SetUp]
        public void Setup()
        {
            // AutoMapper
            var profile = new SensorEventProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);

            // Data
            var data = new List<SensorEvent>()
            {
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.nordeste.sensor02"),new SensorData("p84h499")),
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.norte.sensor02"),new SensorData("")),
                new SensorEvent( new Timestamp("1439002021301"),new Tag("brasil.sul.sensor02"),new SensorData("pk55419"))
            }.AsQueryable().BuildMock();

            _mock = new();
            _mock.Setup(m => m.GetAll()).Returns(data.Object);

            var dataTagRepository = new List<Tag>()
            {
                new Tag("brasil.sul.sensor02"),
                new Tag("brasil.sul.sensor01"),
                new Tag("brasil.sul.sensor01"),
                new Tag("brasil.nordeste.sensor02"),
                new Tag("brasil.norte.sensor01"),
            }.AsQueryable().BuildMock();

            _tagRepositoryMock = new();
            _tagRepositoryMock.Setup(m => m.GetByRegion("sul")).Returns(dataTagRepository.Object.Where(x => x.Region == "sul"));
            _tagRepositoryMock.Setup(m => m.GetByRegion("nordeste")).Returns(dataTagRepository.Object.Where(x => x.Region == "nordeste"));
            _tagRepositoryMock.Setup(m => m.GetByRegion("norte")).Returns(dataTagRepository.Object.Where(x => x.Region == "norte"));
        }


        [Test]
        public async Task Can_Get_All_SensorEvents()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _tagRepositoryMock.Object, _mapper);

            // Act
            var result = await service.GetAllEvents();
            var processed = result.Where(x => x.Status == "Processed");
            var error = result.Where(x => x.Status == "Error");

            // Assert
            _mock.Verify(m => m.GetAll(), Times.AtLeastOnce());
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, processed.Count());
            Assert.AreEqual(1, error.Count());
        }

        [Test]
        public async Task Can_Save_New_Event()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _tagRepositoryMock.Object, _mapper);
            var target = new SensorEventRequestModel
            {
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

        [Test]
        public async Task Can_Calculate_Total_Events_By_Region()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _tagRepositoryMock.Object, _mapper);

            // Act
            var target = await service.GetTagEventByRegion("nordeste");

            // Assert
            Assert.AreEqual(target.Country, "brasil");
            Assert.AreEqual(target.Region, "nordeste");
            Assert.AreEqual(target.Total, 1);
        }

        [Test]
        public async Task Can_Calculate_Total_Events_By_SensorName()
        {
            // Arrange
            var service = new ApplicationService(_mock.Object, _tagRepositoryMock.Object, _mapper);

            // Act
            var target = await service.GetTagEventBySensorName("sul");
            var targetCountry = target.Where(x => x.Country == "brasil").Select(x => x.Country).First();
            var targetRegion = target.Where(x => x.Region == "sul").Select(x => x.Region).First();
            var targetSensorName = target.Where(x => x.SensorName == "sensor01").Select(x => x.Total).First();

            // Assert
            Assert.AreEqual(target.Count(), 2);
            Assert.AreEqual(targetCountry, "brasil");
            Assert.AreEqual(targetRegion, "sul");
            Assert.AreEqual(targetSensorName, 2);
        }
    }
}