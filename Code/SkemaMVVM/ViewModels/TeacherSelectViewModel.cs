using Models;
using Services;
using Views;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class TeacherSelectViewModel : PersonSelectViewModel
    {
        private TeacherContext tc;
        public TeacherSelectViewModel()
        {
            tc = new TeacherContext();
            Person = new TeacherSelectViewData();
            addTeachersToPersons();
        }

        private void addTeachersToPersons()
        {
            List<Teacher> allTeachers = tc.GetAllTeachers();
            foreach (Teacher teacher in allTeachers)
            {
                ObservableCollection<Subject> teachersSubjects = new ObservableCollection<Subject>();
                foreach (var item in teacher.Subjects)
                {
                    teachersSubjects.Add(item);
                }
                ObservableCollection<Class> teachersClasses = new ObservableCollection<Class>();
                foreach (var item in teacher.Classes)
                {
                    teachersClasses.Add(item);
                }
                Person.Persons.Add(new TeacherListItemViewData()
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Address = teacher.Address,
                    City = teacher.City,
                    SocialSecurityNumber = teacher.SocialSecurityNumber,
                    ZipCode = teacher.ZipCode,
                    Subjects = teachersSubjects,
                    Classes = teachersClasses
                });
            }
        }

        public bool CanEdit
        {
            get
            {
                return SelectedPerson != null;
            }
        }

        public ActionCommand EditTeacherCommand
        {
            get
            {
                return new ActionCommand(p => EditTeacher((TeacherListItemViewData)SelectedPerson),  p => CanEdit);
            }
        }

        private void EditTeacher(TeacherListItemViewData teacher)
        {
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel(teacher);
            var editTeacher = new EditTeacher
            {
                DataContext = teacherEditViewModel
            };
            editTeacher.ShowDialog();
        }
        public ActionCommand AddTeacherCommand
        {
            get
            {
                return new ActionCommand(p => AddTeacher());
            }
        }
        private void AddTeacher()
        {
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel();
            var editTeacher = new EditTeacher
            {
                DataContext = teacherEditViewModel
            };
            editTeacher.ShowDialog();
        }
    }
}
