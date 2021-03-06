﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class DataContext : DbContext
    {
        private static DataContext context;
        public DataContext() : base("SchoolDb")
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DataContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new DataContext();
                }
                return context;
            }
        }
    }
}