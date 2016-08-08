namespace BureauAppServiceService.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public partial class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> 
    {

        [Required]
        public string Password { get; set; }

        public int User_LevelID { get; set; }

        [Column(TypeName = "text")]
        public string User_Description { get; set; }

        [StringLength(25)]
        public string Phone2 { get; set; }

        [StringLength(100)]
        public string Email2 { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            //userIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
            //                                this.UserName));

            return userIdentity;
        }

    }

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<User, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    } 

}
