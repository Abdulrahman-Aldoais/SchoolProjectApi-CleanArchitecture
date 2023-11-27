using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructuerBase;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
        public Task<List<Department>> GetDepartmentListAsync();

    }
}
