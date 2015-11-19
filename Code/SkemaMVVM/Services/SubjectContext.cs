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
        public SubjectContext()
        {
        }

        public DataContext DataContext
        {
            get { return Context; }
        }

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