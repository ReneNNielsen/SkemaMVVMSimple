using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeacherContext : DataContext
    {
        public TeacherContext()
        {
        }

        public DataContext DataContext
        {
            get { return Context; }
        }

        public bool AddNewTeacher(Teacher newTeacher)
        {
            Teacher insertedTeacher = Context.Teachers.Add(newTeacher);
            Context.SaveChanges();
            
            if (insertedTeacher.Id > 0)
            {
                return true;
            }
            return false;
        }

        public bool EditTeacher(Teacher newTeacherData)
        {
            Teacher oldTeacherData = Context.Teachers.Find(newTeacherData.Id);
            if(oldTeacherData != null)
            {
                Context.Entry(oldTeacherData).CurrentValues.SetValues(newTeacherData);                
                if(Context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Teacher GetTeacher(int id)
        {
            return Context.Teachers.Find(id);
        }

        public Teacher GetTeacher(string name)
        {
            List<Teacher> allTeachers = Context.Teachers.ToList();
            foreach(Teacher teacher in allTeachers)
            {
                if (teacher.FirstName == name)
                    return teacher;
            }
            return null;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> allTeachers = Context.Teachers.ToList();
            if (allTeachers != null)
            {
                return allTeachers;
            } 
            return null;                
        }
    }
}