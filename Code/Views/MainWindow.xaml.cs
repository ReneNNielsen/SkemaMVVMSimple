using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Models;
using Services;
using System.Data;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            //bool success = false;

            //Subject subject1 = new Subject() { Name = "Test subject" };
            //Subject subject2 = new Subject() { Name = "Test subject2" };
            ////using (var sc = new SubjectContext())
            ////{
            ////    sc.AddNewSubject(subject1);
            ////    sc.AddNewSubject(subject2);
            ////}

            //Class class1 = new Class() { Name = "Test class" };
            //Class class2 = new Class() { Name = "Test class2" };
            ////using (var cc = new ClassContext())
            ////{
            ////    cc.AddNewClass(class1);
            ////    cc.AddNewClass(class2);
            ////}

            //ICollection<Subject> subjects = new ObservableCollection<Subject>();
            //ICollection<Class> classes = new ObservableCollection<Class>();

            //subjects.Add(subject1);
            //subjects.Add(subject2);

            //classes.Add(class1);
            //classes.Add(class2);

            //Teacher newTeacher = new Teacher()
            //{
            //    FirstName = "Fornavn",
            //    LastName = "Efternavn",
            //    SocialSecurityNumber = 010170,
            //    Address = "Hallovej 123",
            //    ZipCode = 1234,
            //    City = "Randers ikke",
            //    Subjects = subjects,
            //    Classes = classes
            //};
            //using (var tc = new TeacherContext())
            //{
            //    success = tc.AddNewTeacher(newTeacher);
            //}
        }
    }
}
