namespace BureauAppServiceService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.Azure.Mobile.Server.Tables;

    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext()
            : base("Name=MS_TableConnectionString")
        {
        }

        public virtual DbSet<Active_Users> Active_Users { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Customer_groups> Customer_groups { get; set; }
        public virtual DbSet<Ghana_Districts> Ghana_Districts { get; set; }
        public virtual DbSet<Payrollrun> Payrollruns { get; set; }
        public virtual DbSet<Project_Stage> Project_Stages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<User_Levels> User_Levels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.User_Level)
                .IsUnicode(false);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.Login_Time)
                .IsUnicode(false);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.Column1)
                .IsUnicode(false);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.Column2)
                .IsUnicode(false);

            modelBuilder.Entity<Active_Users>()
                .Property(e => e.Column3)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Person)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Project)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Customer)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity_Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity_Revenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity_Cash_Received)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Activity_Cash_Paid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Activity>()
                .Property(e => e.txtDate)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.TaskID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_groups>()
                .Property(e => e.customer_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_groups>()
                .Property(e => e.customer_group_description)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_groups>()
                .Property(e => e.redundant_column1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_groups>()
                .Property(e => e.redundant_column2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_groups>()
                .Property(e => e.redundant_column3)
                .IsUnicode(false);

            modelBuilder.Entity<Payrollrun>()
                .Property(e => e.Basic_Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payrollrun>()
                .Property(e => e.PAYE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payrollrun>()
                .Property(e => e.SSNIT_5__)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payrollrun>()
                .Property(e => e.Net_Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Project_Stage>()
                .Property(e => e.StageName)
                .IsUnicode(false);

            modelBuilder.Entity<Project_Stage>()
                .Property(e => e.StageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectStageID)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectManager)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Client)
                .IsFixedLength();

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.StageID)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.TaskPrecedence)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.PersonnellID)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectTask>()
                .Property(e => e.TaskStatus)
                .IsUnicode(false);

            modelBuilder.Entity<User_Levels>()
                .Property(e => e.User_Level_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User_Levels>()
                .Property(e => e.User_Level_Description)
                .IsUnicode(false);
        }
    }
}
