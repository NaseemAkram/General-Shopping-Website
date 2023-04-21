using System.Linq.Expressions;

namespace MyWebsite.DataAccessLayer.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeproperties = null);

        T GetT(Expression<Func<T, bool>> predicate, string? includeproperties = null);

        void Add(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entity);
    }
}
