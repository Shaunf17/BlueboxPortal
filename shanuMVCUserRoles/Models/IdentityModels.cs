using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlueboxPortal.Models;
using System.Collections.Generic;

namespace BlueboxPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Airline> Airline { get; set; }

        public IEnumerable<ApplicationUser> getUsers
        {
            get { return getUsers; }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Airline> Airline { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuidler)
        {
            modelBuidler.Entity<ApplicationUser>()
                .HasMany(t => t.Airline)
                .WithMany(t => t.ApplicationUser)
                .Map(m =>
                {
                    m.ToTable("ApplicationUserAirlines");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("AirlineId");
                });

            base.OnModelCreating(modelBuidler);
        }

        //public System.Data.Entity.DbSet<BlueboxPortal.Models.ApplicationUser> ApplicationUsers { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasMany(al => al.Airline)
        //        .WithMany(au => au.ApplicationUser)
        //        .Map(
        //        m =>
        //        {
        //            m.MapLeftKey("ApplicationUser_Id");
        //            m.MapRightKey("Airline_Id");
        //            m.ToTable("ApplicationUserAirlines");
        //        });
        //}

        //public System.Data.Entity.DbSet<BlueboxPortal.Models.ApplicationUser> ApplicationUsers { get; set; }

    }
}