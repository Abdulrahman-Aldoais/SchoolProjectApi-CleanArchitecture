using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Impelmantation;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
       public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
             services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}