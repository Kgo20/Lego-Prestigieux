using FluentValidation;

namespace Lego_Prestigieux.Models
{
    public class Contact
    {
        public string  Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(e => e.Name)
               .Matches(@"^[A-Za-z0-9-]{3,30}$").WithMessage("Name don't has a good format")
               .NotEmpty().WithMessage("This field is required");
            RuleFor(e => e.Email)
               .EmailAddress().WithMessage("Email don't has a good format")
               .NotEmpty().WithMessage("This field is required");
            RuleFor(e => e.Subject)
              .Matches(@"^[A-Za-z0-9-]{1,30}$").WithMessage("Subject don't has a good format")
              .NotEmpty().WithMessage("This field is required");
            RuleFor(e => e.Description)
              .Matches(@"^[A-Za-z0-9-]{1,30}$").WithMessage("Description don't has a good format")
              .NotEmpty().WithMessage("This field is required");
        }
    }
}
