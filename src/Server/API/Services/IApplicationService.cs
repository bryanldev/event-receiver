using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IApplicationService
    {
        Task<List<SensorEventResponseModel>> GetAllEvents();
        Task<SensorEventRequestModel> SaveEvent(SensorEventRequestModel sensorEventModel);
    }
}