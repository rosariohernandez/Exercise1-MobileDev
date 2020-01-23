using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class GroomBooking
    {
        /*
            A GroomBooking is an agreement between an owner and a groomer to provide services for a pet
            
            Some things that describe a GroomBooking
                - A date and time
                - Price
            
            A GroomBooking must reference
                - A Groomer
                - A Pet
                - An Owner
                - A list of GroomServices
                
        */
        [Key]
        public string BookingID{ get; set; }
        public string Date{ get; set; }
        public int Time{ get; set; }
        public string ServiceType { get; set; }
        public int Price { get; set; }
        public int DiscountCoupon { get; set; }
        public string GroomerID { get; set; }
        public string PetID { get; set; }
        public bool OwnerName { get; set; }



        public int GroomerID { get; set; }
        [ForeignKey("GroomerID")]
        public int PetID { get; set; }
        [ForeignKey("PetID")]
        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual Species Species { get; set; }
    }
}