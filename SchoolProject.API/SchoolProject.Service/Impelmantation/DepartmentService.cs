using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Impelmantation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        public IDepartmentRepository _departmentRepository { get; }

        #endregion

        #region Constractors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion

        public async Task<List<Department>> GetDepartmentLsitAsync()
        {
            return await _departmentRepository.GetDepartmentListAsync();
        }
    }
}
