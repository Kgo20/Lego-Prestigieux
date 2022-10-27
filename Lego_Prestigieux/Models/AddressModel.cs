using Lego_Prestigieux.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lego_Prestigieux.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [ForeignKey("CustomerId")]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }

    }
}
