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
        /// <summary>
        /// The Constructer for TeacherSelectViewModel
        /// </summary>
        public TeacherSelectViewModel()
        {
            Person = new TeacherSelectViewData();
            addTeachersToPersons();
        }

        /// <summary>
        /// add all teacher to the person list
        /// </summary>
        private void addTeachersToPersons()
        {
            using (TeacherContext tc = new TeacherContext())
            {
                List<Teacher> allTeachers = tc.GetAllTeachers();
                foreach (Teacher teacher in allTeachers)
                {
                    if (Person.Persons.Any(p => p.Id == teacher.Id))
                    {
                        if (SelectedPerson != null && SelectedPerson.Id == teacher.Id)
                        {
                            Person.Persons.Remove(SelectedPerson);
                        }
                        else
                        {
                            continue;
                        }
                    }
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
        }

        /// <summary>
        /// The proppetry EditTeacherCommand use to check if there are any teacher selected
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return SelectedPerson != null;
            }
        }

        /// <summary>
        /// Edit teacher command for open a new edit window
        /// </summary>
        public ActionCommand EditTeacherCommand
        {
            get
            {
                return new ActionCommand(p => EditTeacher((TeacherListItemViewData)SelectedPerson),  p => CanEdit);
            }
        }

        /// <summary>
        /// The methode EditTeacherCommand use to open a new edit window for the selected teacher
        /// </summary>
        /// <param name="teacher">The selected teacher</param>
        private void EditTeacher(TeacherListItemViewData teacher)
        {
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel(teacher);
            var editTeacher = new EditTeacher
            {
                DataContext = teacherEditViewModel
            };
            bool? didListChange = editTeacher.ShowDialog();

            if (didListChange == true)
            {
                addTeachersToPersons();
            }
        }

        /// <summary>
        /// Add teacher command for open a new edit window to add the teacher in
        /// </summary>
        public ActionCommand AddTeacherCommand
        {
            get
            {
                return new ActionCommand(p => AddTeacher());
            }
        }

        /// <summary>
        /// The methode AddTeacherCommand use to open a new edit to add the teacher in
        /// </summary>
        private void AddTeacher()
        {
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel();
            var editTeacher = new EditTeacher
            {
                DataContext = teacherEditViewModel
            };
            bool? didListChange = editTeacher.ShowDialog();

            if (didListChange == true)
            {
                addTeachersToPersons();
            }
        }
    }
}
