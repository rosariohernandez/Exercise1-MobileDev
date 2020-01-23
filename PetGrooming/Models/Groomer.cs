using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Groomer
    {
        /* 
            A groomer is someone who is employed to groom pets
            Some things that describe a groomer
                - First Name
                - Last Name
                - Date of Birth
                - Phone Number
                - Hourly Rate

            A booking must reference to a groomer
        */

        [Key]
        public int GroomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PhoneHome { get; set; }
        public string Email { get; set; }
        public string Schedule{ get; set; }
        public string Services { get; set; }
        public int HourlyRate { get; set; }
        public string HiringDate { get; set; }






        //Representing the One in (One Owner to Many Pets)

        public int BookingID { get; set; }
        [ForeignKey("BookingID")]
        public virtual Groomer GroomBooking { get; set; }
    }
}