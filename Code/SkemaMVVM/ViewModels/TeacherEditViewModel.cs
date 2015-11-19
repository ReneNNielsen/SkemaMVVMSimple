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
        private ICollection<Class> classList;

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

        private ObservableCollection<ComboboxItemViewModel> classComboboxItem = new ObservableCollection<ComboboxItemViewModel>();
        public ObservableCollection<ComboboxItemViewModel> ClassComboboxItem
        {
            get
            {
                return classComboboxItem;
            }
            set
            {
                classComboboxItem = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructer for TeacherEditViewModel
        /// </summary>
        public TeacherEditViewModel() : base(new TeacherListItemViewData())
        {
            addSubjectsToList();
            addClassesToList();
        }

        /// <summary>
        /// Constructer for TeacherEditViewModel
        /// </summary>
        /// <param name="teacherData">The TeacherListItemViewData to Edit</param>
        public TeacherEditViewModel(TeacherListItemViewData teacherData) : base(teacherData)
        {
            addSubjectsToList();
            addClassesToList();
        }

        /// <summary>
        /// Add Subjects to SubjectComboboxItem and to subjectList
        /// </summary>
        private void addSubjectsToList()
        {
            using (SubjectContext sc = new SubjectContext())
            { 
                subjectList = sc.GetAllSubjects();
            }
            foreach (Subject item in subjectList)
            {
                SubjectComboboxItem.Add(new ComboboxItemViewModel
                {
                    IsSelected = (PersonData as TeacherListItemViewData).Subjects.Any(f => f.Id == item.Id),
                    Name = item.Name,
                    Id = item.Id
                });
            }
        }

        /// <summary>
        /// Add Classes to ClassComboboxItem and to ClassList
        /// </summary>
        private void addClassesToList()
        {
            using (ClassContext cc = new ClassContext())
            { 
                classList = cc.GetAllClasses();
            }
            foreach (Class item in classList)
            {
                ClassComboboxItem.Add(new ComboboxItemViewModel
                {
                    IsSelected = (PersonData as TeacherListItemViewData).Classes.Any(f => f.Id == item.Id),
                    Name = item.Name,
                    Id = item.Id
                });
            }
        }

        #region Commands

        /// <summary>
        /// The Command for save a teacher
        /// </summary>
        public ActionCommand SaveTeacherCommand
        {
            get
            {
                return new ActionCommand(p => SaveTeacher((EditTeacher)p), p => CanSave);
            }
        }

        /// <summary>
        /// The method the command use to save a Teacher
        /// </summary>
        /// <param name="sender">The EditTeacher window</param>
        private void SaveTeacher(EditTeacher sender)
        {
            TeacherListItemViewData teacherData = (TeacherListItemViewData)PersonData;
                            bool isSaved = false;
            EditTeacher et = sender;
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
                    teacherModel.Subjects.Add(subjectList.Where(f => f.Id == item.Id).FirstOrDefault());
                }
            }
            foreach (ComboboxItemViewModel item in ClassComboboxItem)
            {
                if (item.IsSelected)
                {
                    teacherModel.Classes.Add(classList.Where(f => f.Id == item.Id).FirstOrDefault());
                }
            }

            using (TeacherContext tc = new TeacherContext())
            {

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
        }

        /// <summary>
        /// The command to Cancel the changes
        /// </summary>
        public ActionCommand CanselCommand
        {
            get
            {
                return new ActionCommand(p => Cansel((EditTeacher)p));
            }
        }

        /// <summary>
        /// The method the CanselCommand use to Cancel
        /// </summary>
        /// <param name="sender">The EditTeacher window</param>
        private void Cansel(EditTeacher sender)
        {
            EditTeacher et = sender;
            et.DialogResult = false;
            et.Close();
        }

        #endregion
    }
}
