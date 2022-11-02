using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First_Web_API_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopsController : ControllerBase
    {
        private readonly TechShopDbContext context;

        public LaptopsController(TechShopDbContext context)
        {
            this.context = context;
        }

        //[HttpGet("/all")] // GET: ~/all
        [HttpGet("all")]    // GET: ~/api/laptops/all
        public IActionResult GetAll()
        {
            return Ok(context.Laptops.ToList());
        }

        // put data to action
        // 1 - [FromQuery]: ~/api/laptops/get?id=2
        // 2 - [FromRoute]: ~/api/laptops/get/2

        [HttpGet("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var laptop = context.Laptops.Find(id);

            if (laptop == null) return NotFound();

            return Ok(laptop);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Laptop laptop)
        {
            context.Laptops.Add(laptop);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Laptop laptop)
        {
            if (context.Laptops.Find(laptop.Id) == null)
                return BadRequest();

            context.Laptops.Update(laptop);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var laptop = context.Laptops.Find(id);

            if (laptop == null) return NotFound();

            context.Laptops.Remove(laptop);
            context.SaveChanges();

            return Ok();
        }
    }
}
