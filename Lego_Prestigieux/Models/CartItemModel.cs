using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Selected { get; set; }


        public int CommandId { get; set; }
        public CommandModel CommandModel { get; set; }
    }
}
