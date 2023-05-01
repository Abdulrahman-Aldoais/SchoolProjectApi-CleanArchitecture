using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Impelmantation
{
    public class StudentService: IStudentService
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
        #endregion



    }
}
