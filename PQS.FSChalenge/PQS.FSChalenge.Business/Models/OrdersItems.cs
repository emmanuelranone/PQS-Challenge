using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PQS.FSChalenge.Business.Models
{
    public partial class OrdersItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }

        [MaxLength(255)]
        public string ItemDescription { get; set; }

        [Range(0,100)]
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public Orders Order { get; set; }
    }
}
