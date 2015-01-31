using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;

namespace TeamProject.Data
{
    public class TeamProjectContext:DbContext
    {
        public TeamProjectContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<TeamProjectContext>(null);
        }

        public DbSet<Project> ProjectSet { get; set; }

        public DbSet<Contact> ContactSet { get; set; }

        public DbSet<Company> CompanySet { get; set; }

        public DbSet<TeamMember> TeamMemberSet { get; set; }

        public DbSet<Difficulty> DifficultySet { get; set; }

        public DbSet<Status> StatusSet { get; set; }

        public DbSet<WorkItem> WorkItemSet { get; set; }

        public DbSet<Priority> PrioritySet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }


    }
}

