using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMMS.Models
{
    public class CustomModel
    {
    }
    public class UserTutor
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int UserRoleID { get; set; }
        public int TutorID { get; set; }
        public int TutorLevelID { get; set; }
    }
}