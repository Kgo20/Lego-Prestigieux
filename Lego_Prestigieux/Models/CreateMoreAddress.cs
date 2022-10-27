using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class CreateMoreAddress
    {
        [Key]
        public string Address { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string CustomerId { get; set; }
    }
}
