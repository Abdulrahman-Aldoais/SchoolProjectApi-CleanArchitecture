using SchoolProject.Core.Features.Depatrment.Querise.Respons;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.DepartmentMapp
{
    public partial class DepartmentProfileMapping
    {
        public void GetDepartmentListMapping()
        {
            CreateMap<Department, GetDepartmentListRespons>();
        }
    }
}
