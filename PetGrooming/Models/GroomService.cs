using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class GroomService
    {
        /*
            A GroomService is a type of activity that a Groomer can do for a pet. Some examples might be nail clipping, shampoo, trim, etc.
            
            Some things that describe a GroomService
                - Service Name
                - Cost
                - Duration
         */
        [Key]
        public string ServiceID { get; set; }
        public string ServiceType { get; set; }
        public int ServiceName { get; set; }
        public int Duration{ get; set; }
        public int Price { get; set; }
        






        //Representing the Many in (Many Groomers to Many Groom Booking)

        public int BookingID { get; set; }
        [ForeignKey("BookingID")]
        public virtual  GroomBooking Groomer{ get; set; }
    }
}