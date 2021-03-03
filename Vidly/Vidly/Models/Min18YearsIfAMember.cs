using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    //defining custom validations
    public class Min18YearsIfAMember : ValidationAttribute
    {
        //we can override the IsValid method of ValidationAttribute to define a custom validation
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validation context gives the object that we are working on. 
            //since it is an object, we need to cast it as a customer
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success; // static property of the validationResult

            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required"); //a custom property of the validationResult

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old");
        }
    }
}