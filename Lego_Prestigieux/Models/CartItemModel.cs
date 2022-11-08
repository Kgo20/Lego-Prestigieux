using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lego_Prestigieux.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Selected { get; set; } = true;
        public float PriceUnit { get; set; } = 0;

        public int? CommandModelId { get; set; }
        public CommandModel? CommandModel { get; set; }

        public string UserId { get; set; }
    }
}
