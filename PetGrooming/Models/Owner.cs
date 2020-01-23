using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Owner
    {
        /*
            An owner is someone who owns one or more pets
            Some things that describe an owner:
                - First Name
                - Last Name
                - Address
                - Phone Number (work)
                - Phone Number (home)

            An owner must reference a list of pets
            
        */
        [Key]
        public string OwnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PhoneHome { get; set; }
        public int PhoneWork { get; set; }
        public string Email { get; set; }
        public string PreferedContact{ get; set; }
        public bool PetID { get; set; }
        public bool PetInsurance { get; set; }






        //Representing the One in (One Owner to Many Pets)

        public int PetID { get; set; }
        [ForeignKey("PetID")]
        public virtual Pet Species { get; set; }
    }
}