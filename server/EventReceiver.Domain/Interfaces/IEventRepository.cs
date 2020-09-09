using System.Collections.Generic;
using EventReceiver.Domain.Models;

namespace EventReceiver.Domain.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<SensorEventResponseModel> GetAll();
        object Insert(SensorEventModel sensorEvent);
        TagRegionResponseModel CountByRegion(string region);
        IEnumerable<TagSensorNameResponseModel> CountBySensorName(string sensorName);
    }
}