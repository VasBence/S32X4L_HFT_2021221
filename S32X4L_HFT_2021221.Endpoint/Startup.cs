using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Endpoint.Services;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Repository;

namespace S32X4L_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<UniDbContext, UniDbContext>();
            services.AddTransient<ICoursesLogic, CoursesLogic>();
            services.AddTransient<IStudentsLogic, StudentsLogic>();
            services.AddTransient<ISubjectsLogic, SubjectsLogic>();
            services.AddTransient<ITeacherLogic, TeacherLogic>();

            services.AddTransient<ICoursesRepository, CoursesRepository>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<ISubjectsRepository, SubjectsRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddSignalR();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:42827"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
