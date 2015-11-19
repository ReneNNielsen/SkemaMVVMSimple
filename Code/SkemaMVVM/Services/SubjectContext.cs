using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubjectContext : DataContext
    {
        /// <summary>
        /// Constructor for SubjectContext.
        /// </summary>
        public SubjectContext()
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
        /// Adds a new subject to the database.
        /// </summary>
        /// <param name="newSubject">Subject object containing the new subjects data.</param>
        /// <returns>True if success.</returns>
        public bool AddNewSubject(Subject newSubject)
        {
            Subject insertedSubject = Context.Subjects.Add(newSubject);
            Context.SaveChanges();
            if (insertedSubject.Id > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edits an already created subject based on the ID in the Subject object provided.
        /// </summary>
        /// <param name="newSubjectData">Subject object containing the new data.</param>
        /// <returns>True if success.</returns>
        public Subject GetSubject(int id)
        {
            return Context.Subjects.Find(id);
        }

        public Subject GetSubject(string name)
        {
            List<Subject> allSubjects = Context.Subjects.ToList();
            foreach(Subject theSubject in allSubjects)
            {
                if (theSubject.Name == name)
                    return theSubject;
            }
            return null;
        }

        /// <summary>
        /// Gets a list of all Subjects
        /// </summary>
        /// <returns>List<Subject> object</returns>
        public List<Subject> GetAllSubjects()
        {
            List<Subject> allSubjects = Context.Subjects.ToList<Subject>();
            if (allSubjects != null)
            {
                return allSubjects;
            } 
            return null;                
        }
    }
}