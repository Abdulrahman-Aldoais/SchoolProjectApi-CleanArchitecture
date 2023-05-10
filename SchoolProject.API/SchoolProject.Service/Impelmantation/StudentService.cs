using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Impelmantation
{
    public class StudentService : IStudentService
    {
        #region Fields
        public IStudentRepository _studentRepository { get; }

        #endregion

        #region Constractors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Handel Functions
        public async Task<List<Student>> GetStudentsLsitAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentByIdWithIncludAsync(int id)
        {
            //var student = await _studentRepository.GetByIdAsync(id);//with out Include 
            var student = await _studentRepository.GetTableNoTracking()
                .Include(d => d.Department)
                .Where(x => x.StudID == id)
                .FirstOrDefaultAsync();
            return student;

        }

        public async Task<string> AddStudentAsync(Student student)
        {
            // Add Student
            await _studentRepository.AddAsync(student);
            return "Success";

        }
        // Name verification in database
        public async Task<bool> IsNameExist(string name)
        {
            // check if the name is Exist or not
            var studentResult = await _studentRepository.GetTableNoTracking().Where(n => n.Name.Equals(name)).FirstOrDefaultAsync();
            if (studentResult == null) return false;
            return true;
        }
        // Check the name to be amended in the database
        // that does not have the same ID of the student that we want to modify
        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            //check if the name is Exist or not
            var studentResult = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (studentResult == null) return false;
            return true;
        }
        // Edit Student
        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            // This function implements all codes within the "try"
            // in the event that any part fails to do the previously retreat work
            var tern = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await tern.CommitAsync();
                return "Success";
            }
            catch
            {
                await tern.RollbackAsync();
                return "failed !!!";
                //throw;
            }


        }

        public async Task<Student> GetByIdAsync(int id)
        {
            //var student = await _studentRepository.GetByIdAsync(id);//with out Include 
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }
        #endregion



    }
}
