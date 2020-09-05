using System;
using System.Collections.Generic;
using System.Text;

namespace PQS.FSChalenge.Business.Models
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
        public string OrderDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }
        public decimal Total { get; set; }
        public int QItems { get; set; }

                  
    }
}
