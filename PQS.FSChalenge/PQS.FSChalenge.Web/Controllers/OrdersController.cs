using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PQS.FSChalenge.Business.Services;

namespace PQS.FSChalenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/orders
       /* [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Prueba de la API"};
        }*/

        // GET api/orders/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrderService os = new OrderService();
            var ord = os.GetOrderById(id);

            if (ord.Count == 0)
                return NotFound();

            return Ok(ord);
        }

        // GET api/orders/pending
        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            OrderService os = new OrderService();
            return Ok(os.GetOrders(0));
        }

        // GET api/orders/approved
        [HttpGet("approved")]
        public IActionResult GetApproved()
        {
            OrderService os = new OrderService();
            return Ok(os.GetOrders(1));
        }

        // GET api/orders/rejected
        [HttpGet("rejected")]
        public IActionResult GetRejected()
        {
            OrderService os = new OrderService();
            return Ok(os.GetOrders(-1));
        }


        // POST api/orders
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            OrderService os = new OrderService();
            try
            {
                os.ApproveOrder(id);
            }
            catch (Exception ex) // según la excepción, retorna diferente
            {
                string error = ex.Message.ToString();   
                
                if (error == "OrderId Not Found")
                    return NotFound();
                else if (error == "Invalid Status")
                    return BadRequest();
            }            

            return Ok();
        }
              
        // DELETE api/orders/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            OrderService os = new OrderService();
            try
            {
                os.RejectOrder(id);
            }
            catch (Exception ex) // según la excepción, retorna diferente
            {
                string error = ex.Message.ToString();

                if (error == "OrderId Not Found")
                    return NotFound();
                else if (error == "Invalid Status")
                    return BadRequest();
            }

            return Ok();
        }
    }
}