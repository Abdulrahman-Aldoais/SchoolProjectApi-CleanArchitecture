using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SchoolProject.Core;
using SchoolProject.Core.Features.Students.Querise.Respons;
using SchoolProject.Core.Middleware;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Service;

internal class Program
{
    private static void Main(string[] args)
    {



        var builder = WebApplication.CreateBuilder(args);
        #region Add services to the container.

        builder.Services.AddControllers().AddOData(options =>
        {
            options.Select().Expand().Filter().OrderBy().SetMaxTop(null).Count();
            options.AddRouteComponents("api", GetEdmModel());
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion

        #region Connection SQL
        builder.Services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
        });
        #endregion

        #region Dependiency Injections
        builder.Services.AddInfrastructureDependencies()
                        .AddServiceDependencies()
                        .AddCoreDependencies();
        #endregion


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolProject.API v1");
            });
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<GetStudentListRespons>("GetStudentListRespons");
            return builder.GetEdmModel();
        }

    }
}