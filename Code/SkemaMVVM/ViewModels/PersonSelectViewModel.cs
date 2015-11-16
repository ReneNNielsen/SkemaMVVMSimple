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
        private PersonSelectViewData person;
        public PersonSelectViewModel()
        {
        }

        public PersonSelectViewData Person
        {
            get
            {
                return person;
            }
            protected set
            {
                person = value;
            }
        }



        
    }
}
