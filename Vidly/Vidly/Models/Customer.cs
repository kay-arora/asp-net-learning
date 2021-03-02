using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //out column name wont be nullable
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        //navigation property
        //when we want to load the related properties for a class
        public MembershipType MembershipType { get; set; }

        //foreign key to membership type
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }


    }
}