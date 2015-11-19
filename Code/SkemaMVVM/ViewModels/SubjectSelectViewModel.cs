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
        private bool canAutoAdd = true;
        private SubjectSelectViewData ssvd;

        /// <summary>
        /// Constructor for SubjectSelectViewModel.
        /// </summary>
        public SubjectSelectViewModel()
        {
            Ssvd = new SubjectSelectViewData();
            addSubjects();
        }

        public SubjectSelectViewData Ssvd
        {
            get
            {
                return ssvd;
            }
            set
            {
                ssvd = value;
                OnPropertyChanged();
            }
        }

        private SubjectListItemViewData selectedSubject;
        public SubjectListItemViewData SelectedSubject
        {
            get
            {
                return selectedSubject;
            }
            set
            {
                selectedSubject = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Adds subjects from the database to SubjectViewData
        /// </summary>
        private void addSubjects()
        {
            using (SubjectContext sc = new SubjectContext())
            {
                List<Subject> allSubjects = sc.GetAllSubjects();
                foreach (Subject subject in allSubjects)
                {
                    if (Ssvd.Subjects.Any(p => p.Id == subject.Id))
                    {
                        if (SelectedSubject != null && SelectedSubject.Id == subject.Id)
                        {
                            Ssvd.Subjects.Remove(SelectedSubject);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Ssvd.Subjects.Add(new SubjectListItemViewData()
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                    });
                }
            }
        }

        /// <summary>
        /// Determines if the edit button is pressable
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return canAutoAdd;
            }
        }

        /// <summary>
        /// Command to be run with binding that calls AutoAddSubjects.
        /// </summary>
        public ActionCommand AutoAddCommand2
        {
            get
            {
                return new ActionCommand(p => AutoAddSubjects(),  p => CanEdit);
            }
        }

        /// <summary>
        /// Adds subjects to the database and refreshes the view.
        /// </summary>
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
            canAutoAdd = false;
            addSubjects();
        }
    }
}
