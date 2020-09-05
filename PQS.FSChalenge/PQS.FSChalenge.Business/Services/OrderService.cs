using PQS.FSChalenge.Business.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PQS.FSChalenge.Business.Services
{
    public class OrderService
    {
        public List<OrderInfo> GetOrders(int Status) 
        {            
            FSChalengeContext db = new FSChalengeContext();           
            List<OrderInfo> listOrdersInfo = (from d in db.OrderInfo.Where(p => p.Status.Equals(Status))
                                          select d).ToList();  
            
            return listOrdersInfo;
        }

        public List<Orders> GetOrderById(int OrderId)
        {
            FSChalengeContext db = new FSChalengeContext();
            List<Orders> listOrders = (from d in db.Orders.Include(x => x.OrdersItems).Where(p => p.OrderId.Equals(OrderId))
                                          select d).ToList();

            return listOrders;
        }

        
        public void ApproveOrder(int OrderId)
        {
            FSChalengeContext db = new FSChalengeContext();
            var order = (from d in db.Orders.Where(p => p.OrderId.Equals(OrderId)/* && p.Status == 0*/)
                         select d).ToList();

            if (order.Count == 0)
                throw  new Exception("OrderId Not Found");      // no encontro el id      

            try
            {
                var order_approve = order.Where(p => p.Status == 0).First(); // status debe ser 0 (pendiente)
                order_approve.Status = 1;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Invalid Status"); // el status no era pendiente
            }
            
        }

        public void RejectOrder(int OrderId)
        {
            FSChalengeContext db = new FSChalengeContext();
            var order = (from d in db.Orders.Where(p => p.OrderId.Equals(OrderId))
                         select d).ToList();

            if (order.Count == 0)
                throw new Exception("OrderId Not Found");

            try
            {
                var order_approve = order.Where(p => p.Status == 0).First(); // status debe ser 0 (pendiente)
                order_approve.Status = -1;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Invalid Status"); // el status no era pendiente
            }
        }
    }
}
