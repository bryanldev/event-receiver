
using System.Collections.Generic;
using EventReceiver.Domain.Entities;
using EventReceiver.Domain.Interfaces;
using EventReceiver.Domain.Models;
using EventReceiver.Infra.Data.Context;
using EventReceiver.Infra.Shared.Mapper;

namespace EventReceiver.Infra.Data.Repository
{
    public class EventRepository : BaseRepository<SensorEvent, int>, IEventRepository
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public object Insert(SensorEventModel obj)
        {
            var sensorEvent = obj.ConvertToEvent();

            if (sensorEvent.Invalid)
                return sensorEvent.Notifications;
            
            base.Insert(sensorEvent);
            return obj;
        }

        public IEnumerable<SensorEventResponseModel> GetAll()
        {
            var sensorEvents = base.Select();

            return sensorEvents.ConvertToEvents();
        }

        public TagRegionResponseModel CountByRegion(string region)
        {
            var byRegion = base.GetByRegion(region);

            return byRegion;
        }

        public IEnumerable<TagSensorNameResponseModel> CountBySensorName(string region)
        {
            var bySensorName = base.GetBySensorName(region);

            return bySensorName;
        }
    }
}