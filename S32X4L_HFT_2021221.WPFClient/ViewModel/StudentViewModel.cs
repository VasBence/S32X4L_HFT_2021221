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
    public class StudentViewModel : ObservableObject
    {
        public RestCollection<Students> Students { get; set; }

        private Students selectedStudent;

        public Students SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (value != null)
                {
                    selectedStudent = new Students()
                    {
                        NeptunCode = value.NeptunCode,
                        Name = value.Name,
                        Age = value.Age,
                        AcquiredCredtis = value.AcquiredCredtis,
                        JoinedCourse = value.JoinedCourse,
                        JoinedCourseID = value.JoinedCourseID,

                    };
                    SetProperty(ref selectedStudent, value);
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        IStudentService studentService;
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand CreateStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public StudentViewModel(): this(IsInDesignMode ? null : Ioc.Default.GetService<IStudentService>())       
        {
        }
        public void UpdateStudent(Students student)
        {
            Students.Update(student);
        }

        public void AddStudent(Students student)
        {
            Students.Add(student);
        }
        public void DeleteStudent(string id)
        {
            Students.Delete(id);
        
        
        }
            public StudentViewModel(IStudentService studentService)
            {
            
            if (!IsInDesignMode)
            {
                this.studentService = studentService;
            
                Students = new RestCollection<Students>("http://localhost:6111/", "students","hub");

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    DeleteStudent(SelectedStudent.NeptunCode);
                },
                () =>
                {
                    return SelectedStudent != null;
                });

                CreateStudentCommand = new RelayCommand(() =>
                {
                    Students.Add(new Students()
                    {
                        Name = selectedStudent.Name,
                        Age = selectedStudent.Age,
                        NeptunCode = selectedStudent.NeptunCode,
                        AcquiredCredtis = selectedStudent.AcquiredCredtis,
                        JoinedCourseID = selectedStudent.JoinedCourseID
                    });
                });

                EditStudentCommand = new RelayCommand(
                    () => UpdateStudent(SelectedStudent),
                    () =>SelectedStudent!= null
                    );

                SelectedStudent = new Students();
            }
        }

    }
}
