using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class StockMustBeBetween1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movieObject = (Movie) validationContext.ObjectInstance;

            if (movieObject.NumberInStock >= 1 && movieObject.NumberInStock <= 20)
                return ValidationResult.Success;
            else
                return new ValidationResult("The field Number in Stock must be between 1 and 20");

        }
    }
}