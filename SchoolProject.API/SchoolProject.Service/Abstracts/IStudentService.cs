using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsLsitAsync();
        public Task<Student> GetStudentByIdWithIncludAsync(Guid id);
        public Task<Student> GetByIdAsync(Guid id);
        public Task<string> AddStudentAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, Guid id);
        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
        public IQueryable<Student> GetStudentQueryable();
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderByEnum orderByEnum, string serch);
    }
}
