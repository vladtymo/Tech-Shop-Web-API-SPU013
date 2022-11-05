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

        public LaptopService(TechShopDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Laptop> GetAll()
        {
            return context.Laptops.ToList();
        }

        public Laptop GetById(int id)
        {
            var laptop = context.Laptops.Find(id);

            //if (laptop == null) throw ...

            return laptop;
        }

        public void Create(Laptop laptop)
        {
            context.Laptops.Add(laptop);
            context.SaveChanges();
        }
        public void Edit(Laptop laptop)
        {
            var data = context.Laptops.AsNoTracking().FirstOrDefault(l => l.Id == laptop.Id);
            
            if (data == null) return;

            context.Laptops.Update(laptop);
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
