using MyWebsite.Data;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models;
using MyWebsite.Models.Models;

namespace MyWebsite.DataAccessLayer.Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryDb != null)
            {
                categoryDb.Name = category.Name;
                categoryDb.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
