using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class LogIn
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
