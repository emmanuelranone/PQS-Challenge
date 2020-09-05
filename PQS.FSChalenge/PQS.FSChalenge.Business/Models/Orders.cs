using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PQS.FSChalenge.Business.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersItems = new HashSet<OrdersItems>();
        }

        public int OrderId { get; set; }
        public int Status { get; set; }

        [MaxLength(255)]
        public string OrderDescription { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }

        public ICollection<OrdersItems> OrdersItems { get; set; }
    }
}
