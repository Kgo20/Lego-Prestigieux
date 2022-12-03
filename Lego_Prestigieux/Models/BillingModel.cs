using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class BillingModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string LastNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public int CommandId { get; set; }
        public CommandModel CommandModel { get; set; }
    }

    public class BillingModelValidator : AbstractValidator<BillingModel>
    {
        public BillingModelValidator()
        {
            RuleFor(e => e.PostalCode).Matches("^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$")
            .WithMessage("Le code postal n'a pas le bon format")
            .NotEmpty().WithMessage("This field is required");

            RuleFor(e => e.PhoneNumber).Matches(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")
            .WithMessage("Le numéro de téléphone n'a pas le bon format")
            .NotEmpty().WithMessage("This field is required");
        }
    }
}
