using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }

        //out column name wont be nullable
        [Required(ErrorMessage = "Please Enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        //navigation property
        //when we want to load the related properties for a class
        //public MembershipType MembershipType { get; set; } - we will remove this from our DTO, because it's tightly linked to another domain model
        //dtos should mostly contain simple primitive types
        //this completely decouples DTO from domain object

        //foreign key to membership type
        //[Display(Name = "Membership Type")] - we dont need the display attributes for DTO
        public byte MembershipTypeId { get; set; }

        //[Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

    }
}