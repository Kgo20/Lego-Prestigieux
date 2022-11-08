using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class EditAddress
    {
        public int Id { get; set; }
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

        public string CustomerId { get; set; }

        public int CommandId { get; set; }
    }


    public class EditAddressValidator : AbstractValidator<EditAddress>
    {
        public EditAddressValidator()
        {
            RuleFor(e => e.PostalCode).Matches("^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$")
          .WithMessage("Le code postal n'a pas le bon format")
          .NotEmpty().WithMessage("This field is required");
        }
    }
}
