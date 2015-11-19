using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Constructor for MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            tsvm = new TeacherSelectViewModel();
            ssvm = new SubjectSelectViewModel();
        }

        private TeacherSelectViewModel tsvm;
        public TeacherSelectViewModel Tsvm
        {
            get
            {
                return tsvm;
            }
            set
            {
                tsvm = value;
                OnPropertyChanged();
            }
        }

        private SubjectSelectViewModel ssvm;
        public SubjectSelectViewModel Ssvm
        {
            get
            {
                return ssvm;
            }
            set
            {
                ssvm = value;
                OnPropertyChanged();
            }
        }

    }
}
