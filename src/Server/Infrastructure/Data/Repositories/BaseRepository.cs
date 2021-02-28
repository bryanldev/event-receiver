using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.SensorEventAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        protected BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected async Task Insert(TEntity obj)
        {
            _applicationDbContext.Set<TEntity>().Add(obj);
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}