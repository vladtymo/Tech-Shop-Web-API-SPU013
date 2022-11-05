using BusinessLogic.Interfaces;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_Web_API_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopsController : ControllerBase
    {
        private readonly TechShopDbContext context;
        private readonly ILaptopService laptopService;

        public LaptopsController(TechShopDbContext context, ILaptopService laptopService)
        {
            this.context = context;
            this.laptopService = laptopService;
        }

        //[HttpGet("/all")] // GET: ~/all
        [HttpGet("all")]    // GET: ~/api/laptops/all
        public IActionResult GetAll()
        {
            return Ok(laptopService.GetAll());
        }

        // put data to action
        // 1 - [FromQuery]: ~/api/laptops/get?id=2
        // 2 - [FromRoute]: ~/api/laptops/get/2

        [HttpGet("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var laptop = laptopService.GetById(id);

            if (laptop == null) return NotFound();

            return Ok(laptop);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Laptop laptop)
        {
            laptopService.Create(laptop);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Laptop laptop)
        {
            laptopService.Edit(laptop);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            laptopService.Delete(id);

            return Ok();
        }
    }
}
