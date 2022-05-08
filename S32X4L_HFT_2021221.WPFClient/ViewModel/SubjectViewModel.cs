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
    public class SubjectViewModel : ObservableObject
    {
        public RestCollection<Subjects> Subjects { get; set; }

        private Subjects selectedSubject;

        public Subjects SelectedSubject

        {
            get { return selectedSubject; }
            set
            {
                if (value != null)
                {
                    selectedSubject = new Subjects()
                    {
                        SubjectID = value.SubjectID,
                        Name = value.Name,
                        Credit = value.Credit,
                        SubjectCourses = value.SubjectCourses,

                    };
                    OnPropertyChanged();
                    (DeleteSubjectCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }
        ISubjectService subjectService;
        public ICommand DeleteSubjectCommand { get; set; }
        public ICommand CreateSubjectCommand { get; set; }
        public ICommand EditSubjectCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public SubjectViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<ISubjectService>())
        {
        }
        public void UpdateSubject(Subjects subject)
        {
            Subjects.Update(subject);
        }

        public void AddSubject(Subjects subject)
        {
            Subjects.Add(subject);
        }
        public void DeleteSubject(int id)
        {
            Subjects.Delete(id);


        }
        public SubjectViewModel(ISubjectService subjectService)
        {

            if (!IsInDesignMode)
            {
                this.subjectService = subjectService;

                Subjects = new RestCollection<Subjects>("http://localhost:6111/", "subjects","hub");

                DeleteSubjectCommand = new RelayCommand(() =>
                {
                    DeleteSubject(SelectedSubject.SubjectID);
                                    },
                () =>
                {
                    return SelectedSubject != null;
                });

                CreateSubjectCommand = new RelayCommand(() =>
                {
                    Subjects.Add(new Subjects()
                    {
                        Name = SelectedSubject.Name,
                        Credit = SelectedSubject.Credit,
                        
                    });
                });

                EditSubjectCommand = new RelayCommand(
                    () => UpdateSubject(SelectedSubject),
                    () => SelectedSubject != null
                    );

                SelectedSubject = new Subjects();
            }
        }
    }
}
