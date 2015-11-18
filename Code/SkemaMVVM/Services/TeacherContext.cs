using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeacherContext : DataContext
    {
        DataContext context;

        public TeacherContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public bool AddNewTeacher(Teacher newTeacher)
        {
            Teacher insertedTeacher = context.Teachers.Add(newTeacher);
            context.SaveChanges();
            if (insertedTeacher.Id > 0)
            {
                return true;
            }
            return false;
        }

        public bool EditTeacher(Teacher newTeacherData)
        {
            Teacher oldTeacherData = context.Teachers.Find(newTeacherData.Id);
            if(oldTeacherData != null)
            {
                context.Entry(oldTeacherData).CurrentValues.SetValues(newTeacherData);                
                if(context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Teacher GetTeacher(int id)
        {
            return context.Teachers.Find(id);
        }

        public Teacher GetTeacher(string name)
        {
            List<Teacher> allTeachers = context.Teachers.ToList();
            foreach(Teacher teacher in allTeachers)
            {
                if (teacher.FirstName == name)
                    return teacher;
            }
            return null;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> allTeachers = context.Teachers.ToList();
            if (allTeachers != null)
            {
                return allTeachers;
            } 
            return null;                
        }
    }
}