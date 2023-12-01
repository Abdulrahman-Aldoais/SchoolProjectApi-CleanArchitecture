using SchoolProject.Infrastructure.Conste;
using System.Linq.Expressions;

namespace SchoolProject.Infrastructure.InfrastructuerBase
{
    public interface IMainEentityRepository<T> where T : class
    {


        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] includes = null, bool tracked = true);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, int? skip, int? take, string[] includes = null,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entities);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> filter);

    }
}
