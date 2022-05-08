using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace S32X4L_HFT_2021221.WPFClient.ViewModel
{
    public class TeacherViewModel : ObservableObject
    {
        public RestCollection<Teacher> Teachers { get; set; }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher

        {
            get { return selectedTeacher; }
            set
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                        TeacherID = value.TeacherID,
                        Name = value.Name,
                        Age = value.Age,
                        HeldCourses = value.HeldCourses

                    };
                    SetProperty(ref selectedTeacher, value);
                    (DeleteTeacherCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        ITeacherSerivce teacherService;
        public ICommand DeleteTeacherCommand { get; set; }
        public ICommand CreateTeacherCommand { get; set; }
        public ICommand EditTeacherCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public TeacherViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<ITeacherSerivce>())
        {
        }
        public void CreateTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void UpdateTeacher(Teacher teacher)
        {
            Teachers.Update(teacher);
        }

        public void DeleteTeacher(int id)
        {
            Teachers.Delete(id);


        }
        public TeacherViewModel(ITeacherSerivce teacherSerivce)
        {

            if (!IsInDesignMode)
            {
                this.teacherService = teacherSerivce;

                Teachers = new RestCollection<Teacher>("http://localhost:6111/", "teacher","hub");

                DeleteTeacherCommand = new RelayCommand(() =>
                {
                    DeleteTeacher(SelectedTeacher.TeacherID);
                },
                () =>
                {
                    return SelectedTeacher != null;
                });

                CreateTeacherCommand = new RelayCommand(() =>
                {
                    Teachers.Add(new Teacher()
                    {
                        Name = SelectedTeacher.Name,
                        Age = SelectedTeacher.Age
                    });
                });

                EditTeacherCommand = new RelayCommand(
                    () => UpdateTeacher(SelectedTeacher),
                    () => SelectedTeacher != null
                    );

                SelectedTeacher = new Teacher();
            }
        }
    }
}
