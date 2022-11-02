using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Mock
{
    public static class MockData
    {
        static Random rnd = new Random();
        public static List<Laptop> GetLaptops()
        {
            return new List<Laptop>()
            {
                new Laptop()
                {
                    Id = 1,
                    Model = "Dell Latitude 5320",
                    Display = "13.3″ Full HD",
                    Processor = "11th Gen Intel® Core i5",
                    Price = 699,
                    OperationSystemId = 1,
                    ImagePath = @"https://img.moyo.ua/img/gallery/4867/43/1104939_middle.jpg?1617223785"
                },
                new Laptop()
                {
                    Id = 2,
                    Model = "Samsung Chromebook 4 310XBA-KA1",
                    Display = "11.6″ HD LED Display",
                    Processor = "Intel® Dual-Core",
                    Price = 199,
                    OperationSystemId = 1,
                    ImagePath = @"https://i5.walmartimages.com/asr/8d794c17-41b0-42b2-9e11-4c60bfd81af0_1.54a5a04f52a9a6f929e635df6d8c31e6.jpeg"

                },
                new Laptop()
                {
                    Id = 3,
                    Model = "Lenovo IdeaPad Flex 5",
                    Display = "13.3″ Full HD IPS Touch Screen",
                    Processor = "Intel® Core i3",
                    Price = 419,
                    OperationSystemId = 3,
                    ImagePath = @"https://www.notebookcheck-ru.com/uploads/tx_nbc2/LenovoIdeaPadFlex5-14IIL05__1__06.JPG"
                },
                new Laptop()
                {
                    Id = 4,
                    Model = "Dell Latitude E7420",
                    Display = "14” 4K Anti-glare",
                    Processor = "11th Gen Intel Core i7",
                    Price = 899,
                    OperationSystemId = 4,
                    ImagePath = @"https://hotline.ua/img/tx/132/13238035.jpg"
                }
            };
        }
        public static Laptop GetRandomLaptop()
        {
            var list = GetLaptops();
            return list[rnd.Next(list.Count)];
        }
        public static Laptop GetLaptopById(int id)
        {
            return GetLaptops().FirstOrDefault(l => l.Id == id);
        }

        public static List<OperationSystem> GetOSs()
        {
            return new List<OperationSystem>()
            {
                new OperationSystem()
                {
                    Id = 1,
                    Name = "Windows"
                },
                new OperationSystem()
                {
                    Id = 2,
                    Name = "macOS"
                },
                new OperationSystem()
                {
                    Id = 3,
                    Name = "Linux"
                },
                new OperationSystem()
                {
                    Id = 4,
                    Name = "MS DOS"
                },
            };
        }
    }
}
