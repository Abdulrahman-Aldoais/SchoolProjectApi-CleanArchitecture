using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructuerBase;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        //public ApplicationDbContext _context { get; }
        //بسبب اننا مستخدمين ApplicationDbContext في نفس  GenericRepositoryAsync ولهذا استخدمنا 
        // private readonly DbSet<Student> _student; => _context.Students. 

        private readonly DbSet<Student> _studentRepository;

        #endregion

        #region Constructors
        public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _studentRepository = context.Set<Student>();

        }

        #endregion

        #region Handles Function
        public IQueryable<Student> GetStudentsListAsync()
        {

            return _studentRepository.Include(dep => dep.Department).AsQueryable();
        }
        #endregion




    }
}
