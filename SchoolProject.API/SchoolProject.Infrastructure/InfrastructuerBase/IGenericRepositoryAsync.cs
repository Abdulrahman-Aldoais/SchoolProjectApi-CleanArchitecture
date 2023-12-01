using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolProject.Infrastructure.InfrastructuerBase
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        //TDTO MapEntityToDTOs<TEntity, TDTO>(TEntity entity);
        //TEntity MapDTOsToEntity<TDTO, TEntity>(TDTO tdto);
        Task<IQueryable<T>> GetStudentDynamicWithOdata(ODataQueryOptions<T> options);
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }


}
