using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

//Used Fluent API

namespace ProjectManagement.Models
{
    public class ProjectContext:DbContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<CreateProject> CreatedProject { get; set; }      
        public virtual DbSet<ProjectEvaluation> ProjectEvaluation { get; set; }
        public virtual DbSet<ActiveProject> ActiveProject { get; set; }
        public virtual DbSet<SubmittedProject> SubmittedProject { get; set; }
        public virtual DbSet<UserRole> Roles { get; set; }
    }
}