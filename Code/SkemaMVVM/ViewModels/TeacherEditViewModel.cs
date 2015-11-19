using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Models;
using Views;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class TeacherEditViewModel : PersonEditViewModel
    {
        private ICollection<Subject> subjectList;

        private ObservableCollection<ComboboxItemViewModel> subjectComboboxItem = new ObservableCollection<ComboboxItemViewModel>();
        public ObservableCollection<ComboboxItemViewModel> SubjectComboboxItem
        {
            get
            {
                return subjectComboboxItem;
            }
            set
            {
                subjectComboboxItem = value;
                OnPropertyChanged();
            }
        }

        public TeacherEditViewModel() : base(new TeacherListItemViewData())
        {
            addSubjectsToList();
        }

        public TeacherEditViewModel(TeacherListItemViewData teacherData) : base(teacherData)
        {
            addSubjectsToList();
        }

        private void addSubjectsToList()
        {
            SubjectContext sc = new SubjectContext();
            subjectList = sc.GetAllSubjects();

            foreach (Subject item in subjectList)
            {
                SubjectComboboxItem.Add(new ComboboxItemViewModel
                {
                    IsSelected = (PersonData as TeacherListItemViewData).Subjects.Any(f => f.Name == item.Name),
                    Name = item.Name
                });
            }
        }
        
        #region Commands

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
            ICollection<Subject> teacherSubjects = new ObservableCollection<Subject>();

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
            foreach (ComboboxItemViewModel item in subjectComboboxItem)
            {
                if (item.IsSelected)
                {
                    teacherModel.Subjects.Add((Subject)subjectList.Where(f => f.Name == item.Name).FirstOrDefault());
                }
            }

            
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
                return new ActionCommand(p => Cansel(p));
            }
        }

        private void Cansel(object sender)
        {
            EditTeacher et = (EditTeacher)sender;
            et.DialogResult = false;
            et.Close();
        }

        #endregion
    }
}
