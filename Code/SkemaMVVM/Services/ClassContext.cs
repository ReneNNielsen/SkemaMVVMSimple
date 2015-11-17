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
        DataContext context;

        public ClassContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public bool AddNewClass(Class newClass)
        {
            Class insertedClass = context.Classes.Add(newClass);
            context.SaveChanges();
            if (insertedClass.Id > 0)
            {
                return true;
            }
            return false;
        }

        public Class GetClass(int id)
        {
            return context.Classes.Find(id);
        }

        public Class GetClass(string name)
        {
            List<Class> allClasses = context.Classes.ToList();
            foreach(Class theClass in allClasses)
            {
                if (theClass.Name == name)
                    return theClass;
            }
            return null;
        }

        public List<Class> GetAllClasses()
        {
            List<Class> allClasses = context.Classes.ToList();
            if (allClasses != null)
            {
                return allClasses;
            } 
            return null;                
        }
    }
}