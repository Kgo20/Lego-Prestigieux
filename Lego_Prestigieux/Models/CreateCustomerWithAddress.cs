using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class CreateCustomerWithAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    public class CreateCustomerWithAddressValidator : AbstractValidator<CreateCustomerWithAddress>
    {
        public CreateCustomerWithAddressValidator()
        {
            RuleFor(e => e.EMail).Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Le courriel n'a pas le bon format")
           .NotEmpty().WithMessage("This field is required");

            RuleFor(e => e.PostalCode).Matches("^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$")
            .WithMessage("Le code postal n'a pas le bon format")
            .NotEmpty().WithMessage("This field is required");

            RuleFor(e => e.PhoneNumber).Matches(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")
            .WithMessage("Le numéro de téléphone n'a pas le bon format")
            .NotEmpty().WithMessage("This field is required");

        }
    }
}
