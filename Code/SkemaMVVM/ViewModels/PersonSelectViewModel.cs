using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Models;

namespace ViewModels
{
    public class PersonSelectViewModel : BaseViewModel
    {
        /// <summary>
        /// The Constructer for PersonSelectViewModel
        /// </summary>
        public PersonSelectViewModel()
        {
        }

        private PersonSelectViewData person;
        public PersonSelectViewData Person
        {
            get
            {
                return person;
            }
            protected set
            {
                person = value;
                OnPropertyChanged();
            }
        }

        private PersonListItemViewData selectedPerson;
        public PersonListItemViewData SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
            }
        }
    }
}
