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
    public class SubjectSelectViewModel : BaseViewModel
    {
        public bool autoAddDone = false;

        public SubjectSelectViewModel()
        {
            addSubjects();
        }

        private void addSubjects()
        {
            using (SubjectContext sc = new SubjectContext())
            {
                List<Subject> allSubjects = sc.GetAllSubjects();
                foreach (Subject subject in allSubjects)
                {
                    if (Subject.Persons.Any(p => p.Id == teacher.Id))
                    {
                        continue;
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

        public bool CanEdit
        {
            get
            {
                return autoAddDone;
            }
        }

        public ActionCommand AutoAddCommand
        {
            get
            {
                return new ActionCommand(p => AutoAddSubjects(),  p => CanEdit);
            }
        }

        private void AutoAddSubjects()
        {
            Subject dansk = new Subject() { Name = "Dansk" };
            Subject engelsk = new Subject() { Name = "Engelsk" };
            Subject matematik = new Subject() { Name = "Matematik" };
            Subject biologi = new Subject() { Name = "Biologi" };

            using (SubjectContext sc = new SubjectContext())
            {
                sc.AddNewSubject(dansk);
                sc.AddNewSubject(engelsk);
                sc.AddNewSubject(matematik);
                sc.AddNewSubject(biologi);
            }
            autoAddDone = true;
        }
    }
}
