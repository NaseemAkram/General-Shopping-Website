using MyWebsite.Data;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models.Models;

namespace MyWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productdb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productdb != null)
            {
                productdb.Name = product.Name;
                productdb.Description = product.Description;
                productdb.Price = product.Price;
                if (product.ImageUrl != null)
                {
                    productdb.ImageUrl = product.ImageUrl;
                }
            }

        }
    }
}
