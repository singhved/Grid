using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<CourseStudents> CourseStudents { get; set; }
        public virtual DbSet<CourseData> CourseData { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}