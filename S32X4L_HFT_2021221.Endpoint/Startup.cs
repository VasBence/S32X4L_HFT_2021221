using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Repository;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Data;

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
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
