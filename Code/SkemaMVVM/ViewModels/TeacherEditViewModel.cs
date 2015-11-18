using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Models;
using Views;

namespace ViewModels
{
    public class TeacherEditViewModel : PersonEditViewModel
    {
        public TeacherEditViewModel() : base(new TeacherListItemViewData())
        {

        }

        public TeacherEditViewModel(TeacherListItemViewData teacherData) : base(teacherData)
        {

        }
        
        public ActionCommand SaveTeacherCommand
        {
            get
            {
                return new ActionCommand(p => SaveTeacher(p), p => CanSave);
            }
        }

        private void SaveTeacher(object sender)
        {
            TeacherListItemViewData teacherData = (TeacherListItemViewData)PersonData;
            TeacherContext tc = new TeacherContext();
            bool isSaved = false;
            EditTeacher et = (EditTeacher)sender;

            Teacher teacherModel = new Teacher
            {
                Id = teacherData.Id,
                SocialSecurityNumber = teacherData.SocialSecurityNumber,
                FirstName = teacherData.FirstName,
                LastName = teacherData.LastName,
                Address = teacherData.Address,
                City = teacherData.City,
                ZipCode = teacherData.ZipCode
            };
            if (isEdit)
            {
                isSaved = tc.EditTeacher(teacherModel);
            }
            else
            {
                isSaved = tc.AddNewTeacher(teacherModel);
            }
            if (isSaved)
            {
                et.DialogResult = true;
                et.Close();
            }
            ErrorMsg = "Teacher did not work";
        }

        public ActionCommand CanselCommand
        {
            get
            {
                return new ActionCommand(p => Cansel(p), p => CanSave);
            }
        }

        private void Cansel(object sender)
        {
            EditTeacher et = (EditTeacher)sender;
            et.DialogResult = false;
            et.Close();
        }
        
    }
}
