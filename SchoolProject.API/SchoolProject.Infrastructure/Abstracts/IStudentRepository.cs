using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructuerBase;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public IQueryable<Student> GetStudentsListAsync();

    }
}
