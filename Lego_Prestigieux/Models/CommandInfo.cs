using System;

namespace Lego_Prestigieux.Models
{
    public class CommandInfo
    {
        public float CommandTotal { get; set; }
        public int ProductAmount { get; set; }
        public DateTime CommandCreationDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public CommandStatus Status { get; set; }

        public int CommandId { get; set; }
    }
}
