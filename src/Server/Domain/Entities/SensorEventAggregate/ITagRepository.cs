using System.Linq;

namespace Domain.Entities.SensorEventAggregate
{
    public interface ITagRepository
    {
        IQueryable<Tag> GetByRegion(string region);
    }
}