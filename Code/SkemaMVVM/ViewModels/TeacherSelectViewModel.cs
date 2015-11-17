using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ViewModels
{
    public class TeacherSelectViewModel : PersonSelectViewModel
    {
        private TeacherContext tc;
        public TeacherSelectViewModel()
        {
            tc = new TeacherContext();
            Person = new TeacherSelectViewData();
            tc.AddNewTeacher(new Teacher()
            {
                FirstName = "Ola",
                LastName = "IDontKnow",
                City = "Viborg",
                ZipCode = 7000,
                SocialSecurityNumber = 1205601934
            });
            addTeachersToPersons();
        }

        private void addTeachersToPersons()
        {
            List<Teacher> allTeachers = tc.GetAllTeachers();
            foreach (Teacher teacher in allTeachers)
            {
                Person.Persons.Add(new PersonListItemViewData()
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName
                });
            }
        }

        public bool CanEdit
        {
            get
            {
                return true;
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
            //Open edit Window
        }
    }
}
