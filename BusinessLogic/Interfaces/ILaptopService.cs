using BusinessLogic.DTOs;
using Data.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILaptopService
    {
        IEnumerable<LaptopDto> GetAll();
        LaptopDto? GetById(int id);
        void Create(LaptopDto laptop);
        void Edit(LaptopDto laptop);
        void Delete(int id);
    }
}
