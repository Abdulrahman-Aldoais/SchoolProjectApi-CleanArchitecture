using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructuerBase;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _departmentRepository;


        #region Constructors

        public DepartmentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _departmentRepository = context.Set<Department>();
        }
        #endregion
        public async Task<List<Department>> GetDepartmentListAsync()
        {
            return await _departmentRepository.ToListAsync();
        }



    }
}
