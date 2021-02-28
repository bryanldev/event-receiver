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
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public ApplicationService(ISensorEventRepository sensorEventRespository, ITagRepository tagRepository, IMapper mapper)
        {
            _sensorEventRespository = sensorEventRespository;
            _mapper = mapper;
            _tagRepository = tagRepository;
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

        public async Task<TagResponseByRegionModel> GetTagEventByRegion(string region)
        {
            IQueryable<Tag> query = _tagRepository.GetByRegion(region);

            return await query
                            .GroupBy(x => new { x.Country, x.Region },
                            (x, y) => new TagResponseByRegionModel
                            {
                                Region = x.Region,
                                Country = x.Country,
                                Total = y.Count()
                            })
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TagResponseBySensorNameModel>> GetTagEventBySensorName(string region)
        {
            IQueryable<Tag> query = _tagRepository.GetByRegion(region);

            return await query
                            .GroupBy(x => new { x.Country, x.Region, x.SensorName },
                            (x, y) => new TagResponseBySensorNameModel
                            {
                                Region = x.Region,
                                Country = x.Country,
                                SensorName = x.SensorName,
                                Total = y.Count()
                            })
                            .ToListAsync();
        }


    }
}