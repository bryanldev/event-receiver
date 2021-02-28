using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.SensorEventAggregate
{
    public interface ISensorEventRepository
    {
        IQueryable<SensorEvent> GetAll();
        Task Save(SensorEvent sensorEvent);
    }
}