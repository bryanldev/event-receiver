using System.Linq;
using Domain.Entities.SensorEventAggregate;

namespace Infrastructure.Data.Repositories
{
    public class TagRepository : BaseRepository<Tag, int>, ITagRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TagRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<Tag> GetByRegion(string region)
        {
            return _applicationDbContext.Tag
                .Where(x => x.Region == region);
        }
    }
}