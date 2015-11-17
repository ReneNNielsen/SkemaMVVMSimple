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
        DataContext context;

        public SubjectContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public bool AddNewSubject(Subject newSubject)
        {
            Subject insertedSubject = context.Subjects.Add(newSubject);
            context.SaveChanges();
            if (insertedSubject.Id > 0)
            {
                return true;
            }
            return false;
        }

        public Subject GetSubject(int id)
        {
            return context.Subjects.Find(id);
        }

        public Subject GetSubject(string name)
        {
            List<Subject> allSubjects = context.Subjects.ToList();
            foreach(Subject theSubject in allSubjects)
            {
                if (theSubject.Name == name)
                    return theSubject;
            }
            return null;
        }

        public List<Subject> GetAllSubjects()
        {
            List<Subject> allSubjects = context.Subjects.ToList();
            if (allSubjects != null)
            {
                return allSubjects;
            } 
            return null;                
        }
    }
}