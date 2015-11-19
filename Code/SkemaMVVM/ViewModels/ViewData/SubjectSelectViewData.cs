using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SubjectViewData : BaseViewData
    {
        private ObservableCollection<SubjectListItemViewData> subjects;
        public ObservableCollection<SubjectListItemViewData> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                if (value != subjects)
                {
                    subjects = value;
                    OnPropertyChanged();
                }

            }
        }

        public SubjectViewData()
        {
            Subjects = new ObservableCollection<SubjectListItemViewData>();
        }
    }
}
