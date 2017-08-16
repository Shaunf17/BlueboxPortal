using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BlueboxPortal.Models
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Name Alias")]
        public string NameAlias { get; set; }

        [Display(Name = "Friendly Name")]
        public string FriendlyName { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Database Name")]
        public string DbName { get; set; }

        [Display(Name = "SSRS Folder")]
        public string SSRSFolder { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

        //public virtual ICollection<UserAirlines> UserAirlines { get; set; }

        public IEnumerable<Airline> getAirlines
        {
            get { return getAirlines.OrderBy(a => a.Name); }
        }

    }

    //public class UserAirlines
    //{
    //    public int Id { get; set; }

    //    public string UserId { get; set; }

    //    public int AirlineId { get; set; }

    //    public virtual ApplicationUser ApplicationUser { get; set; }
    //    public virtual Airline Airline { get; set; }
    //}



    //public class AirlineContext : DbContext
    //{
    //    public AirlineContext() : base("AirlineConnection")
    //    {
    //    }

    //    public DbSet<Airline> Airline { get; set; }
    //}
}