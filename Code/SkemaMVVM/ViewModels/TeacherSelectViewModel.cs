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
        public TeacherSelectViewModel()
        {
            Person = new TeacherSelectViewData();
        }

        private void addPersonsToPersons()
        {
            TeacherContext tc = new TeacherContext();
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
                return new ActionCommand(p => EditTeacher(),  p => CanEdit);
            }
        }

        private void EditTeacher()
        {
            
        }
    }
}
