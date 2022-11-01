using System.Collections.Generic;

namespace Lego_Prestigieux.Models
{
    public enum CommandStatus
    {
        Confirmed,
        Canceled,
        InPreparation,
        InDelivery,
        Delivered,
        Return
    }
    
    public class CommandModel
    {
        public int Id { get; set; }
        public ICollection<CartItemModel> Products{ get; set; }
        public CommandStatus Status { get; set; }
    }
}
