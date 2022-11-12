using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LaptopService : ILaptopService
    {
        private readonly TechShopDbContext context;
        private readonly IMapper mapper;

        public LaptopService(TechShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<LaptopDto> GetAll()
        {
            var laptops = context.Laptops.Include(x => x.OperationSystem).ToList();
            return mapper.Map<IEnumerable<LaptopDto>>(laptops);
        }

        public LaptopDto? GetById(int id)
        {
            var laptop = context.Laptops.Find(id);

            if (laptop == null) return null;

            //return new LaptopDto()
            //{
            //    Id = laptop.Id,
            //    Model = laptop.Model,
            //    Display = laptop.Display,
            //    Price = laptop.Price,
            //    Processor = laptop.Processor,
            //    ImagePath = laptop.ImagePath,
            //    OSId = laptop.OperationSystemId,
            //    OSName = laptop.OperationSystem?.Name
            //};
            return mapper.Map<LaptopDto>(laptop);
        }

        public void Create(LaptopDto laptop)
        {
            context.Laptops.Add(mapper.Map<Laptop>(laptop));
            context.SaveChanges();
        }
        public void Edit(LaptopDto laptop)
        {
            var data = context.Laptops.AsNoTracking().FirstOrDefault(l => l.Id == laptop.Id);
            
            if (data == null) return;

            context.Laptops.Update(mapper.Map<Laptop>(laptop));
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var laptop = context.Laptops.Find(id);

            if (laptop == null) return;

            context.Laptops.Remove(laptop);
            context.SaveChanges();
        }

    }
}
