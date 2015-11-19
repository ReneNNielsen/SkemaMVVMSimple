using Models;
using Services;
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
        /// <summary>
        /// Constructor for TeacherContext.
        /// </summary>
        public TeacherContext()
        {
        }

        /// <summary>
        /// Gets the inherited DataContext object.
        /// </summary>
        private DataContext DataContext
        {
            get { return Context; }
        }

        /// <summary>
        /// Adds a new teacher to the database.
        /// </summary>
        /// <param name="newTeacher">Teacher object containing the new teachers data.</param>
        /// <returns>True if success.</returns>
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

        /// <summary>
        /// Edits an already created teacher based on the ID in the Teacher object provided.
        /// </summary>
        /// <param name="newTeacherData">Teacher object containing the new data.</param>
        /// <returns>True if success.</returns>
        public bool EditTeacher(Teacher newTeacherData)
        {
            Teacher oldTeacherData = Context.Teachers.Find(newTeacherData.Id);

            oldTeacherData.Subjects.Clear();
            foreach (Subject newSubject in newTeacherData.Subjects)
            {
                oldTeacherData.Subjects.Add(newSubject);
            }            

            if (oldTeacherData != null)
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

        /// <summary>
        /// Gets a Teacher object from an ID.
        /// </summary>
        /// <param name="id">int ID from the Database.</param>
        /// <returns>Teacher object containing teacher data.</returns>
        public Teacher GetTeacher(int id)
        {
            return Context.Teachers.Find(id);
        }

        /// <summary>
        /// Gets a Teacher object from a string name.
        /// </summary>
        /// <param name="name">String name</param>
        /// <returns>Teacher object containing teacher data.</returns>
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

        /// <summary>
        /// Gets a list of all Teachers
        /// </summary>
        /// <returns>List<Teacher> object</returns>
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