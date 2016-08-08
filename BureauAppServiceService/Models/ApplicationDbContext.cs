namespace BureauAppServiceService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Validation;
    using System.Text;

    public partial class ApplicationDbContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> 

    {
        public ApplicationDbContext()
            : base("Name=MS_TableConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map Entities to their tables.
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CustomRole>().ToTable("UserRole");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserUserRole");
            
            // Set AutoIncrement-Properties
            modelBuilder.Entity<User>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomUserClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CustomRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            // Override some column mappings that do not match our default
            modelBuilder.Entity<User>().Property(r => r.UserName).HasColumnName("User_Name");
            modelBuilder.Entity<User>().Property(r => r.Id).HasColumnName("UserID");
            modelBuilder.Entity<User>().Property(r => r.Email).HasColumnName("Email1");
            modelBuilder.Entity<User>().Property(r => r.PhoneNumber).HasColumnName("Phone1");          
            modelBuilder.Entity<CustomUserLogin>().Property(r => r.UserId).HasColumnName("UserID");
            modelBuilder.Entity<CustomRole>().Property(r => r.Id).HasColumnName("RoleID");
            modelBuilder.Entity<CustomUserClaim>().Property(r => r.Id).HasColumnName("ClaimID");
            modelBuilder.Entity<CustomUserClaim>().Property(r => r.UserId).HasColumnName("UserID");
            modelBuilder.Entity<CustomUserRole>().Property(r => r.UserId).HasColumnName("UserID");
            modelBuilder.Entity<CustomUserRole>().Property(r => r.RoleId).HasColumnName("RoleID");
         
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
