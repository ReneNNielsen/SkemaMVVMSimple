using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PersonEditViewModel : BaseViewModel
    {
        private PersonListItemViewData personData;
        public PersonListItemViewData PersonData
        {
            get
            {
                return personData;
            }
            set
            {
                personData = value;
                OnPropertyChanged();
            }
        }

        private string errorMsg;
        public string ErrorMsg
        {
            get
            {
                return errorMsg;
            }
            protected set
            {
                errorMsg = value;
                OnPropertyChanged();
            }
        }

        protected bool isEdit { get; set; }

        public PersonEditViewModel(PersonListItemViewData personData)
        {
            PersonData = personData;
            if (PersonData.SocialSecurityNumber != 0)
            {
                isEdit = true;
            }
        }

        protected bool CanSave
        {
            get
            {
                return !String.IsNullOrEmpty(PersonData.FirstName) &&
                    !String.IsNullOrEmpty(PersonData.LastName) &&
                    !String.IsNullOrEmpty(PersonData.Address) &&
                    !String.IsNullOrEmpty(PersonData.City) &&
                    PersonData.SocialSecurityNumber != 0 &&
                    PersonData.ZipCode != 0;
            }
        }
    }
}
