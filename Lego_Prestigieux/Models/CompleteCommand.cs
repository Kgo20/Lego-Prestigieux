using System;
using System.Collections.Generic;

namespace Lego_Prestigieux.Models
{
    public class CompleteCommand
    {
        public int CommandId { get; set; }
        public DateTime CommandCreationDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public List<ProductInfoCart> Products { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public AddressModel AddressLivraison { get; set; }

        public float TotalBeforeTaxes { get; set; }
        public float Taxes { get; set; }
        public float Total { get; set; }
        public float ShippingCost { get; set; }

        public CommandStatus CommandStatus { get; set; }
    }
}
