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
        /// <summary>
        /// Constructor for ClassContext.
        /// </summary>
        public ClassContext()
        {
        }

        /// <summary>
        /// Gets the inherited DataContext object.
        /// </summary>
        public DataContext DataContext
        {
            get { return Context; }
        }

        /// <summary>
        /// Adds a new class to the database.
        /// </summary>
        /// <param name="newClass">Class object containing the new classes data.</param>
        /// <returns>True if success.</returns>
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

        /// <summary>
        /// Gets a Class object from an ID.
        /// </summary>
        /// <param name="id">int ID from the Database.</param>
        /// <returns>Class object containing classes data.</returns>
        public Class GetClass(int id)
        {
            return Context.Classes.Find(id);
        }

        /// <summary>
        /// Gets a Class object from a string name.
        /// </summary>
        /// <param name="name">String name</param>
        /// <returns>Class object containing classes data.</returns>
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

        /// <summary>
        /// Gets a list of all Classes
        /// </summary>
        /// <returns>List<Class> object</returns>
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