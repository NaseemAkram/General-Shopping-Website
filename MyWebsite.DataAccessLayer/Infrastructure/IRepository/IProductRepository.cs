using MyWebsite.DataAccessLayer.Infrastructure.Repository;
using MyWebsite.Models.Models;

namespace MyWebsite.DataAccessLayer.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
