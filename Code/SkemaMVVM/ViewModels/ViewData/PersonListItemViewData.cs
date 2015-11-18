using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PersonListItemViewData : BaseViewData
    {
        private int id;
        private string firstName;
        private string lastName;
        private int socialSecurityNumber;
        private string address;
        private int zipCode;
        private string city;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SocialSecurityNumber
        {
            get
            {
                return socialSecurityNumber;
            }
            set
            {
                if (value != socialSecurityNumber)
                {
                    socialSecurityNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value != address)
                {
                    address = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (value != zipCode)
                {
                    zipCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value != city)
                {
                    city = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
