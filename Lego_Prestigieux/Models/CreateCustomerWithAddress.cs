using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class CreateCustomerWithAddress
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
