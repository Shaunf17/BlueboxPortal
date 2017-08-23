using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueboxPortal.Models
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> Admins { get; set; }
        public List<UserViewModel> Managers { get; set; }
    }

    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}