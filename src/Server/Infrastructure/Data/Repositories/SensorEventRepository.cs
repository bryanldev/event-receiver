using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.SensorEventAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SensorEventRepository : BaseRepository<SensorEvent, int>, ISensorEventRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SensorEventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<SensorEvent> GetAll() =>
             _applicationDbContext.SensorEvent
                .Include(prop => prop.Tag)
                .AsNoTracking();

        public async Task Save(SensorEvent sensorEvent)
        {
            await base.Insert(sensorEvent);
        }
    }
}