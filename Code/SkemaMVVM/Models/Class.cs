using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Class
    {
        public Class()
        {
            this.Schedules = new HashSet<Schedule>();
            this.Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
