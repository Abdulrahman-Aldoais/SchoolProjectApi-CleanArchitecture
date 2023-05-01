using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Impelmantation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection Service)
        {   // Configuration of mediator
            // The service will be fully operational at the application level or DLL Files
            Service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //Configuration Of AutoMaper
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}
