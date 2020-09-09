using System.Collections.Generic;
using System.Linq;
using EventReceiver.Domain.Entities;
using EventReceiver.Domain.Models;
using EventReceiver.Infra.Data.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EventReceiver.Infra.Data.Repository
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        private readonly ApplicationDbContext _applicationDbContext;


        protected BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected void Insert(TEntity obj)
        {
            _applicationDbContext.Set<TEntity>().Add(obj);
            _applicationDbContext.SaveChanges();
        }

        protected IEnumerable<SensorEvent> Select() =>
            _applicationDbContext.SensorEvent
                .Include(prop => prop.Tag)
                .ToList();

        protected TagRegionResponseModel GetByRegion(string region)
        {
            var parameter = new SqliteParameter("@region", region);

           return _applicationDbContext.TagRegionResponseModel
                    .FromSqlRaw(
                        $"SELECT Country, Region, COUNT(*) as Total " +
                        $"FROM Tag " +
                        $"WHERE Region = @region " +
                        $"GROUP BY Country, Region", parameter
                    ).FirstOrDefault();
        }


        protected IEnumerable<TagSensorNameResponseModel> GetBySensorName(string region)
        {
            var parameter = new SqliteParameter("@region", region);
            
            return _applicationDbContext.TagSensorNameResponseModel
                    .FromSqlRaw(
                        $"SELECT Country, Region, SensorName, COUNT(*) as Total " +
                        $"from Tag " +
                        $"WHERE Region = @region " +
                        $"GROUP BY Country, Region, SensorName", parameter
                    ).ToList();
        }

    }
}