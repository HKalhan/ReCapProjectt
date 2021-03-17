using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
          {
              new Car{Id= 1, BrandId = 1, ColorId = 1, DailyPrice = 250, ModelYear = 2000, Description = "Otomatik Dizel" },    
              new Car{Id= 2, BrandId =1, ColorId = 2, DailyPrice = 500, ModelYear = 1999, Description = "Manuel Benzin" },
              new Car{Id= 2, BrandId = 3, ColorId = 2, DailyPrice = 150, ModelYear = 2004, Description = "Otomatik Dizel" },
             new Car{Id= 2, BrandId = 3, ColorId = 2, DailyPrice = 250, ModelYear = 2003, Description = "Otomatik Benzin" },
           };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.Id==Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.Description = car.Description;
        }
    }
}

