using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TeacherListItemViewData : PersonListItemViewData
    {
        private ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Class> classes = new ObservableCollection<Class>();
        public ObservableCollection<Class> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = value;
                OnPropertyChanged();
            }
        }
    }
}
