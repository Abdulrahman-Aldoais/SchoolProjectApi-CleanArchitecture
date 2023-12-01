using AutoMapper;
using AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Infrastructure.InfrastructuerBase
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        #region Vars / Props
        //private readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor(s)
        public GenericRepositoryAsync(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        #endregion


        #region Methods

        #endregion

        #region Actions
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }


        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }



        public IDbContextTransaction BeginTransaction()
        {


            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();

        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>().AsQueryable();

        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IQueryable<T>> GetStudentDynamicWithOdata(ODataQueryOptions<T> options)
        {
            var query = await _dbContext.Set<T>().GetQueryAsync(_mapper, options, null);
            return query;
        }

        //public TDTO MapEntityToDTOs<TEntity, TDTO>(TEntity entity)
        //{

        //    return _mapper.Map<TEntity, TDTO>(entity);
        //}

        //public TEntity MapDTOsToEntity<TDTO, TEntity>(TDTO tdto)
        //{
        //    return _mapper.Map<TDTO, TEntity>(tdto);
        //}

        #endregion
    }
}
