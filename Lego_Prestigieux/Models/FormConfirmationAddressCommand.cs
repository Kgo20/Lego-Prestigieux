using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class FormConfirmationAddressCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public List<AddressModel> Addresses { get; set; }

    }
}
