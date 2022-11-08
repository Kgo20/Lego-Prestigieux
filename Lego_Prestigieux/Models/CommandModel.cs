using System;
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
        public DateTime CommandCreationDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public int AddressId { get; set; }
        public string UserId { get; set; }

        public CommandStatus Status { get; set; }
    }
}
