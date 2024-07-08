using Filteration_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filteration_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Context _context;

        public OrderController(Context context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }
        //[HttpPost]
        //public async Task<ActionResult<Order>> PostOrder(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Ensure Customer is attached to the context
        //        if (order.CustomerId != 0)
        //        {
        //            var existingCustomer = await _context.Customers.FindAsync(order.CustomerId);
        //            if (existingCustomer == null)
        //            {
        //                return BadRequest("Customer not found.");
        //            }
        //            order.Customer = existingCustomer;
        //        }

        //        // Clear products to avoid unintentional circular references
        //        order.products = null;

        //        // Add order to context
        //        _context.Orders.Add(order);

        //        // Handle related products explicitly
        //        foreach (var product in order.products)
        //        {
        //            product.OrderId = order.OrderId; // Set the foreign key
        //            _context.Products.Add(product);
        //        }

        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        //    }

        //    return BadRequest(ModelState);
        //}
        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

           
                await _context.SaveChangesAsync();
            

            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            if(order.products.Any())
            {
                throw new Exception("There are products in the order.");

            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }


}

