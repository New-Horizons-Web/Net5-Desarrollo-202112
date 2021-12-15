using EFCore.BikeStore.Web.API.Infrastructure.Dtos;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.BikeStore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BikestoresContext _context;
        public BrandsController(BikestoresContext context)
        {
            _context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            //-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
            //List<Order> orders = _context.Orders.Take(5).ToList();
            /*
            var query = from o in _context.Orders
                        join c in _context.Customers on o.CustomerId equals c.CustomerId
                        join s in _context.Staffs on o.StaffId equals s.StaffId
                        join st in _context.Stores on o.StoreId equals st.StoreId
                        //where o.OrderStatus == 1
                        select new OrderDto
                        {
                            OrderId = o.OrderId,
                            CustomerId = c.CustomerId,
                            OrderStatus = o.OrderStatus,
                            OrderDate = o.OrderDate,
                            RequiredDate = o.RequiredDate,
                            ShippedDate = o.ShippedDate,
                            StoreId = o.StoreId,
                            StaffId = o.StaffId,

                            CustomerName = c.FirstName + " " + c.LastName,
                            StaffName = s.FirstName + " " + s.LastName,
                            StoreName = st.StoreName
                        };
                        
            query = query.Where(o=>o.OrderStatus==1);
            query = query.Take(5);

            List<OrderDto> orders = query.ToList();

            return orders;
            */
            return _context.Brands.ToList();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Brand brand)
        {
            var brandUpdate = _context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
            brandUpdate.BrandName = brand.BrandName;
            _context.Brands.Update(brandUpdate);
            _context.SaveChanges();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brand = _context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
