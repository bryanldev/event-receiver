using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.SensorEventAggregate;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ISensorEventRepository _sensorEventRespository;
        private readonly IMapper _mapper;

        public ApplicationService(ISensorEventRepository sensorEventRespository, IMapper mapper)
        {
            _sensorEventRespository = sensorEventRespository;
            _mapper = mapper;
        }

        public async Task<List<SensorEventResponseModel>> GetAllEvents()
        {
            var response = _sensorEventRespository.GetAll();
            return await response.ProjectTo<SensorEventResponseModel>(_mapper.ConfigurationProvider)
                                 .ToListAsync();
        }

        public async Task<SensorEventRequestModel> SaveEvent(SensorEventRequestModel sensorEventModel)
        {
            var sensorEvent = _mapper.Map<SensorEvent>(sensorEventModel);
            await _sensorEventRespository.Save(sensorEvent);

            return sensorEventModel;
        }

    }
}