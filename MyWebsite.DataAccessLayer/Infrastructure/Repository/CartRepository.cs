using MyWebsite.Data;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models.Models;

namespace MyWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
