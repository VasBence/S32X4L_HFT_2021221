using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace S32X4L_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IStudentsLogic, StudentsLogic>()
                    .AddSingleton<ITeacherLogic, TeacherLogic>()
                    .AddSingleton<ISubjectsLogic, SubjectsLogic>()
                    .AddSingleton<IStudentService, StudentService>()
                    .AddSingleton<ISubjectService, SubjectService>()
                    .AddSingleton<ITeacherSerivce, TeacherSerivce>()                  
                    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    .BuildServiceProvider()
                );
        }
    }
}
