using MyWebsite.DataAccessLayer.Infrastructure.Repository;
using MyWebsite.Models;

namespace MyWebsite.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category category);

    }
}
