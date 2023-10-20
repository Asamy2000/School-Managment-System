using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Models
{
    public class AddressAttribute:ValidationAttribute
    {
        //Value => the prop which is under the Attribute
        //validationContext => the object which is contain the prop
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string address = (string)value;

            if (address == "cairo" | address == "alex" | address == "mnofia")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage = "Address must be in [cairo | alex | mnofia ]");
        }
    }
}
