using Data.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILaptopService
    {
        IEnumerable<Laptop> GetAll();
        Laptop GetById(int id);
        void Create(Laptop laptop);
        void Edit(Laptop laptop);
        void Delete(int id);
    }
}
