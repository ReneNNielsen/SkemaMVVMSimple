using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DbTests
{
    [TestClass]
    public class DbTests
    {

        [TestMethod]
        public void AddNewTeacherClassesAndSubjectsToDb()
        {
            bool success = false; 

            Subject subject1 = new Subject() { Name = "Test subject" };
            Subject subject2 = new Subject() { Name = "Test subject2" };
            using (var sc = new SubjectContext())
            {
                sc.AddNewSubject(subject1);
                sc.AddNewSubject(subject2);
            }

            Class class1 = new Class() { Name = "Test class" };
            Class class2 = new Class() { Name = "Test class2" };
            using (var cc = new ClassContext())
            {
                cc.AddNewClass(class1);
                cc.AddNewClass(class2);
            }

            ICollection<Subject> subjects = new ObservableCollection<Subject>();
            ICollection<Class> classes = new ObservableCollection<Class>();

            subjects.Add(subject1);
            subjects.Add(subject2);

            classes.Add(class1);
            classes.Add(class2);

            Teacher newTeacher = new Teacher()
            {
                FirstName = "Fornavn",
                LastName = "Efternavn",
                SocialSecurityNumber = 010170,
                Address = "Hallovej 123",
                ZipCode = 1234,
                City = "Randers ikke",
                Subjects = subjects,
                Classes = classes
            };
            using (var tc = new TeacherContext())
            {
                success = tc.AddNewTeacher(newTeacher);
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void getTeacherFromDb()
        {
            int id = 1;
            Teacher searchedTeacher;
            using (var tc = new TeacherContext())
            {
                searchedTeacher = tc.GetTeacher(id);
            }
            Assert.IsNotNull(searchedTeacher.Id);
        }

        [TestMethod]
        public void getTeacherFromDbAndEditIt()
        {
            int id = 1;
            bool didWeEdit = false;
            Teacher searchedTeacher;
            using (var tc = new TeacherContext())
            {
                searchedTeacher = tc.GetTeacher(id);
                searchedTeacher.FirstName = "New Name";
                didWeEdit = tc.EditTeacher(searchedTeacher);
            }
            Assert.IsTrue(didWeEdit);
        }

        [TestMethod]
        public void getTeacherFromDbByName()
        {
            string name = "Fornavn";
            Teacher searchedTeacher;
            using (var tc = new TeacherContext())
            {
                searchedTeacher = tc.GetTeacher(name);
            }
            Assert.IsNotNull(searchedTeacher);
        }

        [TestMethod]
        public void getTeachersFromDb()
        {
            List<Teacher> allTeachers;
            using (var tc = new TeacherContext())
            {
                allTeachers = tc.GetAllTeachers();
            }
            Assert.IsNotNull(allTeachers);
        }

        [ClassInitialize]
        public static void Startup(TestContext testcontext)
        {
            Subject subject1 = new Subject() { Name = "Init subject" };
            Subject subject2 = new Subject() { Name = "Init subject2" };
            using (var sc = new SubjectContext())
            {
                sc.AddNewSubject(subject1);
                sc.AddNewSubject(subject2);
            }

            Class class1 = new Class() { Name = "Init class" };
            Class class2 = new Class() { Name = "Init class2" };
            using (var cc = new ClassContext())
            {
                cc.AddNewClass(class1);
                cc.AddNewClass(class2);
            }

            ICollection<Subject> subjects = new ObservableCollection<Subject>();
            ICollection<Class> classes = new ObservableCollection<Class>();

            subjects.Add(subject1);
            subjects.Add(subject2);

            classes.Add(class1);
            classes.Add(class2);

            Teacher newTeacher = new Teacher()
            {
                FirstName = "Ja",
                LastName = "Hallo",
                SocialSecurityNumber = 010203,
                Address = "Hallovej 123",
                ZipCode = 5678,
                City = "Viborg",
                Subjects = subjects,
                Classes = classes
            };
            using (var tc = new TeacherContext())
            {
                tc.AddNewTeacher(newTeacher);
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            using (var tc = new TeacherContext())
            {
                if(tc.Database.Exists())
                {
                    tc.Database.Delete();
                }
            }
        }
    }
}
