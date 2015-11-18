using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher : Person
    {
        public Teacher()
        {
            this.Classes = new HashSet<Class>();
            this.Subjects = new HashSet<Subject>();
        }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
