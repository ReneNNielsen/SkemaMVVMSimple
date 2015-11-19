using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClassContext : DataContext
    {
        public ClassContext()
        {
        }

        public DataContext DataContext
        {
            get { return Context; }
        }

        public bool AddNewClass(Class newClass)
        {
            Class insertedClass = Context.Classes.Add(newClass);
            Context.SaveChanges();
            if (insertedClass.Id > 0)
            {
                return true;
            }
            return false;
        }

        public Class GetClass(int id)
        {
            return Context.Classes.Find(id);
        }

        public Class GetClass(string name)
        {
            List<Class> allClasses = Context.Classes.ToList();
            foreach(Class theClass in allClasses)
            {
                if (theClass.Name == name)
                    return theClass;
            }
            return null;
        }

        public List<Class> GetAllClasses()
        {
            List<Class> allClasses = Context.Classes.ToList();
            if (allClasses != null)
            {
                return allClasses;
            } 
            return null;                
        }
    }
}