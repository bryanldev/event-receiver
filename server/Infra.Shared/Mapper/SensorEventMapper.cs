using System.Collections.Generic;
using System.Linq;
using EventReceiver.Domain.Entities;
using EventReceiver.Domain.Models;
using EventReceiver.Domain.ValueTypes;

namespace EventReceiver.Infra.Shared.Mapper
{
    public static class SensorEventMapper
    {
        public static SensorEvent ConvertToEvent(this SensorEventModel eventModel)
        {
            var timestamp = new Timestamp(eventModel.Timestamp);
            var tag = new Tag(eventModel.Tag);
            var valor = new Valor(eventModel.Valor);
            
            return new SensorEvent(timestamp, tag, valor);
        }

        public static IEnumerable<SensorEventResponseModel> ConvertToEvents(this IEnumerable<SensorEvent> sensorEvent) =>
            new List<SensorEventResponseModel>(sensorEvent.Select(s => 
                new SensorEventResponseModel(s.Timestamp.Time, s.Tag.ToString(), s.Valor.Value, s.Status)));

    }
}