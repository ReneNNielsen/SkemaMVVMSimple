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

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        protected bool isEdit
        {
            get;
            set;
        }

        /// <summary>
        /// The Constructer for PersonEditViewModel
        /// </summary>
        /// <param name="personData">The data for the person to be edited as PersonListItemViewData</param>
        public PersonEditViewModel(PersonListItemViewData personData)
        {
            PersonData = personData;
            if (PersonData.SocialSecurityNumber != 0)
            {
                isEdit = true;
                Title = "Rediger";
            }
            else
            {
                Title = "Opret";
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
