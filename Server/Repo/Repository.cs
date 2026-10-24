using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Repo
{
    public class Repository : IRepository
    {
       List<Car> Cars = new List<Car>
        {
            new Car { Id = 1, Make = "Toyota",          Model = "Camry",        Year = "2022", VIN = "VIN00000000000001", Color = "Black" },
            new Car { Id = 2, Make = "BMW",             Model = "X5",           Year = "2023", VIN = "VIN00000000000002", Color = "White" },
            new Car { Id = 3, Make = "Mercedes-Benz",   Model = "E-Class",      Year = "2021", VIN = "VIN00000000000003", Color = "Silver" },
            new Car { Id = 4, Make = "Honda",           Model = "Civic",        Year = "2020", VIN = "VIN00000000000004", Color = "Blue" },
            new Car { Id = 5, Make = "Ford",            Model = "Mustang",      Year = "2024", VIN = "VIN00000000000005", Color = "Red" },
            new Car { Id = 6, Make = "Audi",            Model = "A6",           Year = "2022", VIN = "VIN00000000000006", Color = "Gray" },
            new Car { Id = 7, Make = "Hyundai",         Model = "Sonata",       Year = "2021", VIN = "VIN00000000000007", Color = "White" },
            new Car { Id = 8, Make = "Kia" ,            Model = "Sportage",     Year = "2023", VIN = "VIN00000000000008", Color = "Green" },
            new Car { Id = 9, Make = "Tesla",           Model = "Model 3",      Year = "2024", VIN = "VIN00000000000009", Color = "Black" },
            new Car { Id = 10, Make = "Volkswagen",     Model = "Golf",         Year = "2020", VIN = "VIN00000000000010", Color = "Blue" },
            new Car { Id = 11, Make = "Nissan",         Model = "Altima",       Year = "2022", VIN = "VIN00000000000011", Color = "Silver" },
            new Car { Id = 12, Make = "Chevrolet",      Model = "Malibu",       Year = "2021", VIN = "VIN00000000000012", Color = "Red" },
            new Car { Id = 13, Make = "Lexus",          Model = "RX 350",       Year = "2023", VIN = "VIN00000000000013", Color = "White" },
            new Car { Id = 14, Make = "Mazda",          Model = "CX-5",         Year = "2022", VIN = "VIN00000000000014", Color = "Gray" },
            new Car { Id = 15, Make = "Porsche",        Model = "911",          Year = "2024", VIN = "VIN00000000000015", Color = "Yellow" },
            new Car { Id = 16, Make = "Volvo",          Model = "XC60",         Year = "2021", VIN = "VIN00000000000016", Color = "Black" },
            new Car { Id = 17, Make = "Jeep",           Model = "Wrangler",     Year = "2023", VIN = "VIN00000000000017", Color = "Green" },
            new Car { Id = 18, Make = "Subaru",         Model = "Forester",     Year = "2022", VIN = "VIN00000000000018", Color = "Blue" },
            new Car { Id = 19, Make = "Ferrari",        Model = "488 GTB",      Year = "2020", VIN = "VIN00000000000019", Color = "Red" },
            new Car { Id = 20, Make = "Land Rover",     Model = "Range Rover",  Year = "2024", VIN = "VIN00000000000020", Color = "Black" }
        };

        public bool Add(Car car)
        {
            Cars.Add(car);
            return true;
        }

        public bool Delete(int id)
        {
            var car = Cars.FirstOrDefault(car => car.Id == id);
            return car != null && Cars.Remove(car);

        }

        public List<Car>? GetAll()
        {
            return Cars.ToList();
        }

        public Car? GetById(int id)
        {
            foreach (var car in Cars)
            {
                if (car.Id == id)
                {
                    Console.WriteLine(car.Id);
                    Console.WriteLine(car.Make);
                    Console.WriteLine(car.Model);
                    Console.WriteLine(car.Year);
                    Console.WriteLine(car.VIN);
                    Console.WriteLine(car.Color);
                    return car;
                }
            }

            return null;
        }

        public bool Update(Car car)
        {
            var existingCar = Cars.FirstOrDefault(c => c.Id == car.Id);

            if (existingCar == null)
                return false;

            existingCar.Id = car.Id;
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.VIN = car.VIN;
            existingCar.Color = car.Color;

            return true;

        }
    }
}
